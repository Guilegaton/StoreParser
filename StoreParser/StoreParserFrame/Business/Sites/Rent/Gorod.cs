using AngleSharp;
using AngleSharp.Dom;
using HtmlParser.Builders.Blocks;
using HtmlParser.Business;
using HtmlParser.Interfaces;
using StoreParser.Business.Abstracts;
using StoreParser.Models;
using StoreParser.Models.Entities;
using StoreParser.Models.ParseModels;
using StoreParser.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace StoreParser.Business.Sites.Rent
{
    public class Gorod : SiteService<RentParseOrder, RentOrder, RentOrderViewModel>
    {
        private static readonly string _rentUrl = "http://an-gorod.com.ua/real/flat/rent?page=";

        protected internal override INode<RentParseOrder> _template => new TableRowBlockBuilder<RentParseOrder>()
                .AddTableDataBlock(tableData => tableData.AddSpanBlock(span => span))
                .AddTableDataBlock(tableData => tableData.AddSpanBlock(span => span).WithProperty(model => model.RoomCount))
                .AddTableDataBlock(tableData => tableData.AddSpanBlock(span => span).WithProperty(model => model.Location))
                .AddTableDataBlock(tableData => tableData.AddSpanBlock(span => span).WithProperty(model => model.Floor))
                .AddTableDataBlock(tableData => tableData.AddSpanBlock(span => span).WithProperty(model => model.Space))
                .AddTableDataBlock(tableData => tableData.AddSpanBlock(span => span).WithProperty(model => model.Price))
                .GetResult();
        
        public override IEnumerable<RentOrder> GetOrders(int pageNumber)
        {
            var html = GetHtml(_rentUrl + pageNumber.ToString());
            var document = GetDocument(html);
            var orders = ProcessSearch(document);
            var result = ProcessParseModels(orders);

            return result;
        }

        protected internal override string GetHtml(string url)
        {
            var htmlResult = string.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                htmlResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            return htmlResult;
        }

        protected internal override IDocument GetDocument(string html)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = context.OpenAsync(req => req.Content(html)).GetAwaiter().GetResult();

            return document;
        }

        protected internal override IEnumerable<RentParseOrder> ProcessSearch(IDocument document)
        {
            var nodes = SearchService.SearchBlock(document, _template);
            var result = new List<RentParseOrder>();
            foreach (var node in nodes)
            {
                result.Add(ParsingService<RentParseOrder>.Parse(node));
            }

            return result;
        }

        private IEnumerable<RentOrder> ProcessParseModels(IEnumerable<RentParseOrder> orders)
        {
            return orders.Select(order => new RentOrder
            {
                Location = order.Location,
                Floor = int.TryParse(order.Floor.Split('/')[0], out int floor) ? (int?)floor : null,
                Price = int.TryParse(order.Price.Replace("грн", "").Replace(".", "").Replace(" ", ""), out int price) ? price : 0,
                RoomCount = int.TryParse(order.RoomCount.Split(' ')[0], out int roomCount) ? roomCount : 0,
                Space = order.Space.Split('/').Select(sp => double.TryParse(sp, out double space) ? (double?)space : null).Where(sp => sp != null).Sum(sp => sp.Value)
            });
        }

        public override IEnumerable<RentOrderViewModel> GetViewModels(int pageNumber)
        {
            var html = GetHtml(_rentUrl + pageNumber.ToString());
            var document = GetDocument(html);
            var orders = ProcessSearch(document);
            var result = ProcessParseModels(orders)
                .Select(entity => new RentOrderViewModel(
                    location: entity.Location,
                    roomCount: entity.RoomCount > 0 ? entity.RoomCount?.ToString() : "NaN",
                    price: entity.Price > 0 ? entity.Price?.ToString() : "NaN",
                    floor: entity.Floor > 0 ? entity.Floor?.ToString() : "NaN",
                    space: entity.Space > 0 ? entity.Space?.ToString() : "NaN"));

            return result;
        }
    }
}

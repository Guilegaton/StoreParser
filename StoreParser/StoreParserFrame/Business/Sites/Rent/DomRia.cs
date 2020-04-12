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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace StoreParser.Business.Sites.Rent
{
    public class DomRia : SiteService<RentParseOrder, RentOrder, RentOrderViewModel>
    {
        private static readonly string _rentUrl = "https://dom.ria.com/arenda-kvartir/kharkov/?page=";

        protected internal override INode<RentParseOrder> _template => new SectionBlockBuilder<RentParseOrder>()
                .AddLinkBlock()
                .AddContainerBlock(contBody => contBody
                    .AddContainerBlock(contTitle => contTitle
                        .AddH3TextBlock(h3 => h3.AddSpanBlock(span => span.AddLinkBlock(link => link.WithProperty(model => model.Location)
                                                                          .AddSpanBlock()
                                                                          .AddSpanBlock()))))
                    .AddContainerBlock(contPrice => contPrice
                        .AddSpanBlock(span => span
                            .AddBoldTextBlock(bold => bold.WithProperty(model => model.Price))))
                    .AddUnorderedListBlock(uList => uList
                        .AddListItemBlock(listItem => listItem.WithProperty(model => model.RoomCount))
                        .AddListItemBlock(listItem => listItem.WithProperty(model => model.Space))))
                .GetResult();

        public override IEnumerable<RentOrder> GetOrders(int pageNumber = 1)
        {
            var html = GetHtml(_rentUrl + pageNumber.ToString());
            var document = GetDocument(html);
            var orders = ProcessSearch(document);
            var result = ProcessParseModels(orders);

            return result;
        }

        public override IEnumerable<RentOrderViewModel> GetViewModels(int pageNumber)
        {
            var html = GetHtml(_rentUrl + pageNumber.ToString());
            var document = GetDocument(html);
            var orders = ProcessSearch(document);
            var result = ProcessParseModels(orders)
                .Select(entity => new RentOrderViewModel(
                    location: entity.Location,
                    roomCount: entity.RoomCount?.ToString() ?? "NaN",
                    price: entity.Price?.ToString() ?? "NaN",
                    floor: entity.Floor?.ToString() ?? "NaN",
                    space: entity.Space?.ToString() ?? "NaN"));

            return result;
        }

        protected internal override IDocument GetDocument(string html)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = context.OpenAsync(req => req.Content(html)).GetAwaiter().GetResult();

            return document;
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


        // TODO: так, смотри, всё не очень хорошо, нужно как-то сгруппировать данные с сайто, только пользователи их пишут всегда по разному, можно попытаться брать гео дату и выводить её но там всё сложно, так что думай

        private IEnumerable<RentOrder> ProcessParseModels(IEnumerable<RentParseOrder> orders)
        {
            var result = new List<RentOrder>();
            foreach (var order in orders)
            {
                var area = order.Location;
                if (order.Location.Split('.').Count() > 2)
                {
                    var areaArray = order.Location.Split('.')[1].Split(' ');
                    area = areaArray.Where(str => str != areaArray.Last()).Aggregate((cur, next) => $"{cur} {next}");
                }
                result.Add( new RentOrder
                {
                    Location = area,
                    Floor = int.TryParse(order.Floor.Split('/')[0], out int floor) ? (int?)floor : null,
                    Price = int.TryParse(order.Price.Replace("грн", "").Replace(".", "").Replace(" ", ""), out int price) ? price : 0,
                    RoomCount = int.TryParse(order.RoomCount.Split(' ')[0], out int roomCount) ? roomCount : 0,
                    Space = double.TryParse(order.Space.Split(' ')[0], out double space) ? space : 0
                });
            }

            return result;
        }
    }
}

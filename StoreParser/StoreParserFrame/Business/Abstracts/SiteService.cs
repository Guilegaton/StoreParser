using AngleSharp.Dom;
using HtmlParser.Interfaces;
using StoreParser.Business.Interfaces;
using System.Collections.Generic;

namespace StoreParser.Business.Abstracts
{
    public abstract class SiteService<TParseModel, TModel, TViewModel> : ISiteService<TModel> where TModel : class, new()
    {
        public abstract IEnumerable<TModel> GetOrders(int pageNumber);
        public abstract IEnumerable<TViewModel> GetViewModels(int pageNumber);
        internal protected abstract string GetHtml(string url);
        internal protected abstract IDocument GetDocument(string html);
        internal protected abstract IEnumerable<TParseModel> ProcessSearch(IDocument document);
        internal protected abstract INode<TParseModel> _template { get; }
    }
}

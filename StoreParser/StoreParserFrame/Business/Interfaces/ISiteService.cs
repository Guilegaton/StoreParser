using AngleSharp.Dom;
using HtmlParser.Interfaces;
using System.Collections.Generic;

namespace StoreParser.Business.Interfaces
{
    public interface ISiteService<TModel> where TModel : class, new()
    {
        IEnumerable<TModel> GetOrders(int pageNumber);
    }
}

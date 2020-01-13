using HtmlParser.Interfaces;
using HtmlParser.Models;
using System.Collections.Generic;

namespace HtmlParser.Builders.Blocks
{
    public class TableBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public TableBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "table"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
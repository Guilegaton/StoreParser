using HtmlParser.Interfaces;
using HtmlParser.Models;
using System.Collections.Generic;

namespace HtmlParser.Builders.Blocks
{
    public class TableBodyBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public TableBodyBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "tbody"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
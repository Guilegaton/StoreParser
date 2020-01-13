using System.Collections.Generic;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders.Blocks
{
    /// <summary>
    /// Builder for nodes with 'blockquote' tag
    /// </summary>
    /// <typeparam name="TModel">
    /// Model, that contains only primitive properties (string, number etc.)
    /// </typeparam>
    public class QuoteBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public QuoteBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "q"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
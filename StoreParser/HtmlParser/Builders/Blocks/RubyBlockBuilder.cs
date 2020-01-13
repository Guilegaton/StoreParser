using HtmlParser.Interfaces;
using HtmlParser.Models;
using System.Collections.Generic;

namespace HtmlParser.Builders.Blocks
{
    public class RubyBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public RubyBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "ruby"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
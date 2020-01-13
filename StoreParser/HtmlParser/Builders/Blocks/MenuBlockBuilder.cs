using HtmlParser.Interfaces;
using HtmlParser.Models;
using System.Collections.Generic;

namespace HtmlParser.Builders.Blocks
{
    public class MenuBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public MenuBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "menu"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
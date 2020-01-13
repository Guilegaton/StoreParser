using HtmlParser.Interfaces;
using HtmlParser.Models;
using System.Collections.Generic;

namespace HtmlParser.Builders.Blocks
{
    public class FrameSetBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public FrameSetBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "frameset"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
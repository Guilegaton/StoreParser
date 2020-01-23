﻿using HtmlParser.Interfaces;
using HtmlParser.Models;
using System.Collections.Generic;

namespace HtmlParser.Builders.Blocks
{
    /// <summary>
    /// Builder for nodes with 'tt' tag
    /// </summary>
    /// <typeparam name="TModel">Model type for "HTML to Models" convert</typeparam>
    public class TeletypeTextBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public TeletypeTextBlockBuilder()
        {
            _node = new BuilderNode<TModel>
            {
                Name = "tt"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
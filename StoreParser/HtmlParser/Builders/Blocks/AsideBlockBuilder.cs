﻿using System.Collections.Generic;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders.Blocks
{
    /// <summary>
    /// Builder for nodes with 'aside' tag
    /// </summary>
    /// <typeparam name="TModel">
    /// Model, that contains only primitive properties (string, number etc.)
    /// </typeparam>
    public class AsideBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public AsideBlockBuilder()
        {
            _node = new BuilderNode<TModel>
            {
                Name = "aside"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
﻿using System.Collections.Generic;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders.Blocks
{
    /// <summary>
    /// Builder for nodes with 'body' tag
    /// </summary>
    /// <typeparam name="TModel">
    /// Model, that contains only primitive properties (string, number etc.)
    /// </typeparam>
    public class BodyBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public BodyBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "body"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
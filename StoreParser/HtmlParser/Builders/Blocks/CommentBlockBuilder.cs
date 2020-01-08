﻿using System.Collections.Generic;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders.Blocks
{
    /// <summary>
    /// Builder for nodes with 'comment' tag
    /// </summary>
    /// <typeparam name="TModel">
    /// Model, that contains only primitive properties (string, number etc.)
    /// </typeparam>
    public class CommentBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public CommentBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "comment"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
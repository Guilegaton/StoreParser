using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders
{
    /// <summary>
    /// Builder for nodes with 'p' tag
    /// </summary>
    /// <typeparam name="TModel">Model, that contains only primitive properties (string, number etc.)</typeparam>
    public class ParagraphBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public ParagraphBlockBuilder()
        {
            _node = new Node<TModel> 
            { 
                Name = "p"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
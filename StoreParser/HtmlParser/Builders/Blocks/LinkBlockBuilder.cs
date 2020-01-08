using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders
{
    /// <summary>
    /// Builder for nodes with 'a' tag
    /// </summary>
    /// <typeparam name="TModel">Model, that contains only primitive properties (string, number etc.)</typeparam>
    public class LinkBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public LinkBlockBuilder()
        {
            _node = new Node<TModel> 
            {
                Name = "a"  
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
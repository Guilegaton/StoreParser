using System.Collections.Generic;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders.Blocks
{
    /// <summary>
    /// Builder for nodes with 'applet' tag
    /// </summary>
    /// <typeparam name="TModel">
    /// Model, that contains only primitive properties (string, number etc.)
    /// </typeparam>
    public class AppletBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public AppletBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "applet"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Public Constructors
    }
}
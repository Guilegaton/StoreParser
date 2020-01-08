using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders
{
    /// <summary>
    /// Builder for nodes with 'div' tag
    /// </summary>
    /// <typeparam name="TModel">Model, that contains only primitive properties (string, number etc.)</typeparam>
    public class ContainerBlockBuilder<TModel> : BaseBlockBuilder<TModel>, INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public ContainerBlockBuilder()
        {
            _node = new Node<TModel>
            {
                Name = "div"
            };
            _nodes = new List<INodeBuilder<TModel>>();
        }

        #endregion Private Constructors
    }
}

using AngleSharp.Dom;
using HtmlParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HtmlParser.Models
{
    public class Node<TModel> : INode<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public Node()
        {
            SubNodes = new List<INode<TModel>>();
            Attributes = new Dictionary<string, string>();
        }

        #endregion Public Constructors

        #region Private Constructors

        private Node(string name, List<INode<TModel>> subNodes, Dictionary<string, string> attributes, IElement element, Expression<Func<TModel, object>> prop)
        {
            var subNodeList = new List<INode<TModel>>();
            foreach (var item in subNodes)
            {
                subNodeList.Add((INode<TModel>)item.Clone());
            }
            SubNodes = subNodeList;

            var attrs = new Dictionary<string, string>();
            foreach (var pair in attributes)
            {
                attrs.Add(new string(pair.Key.ToArray()), new string(pair.Value.ToArray()));
            }
            Attributes = attrs;

            Element = element;
            Property = prop;
            Name = new string(name.ToArray());
        }

        #endregion Private Constructors

        #region Public Properties

        public Dictionary<string, string> Attributes { get; set; }
        public IElement Element { get; set; }
        public string Name { get; set; }
        public Expression<Func<TModel, object>> Property { get; set; }
        public List<INode<TModel>> SubNodes { get; set; }

        #endregion Public Properties

        #region Public Methods

        public object Clone()
        {
            return new Node<TModel>(this.Name, this.SubNodes, this.Attributes, this.Element, this.Property);
        }

        #endregion Public Methods
    }
}
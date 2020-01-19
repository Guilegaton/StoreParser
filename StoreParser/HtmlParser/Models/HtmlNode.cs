using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestConsole
{
    public class HtmlNode<TModel> : Node<TModel> where TModel : class, new()
    {
        #region Public Constructors

        public HtmlNode() : base()
        {
        }

        #endregion Public Constructors

        #region Private Constructors

        private HtmlNode(string name,
            List<INode<TModel>> subNodes,
            Dictionary<string, string> attributes,
            IElement element, Expression prop) : base(name, subNodes, attributes, element, prop)
        {
        }

        #endregion Private Constructors

        #region Public Methods

        public override object Clone()
        {
            return new HtmlNode<TModel>(this.Name, this.SubNodes, this.Attributes, this.Element, this.Property);
        }

        public override MemberExpression GetMemberExpression()
        {
            return (this.Property as Expression<Func<TModel, object>>).Body as MemberExpression;
        }

        #endregion Public Methods
    }
}
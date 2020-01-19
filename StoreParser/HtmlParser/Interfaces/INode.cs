using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestConsole
{
    public interface INode<TModel> : ICloneable
    {
        #region Public Properties

        Dictionary<string, string> Attributes { get; set; }
        IElement Element { get; set; }
        string Name { get; set; }
        Expression Property { get; set; }
        List<INode<TModel>> SubNodes { get; set; }

        #endregion Public Properties

        #region Public Methods

        MemberExpression GetMemberExpression();

        #endregion Public Methods

    }
}
using HtmlParser.Interfaces;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HtmlParser.Business
{
    public class ParsingService<TModel> where TModel : class, new()
    {
        #region Public Methods

        public static TModel Parse(INode<TModel> node)
        {
            var model = new TModel();
            model = FillProperty(model, node);
            foreach (var subNode in node.SubNodes)
            {
                model = Parse(subNode, model);
            }

            return model;
        }

        private static TModel Parse(INode<TModel> node, TModel model)
        {
            model = FillProperty(model, node);
            foreach (var subNode in node.SubNodes)
            {
                model = Parse(subNode, model);
            }

            return model;
        }

        #endregion Public Methods

        #region Private Methods

        private static TModel FillProperty(TModel model, INode<TModel> node)
        {
            if (node.Property != null)
            {
                var property = (node.Property as MemberExpression) ?? ((node.Property as Expression<Func<TModel, object>>).Body as MemberExpression);
                if (property != null &&
                    property.Member is PropertyInfo propInfo)
                {
                    var value = Convert.ChangeType(node.Element.TextContent.Trim(), propInfo.PropertyType);
                    if (value != null)
                    {
                        //propInfo.SetValue(model, value);
                        model.Set(node.GetMemberExpression() , value);
                    }
                }
            }

            return model;
        }



        #endregion Private Methods

    }

    public static class LambdaExtensions
    {

        public static TModel Set<TModel, TValue>(this TModel model, MemberExpression mex, TValue value)
        {

            if (mex == null) throw new ArgumentException();

            var pi = mex.Member as PropertyInfo;
            if (pi == null) throw new ArgumentException();

            object target = model.GetTarget(mex.Expression);
            pi.SetValue(target, value, null);
            return model;
        }

        private static object GetTarget(this object model, Expression expr)
        {
            switch (expr.NodeType)
            {
                case ExpressionType.Parameter:
                    return model;
                case ExpressionType.MemberAccess:
                    MemberExpression mex = (MemberExpression)expr;
                    PropertyInfo pi = mex.Member as PropertyInfo;
                    if (pi == null) throw new ArgumentException();
                    object target = model.GetTarget(mex.Expression);
                    return pi.GetValue(target, null);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
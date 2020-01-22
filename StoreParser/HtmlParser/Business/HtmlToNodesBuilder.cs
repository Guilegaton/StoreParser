using AngleSharp;
using AngleSharp.Dom;
using HtmlParser.Interfaces;
using HtmlParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HtmlParser
{
    public static class HtmlToNodesBuilder<TModel> where TModel : class, new()
    {
        public static IEnumerable<INode<TModel>> ConvertHtmlToNodes(string html)
        {
            var result = new List<INode<TModel>>();
            var config = Configuration.Default;
            var document = new AngleSharp.Html.Parser.HtmlParser().ParseDocument(html);
            foreach (IElement item in document.ChildNodes[0].ChildNodes[1].ChildNodes.Where(node => node.NodeName != "#text"))
            {
                result.Add(GetNode(item));
            }

            return result;
        }


        private static INode<TModel> GetNode(IElement element)
        {
            var node = new HtmlNode<TModel>
            {
                Name = element.TagName.ToLower(),
                Attributes = GetAttributes(element),
                SubNodes = GetSubNodes(element),
                Property = element.Attributes.Any(attr => attr.Name == "@@model") && element.ChildNodes.Any() ? GetProperty(element.Attributes.FirstOrDefault(attr => attr.Name == "@@model").Value) : null
            };
            return node;
        }

        private static Dictionary<string, string> GetAttributes(IElement element)
        {
            var result = new Dictionary<string, string>();
            foreach (var attr in element.Attributes.Where(pair => pair.Name != "@@model"))
            {
                result.Add(attr.Name.ToLower(), attr.Value.ToLower());
            }

            return result;
        }

        private static List<INode<TModel>> GetSubNodes(IElement element)
        {
            var result = new List<INode<TModel>>();

            foreach (var item in element.Children)
            {
                result.Add(GetNode(item));
            }

            return result;
        }

        private static Expression GetProperty(string propCall)
        {
            var properties = propCall.Split('.');
            ParameterExpression pe = Expression.Parameter(typeof(TModel), "source");

            Expression lastMember = pe;

            for (int i = 0; i < properties.Length; i++)
            {
                MemberExpression member = Expression.Property(lastMember, properties[i]);
                lastMember = member;
            }

            return lastMember;
        }


        private static object GetSubProperty(TModel model, Func<TModel, object> func, string propName) 
        {
            var preValue = func.Invoke(model);
            if (preValue.GetType().GetProperties().All(prop => prop.Name != propName))
            {
                throw new Exception($"{typeof(TModel).ToString()} does not contain '{propName}' property.");
            }
            return preValue.GetType().GetProperty(propName).GetValue(preValue);
        }
    }
}

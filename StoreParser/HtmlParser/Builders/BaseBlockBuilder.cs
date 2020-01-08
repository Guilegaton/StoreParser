using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HtmlParser.Builders.Blocks;
using HtmlParser.Interfaces;
using HtmlParser.Models;

namespace HtmlParser.Builders
{
    public abstract class BaseBlockBuilder<TModel> : INodeBuilder<TModel> where TModel : class, new()
    {
        #region Private Properties

        protected Node<TModel> _node { get; set; }
        protected List<INodeBuilder<TModel>> _nodes { get; set; }

        #endregion Private Properties

        #region Public Methods

        #region Add Blocks

        /// <summary>
        /// Add a new builder for the nodes with a 'div' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddContainerBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new ContainerBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'a' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddLinkBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new LinkBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'p' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddParagraphBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new ParagraphBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'abbr' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAbbreviationBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AbbreviationBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'acronym' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAcronymBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AcronymBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'address' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAddressBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AddressBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'applet' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAppletBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AppletBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'area' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAreaBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AppletBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'article' tag to the subnodes tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddArticleBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new ArticleBlockContainer<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'aside' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAsideBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AsideBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'audio' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddAudioBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new AudioBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'b' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddBoldTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new BoldTextBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'bdi' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddSeparateTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new SeparateTextBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'bdo' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddTextDirectionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new TextDirectionBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'blockquote' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddQuoteBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new QuoteBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'body' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddBodyBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new BodyBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'button' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddButtonBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new ButtonBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'canvas' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddCanvasBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CanvasBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'caption' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddCaptionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CaptionBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'center' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddCentredTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CentredTextBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'cite' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddCiteTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CiteTextBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'code' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddCodeTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CodeTextBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'comment' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddCommentBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CommentBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a 'datalist' tag to the aside tree
        /// </summary>
        public virtual INodeBuilder<TModel> AddDatalistBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new DatalistBlockBuilder<TModel>();
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }

        /// <summary>
        /// Add a new builder for the nodes with a custom tag to the subnodes tree 
        /// </summary>
        public virtual INodeBuilder<TModel> AddCustomBlock(string blockName, Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc)
        {
            var nodeBuilder = new CustomBlockBuilder<TModel>(blockName);
            var result = nodeFunc.Invoke(nodeBuilder);
            _nodes.Add(result);

            return this;
        }


        #endregion

        public virtual INode<TModel> GetResult()
        {
            foreach (var node in _nodes)
            {
                _node.SubNodes.Add(node.GetResult());
            }
            return _node;
        }

        public virtual INodeBuilder<TModel> WithAttribute(string name, string value)
        {
            _node.Attributes.Add(name, value);
            return this;
        }

        public virtual INodeBuilder<TModel> WithProperty(Expression<Func<TModel, object>> property)
        {
            _node.Property = property;
            return this;
        }

        #endregion Public Methods
    }
}
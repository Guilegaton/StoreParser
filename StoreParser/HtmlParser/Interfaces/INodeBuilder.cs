using System;
using System.Linq.Expressions;

namespace HtmlParser.Interfaces
{
    public interface INodeBuilder<TModel> where TModel : class, new()
    {
        #region Public Methods

        INodeBuilder<TModel> AddAbbreviationBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAcronymBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAddressBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAppletBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddContainerBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAreaBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddArticleBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAsideBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAudioBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddBoldTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSeparateTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTextDirectionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddQuoteBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddBodyBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddButtonBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCanvasBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCaptionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCentredTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCiteTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCodeTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCommentBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddDatalistBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCustomBlock(string blockName, Func<INodeBuilder<TModel>, INodeBuilder<TModel>> node);

        INodeBuilder<TModel> AddLinkBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddParagraphBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INode<TModel> GetResult();

        INodeBuilder<TModel> WithAttribute(string name, string value);

        INodeBuilder<TModel> WithProperty(Expression<Func<TModel, object>> property);

        #endregion Public Methods
    }
}
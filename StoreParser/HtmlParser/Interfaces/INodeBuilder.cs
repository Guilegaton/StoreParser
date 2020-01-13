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

        INodeBuilder<TModel> AddAreaBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddArticleBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAsideBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddAudioBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddBodyBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddBoldTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddButtonBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCanvasBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCaptionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCentredTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCiteTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCodeTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCommentBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddContainerBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddCustomBlock(string blockName, Func<INodeBuilder<TModel>, INodeBuilder<TModel>> node);

        INodeBuilder<TModel> AddDatalistBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddDetailsBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddDirectoryBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddFooterBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddFormBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddFrameBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddFrameSetBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddH1TextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddH2TextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddH3TextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddH4TextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddH5TextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddH6TextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddHorizontalLineBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddIframeBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddImageBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddInputBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddItalicTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddLabelBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddLinkBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddListItemBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddMainBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddMapBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddMarqueeBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddMenuBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddNavigationBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddNumeratedListBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddOptionElementBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddOptionsGroupBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddParagraphBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddParamBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddPlainTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddQuoteBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddRubyBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddRubyTitleBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSectionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSelectBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSeparateTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSmallTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSpanBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddStrikeTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddStrongTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSubTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSummaryBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddSupTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableBodyBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableDataBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableFootBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableHeaderBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableHeaderDataBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTableRowBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTeletypeTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTextAreaBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddTextDirectionBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddUnderlineTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddUnorderedListBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddVariableTextBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INodeBuilder<TModel> AddVideoBlock(Func<INodeBuilder<TModel>, INodeBuilder<TModel>> nodeFunc);

        INode<TModel> GetResult();

        INodeBuilder<TModel> WithAttribute(string name, string value);

        INodeBuilder<TModel> WithProperty(Expression<Func<TModel, object>> property);

        #endregion Public Methods
    }
}
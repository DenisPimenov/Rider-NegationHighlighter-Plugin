using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.TextControl.DocumentMarkup;
using JetBrains.UI.RichText;

namespace ReSharperPlugin.NegationHighlighter
{
    [RegisterConfigurableSeverity(
        SeverityId,
        CompoundItemName: null,
        Group: HighlightingGroupIds.CodeInfo,
        Title: Message,
        Description: Description,
        DefaultSeverity: Severity.HINT)
    ]
    [ConfigurableSeverityHighlighting(
        SeverityId,
        CSharpLanguage.Name,
        AttributeId = NegationHighlighterAttributeIds.UnaryNot,
        ToolTipFormatString = Message)]
    public class NegationHighlighting : IRichTextToolTipHighlighting
    {
        public const string SeverityId = nameof(NegationHighlighting);
        public const string Message = "Unary Negation";
        public const string Description = "Unary Negation";

        public NegationHighlighting(ITreeNode declaration)
        {
            Declaration = declaration;
        }

        public ITreeNode Declaration { get; }

        public bool IsValid()
        {
            return Declaration.IsValid();
        }

        public DocumentRange CalculateRange()
        {
            if (Declaration is ICSharpExpression expression)
                return expression.GetExpressionRange();

            return Declaration.GetDocumentRange();
        }

        public string ToolTip => Message;

        public string ErrorStripeToolTip => Description;
        public RichTextBlock TryGetTooltip(HighlighterTooltipKind where)
        {
            return HighlightingToolTipHelper.CreateRichTextBlock(Message, CSharpLanguage.Instance!, where);
        }
    }
}
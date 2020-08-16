using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Tree;

namespace ReSharperPlugin.NegationHighlighter
{
    [RegisterConfigurableSeverity(
        NegationHighlighting.SeverityId,
        CompoundItemName: null,
        Group: HighlightingGroupIds.CodeInfo,
        Title: NegationHighlighting.Message,
        Description: NegationHighlighting.Description,
        DefaultSeverity: Severity.HINT)
    ]
    [ConfigurableSeverityHighlighting(
        SeverityId,
        CSharpLanguage.Name,
        AttributeId = NegationHighlighterAttributeIds.UnaryNot,
        ToolTipFormatString = Message)]
    public class NegationHighlighting : IHighlighting
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
            return Declaration.GetDocumentRange();
        }

        public string ToolTip => Message;

        public string ErrorStripeToolTip => Description;
    }
}
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace ReSharperPlugin.NegationHighlighter
{
    [ElementProblemAnalyzer(
        typeof(ICSharpExpression),
        HighlightingTypes = new[]
        {
            typeof(NegationHighlighting)
        })]
    public class NegationAnalyzer : ElementProblemAnalyzer<ICSharpExpression>
    {
        protected override void Run(ICSharpExpression element, ElementProblemAnalyzerData data,
            IHighlightingConsumer consumer)
        {
            switch (element)
            {
                case IUnaryOperatorExpression unaryOperatorExpression
                    when unaryOperatorExpression.UnaryOperatorType == UnaryOperatorType.EXCL:
                    consumer.AddHighlighting(new NegationHighlighting(unaryOperatorExpression.FirstChild));
                    return;
            }
        }
    }
}
using System.Diagnostics.Contracts;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

public static class ExpressionRangeUtils
{
    [Pure]
    public static DocumentRange GetExpressionRange(this ICSharpExpression expression)
    {
        switch (expression)
        {
            case IReferenceExpression referenceExpression:
                return referenceExpression.NameIdentifier.GetDocumentRange();

            case IInvocationExpression
            {
                InvokedExpression: IReferenceExpression { QualifierExpression: not null } invokedExpression
            }:
                return invokedExpression.NameIdentifier.GetDocumentRange();

            case IParenthesizedExpression parenthesizedExpression:
                return parenthesizedExpression.Expression.GetExpressionRange();

            default:
                return expression.GetDocumentRange();
        }
    }
}
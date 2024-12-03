using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.Application.Parts;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.TextControl.DocumentMarkup;

namespace ReSharperPlugin.NegationHighlighter
{
    public class NotHighlighterSettingsNamesProvider()
        : PrefixBasedSettingsNamesProvider(NegationHighlighterAttributeIds.GroupId,
           "Negation_Highlighter");

    [ShellComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class NotHighlighterSeverityPresentationsProvider : IHighlightingCustomPresentationsForSeverityProvider
    {
        public IEnumerable<string> GetAttributeIdsForSeverity(Severity severity)
        {
            if (severity is Severity.HINT or Severity.WARNING or Severity.SUGGESTION)
            {
                return [
                    NegationHighlighterAttributeIds.UnaryNot,
                ];
            }

            return [];
        }
    }
}
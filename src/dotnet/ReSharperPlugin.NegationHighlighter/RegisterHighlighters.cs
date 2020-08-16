using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.TextControl.DocumentMarkup;

namespace ReSharperPlugin.NegationHighlighter
{
    public class NotHighlighterSettingsNamesProvider : PrefixBasedSettingsNamesProvider
    {
        public NotHighlighterSettingsNamesProvider()
            : base(NegationHighlighterAttributeIds.GroupId, NegationHighlighterAttributeIds.GroupId)
        {
        }
    }

    [ShellComponent]
    public class ConfigurableSeverityHacks
    {
        [NotNull] private static readonly Severity[] Severities =
        {
            Severity.HINT,
            Severity.WARNING
        };

        [NotNull] private static readonly string[] HighlightingIds =
        {
            NegationHighlighterAttributeIds.UnaryNot,
        };

        public ConfigurableSeverityHacks()
        {
            var severityIds = HighlightingAttributeIds.ValidHighlightingsForSeverity;
            lock (severityIds)
            {
                foreach (var severity in Severities)
                {
                    if (!severityIds.TryGetValue(severity, out var collection)) continue;

                    foreach (var highlightingId in HighlightingIds)
                    {
                        if (!collection.Contains(highlightingId))
                        {
                            collection.Add(highlightingId);
                        }
                    }
                }
            }
        }
    }
}

using System.Drawing;
using JetBrains.TextControl.DocumentMarkup;

namespace ReSharperPlugin.NegationHighlighter
{
    [RegisterHighlighter(
        UnaryNot,
        GroupId = GroupId,
        BackgroundColor = "Orange",
        DarkBackgroundColor = "Orange",
        ForegroundColor = "Red",
        FontStyle = FontStyle.Bold,
        Layer = HighlighterLayer.SYNTAX)]

    [RegisterHighlighterGroup(
        GroupId, "Negation Highlighter", HighlighterGroupPriority.COMMON_SETTINGS,
        RiderNamesProviderType = typeof(NotHighlighterSettingsNamesProvider))]
    public static class NegationHighlighterAttributeIds
    {
        public const string UnaryNot = "Unary Negation Highlighter !";

        public const string GroupId = "Unary Negation Highlighter";
    }
}

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
        EffectType = EffectType.SOLID_UNDERLINE,
        Layer = HighlighterLayer.ADDITIONAL_SYNTAX)]

    [RegisterHighlighterGroup(
        GroupId, "Negation Highlighter", HighlighterGroupPriority.COMMON_SETTINGS,
        RiderNamesProviderType = typeof(NotHighlighterSettingsNamesProvider))]
    public static class NegationHighlighterAttributeIds
    {
        public const string GroupId = "Unary Negation Highlighter";
        public const string UnaryNot = "Unary Negation Highlighter !";
    }
}
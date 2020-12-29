using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework.Application.Zones;


namespace ReSharperPlugin.NegationHighlighter.Tests
{
  [ZoneDefinition]
  public interface INegationHighlighterTestZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>
  {
  }
}

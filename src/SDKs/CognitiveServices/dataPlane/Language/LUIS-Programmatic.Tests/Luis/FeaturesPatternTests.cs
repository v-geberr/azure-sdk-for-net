namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class FeaturesPatternTests : BaseTest
    {
        [Fact]
        public void GetApplicationVersionPatternFeatures()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var patterns = await client.Features.GetApplicationVersionPatternFeaturesAsync(appId, version);

                Assert.True(patterns.Count > 0);
            });
        }


        [Fact]
        public void CreatePatternFeature()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";

                var newPattern = new PatternCreateObject
                {
                    Name = "EmailPattern",
                    Pattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b"
                };
                var patternId = await client.Features.CreatePatternFeatureAsync(appId, version, newPattern);
                var patterns = await client.Features.GetApplicationVersionPatternFeaturesAsync(appId, version);

                Assert.Contains(patterns, p => p.Id.Equals(patternId));
            });
        }
    }
}

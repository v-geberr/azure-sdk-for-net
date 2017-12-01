﻿namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Xunit;

    public class FeaturesTests : BaseTest
    {
        [Fact]
        public void GetApplicationVersionPatternFeatures()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var features = await client.Features.GetApplicationVersionFeaturesAsync(appId, version);

                Assert.True(features.PatternFeatures.Count > 0);
                Assert.True(features.PhraselistFeatures.Count > 0);
            });
        }
    }
}

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
        public void GetApplicationVersionPatternFeaturesAsync()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var patterns = await client.Features.GetApplicationVersionPatternFeaturesAsync(appId, version);

                Assert.True(patterns.Count > 0);
            });
        }
    }
}

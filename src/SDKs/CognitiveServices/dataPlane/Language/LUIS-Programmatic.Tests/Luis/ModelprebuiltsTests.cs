namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelPrebuiltsTests : BaseTest
    {
        [Fact]
        public void GetAvailablePrebuiltEntityExtractorsAsync()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntities = await client.Model.GetAvailablePrebuiltEntityExtractorsAsync(appId, version);

                Assert.True(prebuiltEntities.Count > 0);
            });
        }
    }
}

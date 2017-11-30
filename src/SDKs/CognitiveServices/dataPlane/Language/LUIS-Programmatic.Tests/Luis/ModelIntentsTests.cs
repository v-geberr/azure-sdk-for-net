namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelIntentsTests : BaseTest
    {
        [Fact]
        public void GetApplicationVersionIntentInfos()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intents = await client.Model.GetApplicationVersionIntentInfosAsync(appId, version);

                Assert.True(intents.All(i => i.ReadableType.Equals("Intent Classifier")));
            });
        }

        [Fact]
        public void CreateIntentClassifier()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";

                var newIntent = new ModelCreateObject
                {
                    Name = "TestIntent"
                };

                var newIntentId = await client.Model.CreateIntentClassifierAsync(appId, version, newIntent);
                var intents = await client.Model.GetApplicationVersionIntentInfosAsync(appId, version);

                Assert.True(Guid.TryParse(newIntentId, out Guid intentGuid));
                Assert.Contains(intents, i => i.Id.Equals(newIntentId) && i.Name.Equals(newIntent.Name));
            });
        }
    }
}

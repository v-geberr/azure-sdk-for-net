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

        [Fact]
        public void GetIntentInfo()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = "d7a08f1a-d276-4364-b2d5-b0235c61e37f";

                var intent = await client.Model.GetIntentInfoAsync(appId, version, intentId);

                Assert.Equal(intentId, intent.Id);
            });
        }

        [Fact]
        public void RenameIntentModel()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = "d7a08f1a-d276-4364-b2d5-b0235c61e37f";
                var newName = new ModelUpdateObject
                {
                    Name = "NewTest"
                };

                var intent = await client.Model.GetIntentInfoAsync(appId, version, intentId);
                await client.Model.RenameIntentModelAsync(appId, version, intentId, newName);
                var newIntent = await client.Model.GetIntentInfoAsync(appId, version, intentId);

                Assert.Equal(intent.Id, newIntent.Id);
                Assert.NotEqual(intent.Name, newIntent.Name);
                Assert.Equal(newName.Name, newIntent.Name);
            });
        }

        [Fact]
        public void DeleteIntentModel()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = "d7a08f1a-d276-4364-b2d5-b0235c61e37f";

                var intents = await client.Model.GetApplicationVersionIntentInfosAsync(appId, version);
                await client.Model.DeleteIntentModelAsync(appId, version, intentId);
                var intentsWithoutDeleted = await client.Model.GetApplicationVersionIntentInfosAsync(appId, version);

                Assert.Contains(intents, i => i.Id.Equals(intentId));
                Assert.DoesNotContain(intentsWithoutDeleted, i => i.Id.Equals(intentId));
            });
        }
    }
}

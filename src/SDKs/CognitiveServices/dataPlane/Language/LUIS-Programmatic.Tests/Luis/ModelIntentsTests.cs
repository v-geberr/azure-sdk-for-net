namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
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
    }
}

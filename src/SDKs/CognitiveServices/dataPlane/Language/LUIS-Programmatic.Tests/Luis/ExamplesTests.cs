namespace LUIS.Programmatic.Tests.Luis
{
    using System.Collections.Generic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class ExamplesTests : BaseTest
    {
        private const string versionId = "0.1";
        
        [Fact]
        public void GetExamples()
        {
            UseClientFor(async client =>
            {
                var examples = await client.Examples.ReviewLabeledExamplesAsync(appId, versionId);

                Assert.NotEmpty(examples);
            });
        }

        [Fact]
        public void GetExamples_ForEmptyApplication_ReturnsEmpty()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject
                {
                    Name = "Examples Test App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var examples = await client.Examples.ReviewLabeledExamplesAsync(appId, versionId);

                await client.Apps.DeleteApplicationAsync(appId);

                Assert.Empty(examples);
            });
        }

        [Fact]
        public void AddExample()
        {
            UseClientFor(async client =>
            {
                var example = new ExampleLabelObject
                {
                    Text = "whats the weather in buenos aires?",
                    IntentName = "WeatherInPlace",
                    EntityLabels = new List<EntityLabelObject>()
                    {
                        new EntityLabelObject()
                        {
                            EntityName = "Place",
                            StartCharIndex = 21,
                            EndCharIndex = 34
                        }
                    }
                };
                var result = await client.Examples.AddLabelAsync(appId, versionId, example);

                Assert.Equal(example.Text, result.UtteranceText);
            });
        }
    }
}

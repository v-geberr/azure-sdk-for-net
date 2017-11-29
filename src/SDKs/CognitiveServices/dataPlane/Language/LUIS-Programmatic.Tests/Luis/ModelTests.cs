namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelTests: BaseTest
    {
        [Fact]
        public void AddCustomPrebuiltDomainToApplication()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.GetApplicationVersionsAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomainToAdd = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainToApplicationAsync(appId, version, prebuiltDomainToAdd);
                var prebuiltModels = await client.Model.GetCustomPrebuiltDomainModelsInfoAsync(appId, version);

                foreach (var result in results)
                {
                    Assert.True(Guid.TryParse(result, out Guid modelGuid));
                    Assert.Contains(prebuiltModels, m => m.Id.Equals(result));
                }
            });
        }
        
    }
}

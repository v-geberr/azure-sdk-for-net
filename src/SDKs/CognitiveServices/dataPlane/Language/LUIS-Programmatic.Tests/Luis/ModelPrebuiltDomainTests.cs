namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelPrebuiltDomainTests: BaseTest
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

        [Fact]
        public void DeleteCustomPrebuiltDomainModels()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.GetApplicationVersionsAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainToApplicationAsync(appId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.GetCustomPrebuiltDomainModelsInfoAsync(appId, version);

                Assert.True(prebuiltModels.Count > 0);

                await client.Model.DeleteCustomPrebuiltDomainModelsAsync(appId, version, prebuiltDomain.DomainName);

                prebuiltModels = await client.Model.GetCustomPrebuiltDomainModelsInfoAsync(appId, version);

                Assert.True(prebuiltModels.Count == 0);
            });
        }

        [Fact]
        public void GetCustomPrebuiltDomainEntitiesInfo()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.GetApplicationVersionsAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainToApplicationAsync(appId, version, prebuiltDomain);
                var prebuiltEntities = await client.Model.GetCustomPrebuiltDomainEntitiesInfoAsync(appId, version);

                Assert.Contains(prebuiltEntities, entity => entity.CustomPrebuiltDomainName == prebuiltDomain.DomainName);
            });
        }

        [Fact]
        public void AddCustomPrebuiltEntityModel()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.GetApplicationVersionsAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltModel = new PrebuiltDomainModelCreateObject
                {
                    DomainName = "Camera",
                    ModelName = "AppName"
                };

                var guidModel = await client.Model.AddCustomPrebuiltEntityModelAsync(appId, version, prebuiltModel);
                var prebuiltEntities = await client.Model.GetCustomPrebuiltDomainEntitiesInfoAsync(appId, version);

                Assert.Contains(prebuiltEntities, entity => entity.Id == guidModel);
            });
        }

        [Fact]
        public void GetCustomPrebuiltDomainIntentsInfo()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.GetApplicationVersionsAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainToApplicationAsync(appId, version, prebuiltDomain);
                var prebuiltIntents = await client.Model.GetCustomPrebuiltDomainIntentsInfoAsync(appId, version);

                Assert.Contains(prebuiltIntents, entity => entity.CustomPrebuiltDomainName == prebuiltDomain.DomainName);
            });
        }
    }
}

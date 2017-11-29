﻿namespace LUIS.Programmatic.Tests.Luis
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
    }
}

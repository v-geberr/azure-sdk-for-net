﻿namespace LUIS.Programmatic.Tests.Luis
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

        [Fact]
        public void GetApplicationVersionPrebuiltInfos()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntities = await client.Model.GetApplicationVersionPrebuiltInfosAsync(appId, version);

                Assert.True(prebuiltEntities.Count > 0);
                Assert.All(prebuiltEntities, e => e.ReadableType.Equals("Prebuilt Entity Extractor"));
            });
        }

        [Fact]
        public void AddPrebuiltEntityExtractors()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "number",
                    "ordinal"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltEntityExtractorsAsync(appId, version, prebuiltEntitiesToAdd);

                Assert.All(prebuiltEntitiesAdded, e => prebuiltEntitiesToAdd.Contains(e.Name));
            });
        }

        [Fact]
        public void GetPrebuiltInfo()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltId = "a065c863-918e-4c56-a267-9aaae3c7dced";

                var prebuiltEntity = await client.Model.GetPrebuiltInfoAsync(appId, version, prebuiltId);

                Assert.Equal(prebuiltId, prebuiltEntity.Id);
            });
        }
    }
}

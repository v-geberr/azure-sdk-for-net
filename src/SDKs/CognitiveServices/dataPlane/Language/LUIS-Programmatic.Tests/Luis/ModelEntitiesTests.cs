namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class ModelSimpleEntitiesTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void GetEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateEntityExtractorAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Existing Entity Test"
                });

                var results = await client.Model.GetApplicationVersionEntityInfosAsync(appId, versionId);

                Assert.NotEqual(0, results.Count);
                Assert.Contains(results, o => o.Name == "Existing Entity Test");

                await client.Model.DeleteEntityModelAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void GetEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateEntityExtractorAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "New Entity Test"
                });

                var result = await client.Model.GetEntityInfoAsync(appId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Entity Extractor", result.ReadableType);

                await client.Model.DeleteEntityModelAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void CreateEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateEntityExtractorAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "New Entity Test"
                });

                var result = await client.Model.GetEntityInfoAsync(appId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Entity Extractor", result.ReadableType);

                await client.Model.DeleteEntityModelAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void RenameEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateEntityExtractorAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Rename Entity Test"
                });

                await client.Model.RenameEntityModelAsync(appId, versionId, entityId, new ModelUpdateObject
                {
                    Name = "Entity Test Renamed"
                });

                var result = await client.Model.GetEntityInfoAsync(appId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("Entity Test Renamed", result.Name);

                await client.Model.DeleteEntityModelAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void DeleteEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateEntityExtractorAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Delete Entity Test"
                });

                await client.Model.DeleteEntityModelAsync(appId, versionId, entityId);

                var results = await client.Model.GetApplicationVersionEntityInfosAsync(appId, versionId);

                Assert.DoesNotContain(results, o => o.Id == entityId);
            });
        }
    }
}

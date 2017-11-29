namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class ModelTests : BaseTest
    {
        [Fact]
        public void GetApplicationVersionCompositeEntityInfos()
        {
            UseClientFor(async client =>
            {
                var result = await client.Model.GetApplicationVersionCompositeEntityInfosAsync(BaseTest.appId, "0.1");

                Assert.Equal(3, result.Count);
                foreach (var entity in result)
                {
                    Assert.True(Guid.TryParse(entity.Id, out Guid id));
                }
            });
        }

        [Fact]
        public void CreateCompositeEntityExtractor()
        {
            UseClientFor(async client =>
            {
                var hierarchicalModel = new HierarchicalModelCreateObject(new List<string>() { "datetime" }, name: "Reservation");
                var result = await client.Model.CreateCompositeEntityExtractorAsync(BaseTest.appId, "0.1", hierarchicalModel);

                Assert.True(Guid.TryParse(result, out Guid id));
            });
        }

        [Fact]
        public void GetCompositeEntityInfo()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.GetApplicationVersionCompositeEntityInfosAsync(BaseTest.appId, "0.1");
                var entityId = entities.Last().Id;
                var result = await client.Model.GetCompositeEntityInfoAsync(BaseTest.appId, "0.1", entityId);

                Assert.True(Guid.TryParse(result.Id, out Guid id));
            });
        }

        [Fact]
        public void UpdateCompositeEntityModel()
        {
            UseClientFor(async client =>
            {
                var hierarchicalModel = new HierarchicalModelUpdateObject(new List<string>() { "datetime" }, name: "Renamed Entity");
                var entities = await client.Model.GetApplicationVersionCompositeEntityInfosAsync(BaseTest.appId, "0.1");
                var entityId = entities.Last().Id;

                await client.Model.UpdateCompositeEntityModelAsync(BaseTest.appId, "0.1", entityId, hierarchicalModel);

                entities = await client.Model.GetApplicationVersionCompositeEntityInfosAsync(BaseTest.appId, "0.1");
                Assert.Equal(hierarchicalModel.Name, entities.Single(e => e.Id == entityId).Name);
            });
        }
    }
}

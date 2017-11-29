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
                var entityId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var childEntity = new ChildEntity(entityId, "datetime");
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

                var result = await client.Model.GetCompositeEntityInfoAsync(BaseTest.appId, "0.1", entities.First().Id);

                Assert.True(Guid.TryParse(result.Id, out Guid id));
            });
        }

    }
}

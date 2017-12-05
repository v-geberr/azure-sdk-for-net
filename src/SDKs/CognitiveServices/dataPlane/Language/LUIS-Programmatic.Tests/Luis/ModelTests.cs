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
                var result = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");

                Assert.Equal(3, result.Count());
                foreach (var entity in result)
                {
                    Assert.True(entity.Id != Guid.Empty);
                }
            });
        }

        [Fact]
        public void CreateCompositeEntityExtractor()
        {
            UseClientFor(async client =>
            {
                var hierarchicalModel = new HierarchicalModelCreateObject(new List<string>() { "datetime" }, name: "Reservation");
                var result = await client.Model.AddCompositeEntityAsync(appId, "0.1", hierarchicalModel);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void GetCompositeEntityInfo()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                var entityId = entities.Last().Id;

                var result = await client.Model.GetCompositeEntityAsync(appId, "0.1", entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void UpdateCompositeEntityModel()
        {
            UseClientFor(async client =>
            {
                var hierarchicalModel = new HierarchicalModelUpdateObject(new List<string>() { "datetime" }, name: "Renamed Entity");
                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                var entityId = entities.Last().Id;

                await client.Model.UpdateCompositeEntityAsync(appId, "0.1", entityId, hierarchicalModel);

                entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                Assert.Equal(hierarchicalModel.Name, entities.Single(e => e.Id == entityId).Name);
            });
        }

        [Fact]
        public void DeleteCompositeEntityModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                var entityId = entities.Last().Id;

                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);

                entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                Assert.DoesNotContain(entities, e => e.Id == entityId);
            });
        }

        [Fact]
        public void CreateCompositeEntityChildModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                var entityId = entities.Last().Id;
                var entity = new CompositeChildModelCreateObject("datetimeV2");

                var result = await client.Model.AddCompositeEntityChildAsync(appId, "0.1", entityId, entity);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void DeleteCompositeEntityChildModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                var entity = entities.Where(e => e.Children.Any()).Last();
                var childEntityId = entity.Children.Last().Id;

                await client.Model.DeleteCompositeEntityChildAsync(appId, "0.1", entity.Id, childEntityId);

                entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                Assert.DoesNotContain(entities, e => e.Id == entity.Id && e.Children.Any(c => c.Id == childEntityId));
            });
        }

        [Fact]
        public void GetApplicationVersionHierarchicalEntityInfos()
        {
            UseClientFor(async client =>
            {
                var result = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");

                Assert.Equal(1, result.Count());
            });
        }

        [Fact]
        public void CreateHierarchicalEntityExtractor()
        {
            UseClientFor(async client =>
            {
                var hierarchicalModel = new HierarchicalModelCreateObject(new List<string>() { Guid.NewGuid().ToString() }, name: "Reservation");

                var result = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", hierarchicalModel);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void GetHierarchicalEntityInfo()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entityId = entities.Last().Id;

                var result = await client.Model.GetHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void UpdateHierarchicalEntityModel()
        {
            UseClientFor(async client =>
            {
                var hierarchicalModel = new HierarchicalModelUpdateObject(new List<string>() { "dummy" }, name: "Renamed Entity");
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entity = entities.Last();

                await client.Model.UpdateHierarchicalEntityAsync(appId, "0.1", entity.Id, hierarchicalModel);

                entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                Assert.Equal(hierarchicalModel.Name, entities.Single(e => e.Id == entity.Id).Name);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntityModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entityId = entities.Last().Id;

                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                Assert.DoesNotContain(entities, e => e.Id == entityId);
            });
        }

        [Fact]
        public void GetHierarchicalEntityChildInfo()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entity = entities.Where(e => e.Children.Any()).Last();
                var childEntityId = entity.Children.Last().Id;

                var result = await client.Model.GetHierarchicalEntityChildAsync(appId, "0.1", entity.Id, childEntityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntityChildModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entity = entities.Where(e => e.Children.Any()).Last();
                var childEntityId = entity.Children.Last().Id;

                await client.Model.DeleteHierarchicalEntityChildAsync(appId, "0.1", entity.Id, childEntityId);

                entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                Assert.DoesNotContain(entities, e => e.Id == entity.Id && e.Children.Any(c => c.Id == childEntityId));
            });
        }

        [Fact]
        public void UpdateHierarchicalEntityChildModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entity = entities.Where(e => e.Children.Any()).Last();
                var childEntity = entity.Children.Last();
                var updateEntity = new HierarchicalChildModelUpdateObject("RenamedChildEntity");

                await client.Model.UpdateHierarchicalEntityChildAsync(appId, "0.1", entity.Id, childEntity.Id, updateEntity);

                entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");

                entity = entities.Last(e => e.Id == entity.Id);
                childEntity = entity.Children.Last(c => c.Id == childEntity.Id);
                Assert.Equal("RenamedChildEntity", childEntity.Name);
            });
        }

        [Fact]
        public void CreateHierarchicalEntityChildModel()
        {
            UseClientFor(async client =>
            {
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                var entity = entities.Where(e => e.Children.Any()).Last();
                var childEntity = new HierarchicalChildModelCreateObject
                {
                    Name = "NewChildEntity"
                };

                var result = await client.Model.AddHierarchicalEntityChildAsync(appId, "0.1", entity.Id, childEntity);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void GetApplicationVersionModelInfos()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var models = await client.Model.ListModelsAsync(appId, versionId);

                foreach (var model in models)
                {
                    var modelInfo = await client.Model.GetEntityAsync(appId, versionId, model.Id);
                    Assert.Equal(model.Name, modelInfo.Name);
                }
            });
        }
    }
}

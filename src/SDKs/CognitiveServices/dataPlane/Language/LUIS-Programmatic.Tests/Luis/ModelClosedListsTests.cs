namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;

    public class ModelClosedListsTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void GetLists()
        {
            UseClientFor(async client =>
            {
                var result = await client.Model.GetApplicationVersionClosedListInfosAsync(appId, versionId);

                Assert.NotEqual(0, result.Count);
                Assert.Contains(result, o => o.Name == "States");
            });
        }

        [Fact]
        public void CreateList()
        {
            UseClientFor(async client =>
            {
                var sample = GetClosedListSample();
                var listId = await client.Model.CreateClosedListEntityModelAsync(appId, versionId, sample);

                Assert.True(Guid.TryParse(listId, out Guid result));
            });
        }

        [Fact]
        public void GetList()
        {
            UseClientFor(async client =>
            {
                var listId = "4b501a95-2720-43d7-8ca9-4166c0faa6cb";
                var list = await client.Model.GetClosedListEntityInfoAsync(appId, versionId, listId);

                // Assert
                Assert.Equal("Retrieve Sample List", list.Name);
                Assert.Equal(3, list.SubLists.Count);
            });
        }

        [Fact]
        public void UpdateList()
        {
            UseClientFor(async client =>
            {
                var listId = "d1f95436-57ac-4524-ae81-5bdd32668ccf";
                var update = new ClosedListModelUpdateObject()
                {
                    Name = "New States",
                    SubLists = new List<WordListObject>()
                    {
                       new WordListObject()
                       {
                           CanonicalForm = "Texas",
                           List = new List<string>() { "TX", "Texas" }
                       }
                    }
                };

                await client.Model.UpdateClosedListEntityModelAsync(appId, versionId, listId, update);
                var updated = await client.Model.GetClosedListEntityInfoAsync(appId, versionId, listId);

                Assert.Equal("New States", updated.Name);
                Assert.Equal(1, updated.SubLists.Count);
                Assert.Equal("Texas", updated.SubLists[0].CanonicalForm);
            });
        }

        [Fact]
        public void DeleteList()
        {
            UseClientFor(async client =>
            {
                var listId = "d1f95436-57ac-4524-ae81-5bdd32668ccf";
                await client.Model.DeleteClosedListEntityModelAsync(appId, versionId, listId);

                var lists = await client.Model.GetApplicationVersionClosedListInfosAsync(appId, versionId);

                Assert.DoesNotContain(lists, o => o.Id == listId);
            });
        }

        private static ClosedListModelCreateObject GetClosedListSample()
        {
            ////    {
            ////    	"name": "States",
            ////    	"sublists": 
            ////    	[
            ////    		{
            ////    			"canonicalForm": "New York",
            ////    			"list": [ "NY", "New York" ]
            ////    		},
            ////    		{
            ////    			"canonicalForm": "Washington",
            ////    			"list": [ "WA", "Washington" ]
            ////    		},
            ////    		{
            ////    			"canonicalForm": "California",
            ////    			"list": [ "CA", "California", "Calif.", "Cal." ]
            ////    		}
            ////    	]
            ////    }

            return new ClosedListModelCreateObject
            {
                Name = "States",
                SubLists = new List<WordListObject>()
                {
                    new WordListObject(
                        "New York",
                        new List<string>() { "NY", "New York" }),

                    new WordListObject(
                        "Washington",
                        new List<string>() { "WA", "Washington" }),

                    new WordListObject(
                        "California",
                        new List<string>() { "CA", "California", "Calif.", "Cal." })
                }
            };
        }
    }
}

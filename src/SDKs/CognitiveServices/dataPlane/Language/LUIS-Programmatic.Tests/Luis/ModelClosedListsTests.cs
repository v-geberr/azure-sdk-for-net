﻿namespace LUIS.Programmatic.Tests.Luis
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
                           List = new List<string>() { "tx", "texas" }
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

        [Fact]
        public void AddWordListsToExistingList()
        {
            UseClientFor(async client =>
            {
                var listId = "f64b2c73-3a8d-4f00-a98b-f4adf57d5553";

                await client.Model.PatchClosedListEntityModelAsync(appId, versionId, listId, new ClosedListModelPatchObject
                {
                    SubLists = new List<WordListObject>()
                    {
                        new WordListObject()
                        {
                            CanonicalForm = "Texas",
                            List = new List<string>() { "tx", "texas" }
                        },
                        new WordListObject()
                        {
                            CanonicalForm = "Florida",
                            List = new List<string>() { "fl", "florida" }
                        }
                    }
                });

                var list = await client.Model.GetClosedListEntityInfoAsync(appId, versionId, listId);

                Assert.Equal(5, list.SubLists.Count);
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "Texas" && o.List.Contains("tx") && o.List.Contains("texas"));
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "Florida" && o.List.Contains("fl") && o.List.Contains("florida"));
            });
        }

        [Fact]
        public void AddWordListToExistingList()
        {
            UseClientFor(async client =>
            {
                var listId = "28027e3b-8356-4cdf-b395-24afb94e9469";

                string sublistId = await client.Model.AddSubListAsync(appId, versionId, listId, new WordListObject()
                {
                    CanonicalForm = "Texas",
                    List = new List<string>() { "tx", "texas" }
                });

                var list = await client.Model.GetClosedListEntityInfoAsync(appId, versionId, listId);

                Assert.True(int.TryParse(sublistId, out int id));
                Assert.Equal(4, list.SubLists.Count);
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "Texas" && o.List.Contains("tx") && o.List.Contains("texas"));
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
            ////    			"list": [ "ny", "new york" ]
            ////    		},
            ////    		{
            ////    			"canonicalForm": "Washington",
            ////    			"list": [ "wa", "washington" ]
            ////    		},
            ////    		{
            ////    			"canonicalForm": "California",
            ////    			"list": [ "ca", "california", "calif.", "cal." ]
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

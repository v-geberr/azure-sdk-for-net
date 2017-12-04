﻿namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System.Linq;
    using Xunit;

    public class VersionsTests: BaseTest
    {
        [Fact]
        public void GetApplicationVersions()
        {
            UseClientFor(async client =>
            {
                var results = await client.Versions.ListAsync(appId);

                Assert.True(results.Count > 0);
                foreach (var version in results)
                {
                    Assert.NotNull(version.Version);
                }
            });
        }

        [Fact]
        public void GetApplicationVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                foreach (var version in versions)
                {
                    var result = await client.Versions.GetAsync(appId, version.Version);
                    Assert.Equal(version.Version, result.Version);
                    Assert.Equal(version.TrainingStatus, result.TrainingStatus);
                }
            });
        }

        [Fact]
        public void RenameApplicationVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var versionToUpdate = new TaskUpdateObject
                {
                    Version = "test"
                };

                await client.Versions.UpdateAsync(appId, first.Version, versionToUpdate);
                var versionsWithUpdate = await client.Versions.ListAsync(appId);

                Assert.Contains(versionsWithUpdate, v => v.Version.Equals(versionToUpdate.Version));
                Assert.DoesNotContain(versionsWithUpdate, v => v.Version.Equals(first.Version));

                await client.Versions.UpdateAsync(appId, versionToUpdate.Version, new TaskUpdateObject
                {
                    Version = first.Version
                });
            });
        }

        [Fact]
        public void DeleteApplicationVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                var newVersion = await client.Versions.CloneAsync(appId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.ListAsync(appId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(newVersion));

                await client.Versions.DeleteAsync(appId, newVersion);

                var versionsWithoutTest = await client.Versions.ListAsync(appId);

                Assert.DoesNotContain(versionsWithoutTest, v => v.Version.Equals(newVersion));
            });
        }

        [Fact]
        public void CloneVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                Assert.DoesNotContain(versions, v => v.Version.Equals(testVersion.Version));

                var newVersion = await client.Versions.CloneAsync(appId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.ListAsync(appId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(newVersion));

                await client.Versions.DeleteAsync(appId, newVersion);
            });
        }
        
        [Fact]
        public void DeleteUnlabelledUtterance()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var versionId = versions.FirstOrDefault().Version;
                var intents = await client.Model.ListIntentsAsync(appId, versionId);
                var intentId = intents.FirstOrDefault().Id;

                var suggestions = await client.Model.GetIntentSuggestionsAsync(appId, versionId, intentId);

                var utteranceToDelete = suggestions.FirstOrDefault().Text;

                await client.Versions.DeleteUnlabelledUtteranceAsync(appId, versionId, utteranceToDelete);

                var suggestionsWithoutDeleted = await client.Model.GetIntentSuggestionsAsync(appId, versionId, intentId);

                Assert.DoesNotContain(suggestionsWithoutDeleted, v => v.Text.Equals(utteranceToDelete));
            });
        }
    }
}

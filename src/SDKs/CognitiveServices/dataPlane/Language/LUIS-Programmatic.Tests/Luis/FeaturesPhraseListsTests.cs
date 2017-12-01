﻿namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;


    public class FeaturesPhraseListsTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void AddPhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.CreatePhraselistFeatureAsync(appId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrases = await client.Features.GetPhraselistFeatureInfoAsync(appId, versionId, id.Value);
                await client.Features.DeletePhraselistFeatureAsync(appId, versionId, id.Value);

                Assert.NotNull(phrases);
                Assert.Equal("DayOfWeek", phrases.Name);
                Assert.Equal("monday,tuesday,wednesday,thursday,friday,saturday,sunday", phrases.Phrases);
            });
        }

        [Fact]
        public void GetPhraseLists()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.CreatePhraselistFeatureAsync(appId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrases = await client.Features.GetApplicationVersionPhraselistFeaturesAsync(appId, versionId);
                await client.Features.DeletePhraselistFeatureAsync(appId, versionId, id.Value);

                Assert.True(phrases.Count > 0);
            });
        }

        [Fact]
        public void GetSinglePhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.CreatePhraselistFeatureAsync(appId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrase = await client.Features.GetPhraselistFeatureInfoAsync(appId, versionId, id.Value);
                await client.Features.DeletePhraselistFeatureAsync(appId, versionId, id.Value);

                Assert.Equal("DayOfWeek", phrase.Name);
                Assert.True(phrase.IsActive);
                Assert.True(phrase.IsExchangeable);
            });
        }

        [Fact]
        public void DeletePhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.CreatePhraselistFeatureAsync(appId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrase = await client.Features.GetPhraselistFeatureInfoAsync(appId, versionId, id.Value);
                await client.Features.DeletePhraselistFeatureAsync(appId, versionId, id.Value);

                var phrases = await client.Features.GetApplicationVersionPhraselistFeaturesAsync(appId, versionId);

                Assert.DoesNotContain(phrases, o => o.Id == id);
            });
        }
    }
}

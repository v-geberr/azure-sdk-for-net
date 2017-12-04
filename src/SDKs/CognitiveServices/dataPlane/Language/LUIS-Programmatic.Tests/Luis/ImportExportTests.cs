namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Newtonsoft.Json;
    using Xunit;

    public class ImportExportTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void ExportVersion()
        {
            UseClientFor(async client =>
            {
                var app = await client.Versions.ExportApplicationVersionAsync(appId, versionId);

                Assert.NotNull(app);
                Assert.Equal("LuisBot", app.Name);
            });
        }

        [Fact]
        public void ImportVersionToApp()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportApp.json"));
            var app = JsonConvert.DeserializeObject<LuisApp>(appJson);

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject
                {
                    Name = "Import Version Test LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var newVersion = await client.Versions.ImportVersionToApplicationAsync(testAppId, app, "0.2");

                await client.Apps.DeleteApplicationAsync(testAppId);

                Assert.Equal("0.2", newVersion);
            });
        }

        [Fact]
        public void ImportApp()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportApp.json"));
            var app = JsonConvert.DeserializeObject<LuisApp>(appJson);

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.ImportApplicationAsync(app, "Test Import LUIS App");
                var testApp = await client.Apps.GetApplicationInfoAsync(testAppId);
                await client.Apps.DeleteApplicationAsync(testAppId);

                Assert.NotNull(testApp);
            });
        }
    }
}

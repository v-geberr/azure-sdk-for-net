﻿namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Globalization;
    using System.IO;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class AppsTests : BaseTest
    {
        [Fact]
        public void GetApplicationsList()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "Existing LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                // Test
                var result = await client.Apps.GetApplicationsListAsync();

                Assert.NotEqual(0, result.Count);
                Assert.All(result, o => Guid.TryParse(o.Id, out Guid id));
                Assert.Contains(result, o => o.Name == "Existing LUIS App");

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void AddApplication()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var savedApp = await client.Apps.GetApplicationInfoAsync(testAppId);

                Assert.True(Guid.TryParse(testAppId, out Guid appGuid));
                Assert.NotNull(savedApp);
                Assert.Equal("New LUIS App", savedApp.Name);
                Assert.Equal("New LUIS App", savedApp.Description);
                Assert.Equal("en-us", savedApp.Culture);
                Assert.Equal("Comics", savedApp.Domain);
                Assert.Equal("IoT", savedApp.UsageScenario);

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void GetApplicationInfo()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "Existing LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var result = await client.Apps.GetApplicationInfoAsync(testAppId);
                Assert.Equal(testAppId, result.Id);
                Assert.Equal("Existing LUIS App", result.Name);
                Assert.Equal("en-us", result.Culture);
                Assert.Equal("Comics", result.Domain);
                Assert.Equal("IoT", result.UsageScenario);

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void RenameApplication()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App to be renamed",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.RenameApplicationAsync(testAppId, new ApplicationUpdateObject
                {
                    Name = "LUIS App name updated",
                    Description = "LUIS App description updated"
                });

                var app = await client.Apps.GetApplicationInfoAsync(testAppId);

                Assert.Equal("LUIS App name updated", app.Name);
                Assert.Equal("LUIS App description updated", app.Description);

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void DeleteApplication()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App to be deleted",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.DeleteApplicationAsync(testAppId);

                // Assert
                var result = await client.Apps.GetApplicationsListAsync();
                Assert.DoesNotContain(result, o => o.Id == testAppId);
            });
        }

        [Fact]
        public void GetApplicationEndpoints()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for endpoint test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var result = await client.Apps.GetEndpointsAsync(testAppId);

                Assert.Equal("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result.Westus);
                Assert.Equal("https://eastus2.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result.Eastus2);
                Assert.Equal("https://westcentralus.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result.Westcentralus);
                Assert.Equal("https://southeastasia.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result.Southeastasia);

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void PublishApplication()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.PublishApplicationAsync(appId, new ApplicationPublishObject
                {
                    IsStaging = false,
                    Region = AzureRegions.Westus.ToString().ToLowerInvariant(),
                    VersionId = "0.1"
                });

                Assert.Equal("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + appId, result.EndpointUrl);
                Assert.Equal("westus", result.EndpointRegion);
                Assert.False(result.IsStaging);
            });
        }

        [Fact]
        public void DownloadApplicationQueryLogs()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Query Logs test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var downloadStream = await client.Apps.DownloadApplicationQueryLogsAsync(testAppId);
                var reader = new StreamReader(downloadStream);

                var csv = reader.ReadToEnd();
                Assert.False(string.IsNullOrEmpty(csv));

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void GetApplicationSettings()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Settings test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var settings = await client.Apps.GetApplicationSettingsAsync(testAppId);

                Assert.Equal(testAppId, settings.Id);
                Assert.False(settings.PublicProperty);

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void UpdateApplicationSettings()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Settings test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.UpdateApplicationSettingsAsync(testAppId, new ApplicationSettingUpdateObject
                {
                    PublicProperty = true
                });

                // Assert
                var settings = await client.Apps.GetApplicationSettingsAsync(testAppId);
                Assert.True(settings.PublicProperty);

                // Cleanup
                await client.Apps.DeleteApplicationAsync(testAppId);
            });
        }

        [Fact]
        public void GetApplicationDomains()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationDomainsAsync();
                foreach (var domain in result)
                {
                    Assert.False(string.IsNullOrWhiteSpace(domain));
                }
            });
        }

        [Fact]
        public void GetApplicationCultures()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationCulturesAsync();
                foreach (var culture in result)
                {
                    var cult = new CultureInfo(culture.Code);
                    Assert.Equal(cult.Name.ToLowerInvariant(), culture.Code);
                }
            });
        }

        [Fact]
        public void GetApplicationUsageScenarios()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationUsageScenariosAsync();
                foreach (var scenario in result)
                {
                    Assert.False(string.IsNullOrWhiteSpace(scenario));
                }
            });
        }

        [Fact]
        public void GetAvailableCustomPrebuiltDomains()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetAvailableCustomPrebuiltDomainsAsync();
                foreach (var prebuiltDomain in result)
                {
                    Assert.NotNull(prebuiltDomain);
                    Assert.False(string.IsNullOrWhiteSpace(prebuiltDomain.Description));
                    Assert.NotNull(prebuiltDomain.Intents);
                    Assert.NotNull(prebuiltDomain.Entities);
                }
            });
        }

        [Fact]
        public void GetAvailableCustomPrebuiltDomainsForCulture()
        {
            UseClientFor(async client =>
            {
                var resultsUS = await client.Apps.GetAvailableCustomPrebuiltDomainsForCultureAsync("en-US");
                var resultsCN = await client.Apps.GetAvailableCustomPrebuiltDomainsForCultureAsync("zh-CN");

                foreach (var resultUS in resultsUS)
                {
                    Assert.DoesNotContain(resultsCN, r => r.Description == resultUS.Description);
                }
                foreach (var resultCN in resultsCN)
                {
                    Assert.DoesNotContain(resultsUS, r => r.Description == resultCN.Description);
                }
            });
        }

        [Fact]
        public void AddCustomPrebuiltApplication()
        {
            UseClientFor(async client =>
            {
                var domain = new PrebuiltDomainCreateObject
                {
                    Culture = "en-US",
                    DomainName = "Calendar"
                };
                var result = await client.Apps.AddCustomPrebuiltApplicationAsync(domain);

                Assert.True(Guid.TryParse(result, out Guid appGuid));
            });
        }
    }
}

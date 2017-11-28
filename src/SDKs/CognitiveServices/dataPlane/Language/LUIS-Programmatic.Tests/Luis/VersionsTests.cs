namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Xunit;

    public class VersionsTests: BaseTest
    {
        [Fact]
        public void GetApplicationVersions()
        {
            UseClientFor(async client =>
            {
                var results = await client.Versions.GetApplicationVersionsAsync(appId);

                Assert.True(results.Count > 0);
                foreach (var version in results)
                {
                    Assert.NotNull(version.Version);
                }
            });
        }
        
    }
}

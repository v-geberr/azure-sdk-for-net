using System;
using System.Collections.Generic;
using System.Linq;
using LUIS.Programmatic.Tests.Luis;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.LUIS.Programmatic.Tests.Luis
{
    public class ModelsTests : BaseTest
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
    }
}

﻿namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class PermissionsTests: BaseTest
    {
        [Fact]
        public void GetApplicationsList()
        {
            UseClientFor(async client =>
            {
                var result = await client.Permissions.GetApplicationUserAccessListAsync(appId);

                Assert.Equal("owner.user@microsoft.com", result.Owner);
                Assert.Equal(new string[] { "guest@outlook.com" }, result.Emails);
            });
        }
        [Fact]
        public void AddUserToAccessList()
        {
            UseClientFor(async client =>
            {
                var userToAdd = new UserToAdd
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.AddUserToAccessListAsync(appId, userToAdd);
                var result = await client.Permissions.GetApplicationUserAccessListAsync(appId);

                Assert.True(result.Emails.Contains(userToAdd.Email));
            });
        }
    }
}

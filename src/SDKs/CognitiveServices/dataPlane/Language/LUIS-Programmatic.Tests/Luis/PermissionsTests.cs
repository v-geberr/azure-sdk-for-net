namespace LUIS.Programmatic.Tests.Luis
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
                var userToAdd = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.AddUserToAccessListAsync(appId, userToAdd);
                var result = await client.Permissions.GetApplicationUserAccessListAsync(appId);

                Assert.True(result.Emails.Contains(userToAdd.Email));
            });
        }

        [Fact]
        public void RemoveUserFromAccessList()
        {
            UseClientFor(async client =>
            {
                var userToRemove = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.RemoveUserFromAccessListAsync(appId, userToRemove);
                var result = await client.Permissions.GetApplicationUserAccessListAsync(appId);

                Assert.False(result.Emails.Contains(userToRemove.Email));
            });
        }

        [Fact]
        public void UpdateAccessList()
        {
            UseClientFor(async client =>
            {
                var collaborators = new CollaboratorsArray
                {
                    Emails = new string[] 
                    {
                        "guest@outlook.com",
                        "invited.user@live.com"
                    }
                };

                await client.Permissions.UpdateAccessListAsync(appId, collaborators);
                var result = await client.Permissions.GetApplicationUserAccessListAsync(appId);

                Assert.Equal(collaborators.Emails, result.Emails);
            });
        }
    }
}

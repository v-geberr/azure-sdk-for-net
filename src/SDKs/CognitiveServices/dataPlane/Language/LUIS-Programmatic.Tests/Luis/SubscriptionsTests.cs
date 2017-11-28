namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class SubscriptionsTests : BaseTest
    {
        [Fact]
        public void GetSubscriptionsList()
        {
            UseClientFor(async client =>
            {
                var result = await client.User.GetUserSubscriptionKeysAsync();

                Assert.Equal(2, result.Count);
                foreach (var subscriptionKeyInfo in result)
                {
                    Assert.True(Guid.TryParse(subscriptionKeyInfo.SubscriptionKey, out Guid id));
                }
            });
        }

        [Fact(Skip = "HTTP 410 Gone")]
        public void RenameSubscription()
        {
            var subscriptionName = $"LUIS Subscription name updated ({Guid.NewGuid().ToString()})";
            UseClientFor(async client =>
            {
                await client.User.RenameSubscriptionKeyAsync(new UserSubscriptionCreateObject
                {
                    SubscriptionKey = BaseTest.subscriptionKey,
                    SubscriptionName = subscriptionName,
                });

                var subscriptionList = await client.User.GetUserSubscriptionKeysAsync();

                Assert.Contains(subscriptionList, s => s.SubscriptionKey == BaseTest.subscriptionKey);
                var subscription = subscriptionList.Single(s => s.SubscriptionKey == BaseTest.subscriptionKey);
                Assert.Equal(subscriptionName, subscription.SubscriptionName);
            });
        }

        [Fact(Skip = "HTTP 410 Gone")]
        public void AddSubscription()
        {
            var subscriptionKey = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var subscriptionName = $"LUIS Subscription name ({subscriptionKey})";
            UseClientFor(async client =>
            {
                await client.User.AddSubscriptionKeyAsync(new UserSubscriptionCreateObject
                {
                    SubscriptionKey = subscriptionKey,
                    SubscriptionName = subscriptionName
                });

                var subscriptionList = await client.User.GetUserSubscriptionKeysAsync();

                Assert.Contains(subscriptionList, s => s.SubscriptionKey == subscriptionKey);
            });
        }

        [Fact(Skip = "HTTP 410 Gone")]
        public void DeleteSubscription()
        {
            var subscriptionKey = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var subscriptionName = $"LUIS Subscription name ({subscriptionKey})";
            UseClientFor(async client =>
            {
                await client.User.AddSubscriptionKeyAsync(new UserSubscriptionCreateObject
                {
                    SubscriptionKey = subscriptionKey,
                    SubscriptionName = subscriptionName
                });

                await client.User.DeleteSubscriptionKeyAsync(subscriptionKey);

                var subscriptionList = await client.User.GetUserSubscriptionKeysAsync();

                Assert.DoesNotContain(subscriptionList, s => s.SubscriptionKey == subscriptionKey);
            });
        }
    }
}
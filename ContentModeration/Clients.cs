using Microsoft.Azure.CognitiveServices.ContentModerator;
using System;

namespace ContentModeration
{
    public static class Clients
    {
        /// <summary>
        /// The base URL fragment for Content Moderator calls.
        /// Uses the Azure Content Moderator endpoint from the environment variables.
        /// </summary>
        private static readonly string Endpoint = Environment.GetEnvironmentVariable("CONTENT_MODERATOR_ENDPOINT");

        /// <summary>
        /// The Content Moderator subscription key
        /// Uses the Azure Content Moderator subscription from the environment variables.
        /// </summary>
        private static readonly string SubscriptionKey = Environment.GetEnvironmentVariable("CONTENT_MODERATOR_SUBSCRIPTION_KEY");

        /// <summary>
        /// Returns a new Conent Moderator client using the Azure subscription.
        /// </summary>
        /// <returns>The new Client.</returns>
        /// <remarks>The <see cref="ContentModeratorClient"/> is disposable.
        /// When you have finished using the cient, it should be disposed of.</remarks>
        public static ContentModeratorClient NewClient()
        {
            // Create and initialize an instance of the Content Moderator API wrapper.
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(SubscriptionKey));

            client.Endpoint = Endpoint;
            return client;
        }
    }
}

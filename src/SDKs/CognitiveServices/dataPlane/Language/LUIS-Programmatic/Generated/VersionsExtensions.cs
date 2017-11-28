// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Versions.
    /// </summary>
    public static partial class VersionsExtensions
    {
            /// <summary>
            /// Creates a new version equivalent to the current snapshot of the selected
            /// application version.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='taskUpdateObject'>
            /// An object containing the new version ID.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task CloneVersionAsync(this IVersions operations, string appId, string versionId, TaskUpdateObject taskUpdateObject = default(TaskUpdateObject), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.CloneVersionWithHttpMessagesAsync(appId, versionId, taskUpdateObject, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets the application versions info.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='skip'>
            /// The number of entries to skip. Default value is 0.
            /// </param>
            /// <param name='take'>
            /// The number of entries to return. Maximum page size is 500. Default is 100.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetApplicationVersionsAsync(this IVersions operations, string appId, int? skip = 0, int? take = 100, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetApplicationVersionsWithHttpMessagesAsync(appId, skip, take, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets the task info.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetApplicationVersionAsync(this IVersions operations, string appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetApplicationVersionWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Updates the name or description of the application version.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='taskUpdateObject'>
            /// A JSON object containing Name and Description of the application.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RenameApplicationVersionAsync(this IVersions operations, string appId, string versionId, TaskUpdateObject taskUpdateObject = default(TaskUpdateObject), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.RenameApplicationVersionWithHttpMessagesAsync(appId, versionId, taskUpdateObject, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Deletes an application version.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteApplicationVersionAsync(this IVersions operations, string appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteApplicationVersionWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Exports a LUIS application to JSON format.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ExportApplicationVersionAsync(this IVersions operations, string appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ExportApplicationVersionWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets the given application version's subscription key.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetApplicationVersionSubscriptionKeyAsync(this IVersions operations, string appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetApplicationVersionSubscriptionKeyWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Assigns a subscription key to the given application version.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='keyValue'>
            /// The value of the endpoint key to assign to the application.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AssignSubscriptionKeyToVersionAsync(this IVersions operations, string appId, string versionId, string keyValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.AssignSubscriptionKeyToVersionWithHttpMessagesAsync(appId, versionId, keyValue, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Assigns an external API key to the given application according to the
            /// specified key type.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='externalKeyUpdateObject'>
            /// The external api key to be assigned.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateApplicationVersionExternalKeyAsync(this IVersions operations, string appId, string versionId, ExternalKeyUpdateObject externalKeyUpdateObject = default(ExternalKeyUpdateObject), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.UpdateApplicationVersionExternalKeyWithHttpMessagesAsync(appId, versionId, externalKeyUpdateObject, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets the given application versions's external keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetApplicationVersionExternalApiKeysAsync(this IVersions operations, string appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetApplicationVersionExternalApiKeysWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Deletes an external API key currently associated to the given application
            /// according for the specified key type.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='keyType'>
            /// The external key type.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteApplicationVersionExternalKeyAsync(this IVersions operations, string appId, string versionId, string keyType, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteApplicationVersionExternalKeyWithHttpMessagesAsync(appId, versionId, keyType, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Imports a new version into a LUIS application, the version's JSON should be
            /// included in in the request body.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The imported versionId.
            /// </param>
            /// <param name='jSONApp'>
            /// A JSON representing the LUIS application structure.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ImportVersionToApplicationAsync(this IVersions operations, string appId, string versionId = default(string), JSONApp jSONApp = default(JSONApp), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ImportVersionToApplicationWithHttpMessagesAsync(appId, versionId, jSONApp, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Deleted an unlabelled utterance.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID of the task.
            /// </param>
            /// <param name='body'>
            /// The utterance text to delete
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteUnlabelledUtteranceAsync(this IVersions operations, string appId, string versionId, object body = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteUnlabelledUtteranceWithHttpMessagesAsync(appId, versionId, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}

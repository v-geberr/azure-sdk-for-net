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
    /// Extension methods for Permissions.
    /// </summary>
    public static partial class PermissionsExtensions
    {
            /// <summary>
            /// Gets the list of user emails that have permissions to access your
            /// application.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<UserAccessList> GetApplicationUserAccessListAsync(this IPermissions operations, string appId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetApplicationUserAccessListWithHttpMessagesAsync(appId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Adds a user to the allowed list of users to access this LUIS
            /// application.Users are added using their email address.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='body'>
            /// A JSON object containing the user's email address.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AddUserToAccessListAsync(this IPermissions operations, string appId, object body = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.AddUserToAccessListWithHttpMessagesAsync(appId, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Removed a user to the allowed list of users to access this LUIS
            /// application.Users are removed using their email address.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='body'>
            /// A JSON object containing the user's email address.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RemoveUserFromAccessListAsync(this IPermissions operations, string appId, object body = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.RemoveUserFromAccessListWithHttpMessagesAsync(appId, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Replaces the current users access list with the one sent in the body.If an
            /// empty list is sent, all access to other users will be removed.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// Format - guid. The application ID.
            /// </param>
            /// <param name='body'>
            /// A JSON object containing a list of user's email addresses.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateAccessListAsync(this IPermissions operations, string appId, object body = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.UpdateAccessListWithHttpMessagesAsync(appId, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}

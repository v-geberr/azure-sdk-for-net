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
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Train.
    /// </summary>
    public static partial class TrainExtensions
    {
            /// <summary>
            /// Sends a training request for a version of a specified LUIS app. This POST
            /// request initiates a request asynchronously. To determine whether the
            /// training request is successful, submit a GET request to get training
            /// status. Note: The application version is not fully trained unless all the
            /// models (intents and entities) are trained successfully or are up to date.
            /// To verify training success, get the training status at least once after
            /// training is complete.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EnqueueTrainingResponse> TrainApplicationVersionAsync(this ITrain operations, System.Guid appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.TrainApplicationVersionWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the training status of all models (intents and entities) for the
            /// specified LUIS app. You must call the train API to train the LUIS app
            /// before you call this API to get training status. "appID" specifies the LUIS
            /// app ID. "versionId" specifies the version number of the LUIS app. For
            /// example, "0.1".
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='appId'>
            /// The application ID.
            /// </param>
            /// <param name='versionId'>
            /// The version ID.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ModelTrainingInfo>> GetApplicationVersionTrainingStatusAsync(this ITrain operations, System.Guid appId, string versionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetApplicationVersionTrainingStatusWithHttpMessagesAsync(appId, versionId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}

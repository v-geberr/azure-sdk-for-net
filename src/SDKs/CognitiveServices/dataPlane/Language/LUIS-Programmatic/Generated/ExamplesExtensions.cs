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
    /// Extension methods for Examples.
    /// </summary>
    public static partial class ExamplesExtensions
    {
            /// <summary>
            /// Adds a labeled example to the application.
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
            /// <param name='exampleLabelObject'>
            /// An example label with the expected intent and entities.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LabelExampleResponse> AddAsync(this IExamples operations, System.Guid appId, string versionId, ExampleLabelObject exampleLabelObject, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.AddWithHttpMessagesAsync(appId, versionId, exampleLabelObject, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Adds a batch of labeled examples to the application.
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
            /// <param name='exampleLabelObjectArray'>
            /// Array of examples.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<BatchLabelExample>> BatchAsync(this IExamples operations, System.Guid appId, string versionId, IList<ExampleLabelObject> exampleLabelObjectArray, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BatchWithHttpMessagesAsync(appId, versionId, exampleLabelObjectArray, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns examples to be reviewed.
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
            /// <param name='skip'>
            /// The number of entries to skip. Default value is 0.
            /// </param>
            /// <param name='take'>
            /// The number of entries to return. Maximum page size is 500. Default is 100.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<LabeledUtterance>> ListAsync(this IExamples operations, System.Guid appId, string versionId, int? skip = 0, int? take = 100, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(appId, versionId, skip, take, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the labeled example with the specified ID.
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
            /// <param name='exampleId'>
            /// The example ID.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IExamples operations, System.Guid appId, string versionId, int exampleId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(appId, versionId, exampleId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}

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
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Features operations.
    /// </summary>
    public partial interface IFeatures
    {
        /// <summary>
        /// Creates a new pattern feature.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='patternCreateObject'>
        /// The Name and Pattern of the feature.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<int?>> CreatePatternFeatureWithHttpMessagesAsync(System.Guid appId, string versionId, PatternCreateObject patternCreateObject, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all application version pattern features.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='skip'>
        /// The number of entries to skip. Default value is 0.
        /// </param>
        /// <param name='take'>
        /// The number of entries to return. Maximum page size is 500. Default
        /// is 100.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<IList<PatternFeatureInfo>>> GetApplicationVersionPatternFeaturesWithHttpMessagesAsync(System.Guid appId, string versionId, int? skip = 0, int? take = 100, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates a new phraselist feature.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='phraselistCreateObject'>
        /// A Phraselist object containing Name, comma-separated Phrases and
        /// the isExchangeable boolean. Default value for isExchangeable is
        /// true.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<int?>> CreatePhraselistFeatureWithHttpMessagesAsync(System.Guid appId, string versionId, PhraselistCreateObject phraselistCreateObject, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets phraselist features.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='skip'>
        /// The number of entries to skip. Default value is 0.
        /// </param>
        /// <param name='take'>
        /// The number of entries to return. Maximum page size is 500. Default
        /// is 100.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<IList<PhraseListFeatureInfo>>> GetApplicationVersionPhraselistFeaturesWithHttpMessagesAsync(System.Guid appId, string versionId, int? skip = 0, int? take = 100, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all application version features.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='skip'>
        /// The number of entries to skip. Default value is 0.
        /// </param>
        /// <param name='take'>
        /// The number of entries to return. Maximum page size is 500. Default
        /// is 100.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<FeaturesResponseObject>> GetApplicationVersionFeaturesWithHttpMessagesAsync(System.Guid appId, string versionId, int? skip = 0, int? take = 100, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets pattern feature info.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='patternId'>
        /// The pattern feature ID.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<PatternFeatureInfo>> GetPatternFeatureInfoWithHttpMessagesAsync(System.Guid appId, string versionId, int patternId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the pattern, the name and the state of the pattern feature.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='patternId'>
        /// The pattern feature ID.
        /// </param>
        /// <param name='patternUpdateObject'>
        /// The new values for: - Just a boolean called IsActive, in which case
        /// the status of the feature will be changed. - Name, Pattern and a
        /// boolean called IsActive to update the feature.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> UpdatePatternFeatureWithHttpMessagesAsync(System.Guid appId, string versionId, int patternId, PatternUpdateObject patternUpdateObject, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a pattern feature from an application version.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='patternId'>
        /// The pattern feature ID.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> DeletePatternFeatureWithHttpMessagesAsync(System.Guid appId, string versionId, int patternId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets phraselist feature info.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='phraselistId'>
        /// The ID of the feature to be retrieved.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<PhraseListFeatureInfo>> GetPhraselistFeatureInfoWithHttpMessagesAsync(System.Guid appId, string versionId, int phraselistId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the phrases, the state and the name of the phraselist
        /// feature.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='phraselistId'>
        /// The ID of the feature to be updated.
        /// </param>
        /// <param name='phraselistUpdateObject'>
        /// A PhraselistUpdateObject object containing either: - Just a boolean
        /// called IsActive, in which case the status of the feature will be
        /// changed. - Name, Pattern, Mode, and a boolean called IsActive to
        /// update the feature.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> UpdatePhraselistFeatureWithHttpMessagesAsync(System.Guid appId, string versionId, int phraselistId, PhraselistUpdateObject phraselistUpdateObject = default(PhraselistUpdateObject), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a phraselist feature from an application.
        /// </summary>
        /// <param name='appId'>
        /// Format - guid. The application ID.
        /// </param>
        /// <param name='versionId'>
        /// The version ID of the task.
        /// </param>
        /// <param name='phraselistId'>
        /// The ID of the feature to be deleted.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> DeletePhraselistFeatureWithHttpMessagesAsync(System.Guid appId, string versionId, int phraselistId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

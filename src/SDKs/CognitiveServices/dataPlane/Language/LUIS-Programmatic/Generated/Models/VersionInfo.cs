// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class VersionInfo
    {
        /// <summary>
        /// Initializes a new instance of the VersionInfo class.
        /// </summary>
        public VersionInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VersionInfo class.
        /// </summary>
        /// <param name="trainingStatus">Possible values include:
        /// 'NeedsTraining', 'InProgress', 'Trained'</param>
        public VersionInfo(string version, TrainingStatus trainingStatus, System.DateTime? createdDateTime = default(System.DateTime?), System.DateTime? lastModifiedDateTime = default(System.DateTime?), System.DateTime? lastTrainedDateTime = default(System.DateTime?), System.DateTime? lastPublishedDateTime = default(System.DateTime?), string endpointUrl = default(string), IDictionary<string, string> assignedEndpointKey = default(IDictionary<string, string>), int? intentsCount = default(int?), int? entitiesCount = default(int?), int? endpointHitsCount = default(int?))
        {
            Version = version;
            CreatedDateTime = createdDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            LastTrainedDateTime = lastTrainedDateTime;
            LastPublishedDateTime = lastPublishedDateTime;
            EndpointUrl = endpointUrl;
            AssignedEndpointKey = assignedEndpointKey;
            IntentsCount = intentsCount;
            EntitiesCount = entitiesCount;
            EndpointHitsCount = endpointHitsCount;
            TrainingStatus = trainingStatus;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastTrainedDateTime")]
        public System.DateTime? LastTrainedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastPublishedDateTime")]
        public System.DateTime? LastPublishedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpointUrl")]
        public string EndpointUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assignedEndpointKey")]
        public IDictionary<string, string> AssignedEndpointKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "intentsCount")]
        public int? IntentsCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entitiesCount")]
        public int? EntitiesCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpointHitsCount")]
        public int? EndpointHitsCount { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'NeedsTraining',
        /// 'InProgress', 'Trained'
        /// </summary>
        [JsonProperty(PropertyName = "trainingStatus")]
        public TrainingStatus TrainingStatus { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Version == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Version");
            }
        }
    }
}

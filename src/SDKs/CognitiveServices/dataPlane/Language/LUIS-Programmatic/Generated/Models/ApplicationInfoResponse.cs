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
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ApplicationInfoResponse
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationInfoResponse class.
        /// </summary>
        public ApplicationInfoResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationInfoResponse class.
        /// </summary>
        /// <param name="id">The GUID of the application.</param>
        public ApplicationInfoResponse(System.Guid? id = default(System.Guid?), string name = default(string), string description = default(string), string culture = default(string), string usageScenario = default(string), string domain = default(string), int? versionsCount = default(int?), string createdDateTime = default(string), object endpoints = default(object), int? endpointHitsCount = default(int?), string activeVersion = default(string))
        {
            Id = id;
            Name = name;
            Description = description;
            Culture = culture;
            UsageScenario = usageScenario;
            Domain = domain;
            VersionsCount = versionsCount;
            CreatedDateTime = createdDateTime;
            Endpoints = endpoints;
            EndpointHitsCount = endpointHitsCount;
            ActiveVersion = activeVersion;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the GUID of the application.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "culture")]
        public string Culture { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "usageScenario")]
        public string UsageScenario { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionsCount")]
        public int? VersionsCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public string CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpoints")]
        public object Endpoints { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpointHitsCount")]
        public int? EndpointHitsCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activeVersion")]
        public string ActiveVersion { get; set; }

    }
}

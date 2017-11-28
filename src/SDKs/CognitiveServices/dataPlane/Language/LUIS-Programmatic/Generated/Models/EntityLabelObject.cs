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

    public partial class EntityLabelObject
    {
        /// <summary>
        /// Initializes a new instance of the EntityLabelObject class.
        /// </summary>
        public EntityLabelObject()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EntityLabelObject class.
        /// </summary>
        public EntityLabelObject(string entityName = default(string), int? startCharIndex = default(int?), int? endCharIndex = default(int?))
        {
            EntityName = entityName;
            StartCharIndex = startCharIndex;
            EndCharIndex = endCharIndex;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EntityName")]
        public string EntityName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StartCharIndex")]
        public int? StartCharIndex { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EndCharIndex")]
        public int? EndCharIndex { get; set; }

    }
}

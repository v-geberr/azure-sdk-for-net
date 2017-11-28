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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ExampleLabelObject
    {
        /// <summary>
        /// Initializes a new instance of the ExampleLabelObject class.
        /// </summary>
        public ExampleLabelObject()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ExampleLabelObject class.
        /// </summary>
        public ExampleLabelObject(string text = default(string), IList<EntityLabelObject> entityLabels = default(IList<EntityLabelObject>), string intentName = default(string))
        {
            Text = text;
            EntityLabels = entityLabels;
            IntentName = intentName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EntityLabels")]
        public IList<EntityLabelObject> EntityLabels { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IntentName")]
        public string IntentName { get; set; }

    }
}

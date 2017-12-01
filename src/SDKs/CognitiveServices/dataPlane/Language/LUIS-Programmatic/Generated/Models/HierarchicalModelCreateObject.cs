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

    public partial class HierarchicalModelCreateObject
    {
        /// <summary>
        /// Initializes a new instance of the HierarchicalModelCreateObject
        /// class.
        /// </summary>
        public HierarchicalModelCreateObject()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HierarchicalModelCreateObject
        /// class.
        /// </summary>
        public HierarchicalModelCreateObject(IList<string> children = default(IList<string>), string name = default(string))
        {
            Children = children;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public IList<string> Children { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}

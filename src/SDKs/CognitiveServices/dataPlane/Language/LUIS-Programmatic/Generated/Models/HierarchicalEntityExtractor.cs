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

    public partial class HierarchicalEntityExtractor : ModelInfo
    {
        /// <summary>
        /// Initializes a new instance of the HierarchicalEntityExtractor
        /// class.
        /// </summary>
        public HierarchicalEntityExtractor()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HierarchicalEntityExtractor
        /// class.
        /// </summary>
        /// <param name="readableType">Possible values include: 'Entity
        /// Extractor', 'Hierarchical Entity Extractor', 'Hierarchical Child
        /// Entity Extractor', 'Composite Entity Extractor', 'Closed List
        /// Entity Extractor', 'Prebuilt Entity Extractor', 'Intent
        /// Classifier'</param>
        /// <param name="id">The GUID of the Entity Model.</param>
        /// <param name="name">Name of the Entity Model.</param>
        /// <param name="typeId">The type ID of the Entity Model.</param>
        public HierarchicalEntityExtractor(string readableType, string id = default(string), string name = default(string), double? typeId = default(double?), IList<ChildEntity> children = default(IList<ChildEntity>))
            : base(readableType, id, name, typeId)
        {
            Children = children;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public IList<ChildEntity> Children { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}

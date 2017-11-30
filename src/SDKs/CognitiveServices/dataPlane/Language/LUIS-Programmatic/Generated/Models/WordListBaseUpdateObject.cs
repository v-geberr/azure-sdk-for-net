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

    public partial class WordListBaseUpdateObject
    {
        /// <summary>
        /// Initializes a new instance of the WordListBaseUpdateObject class.
        /// </summary>
        public WordListBaseUpdateObject()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WordListBaseUpdateObject class.
        /// </summary>
        public WordListBaseUpdateObject(string canonicalForm = default(string), IList<string> list = default(IList<string>))
        {
            CanonicalForm = canonicalForm;
            List = list;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "canonicalForm")]
        public string CanonicalForm { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public IList<string> List { get; set; }

    }
}

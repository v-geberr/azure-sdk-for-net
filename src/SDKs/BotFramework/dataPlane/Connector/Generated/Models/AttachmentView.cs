// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.BotFramework.Connector.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Attachment View name and size
    /// </summary>
    public partial class AttachmentView
    {
        /// <summary>
        /// Initializes a new instance of the AttachmentView class.
        /// </summary>
        public AttachmentView()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AttachmentView class.
        /// </summary>
        /// <param name="viewId">content type of the attachmnet</param>
        /// <param name="size">Name of the attachment</param>
        public AttachmentView(string viewId = default(string), int? size = default(int?))
        {
            ViewId = viewId;
            Size = size;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets content type of the attachmnet
        /// </summary>
        [JsonProperty(PropertyName = "viewId")]
        public string ViewId { get; set; }

        /// <summary>
        /// Gets or sets name of the attachment
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int? Size { get; set; }

    }
}

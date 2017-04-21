// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation.Models
{
    /// <summary>
    /// Definition of the content link.
    /// </summary>
    public partial class ContentLink
    {
        private ContentHash _contentHash;
        
        /// <summary>
        /// Optional. Gets or sets the hash.
        /// </summary>
        public ContentHash ContentHash
        {
            get { return this._contentHash; }
            set { this._contentHash = value; }
        }
        
        private Uri _uri;
        
        /// <summary>
        /// Optional. Gets or sets the uri of the runbook content.
        /// </summary>
        public Uri Uri
        {
            get { return this._uri; }
            set { this._uri = value; }
        }
        
        private string _version;
        
        /// <summary>
        /// Optional. Gets or sets the version of the content.
        /// </summary>
        public string Version
        {
            get { return this._version; }
            set { this._version = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ContentLink class.
        /// </summary>
        public ContentLink()
        {
        }
    }
}

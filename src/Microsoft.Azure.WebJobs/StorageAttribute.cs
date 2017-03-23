// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Base class for all Azure Storage binding attributes.
    /// </summary>
    public abstract class StorageAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the Azure Storage connection string to use.
        /// </summary>
        public string Account { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Office.Users
{
    /// <summary>
    /// User
    /// </summary>
    public class OfficeUser
    {
        /// <summary>
        /// Office
        /// </summary>
        public string Office { get; internal set; }

        /// <summary>
        /// Name
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; internal set; }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace DependencyInjection.Scopes
{
    public class CommonIdProvider : IGlobalIdProvider
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}

﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Scopes
{
    public class MyServiceB
    {
        public MyServiceB(ICommonIdProvider idProvider)
        {
            IdProvider = idProvider;
        }

        public ICommonIdProvider IdProvider { get; }
    }
}

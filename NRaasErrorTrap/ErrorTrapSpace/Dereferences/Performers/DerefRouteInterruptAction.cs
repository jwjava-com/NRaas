﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Routing;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefRouteInterruptAction : Dereference<RouteInterruptAction>
    {
        protected override DereferenceResult Perform(RouteInterruptAction reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mRoutingSim", field, objects))
            {
                Remove(ref reference.mRoutingSim);
                return DereferenceResult.Continue;
            }

            return DereferenceResult.Failure;
        }
    }
}

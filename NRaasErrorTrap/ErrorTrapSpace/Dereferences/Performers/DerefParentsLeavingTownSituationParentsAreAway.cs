﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefParentsLeavingTownSituationParentsAreAway : Dereference<ParentsLeavingTownSituation.ParentsAreAway>
    {
        protected override DereferenceResult Perform(ParentsLeavingTownSituation.ParentsAreAway reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            DereferenceResult reason = MatchAndRemove(reference, "mOnOwnerDyingButStillSelectableListener", field, ref reference.mOnOwnerDyingButStillSelectableListener, objects, DereferenceResult.End);
            if (reason != DereferenceResult.Failure)
            {
                return reason;
            }

            return DereferenceResult.Failure;
        }
    }
}

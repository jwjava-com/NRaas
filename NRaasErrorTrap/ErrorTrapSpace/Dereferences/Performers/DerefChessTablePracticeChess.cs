﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.HobbiesSkills;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class ChessTablePracticeChess : Dereference<ChessTable.PracticeChess>
    {
        protected override DereferenceResult Perform(ChessTable.PracticeChess reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mChessPiece", field, objects))
            {
                //Remove(ref reference.mChessPiece);
                return DereferenceResult.Continue;
            }

            return DereferenceResult.Failure;
        }
    }
}

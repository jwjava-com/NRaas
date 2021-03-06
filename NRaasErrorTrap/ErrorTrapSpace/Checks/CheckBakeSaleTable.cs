﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using NRaas.CommonSpace.Tasks;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.Miscellaneous;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Checks
{
    public class CheckBakeSaleTable : Check<BakeSaleTable>
    {
        protected override bool PrePerform(BakeSaleTable table, bool postLoad)
        {
            if (BakeSaleTable.Simulation.DemandTable.Count < 3)
            {
                BakeSaleTable.Simulation.UpdateBakedGoodsDemand();
            }

            return true;
        }
    }
}

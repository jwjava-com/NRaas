﻿using NRaas.CommonSpace.Options;
using NRaas.OverwatchSpace.Interfaces;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.OverwatchSpace.Settings
{
    public class ReportFirstResetCheck : BooleanOption
    {
        public override string GetTitlePrefix()
        {
            return "ReportFirstResetCheck";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return new NRaas.OverwatchSpace.Settings.ListingOption(); }
        }

        protected override bool Allow(GameHitParameters<GameObject> parameters)
        {
            if (!Overwatch.Settings.mResetCheck) return false;

            return base.Allow(parameters);
        }

        protected override bool Value
        {
            get
            {
                return NRaas.Overwatch.Settings.mReportFirstResetCheck;
            }
            set
            {
                NRaas.Overwatch.Settings.mReportFirstResetCheck = value;
            }
        }
    }
}

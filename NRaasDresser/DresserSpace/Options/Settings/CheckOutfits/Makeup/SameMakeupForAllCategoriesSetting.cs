﻿using NRaas.CommonSpace.Options;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.DresserSpace.Options.Settings.CheckOutfits.Makeup
{
    public class SameMakeupForAllCategoriesSetting : BooleanSettingOption<GameObject>, IMakeupOption
    {
        protected override bool Value
        {
            get
            {
                return Dresser.Settings.mSameMakeupForAllCategories;
            }
            set
            {
                Dresser.Settings.mSameMakeupForAllCategories = value;
            }
        }

        public override string GetTitlePrefix()
        {
            return "SameMakeupForAllCategories";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return new ListingOption(); }
        }
    }
}

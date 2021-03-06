﻿using NRaas.CommonSpace.Options;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.RegisterSpace.Options.Service
{
    public class CostSetting : IntegerSettingOption<GameObject>, IServiceOption
    {
        Sims3.Gameplay.Services.Service mData;

        public CostSetting(Sims3.Gameplay.Services.Service data)
        {
            mData = data;
        }

        protected override int Value
        {
            get
            {
                if (mData == null) return 0;

                return Register.Settings.GetSettingsForService(mData).cost;
            }
            set
            {
                ServiceSettingKey key = Register.Settings.GetSettingsForService(mData);
                key.cost = value;
                key.SetSettings(mData);
            }
        }

        public override string GetTitlePrefix()
        {
            return "ServiceCost";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return null; }
        }
    }
}

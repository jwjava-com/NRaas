﻿using NRaas.CommonSpace.Options;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.DresserSpace.Options.Settings.CheckOutfits.Accessories
{
    public class ListingOption : InteractionOptionList<IAccessoriesOption, GameObject>, ICheckOutfitsOption
    {
        public override string GetTitlePrefix()
        {
            return "Accessories";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return null; }
        }
    }
}

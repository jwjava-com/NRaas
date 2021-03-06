﻿using NRaas.MasterControllerSpace.Helpers;
using NRaas.MasterControllerSpace.SelectionCriteria;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.MasterControllerSpace.Sims.Basic.Baby
{
    public class BabySeed : SimFromList, IBabyOption
    {
        public override string GetTitlePrefix()
        {
            return "BabyGenSeed";
        }

        protected override int GetMaxSelection()
        {
            return 0;
        }

        protected override bool CanApplyAll()
        {
            return true;
        }

        protected override bool PrivateAllow(SimDescription me)
        {
            if (!base.PrivateAllow(me)) return false;

            return (me.Pregnancy != null);
        }

        protected override bool Run(SimDescription me, bool singleSelection)
        {
            if (!ApplyAll)
            {
                if (!AcceptCancelDialog.Show(Common.Localize(GetTitlePrefix() + ":Prompt", me.IsFemale, new object[] { me })))
                {
                    return false;
                }
            }

            if (me.Pregnancy != null)
            {
                me.Pregnancy.mRandomGenSeed = RandomUtil.GetInt(0x7fffffff);
            }

            return true;
        }
    }
}

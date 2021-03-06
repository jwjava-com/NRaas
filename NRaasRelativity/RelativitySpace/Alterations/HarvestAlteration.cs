﻿using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems.Children;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects.ChildrenObjects;
using Sims3.Gameplay.Objects.Gardening;
using Sims3.Gameplay.Objects.HobbiesSkills;
using Sims3.Gameplay.Objects.Plumbing;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using Sims3.UI.CAS;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.RelativitySpace.Alterations
{
    public class HarvestAlteration : IAlteration
    {
        float mMinTime;
        float mMaxTime;

        float mFactor;

        public HarvestAlteration(float factor)
        {
            mFactor = factor;
        }

        public void Store()
        {
            mMinTime = HarvestPlant.kHarvestInteractionTuning.kTimeMin;
            mMaxTime = HarvestPlant.kHarvestInteractionTuning.kTimeMax;

            HarvestPlant.kHarvestInteractionTuning.kTimeMin = Alteration.AdjustToMinimum(HarvestPlant.kHarvestInteractionTuning.kTimeMin * mFactor, Alteration.sDefaultMinimum);
            HarvestPlant.kHarvestInteractionTuning.kTimeMax = Alteration.AdjustToMinimum(HarvestPlant.kHarvestInteractionTuning.kTimeMax * mFactor, Alteration.sDefaultMinimum);
        }

        public void Revert()
        {
            HarvestPlant.kHarvestInteractionTuning.kTimeMin = mMinTime;
            HarvestPlant.kHarvestInteractionTuning.kTimeMax = mMaxTime;
        }
    }
}

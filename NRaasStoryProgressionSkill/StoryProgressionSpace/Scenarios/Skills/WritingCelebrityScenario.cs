﻿using NRaas.CommonSpace.Scoring;
using NRaas.CommonSpace.ScoringMethods;
using NRaas.StoryProgressionSpace.Careers;
using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using NRaas.StoryProgressionSpace.Scenarios.Friends;
using NRaas.StoryProgressionSpace.Situations;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.CelebritySystem;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Objects.Electronics;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using Sims3.UI.Hud;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.StoryProgressionSpace.Scenarios.Skills
{
    public class WritingCelebrityScenario : SimEventScenario<IncrementalEvent>
    {
        public WritingCelebrityScenario()
        { }
        protected WritingCelebrityScenario(WritingCelebrityScenario scenario)
            : base (scenario)
        { }

        public override string GetTitlePrefix(PrefixType type)
        {
            if (type != PrefixType.Pure) return null;

            return "WritingCelebrity";
        }

        protected override bool Progressed
        {
            get { return true; }
        }

        protected override bool AllowActive
        {
            get { return true; }
        }

        public override bool SetupListener(IEventHandler events)
        {
            return events.AddListener(this, EventTypeId.kWroteBookWithRoyaltyAmount);
        }

        protected override bool Allow()
        {
            if (!GetValue<Option,bool>()) return false;

            return base.Allow();
        }

        protected override bool Allow(SimDescription sim)
        {
            if (!Friends.AllowCelebrity(this, sim))
            {
                IncStat("User Denied");
                return false;
            }

            return base.Allow(sim);
        }

        protected override bool PrivateUpdate(ScenarioFrame frame)
        {
            Friends.AccumulateCelebrity(Sim, (int)Event.Increment / 10);
            return true;
        }

        public override Scenario Clone()
        {
            return new WritingCelebrityScenario(this);
        }

        public class Option : BooleanEventOptionItem<ManagerSkill, WritingCelebrityScenario>, IDebuggingOption
        {
            public Option()
                : base(true)
            { }

            public override string GetTitlePrefix()
            {
                return "WritingCelebrity";
            }
        }
    }
}

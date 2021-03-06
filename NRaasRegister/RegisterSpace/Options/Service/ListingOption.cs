﻿using NRaas.CommonSpace.Options;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.MapTags;
using Sims3.Gameplay.Objects.Decorations;
using Sims3.Gameplay.Objects.HobbiesSkills;
using Sims3.Gameplay.Objects.RabbitHoles;
using Sims3.Gameplay.Services;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.RetunerSpace.Options.Socials
{
    public class ListingOption : InteractionOptionList<ServiceListingOption, GameObject>, IPrimaryOption<GameObject>
    {
        public ListingOption()
        { }

        public override string GetTitlePrefix()
        {
            return "ServiceRoot";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return null; }
        }

        public override List<ServiceListingOption> GetOptions()
        {
            List<ServiceListingOption> results = new List<ServiceListingOption>();            

            foreach (Service data in Services.AllServices)
            {
                ServiceNPCSpecifications.ServiceSpecifications specs;
                if (ServiceNPCSpecifications.sServiceSpecifications.TryGetValue(data.ServiceType.ToString(), out specs))
                {
                    if (GameUtils.IsInstalled(specs.Version) && data.ServiceType != ServiceType.TimeTraveler)
                    {
                        ServiceListingOption option = new ServiceListingOption(data);
                        results.Add(option);
                    }
                }
            }

            return results;
        }
    }
}
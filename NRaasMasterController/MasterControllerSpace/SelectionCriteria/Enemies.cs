﻿using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using Sims3.UI.CAS;
using Sims3.UI.Hud;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.MasterControllerSpace.SelectionCriteria
{
    public class Enemies : SelectionTestableOptionList<Enemies.Item, int, int>
    {
        public override string GetTitlePrefix()
        {
            return "Criteria.Enemies";
        }

        public class Item : TestableOption<int, int>
        {
            public override bool Get(SimDescription me, IMiniSimDescription actor, Dictionary<int,int> results)
            {
                try
                {
                    int count = 0;
                    foreach (Relationship relation in Relationship.Get(me))
                    {
                        if ((relation.CurrentLTRLiking < -75) || (relation.AreEnemies()))
                        {
                            count++;
                        }
                    }

                    results[count] = count;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public override bool Get(MiniSimDescription me, IMiniSimDescription actor, Dictionary<int, int> results)
            {
                try
                {
                    int count = 0;
                    foreach (MiniRelationship relation in me.MiniRelationships)
                    {
                        if ((relation.CurrentLTRLiking < -75) || (relation.AreEnemies()))
                        {
                            count++;
                        }
                    }

                    results[count] = count;
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public override void SetValue(int value, int storeType)
            {
                mValue = value;

                mName = EAText.GetNumberString(value);
            }
        }
    }
}

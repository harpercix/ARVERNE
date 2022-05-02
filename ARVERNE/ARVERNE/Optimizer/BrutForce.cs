using System;
using System.Collections.Generic;
using ARVERNE.Parts;
using ARVERNE.Stages;

namespace ARVERNE.Optimizer
{
    public class BrutForce
    {
        private static void CreatCrafts(int NbStage, int DVNeeded, ref Craft bestCraft,
            Dictionary<string, Part[]> parts, Craft craft)
        {
            if (craft.CalculTotalDV() > DVNeeded)
            {
                if (bestCraft is null)
                {
                    bestCraft = craft;
                    bestCraft.CalculMass();
                }
                else if (craft.CalculMass() < bestCraft.TotalMass)
                {
                    bestCraft = craft;
                }
                return;
            }

            for (int i = 0; i < craft.Stages.Count; i++)
            {
                Craft newCraft = craft.Clone();
                newCraft.Stages[i].Tanks.Add((OxFuelPart) parts["OxFuel"][0]);
                newCraft.CalculTotalDV();
                CreatCrafts(NbStage, DVNeeded, ref bestCraft, parts, newCraft);
            }
        }

        public static Craft BrutForcer(int DVNeeded, Dictionary<string, Part[]> parts, int NbStageMax, 
            int payloadMass)
        {
            Craft bestCraft = null;
            for (int i = 1; i < NbStageMax; i++)
            {
                Craft craft = new Craft(new List<Stage>(), payloadMass);
                for (int j = 0; j < i; j++)
                {
                    craft.Stages.Add(new Stage(new List<OxFuelPart>(), (EnginePart) parts["Engine"][0].Clone(),
                        (InlineDecouplerPart) parts["Decoupler"][0].Clone(), 0));
                }
                
                CreatCrafts(i, DVNeeded, ref bestCraft, parts, craft);
            }

            return bestCraft;
        }

    }
}
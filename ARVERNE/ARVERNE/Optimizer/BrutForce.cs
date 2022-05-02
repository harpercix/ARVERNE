using System;
using System.Collections.Generic;
using ARVERNE.Parts;
using ARVERNE.Stages;

namespace ARVERNE.Optimizer
{
    public class BrutForce
    {
        private static void CreatCrafts(int NbStage, int DVNeeded, List<Craft> crafts,
            Dictionary<string, Part[]> parts, Craft craft)
        {
            if (craft.CalculTotalDV() > DVNeeded)
            {
                crafts.Add(craft);
                return;
            }

            for (int i = 0; i < craft.Stages.Count; i++)
            {
                Craft newCraft = craft.Clone();
                newCraft.Stages[i].Tanks.Add((OxFuelPart) parts["OxFuel"][0]);
                newCraft.CalculTotalDV();
                CreatCrafts(NbStage, DVNeeded, crafts, parts, newCraft);
            }
        }

        private static List<Craft> BrutForcer(int DVNeeded, Dictionary<string, Part[]> parts, int NbStageMax, 
            int payloadMass)
        {
            List<Craft> crafts = new List<Craft>();
            for (int i = 1; i < NbStageMax; i++)
            {
                Craft craft = new Craft(new List<Stage>(), payloadMass);
                for (int j = 0; j < i; j++)
                {
                    craft.Stages.Add(new Stage(new List<OxFuelPart>(), (EnginePart) parts["Engine"][0].Clone(),
                        (InlineDecouplerPart) parts["Decoupler"][0].Clone(), 0));
                }

                CreatCrafts(i, DVNeeded, crafts, parts, craft);
            }

            return crafts;
        }

        public static Craft BrutForcerMain(int DVNeeded, Dictionary<string, Part[]> parts, int NbStageMax,
            int payloadMass)
        {
            List<Craft> crafts = BrutForcer(DVNeeded, parts, NbStageMax, payloadMass);
            Craft bestCraft = crafts[0];
            int mass = bestCraft.CalculMass();
            for (int i = 1; i < crafts.Count; i++)
            {
                Console.WriteLine(crafts[i].Print());
                if (crafts[i].CalculMass() < mass)
                {
                    bestCraft = crafts[i];
                    mass = bestCraft.TotalMass;
                }
            }

            return bestCraft;
        }
    }
}
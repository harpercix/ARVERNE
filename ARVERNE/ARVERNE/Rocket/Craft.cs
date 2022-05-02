using System;
using System.Collections.Generic;

namespace ARVERNE.Stages
{
    public class Craft
    {
        private List<Stage> stages;
        private double totalDV;
        private int payloadMass;
        private int totalMass;

        public List<Stage> Stages => stages;
        public int TotalMass => totalMass;

        public Craft(List<Stage> stages, int payloadMass)
        {
            this.stages = stages;
            this.payloadMass = payloadMass;
            CalculTotalDV();
        }

        public double CalculTotalDV()
        {
            CalculMass();
            totalDV = 0;
            foreach (Stage stage in stages)
            {
                totalDV += stage.DV;
            }

            return totalDV;
        }

        public int CalculMass()
        {
            if (stages.Count > 0)
            {
                stages[^1].CalculMass();
                stages[^1].PayloadMass = payloadMass;
                for (int i = stages.Count - 2; i >= 0; i--)
                {
                    stages[i].PayloadMass = stages[i + 1].WetMass + stages[i + 1].PayloadMass;
                }

                foreach (Stage stage in stages)
                {
                    stage.CalculMass();
                    totalMass += stage.WetMass;
                }

                totalMass += payloadMass;
            }
            return totalMass;
        }

        public Craft Clone()
        {
            List<Stage> newStages = new List<Stage>();
            foreach (Stage stage in stages)
            {
                newStages.Add(stage.Clone());
            }
            return new Craft(newStages, payloadMass);
        }

        public string Print()
        {
            string v = "";
            v += "TotalDV = " + totalDV.ToString() + "\n";
            v += "TotalMass = " + totalMass.ToString() + "\n";
            v += "PayloadMass = " + payloadMass.ToString() + "\n";
            v += stages.Count + ":\n";
            foreach (Stage stage in stages)
            {
                v += stage.Print(2);
            }

            return v;
        }
    }
}
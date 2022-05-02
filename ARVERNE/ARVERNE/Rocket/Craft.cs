using System.Collections.Generic;

namespace ARVERNE.Stages
{
    public class Craft
    {
        private List<Stage> stages;
        private double totalDV;
        private int payloadMass;

        public List<Stage> Stages => stages;

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

        private void CalculMass()
        {
            Stages[stages.Count - 1].CalculMass();
            Stages[stages.Count - 1].PayloadMass = payloadMass;
            for (int i = stages.Count - 2; i >= 0; i++)
            {
                stages[i].PayloadMass = stages[i + 1].WetMass + stages[i + 1].PayloadMass;
            }
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
    }
}
namespace ARVERNE.Stages
{
    public class Craft
    {
        private Stage[] stages;
        private double totalDV;

        public Craft(Stage[] stages)
        {
            this.stages = stages;
        }

        private void CalculTotalDV()
        {
            totalDV = 0;
            foreach (Stage stage in stages)
            {
                totalDV += stage.DV;
            }
        }
    }
}
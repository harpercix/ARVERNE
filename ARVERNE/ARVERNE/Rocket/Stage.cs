using System;
using ARVERNE.Parts;
using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Stages
{
    public class Stage
    {
        private int oxydizerTotal;
        private int fuelTotal;
        private int wetMass;
        private int dryMass;
        private double dV;
        private double burnTime;
        private int payloadMass; // Or stage above
        private OxFuelPart[] tanks;
        private EnginePart engine;
        private InlineDecouplerPart decoupler;

        public double DV => dV;

        public Stage(OxFuelPart[] tanks, EnginePart engine, InlineDecouplerPart decoupler, int payloadMass)
        {
            this.tanks = tanks;
            this.engine = engine;
            this.decoupler = decoupler;
            this.payloadMass = payloadMass;
            CalculMass();
            CalculDeltaV();
        }
        
        private void CalculDeltaV()
        {
            dV = engine.Isp * Values.gravity * Math.Log(wetMass / dryMass);
        }

        private void CalculMass()
        {
            dryMass = payloadMass;
            wetMass = payloadMass;
            foreach (OxFuelPart tank in tanks)
            {
                dryMass += tank.DryMass;
                wetMass += tank.WetMass;
            }

            dryMass += engine.Mass + decoupler.Mass;
            wetMass += engine.Mass + decoupler.Mass;
        }
    }
}
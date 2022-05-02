using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        private List<OxFuelPart> tanks;
        private EnginePart engine;
        private InlineDecouplerPart decoupler;

        public double DV => dV;
        public int WetMass => wetMass;
        public List<OxFuelPart> Tanks => tanks;

        public int PayloadMass
        {
            get => payloadMass;
            set => payloadMass = value;
        }

        public Stage(List<OxFuelPart> tanks, EnginePart engine, InlineDecouplerPart decoupler, int payloadMass)
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

        public int CalculMass()
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
            return wetMass;
        }

        public Stage Clone()
        {
            List<OxFuelPart> newtanks = new List<OxFuelPart>();
            foreach (OxFuelPart tank in tanks)
            {
                newtanks.Add((OxFuelPart) tank.Clone());
            }
            return new Stage(newtanks, (EnginePart) engine.Clone(), (InlineDecouplerPart) decoupler.Clone(), payloadMass);
        }

        public string Print(int spacing)
        {
            string s = "", v = "";
            for (int i = 0; i < spacing; i++)
            {
                s += " ";
            }

            v += s + dV + "m/s, (" + wetMass + "-" + dryMass + ")\n";
            return v;
        }
    }
}
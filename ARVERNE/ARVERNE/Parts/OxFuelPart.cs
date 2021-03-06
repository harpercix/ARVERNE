using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class OxFuelPart : Part
    {
        private int oxidizer;
        private int fuel;
        private int wetMass;
        private int dryMass;
        private int bottomDiameter;
        private int topDiameter;
        private bool radialJoint;
        public int WetMass => wetMass;
        public int DryMass => dryMass;
        public int Oxidizer => oxidizer;
        public int Fuel => fuel;

        public OxFuelPart(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints, int oxidizer, int fuel, 
            int dryMass) : base(mass, name, radialJoint, inlineJoints)
        {
            this.oxidizer = oxidizer;
            this.fuel = fuel;
            this.wetMass = dryMass + Values.oxydizerDensity*oxidizer + Values.liquidFuelDensity*fuel;
            this.dryMass = dryMass;
            this.radialJoint = radialJoint;
            this.bottomDiameter = bottomDiameter;
            this.topDiameter = topDiameter;
        }
        public OxFuelPart(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints, int oxidizer, int fuel, 
            int wetMass, int dryMass) : base(mass, name, radialJoint, inlineJoints)
        {
            this.oxidizer = oxidizer;
            this.fuel = fuel;
            this.wetMass = wetMass;
            this.dryMass = dryMass;
            this.bottomDiameter = bottomDiameter;
            this.topDiameter = topDiameter;
        }

        public override Part Clone()
        {
            
            return new OxFuelPart(Mass, Name, radialJoint, CopyInlineJoints(), oxidizer, fuel, wetMass, dryMass);
        }
    }
}
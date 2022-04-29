using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class OxFuelPart : Part
    {
        private int oxidizer;
        private int fuel;
        private int emptyMass;
        private int bottomDiameter;
        private int topDiameter;

        public OxFuelPart(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints, int oxidizer, int fuel, 
            int emptyMass, int bottomDiameter, int topDiameter) : base(mass, name, radialJoint, inlineJoints)
        {
            this.oxidizer = oxidizer;
            this.fuel = fuel;
            this.emptyMass = emptyMass;
            this.bottomDiameter = bottomDiameter;
            this.topDiameter = topDiameter;
        }
    }
}
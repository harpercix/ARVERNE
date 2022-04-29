using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class EnginePart: Part
    {
        private int thrust;
        private int isp;
        private float fuelConsumption;
        private int diameter;
        
        public EnginePart(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints, float fuelConsumption,
            int diameter) : 
            base(mass, name, radialJoint, inlineJoints)
        {
            this.fuelConsumption = fuelConsumption;
            this.diameter = diameter;
        }
    }
}
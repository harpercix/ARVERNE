using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class EnginePart: Part
    {
        private int thrust;
        private int isp;
        private double fuelConsumption;
        private int diameter;
        
        public EnginePart(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints, int thrust, int isp,
            double fuelConsumption) : base(mass, name, radialJoint, inlineJoints)
        {
            this.fuelConsumption = fuelConsumption;
            this.thrust = thrust;
            this.isp = isp;
        }
    }
}
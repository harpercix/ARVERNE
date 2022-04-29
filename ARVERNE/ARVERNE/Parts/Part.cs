using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class Part
    {
        private int mass;
        private string name;
        private bool radialJoint;
        private InlineJoint[] inlineJoints;

        public Part(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints)
        {
            this.mass = mass;
            this.name = name;
            this.radialJoint = radialJoint;
            this.inlineJoints = inlineJoints;
        }
    }
}
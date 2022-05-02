using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class Part
    {
        private int mass;
        private string name;
        private bool radialJoint;
        private InlineJoint[] inlineJoints;
        public int Mass => mass;
        public string Name => name;
        public bool RadialJoint => radialJoint;
        public InlineJoint[] InlineJoints => inlineJoints;

        public Part(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints)
        {
            this.mass = mass;
            this.name = name;
            this.radialJoint = radialJoint;
            this.inlineJoints = inlineJoints;
        }

        public virtual Part Clone()
        {
            return new Part(mass, name, radialJoint, inlineJoints);
        }

        public InlineJoint[] CopyInlineJoints()
        {
            InlineJoint[] newInlineJoints = new InlineJoint[InlineJoints.Length];
            InlineJoints.CopyTo(newInlineJoints, 0);
            return newInlineJoints;
        }
    }
}
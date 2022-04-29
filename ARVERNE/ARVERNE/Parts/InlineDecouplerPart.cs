using ARVERNE.Parts.PartsProperties;

namespace ARVERNE.Parts
{
    public class InlineDecouplerPart: Part
    {
        public InlineDecouplerPart(int mass, string name, bool radialJoint, InlineJoint[] inlineJoints) : 
            base(mass, name, radialJoint, inlineJoints)
        {
        }
    }
}
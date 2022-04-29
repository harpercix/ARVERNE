using System.Numerics;

namespace ARVERNE.Parts.PartsProperties
{
    public class InlineJoint
    {
        private int diameter;
        private Vector3 coords;
        private Quaternion angle;

        public InlineJoint(int diameter, Vector3 coords, Quaternion angle)
        {
            this.diameter = diameter;
            this.coords = coords;
            this.angle = angle;
        }
    }
}
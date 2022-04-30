using System;
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

        public static bool AreCompatible(InlineJoint joint1, InlineJoint joint2)
        {
            bool onlyOne180 = false;
            foreach (float angle in new float[]
                     {
                         joint1.angle.X, joint1.angle.Y, joint1.angle.Z,
                         joint2.angle.X, joint2.angle.Y, joint2.angle.Z
                     })
            {
                if (Math.Abs(angle - 180) < 1)
                {
                    if (onlyOne180)
                    {
                        return false;
                    }

                    onlyOne180 = true;
                }
            }
            return joint1.diameter == joint2.diameter && onlyOne180;
        }
    }
}
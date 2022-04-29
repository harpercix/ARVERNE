using System;
using System.Numerics;
using ARVERNE.Parts;
using ARVERNE.Parts.PartsProperties;

namespace ARVERNE
{
    class Program
    {
        static void Main(string[] args)
        {
            Part[] parts = new Part[]
            {
                new OxFuelPart(560,
                    "FL-T100 Fuel Tank",
                    true,
                    new InlineJoint[]
                    {
                        new InlineJoint(1250, new Vector3(0, -3125, 0), new Quaternion(0, 0, 180, 0)),
                        new InlineJoint(1250, new Vector3(0, 3125, 0), new Quaternion(0, 0, 0, 0))
                    },
                    55,
                    45,
                    60
                ),
                new EnginePart(1250, 
                    "LV-T30 \"Reliant\" Liquid Fuel Engine",
                    false,
                    new InlineJoint[]
                    {
                        new InlineJoint(1250, new Vector3(0, 7215, 0), new Quaternion(0, 0, 0, 0)),
                        new InlineJoint(1250, new Vector3(0, 7215, 0), new Quaternion(0, 0, 180, 0))
                    },
                    205160,
                    265,
                    15.79)
            };

        Console.WriteLine("Hello World!");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Numerics;
using ARVERNE.Optimizer;
using ARVERNE.Parts;
using ARVERNE.Parts.PartsProperties;
using ARVERNE.Stages;

namespace ARVERNE
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Part[]> parts = new Dictionary<string, Part[]>()
            {
                {"OxFuel", new Part[]{
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
                )}},
                {"Engine", new Part[]{
                new EnginePart(1250, 
                    "LV-T30 \"Reliant\" Liquid Fuel Engine",
                    false,
                    new InlineJoint[]
                    {
                        new InlineJoint(1250, new Vector3(0, 7215, 0), new Quaternion(0, 0, 0, 0)),
                        new InlineJoint(1250, new Vector3(0, -7215, 0), new Quaternion(0, 0, 180, 0))
                    },
                    205160,
                    265,
                    15.79)}},
                {"Decoupler", new Part[]{
                new InlineDecouplerPart(40,
                    "TD-12 Decoupler",
                    false,
                    new InlineJoint[]
                    {
                        new InlineJoint(1250, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)),
                        new InlineJoint(1250, new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0))
                    })}}
            };
            Craft bestCraft = BrutForce.BrutForcerMain(1000, parts, 3, 0);
            Console.WriteLine(bestCraft.Print());
        }
    }
}
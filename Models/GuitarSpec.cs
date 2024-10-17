using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuitarStoreApplication.Types;

namespace GuitarStoreApplication.Models

{
    internal class GuitarSpec
    {
        public Builder Builder { get; }
        public string Model { get; }
        public GuitarType Type { get; }
        public Wood BackWood { get; }
        public Wood TopWood { get; }

        public GuitarSpec(Builder builder, string model, GuitarType type, Wood backWood, Wood topWood)
        {
            Builder = builder;
            Model = model;
            Type = type;
            BackWood = backWood;
            TopWood = topWood;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public abstract class Modifier
    {
        public int ModifierId { get; private set; }
        public ICollection<ExerciseModifier> ExerciseModifiers { get; set; }
        public string Value { get; set; }

        public Modifier()
        {

        }
        public Modifier(string value)
        {
            Value = value;
        }

        override
        public abstract string ToString();
        public abstract void Transform();
    }
}

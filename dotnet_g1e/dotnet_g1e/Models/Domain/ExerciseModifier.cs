using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class ExerciseModifier
    {
        public int ExerciseId { get; private set; }
        public Exercise Exercise { get; set; }
        public int ModifierId { get; private set; }
        public Modifier Modifier { get; set; }
    }
}

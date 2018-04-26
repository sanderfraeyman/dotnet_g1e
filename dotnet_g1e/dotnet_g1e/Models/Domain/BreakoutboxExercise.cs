using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class BreakoutboxExercise
    {
        public int BreakoutboxId { get; private set; }
        public Breakoutbox Breakoutbox { get; set; }
        public int ExerciseId { get; private set; }
        public Exercise Exercise { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class Exercise
    {
        public int ExerciseId { get; private set; }
        public List<ExerciseModifier> ExerciseModifiers { get; set; }
        public List<BreakoutboxExercise> BreakoutboxExercises { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Trim().Equals("")) throw new ArgumentException("Name can not be empty");
                name = value;
            }
        }
        //public Blob Task { get; set; }
        //public Blob Feedback { get; set; }
        public DateTime DateOfCreation
        {
            get { return dateOfCreation; }
            private set { dateOfCreation = DateTime.Now; }
        }
        public bool InActiveUse { get; set; } = false;
        public string Course { get; set; }
        public int TimeLimit
        {
            get { return timeLimit; }
            set
            {
                if (value < 0) throw new ArgumentException("Timelimit can not be negative, enter 0 for infinite limit");
                timeLimit = value;
            }
        }
        [NotMapped]
        public List<Modifier> Modifiers { get; set; }
        public Result<string> Result { get; set; }

        private DateTime dateOfCreation;
        private string name;
        private int timeLimit;

        //Still need to implement constructors with the blobs
        public Exercise()
        {

        }
        public Exercise(string name, Result<String> result, List<Modifier> modifiers, string course) : this(name, result, modifiers, course, 0) { }
        public Exercise(string name, Result<String> result, List<Modifier> modifiers) : this(name, result, modifiers, "", 0) { }
        public Exercise(string name, Result<String> result, List<Modifier> modifiers, int timeLimit) : this(name, result, modifiers, "", timeLimit) { }
        public Exercise(string name, Result<String> result, List<Modifier> modifiers, string course, int timelimit)
        {
            Name = name;
            Result = result;
            Modifiers = modifiers;
            Result = result;
            Course = course;
            TimeLimit = timelimit;
            DateOfCreation = DateTime.Now;
        }

        public bool HasModifiers()
        {
            return Modifiers.Count>0 ? true : false;
        }

        override
        public string ToString()
        {
            return String.Format("%-10s(%s)%n", Name, Course);
        }
    }
}

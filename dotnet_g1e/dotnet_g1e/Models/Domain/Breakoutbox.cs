using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace dotnet_g1e.Models.Domain
{
    public class Breakoutbox
    {
        public int BreakoutboxId { get; private set; }
        public List<BreakoutboxAction> BreakoutboxActions { get; set; }
        public List<BreakoutboxAccessCode> BreakoutboxAccessCodes { get; set; }
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
        public string Description { get; set; }
        public bool InActiveUse { get; set; } = false;
        public DateTime DateOfCreation {
            get { return dateOfCreation; }
            private set { dateOfCreation = DateTime.Now; }
        }
        [NotMapped]
        public List<Exercise> Exercises {
            get { return exercises; }
            set {
                exercises = value;
                exercises.ForEach(e => e.InActiveUse = true);
            }
        }
        [NotMapped]
        public List<AccessCode> AccessCodes { get; set; }
        [NotMapped]
        public List<Action> Actions { get; set; }

        private string name;
        private DateTime dateOfCreation;
        private List<Exercise> exercises;

        public Breakoutbox()
        {
        }

        public Breakoutbox(string name, string description, List<Action> actions, List<AccessCode> accessCodes,List<Exercise> exercises)
        {
            Name = name;
            Description = description;
            Actions = actions;
            AccessCodes = accessCodes;
            Exercises = exercises;
            DateOfCreation = DateTime.Now;
        }

        override
        public string ToString() => "BreakoutBox " + Name + "\nCreated on: " + DateOfCreation;

        //Checks if the amount of access codes is equal to the amount of actions -1 (last action is "find the treasure" by default)
        public bool ValidateBox()
        {
            if (AccessCodes.Count != Actions.Count()-1) return false;
            return true;
        }
    }

}

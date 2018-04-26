using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class Action
    {
        public int ActionId { get; private set; }
        public List<BreakoutboxAction> BreakoutboxActions { get; set; }

        public string Instruction
        {
            get { return instruction; }
            set
            {
                if (value.Trim().Equals("")) throw new ArgumentException("Instruction can not be empty");
                instruction = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Trim().Equals("")) throw new ArgumentException("Name can not be empty");
                name = value;
            }
        }
        public AccessCode Code { get; set; }

        private string name;
        private string instruction;

        public Action()
        {
                
        }
        public Action(string name, string instruction)
        {
            Name = name;
            Instruction = instruction;
        }

        override
        public string ToString()
        {
            return "Actie: " + Name + " met instructie: " + Instruction;
        }
    }
}

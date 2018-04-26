using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class AddModifier : Modifier
    {
        public AddModifier()
        {
                
        }
        public AddModifier(string value) : base(value) { }
        public override string ToString()
        {
            return "+" + Value;
        }

        public override void Transform()
        {
            
        }
    }
}

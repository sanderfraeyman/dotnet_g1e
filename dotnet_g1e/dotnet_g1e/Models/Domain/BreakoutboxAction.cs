using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class BreakoutboxAction
    {
        public int BreakoutboxId { get; private set; }
        public Breakoutbox Breakoutbox { get; set; }
        public int ActionId { get; private set; }
        public Action Action { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class BreakoutboxAccessCode
    {
        public int BreakoutboxId { get; private set; }
        public Breakoutbox Breakoutbox { get; set; }
        public int AccessCodeId { get; private set; }
        public AccessCode AccessCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class SessionPlayGroup
    {
        public int SessionId { get; private set; }
        public Session Session { get; set; }
        public int PlayGroupId { get; private set; }
        public PlayGroup PlayGroup { get; set; }
    }
}

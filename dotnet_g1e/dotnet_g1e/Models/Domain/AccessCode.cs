using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class AccessCode
    {
        public int AccessCodeId { get; private set; }
        public List<BreakoutboxAccessCode> BreakoutboxAccessCodes { get; set; }
        public string Code { get; private set; }
        public AccessCode()
        {

        }
        public AccessCode(string code)
        {
            Code = code;
        }

        override
        public string ToString()
        {
            return "Toegangscode : "+Code;
        }
    }
}

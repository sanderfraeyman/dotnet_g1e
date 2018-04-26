using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class Result <T>
    {
        public int ResultId { get; private set; }
        //has to be generic
        public T Value { get; set; }

        public Result()
        {

        }
        public Result(T value)
        {
            Value = value;
        }
    }
}

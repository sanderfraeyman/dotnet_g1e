using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class ClassGroupPupil
    {
        public int ClassGroupId { get; private set; }
        public Classgroup Classgroup { get; set; }
        public int PupilId { get; private set; }
        public Pupil Pupil { get; set; }
    }
}

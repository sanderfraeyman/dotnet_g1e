using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class PlayGroupPupil
    {
        public int PlayGroupId { get; private set; }
        public PlayGroup PlayGroup { get; set; }
        public int PupilId { get; private set; }
        public Pupil Pupil { get; set; }
    }
}

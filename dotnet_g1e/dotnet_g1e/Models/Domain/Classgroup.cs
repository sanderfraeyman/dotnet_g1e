using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_g1e.Models.Domain
{
    public class Classgroup
    {
        public int ClassGroupId { get; private set; }
        public List<ClassGroupPupil> ClassGroupPupils { get; set; }
        public string ClassgroupName { get; private set; }
        [NotMapped]
        private List<Pupil> Pupils { get; set; }

        public Classgroup()
        {
        }

        public Classgroup(string classgroupName, List<Pupil> pupils)
        {
            ClassgroupName = classgroupName;
            Pupils = pupils;
        }

        override
        public string ToString()
        {
            string res = String.Format("Klas: %s:\n", ClassgroupName);
            foreach (Pupil p in Pupils)
            {
                res += p.FirstName + " " + p.LastName + "\n";
            }
            return res;
        }

    } 
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_g1e.Models.Domain
{
    public class PlayGroup
    {
        public int PlayGroupId { get; private set; }
        public bool ActiveSession { get; set; }
        public List<PlayGroupPupil> PlayGroupPupils { get; set; }
        public List<SessionPlayGroup> SessionPlayGroups { get; set; } = new List<SessionPlayGroup>();
        public string Name { get; private set; }
        [NotMapped]
        public List<Pupil> Pupils { get; private set; }

        public PlayGroup()
        {
        }

        public PlayGroup(string name, List<Pupil> pupils)
        {
            Name = name;
            Pupils = pupils;
        }

        public void AddPupil(Pupil pupil)
        {
            this.Pupils.Add(pupil);
        }

        public void RemovePupil(Pupil pupil)
        {
            this.Pupils.Remove(pupil);
        }

        override
        public string ToString()
        {
            string res = String.Format("Groep: %s\n", Name);
            foreach (Pupil p in Pupils)
            {
                res += p.FirstName + " " + p.LastName + "\n";
            }
            return res;
        }
    } 
}

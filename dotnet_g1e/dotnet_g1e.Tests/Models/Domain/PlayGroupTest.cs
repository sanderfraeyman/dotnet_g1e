using dotnet_g1e.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class PlayGroupTest
    {
        private Pupil testPupil;
        private List<Pupil> emptyPupils;
        private PlayGroup testPlaygroup;

        public PlayGroupTest()
        {
            testPupil = new Pupil("Test", "Tester");
            emptyPupils = new List<Pupil>();
            testPlaygroup = new PlayGroup("testGroup", emptyPupils);
        }

        [Fact]
        public void AddPupilAddsPupilToGroup()
        {
            testPlaygroup.AddPupil(testPupil);
            Assert.Equal(1, testPlaygroup.Pupils.Count);
        }

        [Fact]
        public void RemovePupilRemovesPupilFromGroup()
        {
            testPlaygroup.AddPupil(testPupil);
            testPlaygroup.RemovePupil(testPupil);
            Assert.Equal(0, testPlaygroup.Pupils.Count);
        }
    }
}

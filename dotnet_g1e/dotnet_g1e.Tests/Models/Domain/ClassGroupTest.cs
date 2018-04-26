using dotnet_g1e.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class ClassGroupTest
    {
        private Pupil testPupil;
        private List<Pupil> emptyPupils;
        private Classgroup testClassGroup;

        public ClassGroupTest()
        {
            testPupil = new Pupil("Test", "Tester");
            emptyPupils = new List<Pupil>();
            testClassGroup = new Classgroup("testGroup", emptyPupils);
        }

        //No methods or attributes to test yet
    }
}

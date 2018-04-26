using dotnet_g1e.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class PupilTest
    {

        public PupilTest()
        {

        }

        #region Constructor
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        [InlineData("3")]
        public void NewPupil_WrongName_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Pupil(name,name));
        }

        [Theory]
        [InlineData("Jan")]
        [InlineData("Pieter-Jan")]
        [InlineData("D'Hooge")]
        [InlineData("Ik kan geen speciale karakters typen met mn keyboard")]
        [InlineData("Pieter-Jan D'Hooge Jr.")]
        public void NewPupil_AcceptedName_ReturnsTrue(string name)
        {
            Pupil p = new Pupil(name, name);
            Assert.True(name == p.FirstName);
        }

        #endregion
    }
}

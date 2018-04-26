using System;
using Xunit;
using System.Collections.Generic;
using dotnet_g1e.Models.Domain;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class SessionTest
    {
        private string ValidName = "Test234"; //Can not be empty, all characters allowed
        private string ValidDescription = ""; // -
        private DateTime ValidDate = new DateTime(2020, 1, 1); //Must be in the future
        private Classgroup ValidClassGroup = new Classgroup(); // - 
        private Breakoutbox ValidBreakoutbox; //InActiveUse has to be set to true
        private List<PlayGroup> ValidGroups = new List<PlayGroup>
            {
                new PlayGroup("1", new List<Pupil>()),
                new PlayGroup("2", new List<Pupil>()),
                new PlayGroup("3", new List<Pupil>())
            }; // -

        public SessionTest()
        {
            ValidBreakoutbox = new Breakoutbox(ValidName, ValidDescription, new List<dotnet_g1e.Models.Domain.Action>(), new List<AccessCode>(), new List<Exercise>());
        }

        #region Constructor
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewSession_WrongName_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Session(name, ValidDescription,ValidDate,ValidClassGroup,ValidGroups,ValidBreakoutbox));
        }

        [Fact]
        public void NewSession_DateInPast_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Session(ValidName, ValidDescription, new DateTime(1990,1,1), ValidClassGroup, ValidGroups, ValidBreakoutbox));
        }

        [Fact]
        public void NewSession_BreakoutboxInActiveSession_ReturnsTrue()
        {
           Session s = new Session(ValidName, ValidDescription, ValidDate, ValidClassGroup, ValidGroups, ValidBreakoutbox);
           Assert.True(ValidBreakoutbox.InActiveUse);
        }

        [Fact]
        public void NewSession_DateOfCreationCheck_ReturnsTrue()
        {
            Session s = new Session(ValidName, ValidDescription, ValidDate, ValidClassGroup, ValidGroups, ValidBreakoutbox);
            Assert.Equal(DateTime.Now.DayOfYear , s.DateOfCreation.DayOfYear);
            Assert.Equal(DateTime.Now.Year, s.DateOfCreation.Year);
        }

        #endregion
    }
}

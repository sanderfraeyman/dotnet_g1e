
using dotnet_g1e.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class BreakoutboxTest
    {
        private string ValidName; //Can not be empty, all characters allowed
        private string ValidDescription; // -
        private List<dotnet_g1e.Models.Domain.Action> ValidActions;
        private List<AccessCode> ValidAccessCodes;
        private List<Exercise> ValidExercises;

        public BreakoutboxTest()
        {
            ValidName = "Test234";
            ValidDescription = "";
            ValidActions = new List<dotnet_g1e.Models.Domain.Action>
            {
                new dotnet_g1e.Models.Domain.Action("action1","Turn left"),
                new dotnet_g1e.Models.Domain.Action("action2","Turn right"),
                new dotnet_g1e.Models.Domain.Action("action3","Boom")
            };
            ValidAccessCodes = new List<AccessCode>
            {
                new AccessCode("1"),
                new AccessCode("2"),
            };
            ValidExercises = new List<Exercise>
            {
                new Exercise("Ex1",new Result<string>(), new List<Modifier>()),
                new Exercise("Ex2",new Result<string>(), new List<Modifier>()),
                new Exercise("Ex3",new Result<string>(), new List<Modifier>())
            };
        }

        #region Constructor
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewBox_WrongName_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Breakoutbox(name,ValidDescription,ValidActions,ValidAccessCodes,ValidExercises));
        }

        [Fact]
        public void NewBox_DateOfCreationCheck_ReturnsTrue()
        {
            Breakoutbox b = new Breakoutbox(ValidName, ValidDescription, ValidActions, ValidAccessCodes, ValidExercises);
            Assert.Equal( DateTime.Now.DayOfYear, b.DateOfCreation.DayOfYear);
            Assert.Equal( DateTime.Now.Year, b.DateOfCreation.Year);
        }

        [Fact]
        public void NewBox_ExercisesAreSetToInActiveUse_ReturnsTrue()
        {
            Breakoutbox b = new Breakoutbox(ValidName, ValidDescription, ValidActions, ValidAccessCodes, ValidExercises);
            Assert.True(b.Exercises[0].InActiveUse);
        }

        #endregion

        [Fact]
        public void Validate_CorrectAmount_ReturnsTrue()
        {
            Breakoutbox b = new Breakoutbox(ValidName, ValidDescription, ValidActions, ValidAccessCodes, ValidExercises);
            Assert.True(b.ValidateBox());
        }

        [Fact]
        public void Validate_InCorrectAmount_ReturnsFalse()
        {
            ValidAccessCodes.Add(new AccessCode("3"));
            Breakoutbox b = new Breakoutbox(ValidName, ValidDescription, ValidActions, ValidAccessCodes, ValidExercises);
            Assert.False(b.ValidateBox());
        }


    }
}

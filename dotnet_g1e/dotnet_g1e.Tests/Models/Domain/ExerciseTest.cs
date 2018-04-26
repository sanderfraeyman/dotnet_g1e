using dotnet_g1e.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class ExerciseTest
    {
        private Result<string> result;
        private List<Modifier> modifiers;
        private List<Modifier> emptyModifiers;
        private string Name;
        public ExerciseTest()
        {
            result = new Result<string>("2");
            modifiers = new List<Modifier>
            {
                new AddModifier("1"),
                new AddModifier("2"),
                new AddModifier("3")
            };
            emptyModifiers = new List<Modifier>();
            Name = "Test123";
        }

        #region Constructor
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewExercise_WrongName_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Exercise(name, result, modifiers));
        }

        [Fact]
        public void NewExercise_NegativeTimeLimit_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Exercise(Name,result,modifiers,-1));
        }

        [Fact]
        public void NewExercise_DateOfCreationCheck_ReturnsTrue()
        {
            Exercise b = new Exercise(Name, result, modifiers);
            Assert.Equal(DateTime.Now.DayOfYear, b.DateOfCreation.DayOfYear);
            Assert.Equal(DateTime.Now.Year, b.DateOfCreation.Year);
        }

        #endregion

        [Fact]
        public void NewExercise_HasModifiers_ReturnsTrue()
        {
            Exercise b = new Exercise(Name, result, modifiers);
            Assert.True(b.HasModifiers());
        }

        [Fact]
        public void NewExercise_HasModifiers_ReturnsFalse()
        {
            Exercise b = new Exercise(Name, result, emptyModifiers);
            Assert.False(b.HasModifiers());
        }
    }
}

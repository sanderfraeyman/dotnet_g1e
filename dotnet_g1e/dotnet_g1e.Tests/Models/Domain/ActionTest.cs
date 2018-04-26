using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g1e.Tests.Models.Domain
{
    public class ActionTest
    {
        private string ValidString;

        public ActionTest()
        {
            ValidString = "test123";
        }

        #region Constructor
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewAction_WrongName_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new dotnet_g1e.Models.Domain.Action(name, ValidString));
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewAction_WrongInstruction_ThrowsException(string instruction)
        {
            Assert.Throws<ArgumentException>(() => new dotnet_g1e.Models.Domain.Action(ValidString, instruction));
        }

        #endregion
    }
}

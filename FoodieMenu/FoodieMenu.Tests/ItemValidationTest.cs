using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieMenu.Web.Components.Pages;

namespace FoodieMenu.Tests
{
    [TestClass]
    public class ItemValidationTest
    {
        [TestMethod]
        public void CheckIfStartOfTheStringIsInvalid_FailsEmptySpace()
        {
            // Arrange 
            string invalidName = " StartsWithWhiteSpace";
            AddMenu addMenu = new AddMenu();


            // Act 
            bool result = addMenu.CheckIfStartOfTheStringIsInvalid(invalidName);
            // Assert

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfStartOfTheStringIsInvalid_PassValidName()
        {
            // Arrange 
            string validName = "Valid Menu Name";
            AddMenu addMenu = new AddMenu();


            // Act 
            bool result = addMenu.CheckIfStartOfTheStringIsInvalid(validName);
            // Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsLineBreak_TrueStringWithLineBreak()
        {
            // Arrange 
            string StringWithLineBreak = "Invalid\nString";
            AddMenu addMenu = new AddMenu();


            // Act 
            bool result = addMenu.ContainsLineBreak(StringWithLineBreak);
            // Assert

            Assert.IsTrue(result);
        }

        public void ContainsLineBrake_FalseStringWithoutLineBreak()
        {
            // Arrange 
            string StringWithNoLineBreak = "Valid string";
            AddMenu addMenu = new AddMenu();


            // Act 
            bool result = addMenu.ContainsLineBreak(StringWithNoLineBreak);
            // Assert

            Assert.IsFalse(result);
        }
    }
}

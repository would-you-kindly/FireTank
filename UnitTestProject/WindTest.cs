using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FireSafety;

namespace UnitTestProject
{
    [TestClass]
    public class WindTest
    {
        [TestMethod]
        public void WindInit_Up_DirectionIsUp()
        {
            // Arrange
            Wind wind = new Wind(Wind.Direction.Up);

            // Act

            // Assert
            Assert.AreEqual(Wind.Direction.Up, wind.direction);
        }
    }
}

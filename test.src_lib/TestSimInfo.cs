using System;
using Xunit;
using src_lib.Models;

namespace test.src_lib
{
    public class TestSimInfo
    {
        [Fact]
        public void TickCount_ShoudStayAtZero()
        {
            // Arrange
            var si = new SimInfo();

            // Act
            si.TickCount = -1;

            // Assert
            Assert.Equal(0, si.TickCount);
        }
    }
}

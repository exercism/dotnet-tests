using System;
using Xunit;

namespace Exercism.Tests.Tests
{
    public class TaskAttributeTests
    {
        [Fact]
        public void AllowsOneDeclaration()
        {
            [Task(1)]
            string TestMethod() => "One";
        }
        
        [Fact]
        public void AllowsMultipleDeclarations()
        {
            [Task(1), Task(2), Task(3)]
            string TestMethod() => "One, Two, Three";
        }
        
        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenNumberIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TaskAttribute(0));
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-82)]
        [InlineData(-123_832_991)]
        public void ThrowsArgumentOutOfRangeExceptionWhenNumberIsNegative(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TaskAttribute(number));
        }
    }
}

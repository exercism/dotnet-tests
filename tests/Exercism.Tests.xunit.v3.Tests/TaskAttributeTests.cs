namespace Exercism.Tests.xunit.v3.Tests;

public class TaskAttributeTests
{
    [Fact]
    public void CanBeUsedOnMethod()
    {
        [Task(1)]
        string TestMethod() => "One";
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
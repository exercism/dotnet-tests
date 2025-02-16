using System.Globalization;
using Xunit;

namespace Exercism.Tests.Tests
{
    [UseCulture("en-US")]
    public class UseCultureAttributeTests
    {
        [Fact]
        [UseCulture("nl-NL")]
        public void SpecifyCulture()
        {
            Assert.Equal("nl-NL", CultureInfo.CurrentCulture.Name);
            Assert.Equal("nl-NL", CultureInfo.CurrentUICulture.Name);
        }
        
        [Fact]
        [UseCulture("nl-NL", "nl-BE")]
        public void SpecifyCultureAndUiCulture()
        {
            Assert.Equal("nl-NL", CultureInfo.CurrentCulture.Name);
            Assert.Equal("nl-BE", CultureInfo.CurrentUICulture.Name);
        }

        [Fact]
        [UseCulture]
        public void DontSpecifyCulture()
        {
            Assert.Equal(CultureInfo.InvariantCulture.Name, CultureInfo.CurrentCulture.Name);
            Assert.Equal(CultureInfo.InvariantCulture.Name, CultureInfo.CurrentUICulture.Name);
        }
        
        [Fact]
        public void InheritCultureFromClass()
        {
            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
            Assert.Equal("en-US", CultureInfo.CurrentUICulture.Name);
        }
    }
}

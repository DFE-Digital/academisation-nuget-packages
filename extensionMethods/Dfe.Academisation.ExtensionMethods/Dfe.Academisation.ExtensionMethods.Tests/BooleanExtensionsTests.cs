using FluentAssertions;

namespace Dfe.Academisation.ExtensionMethods.Tests
{
    public class BooleanExtensionsTests
    {
        [Fact]
        public void ToYesNoString_WithFalse_ReturnsNo()
        {
            false.ToYesNoString().Should().Be("No");
        }

        [Fact]
        public void ToYesNoString_WithTrue_ReturnsYes()
        {
            true.ToYesNoString().Should().Be("Yes");
        }
    }

}

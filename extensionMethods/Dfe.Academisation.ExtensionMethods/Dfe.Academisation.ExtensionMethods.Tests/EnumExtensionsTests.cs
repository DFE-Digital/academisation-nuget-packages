using FluentAssertions;

namespace Dfe.Academisation.ExtensionMethods.Tests
{
    public class EnumExtensionsTests
    {
        [Theory]
        [InlineData(ExampleEnum.RegionalDirectorForRegion, "Regional Director for the region")]
        [InlineData(ExampleEnum.OtherRegionalDirector, "A different Regional Director")]
        [InlineData(ExampleEnum.Minister, "Minister")]
        public void Should_return_the_description_of_enum(ExampleEnum input, string expectedDescription)
        {
            string result = input.ToDescription();

            result.Should().Be(expectedDescription);
        }

        [Theory]
        [InlineData(ExampleEnum.Approved, "Approved")]
        [InlineData(null, "")]
        public void Should_return_the_name_of_enum_when_no_description(ExampleEnum? input, string expectedDescription)
        {
            string result = input.ToDescription();

            result.Should().Be(expectedDescription);
        }
    }
}

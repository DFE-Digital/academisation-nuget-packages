namespace Dfe.Academisation.ExtensionMethods.Tests;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StringExtensionsTests
{
    private const string ACRONYM_SENTENCE = "DAO is CaptuRed CoRrectLy with MAT in DfE";
    private const string LOWER_CASE = "this is lower case";

    [Fact]
    public void ToSentenceCase_WithAcronyms_ReturnsCorrectly()
    {
        ACRONYM_SENTENCE.ToSentenceCase().Should().Be("DAO Is captured correctly with MAT in DfE");
    }

    [Fact]
    public void ToSentenceCase_WithLowerCase_ReturnsCorrectly()
    {
        LOWER_CASE.ToSentenceCase().Should().Be("This is lower case");
    }

    [Theory]
    [InlineData("MAT", true)]
    [InlineData("TEAM", true)]
    [InlineData("DAO-", false)]
    [InlineData("DfE", true)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData(null, false)]
    public void IsAcronym_ShouldReturnExpectedResult(string word, bool expected)
    {
        // Act
        var result = StringExtensions.IsAcronym(word);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("MAT", true)]
    [InlineData("TEAM", true)]
    [InlineData("Mat", false)]
    [InlineData("Hello", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsAllCaps_ShouldReturnExpectedResult(string word, bool expected)
    {
        // Act
        var result = StringExtensions.IsAllCaps(word);

        // Assert
        result.Should().Be(expected);
    }
    [Fact]
    public void ToBool_Should_ReturnTrue_When_StringIsYes()
    {
        // Arrange
        string yes = "Yes";

        // Act
        bool result = yes.ToBool();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ToBool_Should_ReturnFalse_When_StringIsNo()
    {
        // Arrange
        string no = "No";

        // Act
        bool result = no.ToBool();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void ToBool_Should_ThrowArgumentException_When_StringIsNotYesOrNo()
    {
        // Arrange
        string notYesOrNo = "Maybe";

        // Act
        Action act = () => notYesOrNo.ToBool();

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("The string must be either 'Yes' or 'No'.");
    }

    [Fact]
    public void ToFirstUpper_Uppercases_First_Character_And_Returns_Whole_String()
    {
        string input = "this_is_a_test";

        string result = input.ToFirstUpper();
        _ = result.Should().Be("This_is_a_test");
    }
}

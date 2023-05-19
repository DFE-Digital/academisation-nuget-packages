using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academisation.ExtensionMethods.Tests
{

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
    }
}
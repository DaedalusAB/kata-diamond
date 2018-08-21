using System;
using System.Collections.Generic;
using System.Linq;
using DiamondCata;
using Xunit;

namespace DiamondCataTests
{
    public class CharHelperTests
    {
        [Theory]
        [InlineData('a')]
        [InlineData('A')]
        [InlineData('z')]
        public void GetAlphabeticalIndex(char c)
        {
            Assert.Equal(char.ToUpper(c) - 65 + 1, c.GetAlphabeticalIndex());
        }

        [Fact]
        public void GetWithPreviousChars()
        {
            var chars = 'e'.GetWithPreviousChars();
            var expectedChars = new List<char>() { 'A', 'B', 'C', 'D', 'E' };

            Assert.Equal(5, chars.Count);
            Assert.True(expectedChars.SequenceEqual(chars));
        }
    }
}

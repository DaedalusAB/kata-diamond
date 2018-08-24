using DiamondCata;
using Xunit;

namespace DiamondCataTests
{
    public class DiamondKataTests
    {
        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        public void BuildQuarterDiamond(char letter)
        {
            var diamondBuilder = new DiamondBuilder(letter);
            var diamonQuarter = diamondBuilder
                .BasicQuarter()
                .Build();
            var diamondChars = letter.GetWithPreviousChars();

            Assert.Equal(letter.GetAlphabeticalIndex(), diamonQuarter.Length);
            Assert.All(diamonQuarter, s => Assert.Equal(letter.GetAlphabeticalIndex(), s.Length));
            Assert.All(diamondChars, c => diamonQuarter[c.GetAlphabeticalIndex() - 1].IndexOf(c).Equals(diamonQuarter.Length - c.GetAlphabeticalIndex()));
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        public void BuildHalfDiamond(char letter)
        {
            var diamondBuilder = new DiamondBuilder(letter);
            var diamondHalf = diamondBuilder
                .BasicQuarter()
                .ExtendVertically()
                .Build();
            var diamondChars = letter.GetWithPreviousChars();
            var diamondHeight = letter.GetAlphabeticalIndex() * 2 - 1;

            Assert.Equal(diamondHeight, diamondHalf.Length);
            Assert.All(diamondChars, c => diamondHalf[c.GetAlphabeticalIndex() - 1].Equals(diamondHalf[diamondHalf.Length - c.GetAlphabeticalIndex()]));
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        public void BuildDiamondForChar(char letter)
        {
            var diamondBuilder = new DiamondBuilder(letter);
            var diamondWhole = diamondBuilder
                .BasicQuarter()
                .ExtendVertically()
                .Mirror()
                .Build();
            var diamondChars = letter.GetWithPreviousChars();
            var diamondSize = letter.GetAlphabeticalIndex() * 2 - 1;

            Assert.Equal(diamondSize, diamondWhole.Length);
            Assert.All(diamondWhole, s => s.Length.Equals(diamondSize));
            Assert.All(diamondChars, c => diamondWhole[c.GetAlphabeticalIndex() - 1][diamondSize / 2 - c.GetAlphabeticalIndex() + 1].Equals(c));
            Assert.All(diamondChars, c => diamondWhole[c.GetAlphabeticalIndex() - 1][diamondSize / 2 + c.GetAlphabeticalIndex() - 1].Equals(c));
            Assert.All(diamondChars, c => diamondWhole[c.GetAlphabeticalIndex() - 1].Equals(diamondWhole[diamondSize - 1]));
        }
    }
}


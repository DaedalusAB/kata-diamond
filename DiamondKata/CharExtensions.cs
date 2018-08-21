using System.Collections.Generic;
using System.Linq;

namespace DiamondCata
{
    public static class CharExtensions
    {
        public static int GetAlphabeticalIndex(this char c)
        {
            return char.ToUpper(c) - 65 + 1;
        }

        public static IReadOnlyList<char> GetWithPreviousChars(this char c)
        {
            return Enumerable.Range(65, c.GetAlphabeticalIndex()).Select(decChar => (char) decChar).ToList();
        }
    }
}

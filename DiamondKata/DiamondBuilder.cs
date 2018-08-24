using System;
using System.Collections.Generic;
using System.Linq;
using DiamondCata;

namespace DiamondCataTests
{
    public class DiamondBuilder
    {
        private string[] _partialDiamond;
        private readonly char _diamondChar;

        public DiamondBuilder(char diamondChar)
        {
            _diamondChar = diamondChar;
        }

        public DiamondBuilder BasicQuarter()
        {
            var diamondChars = _diamondChar.GetWithPreviousChars();
            _partialDiamond = new string[_diamondChar.GetAlphabeticalIndex()];

            foreach (var diamondChar in diamondChars)
            {
                var row = Enumerable.Repeat('-', _diamondChar.GetAlphabeticalIndex()).ToArray();
                row[diamondChar.GetAlphabeticalIndex() - 1] = diamondChar;
                _partialDiamond[diamondChar.GetAlphabeticalIndex() - 1] = new string(row.Reverse().ToArray());
            }

            return this;
        }
        public DiamondBuilder ExtendVertically()
        {
            var duplicates = _partialDiamond.Take(_partialDiamond.Length - 1).Reverse().ToArray();
            _partialDiamond = _partialDiamond.Concat(duplicates).ToArray();

            return this;
        }

        public DiamondBuilder Mirror()
        {
            for (var i = 0; i < _partialDiamond.Length; i++)
            {
                _partialDiamond[i] += new string(_partialDiamond[i].Take(_partialDiamond[i].Length - 1).Reverse().ToArray());
            }

            return this;
        }

        public string[] Build()
        {
            return _partialDiamond;
        }
    }
}


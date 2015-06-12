using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HassRandomLanguage
{
    public class LanguageValidator
    {
        private readonly string language;

        private readonly Regex languageRegex = new Regex(@"^([a-z]\^n)+$");

        public LanguageValidator(string language)
        {
            this.language = language;
        }

        public bool IsLanguageValid()
        {
            return languageRegex.IsMatch(language);
        }

        public bool IsWordValid(string word)
        {
            if (!this.IsLanguageValid() || string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            var match = languageRegex.Match(language);

            int start = match.Groups.Count > 1 ? 1 : 0;

            int numberOfCaptures = -1;

            for (int i = start; i < match.Groups.Count; i++)
            {
                numberOfCaptures = match.Groups[i].Captures.Count;
            }
            if (word.Length == numberOfCaptures)
            {
                return true;
            }
            int? matchNumber = null;

            bool isWordValid = this.ValidWord(word, ref matchNumber);

            if (!isWordValid)
            {
                return false;
            }
            return word.Length / matchNumber == numberOfCaptures;
        }

        private bool ValidWord(string word, ref int? matchNumber)
        {
            int initialMatch = 0;

            char[] next = word.Skip(matchNumber ?? 0).ToArray();

            char first = next[0];

            for (int i = 1; i < next.Length; i++)
            {
                if (first == next[i])
                {
                    ++initialMatch;
                }
                else if (!matchNumber.HasValue)
                {
                    matchNumber = initialMatch + 1;
                    return this.ValidWord(word, ref matchNumber);
                }
                else if (matchNumber != initialMatch + 1)
                {
                    return false;
                }
                else
                {
                    return this.ValidWord(new string(next), ref matchNumber);
                }
            }
            return word.Length >= matchNumber + 1;
        }
    }
}

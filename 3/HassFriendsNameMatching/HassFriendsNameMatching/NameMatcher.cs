using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HassFriendsNameMatching
{
    public class NameMatcher
    {
        private bool knowMale = false;
        private bool knowFemale = false;

        public string CalculateChanceOfSuccess(string input)
        {
            return input;
        }

        public void SetMaleFemaleMatch(string input)
        {
            var match = input.Split(' ');

            if (match.Length > 0)
            {
                this.knowMale = match[0] == "1";
            }
            else if (match.Length > 1)
            {
                this.knowFemale = match[1] == "1";
            }
        }

        public void SetNames(string names)
        {

        }
    }
}

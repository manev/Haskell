using System;

namespace HassFriendsNameMatching
{
    public class NameMatcher
    {
        private int knownMaleCount = 0;
        private int knownFemaleCount = 0;

        private readonly string MaleSuffix = "ss";
        private readonly string FemaleSuffix = "tta";

        private string[] Names = new string[0];

        public string CalculateChanceOfSuccess(string input)
        {
            this.Names = input.Split(' ');

            if (this.Names == null || this.Names.Length == 0)
            {
                throw new Exception("Task definiton doesn't meet the requirenments");
            }

            Tuple<int, int> maleFemaleCountMap = this.GetMaleFemaleCountTuple();
        
            decimal maleRestFactor = this.GetRestFactor(maleFemaleCountMap.Item1, this.knownMaleCount);
            decimal femaleRestFactor = this.GetRestFactor(maleFemaleCountMap.Item2, this.knownFemaleCount);

            decimal sum = maleRestFactor + femaleRestFactor;

            maleRestFactor = maleRestFactor == 0 ? 0 : Math.Round(maleRestFactor / sum, 2);
            femaleRestFactor = femaleRestFactor == 0 ? 0 : Math.Round(femaleRestFactor / sum, 2);

            if (maleRestFactor == femaleRestFactor && maleRestFactor == 0)
            {
                return "100%";
            }

            decimal maleChanceForSuccess = this.CalculateChance(maleFemaleCountMap.Item1, this.knownMaleCount);
            decimal femaleChanceForSuccess = this.CalculateChance(maleFemaleCountMap.Item2, this.knownFemaleCount);

            decimal maleFactorPer = maleChanceForSuccess * maleRestFactor;
            decimal femaleFactorPer = femaleChanceForSuccess * femaleRestFactor;

            return (maleFactorPer + femaleFactorPer).ToString() + "%";
        }

        private int GetRestFactor(int realNameCount, int knownPersonCount)
        {
            if (realNameCount < knownPersonCount)
            {
                throw new Exception("Not possible to know more names then the real count");
            }

            if (knownPersonCount == 0)
            {
                return realNameCount;
            }

            int rest = realNameCount - knownPersonCount;
            if (rest == 1)
            {
                return 0;
            }
            return rest;
        }

        private decimal CalculateChance(int realNameCount, int knownPersonCount)
        {
            if (realNameCount == 0)
            {
                return 100;
            }
            if (realNameCount < knownPersonCount)
            {
                throw new Exception("Not possible to know more names then the real count");
            }

            int delta = realNameCount - knownPersonCount;

            return delta > 0 ? 100 / delta : 100;
        }

        public void SetGenderMatchCount(string input)
        {
            var match = input.Split(' ');

            if (match.Length > 0)
            {
                int.TryParse(match[0], out this.knownMaleCount);
            }
            if (match.Length > 1)
            {
                int.TryParse(match[1], out this.knownFemaleCount);
            }
        }

        private Tuple<int, int> GetMaleFemaleCountTuple()
        {
            int maleCount = 0;
            int femaleCount = 0;

            foreach (string name in this.Names)
            {
                if (name.EndsWith(this.MaleSuffix))
                {
                    ++maleCount;
                }
                else if (name.EndsWith(this.FemaleSuffix))
                {
                    ++femaleCount;
                }
            }

            return Tuple.Create(maleCount, femaleCount);
        }
    }
}

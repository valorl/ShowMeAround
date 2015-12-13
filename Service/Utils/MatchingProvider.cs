using Data;
using Data.Utils;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Utils
{
    public class MatchingProvider
    {
        private const int MAX_AGE_GAP = 15;
        private const double LANG_WEIGHT = 0.5;
        private const double INTEREST_WEIGHT = 1.5;

        public MatchingProvider() { }

        public Match GetMatch(User traveler, User guide)
        {
            var match = new Match()
            {
                Traveler = traveler,
                Guide = guide,
                Score = CalculateScore(traveler, guide)
            };
            return match;
        }

        private int CalculateScore(User traveler, User guide)
        {
            int l_score = GetLangScore(traveler, guide);
            if (l_score < 0) return 0;
            int i_score = GetInterestScore(traveler, guide);

            int l_score_with_weight = (int)Math.Round(l_score * LANG_WEIGHT);
            int i_score_with_weight = (int)Math.Round(i_score * INTEREST_WEIGHT);

            return l_score_with_weight + i_score_with_weight;
        }

        private int GetLangScore(User traveler, User guide)
        {
            int commonCount = traveler.Languages.Intersect(guide.Languages).ToList().Count;
            commonCount--;
            int score = (int)Math.Round((double)commonCount / (traveler.Languages.Count - 1) * 100);
            return score;
        }
        private int GetInterestScore(User traveler, User guide)
        {
            int commonCount = traveler.Interests.Intersect(guide.Interests).ToList().Count;
            int score = (int)Math.Round((double)commonCount / traveler.Interests.Count * 100);
            return score;
        }
    }
}

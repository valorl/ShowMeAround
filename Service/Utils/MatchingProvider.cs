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
        private const double AGE_WEIGHT = 1;


        public MatchingProvider()
        {

        }

        public Match GetMatch(User traveler, User guide)
        {
            var match = new Match() {
                Traveler = traveler,
                Guide = guide,
                Score = CalculateScore(traveler, guide)
            };
            return match;
        }

        private double CalculateScore(User traveler, User guide)
        {
            int l_score = GetLangScore(traveler, guide);
            // Condition: At least 1 common language
            if (l_score < 0) return 0;  
            int i_score = GetInterestScore(traveler, guide);
            int age_score = GetAgeScore(traveler, guide);

            // apply weight
            int final = (int)Math.Round(age_score * AGE_WEIGHT + l_score * LANG_WEIGHT + i_score * INTEREST_WEIGHT);
            return final;
        }

        private int GetLangScore(User traveler, User guide)
        {
            int commonCount = traveler.Languages.Intersect(guide.Languages).ToList().Count;
            // 1 language is mandatory -> if 0 common languages: make the score negative , then check during calculation
            commonCount -= 1;
            int score = (int)Math.Round((double)(commonCount / traveler.Languages.Count)) * 100;
            
            score -= (int)Math.Round((double)(1 / traveler.Languages.Count)) * 100;
            return score;
        }
        private int GetInterestScore(User traveler, User guide)
        {
            int commonCount = traveler.Interests.Intersect(guide.Interests).ToList().Count;
            int score = (int)Math.Round((double)(commonCount / traveler.Interests.Count)) * 100;
            return score;
        }
        private int GetAgeScore(User traveler, User guide)
        {
            int ageDiff = GetAgeDifference(traveler.BirthDate, guide.BirthDate);
            int partialScore = -(ageDiff) + MAX_AGE_GAP;
            int score = (int)Math.Round((double)(partialScore / MAX_AGE_GAP)) * 100;
            return score;
        }

        private int GetAgeDifference(DateTime tAge, DateTime gAge)
        {
            var yearNow = DateTime.Now.Year;
            var ageTraveler = yearNow - tAge.Year;
            var ageGuide = yearNow - gAge.Year;

            int ageDiff = Math.Abs(ageTraveler - ageGuide);
            return ageDiff;
        }


    }
}
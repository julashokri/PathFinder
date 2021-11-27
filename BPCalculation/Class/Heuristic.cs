using PathFinder.Interface;
using System;
using System.Linq;


namespace PathFinder.Class
{
    public class Heuristic : IHeuristic
    {
        public int Distance(string word1, string word2)
        {
            return word1.Where((ch, index) => Char.ToLower(ch) != Char.ToLower(word2[index])).Count();
        }

        public bool SatisfyStepForward(string word1, string word2)
        {
            return Distance(word1, word2) == 1;
        }
    }
}

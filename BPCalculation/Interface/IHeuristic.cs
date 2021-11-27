namespace PathFinder.Interface
{
    public interface IHeuristic
    {
        int Distance(string word1, string word2);

        bool SatisfyStepForward(string word1, string word2);
    }
}

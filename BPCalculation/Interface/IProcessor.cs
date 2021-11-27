using PathFinder.DataObjects;
using System.Collections.Generic;

namespace PathFinder.Interface
{
    public interface IProcessor
    {
        List<Word> WordDictionary { get; set; }

        List<Word> FindPath(string startWord, string endWord);
    }
}

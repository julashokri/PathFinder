using PathFinder.DataObjects;
using PathFinder.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder.Class
{
    public class Processor : IProcessor
    {
        public List<Word> WordDictionary { get; set; }

        private IHeuristic _heuristic;

        public Processor(List<Word> wordDictionary, IHeuristic heuristic)
        {
            WordDictionary = wordDictionary;
            _heuristic = heuristic;
        }

        public List<Word> FindPath(string startWord, string endWord)
        {
            List<Word> path = new List<Word>();
            path.Add(new Word() { Value = startWord });
            while(path.Count > 0 && path[^1].Value.ToLower() != endWord.ToLower() && path[^1].Value.ToLower() != null)
            {
                Word nextWord = WordDictionary.Where(x => _heuristic.SatisfyStepForward(path[^1].Value, x.Value) && !x.Used)
                                              .OrderBy(x => _heuristic.Distance(x.Value, endWord))
                                              .FirstOrDefault();

                if (nextWord != null)
                {
                    nextWord.Used = true;
                    path.Add(nextWord);
                }
                else
                {
                    //one step back
                    path.RemoveAt(path.Count - 1);
                }
            }
            return path;
        }

        
    }
}

using PathFinder.DataObjects;
using PathFinder.Interface;
using System;
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
            try
            {
                List<Word> path = new List<Word>();
                path.Add(new Word() { Value = startWord });
                while (!ListIsEmpty(path) && !IsGoalFound(path, endWord))
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
                if (ListIsEmpty(path))
                    path.Add(new Word() { Value = "Path not found!:(" });
                return path;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Processor.FindPath :"+ ex.Message);
                return null;
            }
        }

        private bool ListIsEmpty(List<Word> path)
        {
            return path.Count == 0;
        }

        private bool IsGoalFound(List<Word> path, string endWord)
        {
            return string.Equals(path[^1].Value.ToLower(), endWord.ToLower());
        }
    }
}

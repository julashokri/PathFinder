using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathFinder.Interface;
using PathFinder.Class;
using PathFinder.DataObjects;
using System.Collections.Generic;

namespace BPUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIFDistanceOfTheWordsCalculateCorrectly()
        {
            IHeuristic heuristic = new Heuristic();
            Assert.AreEqual(3, heuristic.Distance("Spin","star"));
            Assert.AreEqual(0, heuristic.Distance("Spin","sPIn"));
            Assert.AreEqual(0, heuristic.Distance("",""));
        }

        [TestMethod]
        public void TestIFSatisfyNextStepWorksCorrectly()
        {
            IHeuristic heuristic = new Heuristic();
            Assert.IsFalse(heuristic.SatisfyStepForward("Spin", "Spin"));
            Assert.IsFalse(heuristic.SatisfyStepForward("Spit", "Spon"));
            Assert.IsFalse(heuristic.SatisfyStepForward("", ""));
            Assert.IsTrue(heuristic.SatisfyStepForward("Spin", "Spit"));
        }

        [TestMethod]
        public void TestIFAgorithm()
        {
            IHeuristic heuristic = new Heuristic();
            List<Word> dictionary = InitializeDictionary();
            IProcessor processor = new Processor(dictionary, heuristic);
            List<Word> path = processor.FindPath("Spin", "Spot");

            Assert.AreEqual(3, path.Count);
            Assert.AreEqual("Spin", path[0].Value);
            Assert.IsTrue(heuristic.SatisfyStepForward("Spin", path[1].Value));
            Assert.IsTrue(heuristic.SatisfyStepForward(path[1].Value, "Spot"));
            Assert.AreEqual("Spot", path[2].Value);
        }


        internal List<Word> InitializeDictionary()
        {
            return new List<Word>() 
            {
                new Word {Value = "Spin" },
                new Word {Value = "Spot" },
                new Word {Value = "Span" },
                new Word {Value = "Spat" },
                new Word {Value = "Spit" }
            };

        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

using PathFinder.Class;
using PathFinder.Interface;
using PathFinder.DataObjects;

namespace BP
{
    class Program
    {
        static void Main(string[] args)
        {
            //if(args.Length < 4)
            //{
            //    args = new string[] {"in.txt","Spin","Spot","out.txt" };
            //}
            if (IncorrectInputArrguments(args))
            {
                Console.WriteLine("Please check your input argumnets.");
                return;
            }
            try
            {
                //input
                IStreamHelper streamHelper = new StreamHelper();
                List<Word> dictionary = streamHelper.ReadFile(args[0], args[1].Length);

                IHeuristic heuristic = new Heuristic();

                //process
                IProcessor processor = new Processor(dictionary, heuristic);
                List<Word> path = processor.FindPath(args[1], args[2]);

                //output
                streamHelper.WriteFile(args[3], path);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        internal static bool IncorrectInputArrguments(string[] args)
        {
            try
            {
                if (args == null)
                {
                    return true;
                }
                if (args[1].Length != args[2].Length || args[1].Length < 2)
                {
                    return true;
                }
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine("Inoput file doesn't exist");
                    return true;
                }
                if (string.IsNullOrEmpty(args[3]))
                {
                    Console.WriteLine("Output file name is empty");
                    return true;
                }
            }
            catch
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using PathFinder.Interface;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using PathFinder.DataObjects;

namespace PathFinder.Class
{
    public class StreamHelper : IStreamHelper
    {
        public List<Word> ReadFile(string path, int wordSize)
        {
            List<Word> result = new List<Word>();
            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    if (line.Length == wordSize)
                    {
                        result.Add(new Word { Value = line , Used = false});
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errors occured: {0}", ex.Message);
            }
            return result;
        }

        public async Task<bool> WriteFile(string path, List<Word> output)
        {
            if (string.IsNullOrEmpty(path) || output == null)
            {
                return false;
            }
            try
            {
                string formattedOutput = string.Join(',', output.Select(x => x.Value));
                await File.WriteAllTextAsync(path, formattedOutput);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errors occured: {0}", ex.Message);
                return false;
            }
        }
    }
}

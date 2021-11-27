using PathFinder.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinder.Interface
{
    public interface IStreamHelper
    {
        /// <summary>
        /// Read file contents and peresents each line as string
        /// </summary>
        /// <param name="path">path for the file</param>
        /// <returns>one string per line</returns>
        List<Word> ReadFile(string path, int wordSize);

        Task<bool> WriteFile(string path, List<Word> output);

        //List<string> Filter(List<string> input, List<IInputRule> rules); 

    }
}

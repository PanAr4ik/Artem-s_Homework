
using System.Text.RegularExpressions;

namespace EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Это пример текста.В этом тексте слово текст встречается два два раза текст раза.";

            char[] separators = { ' ', ',', '!', '?' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries); 

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string lowerWord = word.ToLower(); 
                if (wordCount.ContainsKey(lowerWord))
                    wordCount[lowerWord]++;
                else
                    wordCount.Add(lowerWord, 1);
            }

            foreach (var entry in wordCount)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }


        }
    }
}

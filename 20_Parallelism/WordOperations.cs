using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _20_Parallelism
{
    class WordOperations
    {
        private static string[] _words;

        public static void Run()
        {
            Console.WriteLine("Pobieranie danych...");
            _words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            Console.WriteLine($"Znaleziono {_words.Count()} słów.");

            Console.Error.WriteLine("Sekwencyjne wykonanie operacji...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RunSequential();
            stopwatch.Stop();
            Console.Error.WriteLine("Czas wykonania: {0}ms", stopwatch.ElapsedMilliseconds);


            Console.Error.WriteLine("Równoległe wykonanie operacji...");
            stopwatch = new Stopwatch();
            stopwatch.Start();

            RunParaller();
            stopwatch.Stop();
            Console.Error.WriteLine("Czas wykonania: {0}ms", stopwatch.ElapsedMilliseconds);
        }

        static void RunSequential()
        {
            Console.WriteLine("Zacznij pierwsze zadanie...");
            GetLongestWord(_words);

            Console.WriteLine("Zacznij drugie zadanie...");
            GetMostCommonWords(_words);

            Console.WriteLine("Zacznij trzecie zadanie...");
            GetCountForWord(_words, "sleep");
        }

        static void RunParaller()
        {
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Zacznij pierwsze zadanie...");
                    GetLongestWord(_words);
                },
                () =>
                {
                    Console.WriteLine("Zacznij drugie zadanie...");
                    GetMostCommonWords(_words);
                },
                () =>
                {
                    Console.WriteLine("Zacznij trzecie zadanie...");
                    GetCountForWord(_words, "sleep");
                }
            );
        }

        private static void GetCountForWord(string[] words, string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;

            Console.WriteLine($@"Zadanie 3 -- Słowo ""{term}"" występuje {findWord.Count()} razy.");
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            var commonWords = frequencyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Zadanie 2 -- Najczęściej występujące słowa to:");
            foreach (var v in commonWords)
            {
                sb.AppendLine("  " + v);
            }
            Console.WriteLine(sb.ToString());
        }

        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words
                               orderby w.Length descending
                               select w).First();

            Console.WriteLine($"Zadanie 1 -- Najdłuższe słowo to {longestWord}.");
            return longestWord;
        }

        static string[] CreateWordArray(string uri)
        {
            Console.WriteLine($"Pobieranie danych z {uri}");

            string s = new WebClient().DownloadString(uri);

            return s.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
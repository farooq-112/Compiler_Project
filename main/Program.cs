using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Program
{
    class Program
    {
        static readonly string textFile = "assets/sample.txt";
       

        static void Main(String[] args)
        {
            
             string text = File.ReadAllText(textFile); 

            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();
            Dictionary<int, Tuple<int, string>> value = lexicalAnalyzer.BreakWord( text);
            var g =lexicalAnalyzer.classPart(ref value);
            foreach (var item in value)
            {
                Console.Write(item.Key + ":");
                Console.WriteLine(item.Value);
            }

             foreach (var item in g)
            {
                Console.Write(item.Key + ":");
                Console.WriteLine(item.Value);
            }
        }
    }
}

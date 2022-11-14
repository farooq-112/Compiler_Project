
using System.IO;
namespace Program
{
    class Program
    {
        static readonly string textFile = "assets/sample.txt";
        static readonly string tokenFile = "assets/farooq.txt";
        public static void Main(String[] args)
        {
            string text = File.ReadAllText(textFile);

            // breakWord
            LexicalGenerartor program = new LexicalGenerartor();  // Creating Object  
            Dictionary<int, Tuple<int, string>> words = program.breakWord(ref text); // Calling Function    
            Dictionary<int, Tuple<int, string, string>> classes = program.classPart(ref words);
            StreamWriter sw = new StreamWriter(tokenFile);
            foreach (var item in classes)
            {
                sw.WriteLine(item.Key + "::" + item.Value);
                // Console.Write(item.Key + "::"); Console.WriteLine(item.Value);

            }
            sw.Close();

            string tokenSet = File.ReadAllText(tokenFile);
            SyntaxGenerator syntaxGenerator = new SyntaxGenerator();
            syntaxGenerator.starting(ref classes);

        }
       
    }
}
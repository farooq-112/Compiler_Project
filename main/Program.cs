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
            var tem = "";
            List<string> list = new List<string>();
            foreach (var i in text)
            {
                if (i == ' ')
                {
                    foreach (var j in Constant.keywords)
                    {
                        if (tem == j)
                        {
                            Console.WriteLine(tem + ":  KeyWord");
                        }
                    }
                    list.Add(tem);
                    tem = "";
                }
                else
                {
                    tem += i;
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine(item + "\n");
            }
        }
    }
}

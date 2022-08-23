using System;
using System.IO;

namespace Program
{
    class Program
    {
        static readonly string textFile = "assets/sample.txt"; 
        static void Main(String[] args){
            Console.WriteLine("Hello ");
            
             string text = File.ReadAllText(textFile);  
             Console.WriteLine(text);  
            
        }
    
 
    }

}

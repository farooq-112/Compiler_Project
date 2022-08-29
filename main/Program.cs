using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Program
{
    class Program
    {
        static readonly string textFile = "assets/sample.txt";

        // isKeyword Function Start
         public bool isKeyword(string message)  
        {  
            // Console.WriteLine("Hello " + message);  
            
                if(Constant.keywords.Contains(message.Trim()))
                {
                    return true;
                }else if(Constant.oopKeywords.Contains(message.Trim())){
                    return true;
                    // Console.WriteLine(message + ":  KeyWord", "class : " + "OOP Keyword");
                }else if(Constant.dataTypes.Contains(message.Trim())){
                    return true;
                    // Console.WriteLine(message + ":  KeyWord", "class : " + "DataType");
                }else if(Constant.accessModifier.Contains(message.Trim())){
                    return true;
                    // Console.WriteLine(message + ":  KeyWord", "class : " + "Access Modifier");
                }
            return false;
            // No return statement  
        } 
        // isKeyword Function End

        // isOperator Function Start
         public void isOperator(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isOperator Function End
        
        // isIdentifier Function Start
         public void isIdentifier(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isIdentifier Function End
        
        // isCharacter Function Start
         public void isCharacter(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isCharacter Function End
        
        // isInt Function Start
         public void isInt(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isInt Function End
        
        // isFloat Function Start
         public void isFloat(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isFloat Function End
        
        // isString Function Start
         public void isString(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isString Function End
        
        // isPunctuator Function Start
         public void isPunctuator(string message)  
        {  
            Console.WriteLine("Hello " + message);  
            // No return statement  
        } 
        // isPunctuator Function End

        // breakWord Function Start
         public void breakWord()  
        {  
            string text = File.ReadAllText(textFile);
            var tem = "";
            List<string> list = new List<string>();
            foreach (var i in text)
            {
                if (i != '\r')
                {
                    if (i == ' ')
                    {
                        if (isKeyword(tem))
                        {
                        Console.WriteLine(tem + ":  KeyWord, class : Access Modifier");   
                        }
                        
                        list.Add(tem.Trim());
                        tem = "";
                    }
                    else
                    {
                        tem += i;
                    }
                }else{
                    list.Add(tem.Trim());
                    tem = "";
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine(item + item.Length + "");
            }
        } 
        // breakWord Function End

        static void Main(String[] args)
        {
            // isKeyword

            // isOperator

            // isIdentifier

            // isCharacter

            // isInt
            
            // isFloat

            // isString

            // isPunctuator

            // breakWord
            Program program = new Program(); // Creating Object  
            program.breakWord(); // Calling Function    
            
        }
    }
}

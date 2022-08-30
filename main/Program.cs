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

            if (Constant.keywords.Contains(message.Trim()))
            {
                Console.WriteLine(message + ":  KeyWord  , class :  Keyword");
            }
            else if (Constant.oopKeywords.Contains(message.Trim()))
            {

                Console.WriteLine(message + ":  KeyWord, class :  OOP Keyword");
            }
            else if (Constant.dataTypes.Contains(message.Trim()))
            {

                Console.WriteLine(message + ":  KeyWord, class :  DataType");
            }
            else if (Constant.accessModifier.Contains(message.Trim()))
            {

                Console.WriteLine(message + ":  KeyWord, class :  Access Modifier");
            }
            return false;
            // No return statement  
        }
        // isKeyword Function End

        // isOperator Function Start
        public void isOperator(string message)
        {
            // Console.WriteLine("Hello " + message);
            foreach (char c in message)
            {
                if (Constant.arithematic.Contains(c))
                {
                    Console.WriteLine(c + ":  Operator, class :  Operator");
                }
            }

            // No return statement  
        }
        // isOperator Function End

        // isIdentifier Function Start
        public void isIdentifier(string message)
        {
            var isIdentifier = @"^@?[\p{L}\p{Nl}_][\p{Cf}\p{L}\p{Mc}\p{Mn}\p{Nd}\p{Nl}\p{Pc}]*$";
            if (Regex.IsMatch(message, isIdentifier, RegexOptions.CultureInvariant))
            {
                if (isInt(message))
                {
                    Console.WriteLine(message + ":  Int, class :  DataType");
                }
                else if (isFloat(message))
                {
                    Console.WriteLine(message + ":  Float, class :  DataType");

                }
                else if (isCharacter(message))
                {
                    Console.WriteLine(message + ":  Character, class :  DataType");
                }
                else if (isString(message))
                {
                    Console.WriteLine(message + ":  String, class :  DataType");
                }
                else
                {
                    Console.WriteLine(message + ":  Identifier, class :  Identifier");
                }
            }

            // No return statement  
        }
        // isIdentifier Function End

        // isCharacter Function Start
        public bool isCharacter(string message)
        {
            var isChar = @"\b[M]\w+";
            if (Regex.IsMatch(message, isChar, RegexOptions.CultureInvariant))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // isCharacter Function End

        // isInt Function Start
        public bool isInt(string message)
        {
            var isInteger = @"^[0-9]*$";
            if (Regex.IsMatch(message, isInteger, RegexOptions.CultureInvariant))
            {
                return true;
            }
            else
            {
                return false;
            }
            // No return statement  
        }
        // isInt Function End

        // isFloat Function Start
        public bool isFloat(string message)
        {
            var isFloat = @"^[0-9]*(?:\.[0-9]*)?$";
            if (Regex.IsMatch(message, isFloat, RegexOptions.CultureInvariant))
            {
                return true;
            }
            else
            {
                return false;
            }
            // No return statement  
        }
        // isFloat Function End

        // isString Function Start
        public bool isString(string message)
        {
            var isString = @"^[0-9]*(?:\.[0-9]*)?$";
            if (Regex.IsMatch(message, isString, RegexOptions.CultureInvariant))
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        // isString Function End

        // isPunctuator Function Start
        public void isPunctuator(string message)
        {
           foreach (char c in message)
            {
            if (Constant.punctuator.Contains(c)){
                Console.WriteLine(c + ":  Punctuator, class :  Punctuator");
            }
            }
            
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
                // if (i != '\r')
                // {
                if (i == ' ' || i == '\n')
                {
                    isKeyword(tem);
                    isOperator(tem);
                    isIdentifier(tem);
                    isPunctuator(tem);

                    list.Add(tem.Trim());
                    tem = "";
                }
                else
                {
                    tem += i;
                }
                // }else{
                //     list.Add(tem.Trim());
                //     tem = "";
                // }
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

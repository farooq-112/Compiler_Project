using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Program
{
    class Program
    {
        static readonly string textFile = "assets/sample.txt";
        static int lineNumber = 1;

        // isKeyword Function Start
        // public bool isKeyword(string message)
        // {
        //     // Console.WriteLine("Hello " + message);  

        //     if (Constant.keywords.Contains(message.Trim()))
        //     {
        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord  , class :  Keyword");
        //     }
        //     else if (Constant.oopKeywords.Contains(message.Trim()))
        //     {

        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord, class :  OOP Keyword");
        //     }
        //     else if (Constant.dataTypes.Contains(message.Trim()))
        //     {

        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord, class :  DataType");
        //     }
        //     else if (Constant.accessModifier.Contains(message.Trim()))
        //     {

        //         Console.WriteLine("line no :" + lineNumber +" "+ message + ":  KeyWord, class :  Access Modifier");
        //     }
        //     return false;
        //     // No return statement  
        // }
        // // isKeyword Function End

        // // isOperator Function Start
        // public void operator_seperator(char message)
        // {
        //     // Console.WriteLine("Hello " + message);
        //     if(message == '+')
        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  Addition, class :  Operator");
        //     if(message == '-')
        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  Subtraction, class :  Operator");
        //     if(message == '*')
        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  Multiply, class :  Operator");
        //     if(message == '/')
        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  Divide, class :  Operator");
        //     if(message == '%')
        //         Console.WriteLine("line no :" + lineNumber +" " + message + ":  Modular, class :  Operator");
        //     // foreach (char c in message)
        //     // {
        //     //     if (Constant.arithematic.Contains(c))
        //     //     {
        //     //         Console.WriteLine(c + ":  Operator, class :  Operator");
        //     //     }
        //     // }

        //     // No return statement  
        // }
        // // isOperator Function End

        // // isOperator Function Start
        // public static bool isOperator(string message)
        // {
        //     foreach (char c in message)
        //     {
        //          if (Constant.arithematic.Contains(c))
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        //     // No return statement  
        // }
        // // isOperator Function End

        // // isIdentifier Function Start
        // public void isIdentifier(string message)
        // {
        //     var isIdentifier = @"^@?[\p{L}\p{Nl}_][\p{Cf}\p{L}\p{Mc}\p{Mn}\p{Nd}\p{Nl}\p{Pc}]*$";
        //     if (Regex.IsMatch(message, isIdentifier, RegexOptions.CultureInvariant))
        //     {
        //         if (isInt(message))
        //         {
        //             Console.WriteLine("line no :" + lineNumber +" " + message + ":  Int, class :  DataType");
        //         }
        //         else if (isFloat(message))
        //         {
        //             Console.WriteLine("line no :" + lineNumber +" " + message + ":  Float, class :  DataType");

        //         }
        //         else if (isCharacter(message))
        //         {
        //             Console.WriteLine("line no :" + lineNumber +" " + message + ":  Character, class :  DataType");
        //         }
        //         else if (isString(message))
        //         {
        //             Console.WriteLine("line no :" + lineNumber +" " + message + ":  String, class :  DataType");
        //         }
        //         else
        //         {
        //             Console.WriteLine("line no :" + lineNumber +" " + message + ":  Identifier, class :  Identifier");
        //         }
        //     }

        // No return statement  
        // }
        // isIdentifier Function End

        // isCharacter Function Start
        // public bool isCharacter(string message)
        // {
        //     var isChar = ;
        //     if (Regex.IsMatch(message, isChar, RegexOptions.CultureInvariant))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
        // // isCharacter Function End

        // // isInt Function Start
        // public bool isInt(string message)
        // {
        //     var isInteger = ;
        //     if (Regex.IsMatch(message, isInteger, RegexOptions.CultureInvariant))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        //     // No return statement  
        // }
        // // isInt Function End

        // // isFloat Function Start
        // public bool isFloat(string message)
        // {
        //     var isFloat =;
        //     if (Regex.IsMatch(message, isFloat, RegexOptions.CultureInvariant))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        //     // No return statement  
        // }
        // // isFloat Function End

        // // isString Function Start
        // public bool isString(string message)
        // {
        //     var isString = @"^[0-9]*(?:\.[0-9]*)?$";
        //     if (Regex.IsMatch(message, isString, RegexOptions.CultureInvariant))
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
        // // isString Function End

        // // isPunctuator Function Start
        // public void isPunctuator(string message)
        // {
        //    foreach (char c in message)
        //     {
        //     if (Constant.punctuator.Contains(c)){
        //         Console.WriteLine("line no : "+ lineNumber + " " + c + ":  Punctuator, class :  Punctuator");
        //     }
        //     }

        // }
        // // isPunctuator Function End

        // lineIncrease Function Start

        private static string getString(ref string text,ref int i){
            string tem = "";
            tem += text[i];
            i++;
            while (i < text.Length)
            {
                if (text[i]== '\n')
                {
                    i++;
                    lineIncrease(ref i);
                    return tem;
                }
                if (text[i] == '\"')
                {
                    
                        tem += text[i];
                        return tem;
                }else{
                    tem += text[i];
                    i++;
                }
                
            }
            return tem;
        }




        private static bool lineIncrease(ref int i)
        {
            // Line Increment Function 
            lineNumber++;
            i++;
            return true;
        }
        // lineIncrease Function End

        // singleLineComment Function Start
        private static bool singleLineComment(ref string input, ref int index)
        {
            // Single Line Comment
            while (index < input.Length)
            
            {
                Console.WriteLine(input[index]);
                if (input[index] == '\n')
                {
                    index++;
                    lineNumber++;
                    return true;
                }
                index++;
            }
            Console.WriteLine(input[index]);
            return true;
        }
        // singleLineComment Function End

        // multiLineComment Function Start
        static bool multiLineComment(ref string input,ref int index)
        {
            // Multiline Comment Function
            while (index < input.Length)
            {
                Console.Write(input[index]);
                if (input[index] == '\n')
                {
                    index++;
                    // i = index;            
                    lineIncrease(ref index);
                }

                if (input[index] == '*')
                {
                    if (input[index + 1] == '/')
                    {
                        index += 1;
                        return true;
                    }
                }
                index++;
                // i = index;
            }
            return true;
        }
        // multiLineComment Function End

        // breakWord Function Start
        public Dictionary<int, Tuple<int, string>> breakWord(string text)
        {
            var breakWords = new Dictionary<int, Tuple<int, string>>();
            int key = 0;
            var tem = "";
            List<string> list = new List<string>();
            int i = 0;
            while (i < text.Length)
            {
                if (Constant.operators.ContainsKey(text[i].ToString()))
                {
                    if (text[i] == '/')
                    {
                        if (text[i + 1] == '/')
                        {
                            i += 2;
                            singleLineComment(ref text, ref i);
                        }
                        else if (text[i + 1] == '*')
                        {
                            i += 2;
                            multiLineComment(ref text, ref i);
                        }else if (text[i+1]== '='){
                            tem += "/=";
                            i += 2;
                        }else{
                            string word = text[i].ToString();
                            i++;
                            breakWords.Add(key, Tuple.Create(lineNumber, word));
                        }
                        tem = "";
                    }else if(text[i] != '/'){
                        i++;
                    }
                
                }
                if(text[i]== '\"'){
                    string word = getString(ref text,ref i);
                    breakWords.Add(key, Tuple.Create(lineNumber,word));
                }

                else
                {
                     Console.WriteLine(tem);
                            Console.WriteLine(i);
                    tem += text[i];
                    i++;
                }


            }
            return breakWords;
        }
        // breakWord Function End

        static void Main(String[] args)
        {

            string text = File.ReadAllText(textFile);
         

            // breakWord
            Program program = new Program(); // Creating Object  
            program.breakWord(text); // Calling Function    

        }
    }
}

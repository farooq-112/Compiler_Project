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
        static int i = 0;

        // isKeyword Function Start
        public bool isKeyword(string message)
        {
            // Console.WriteLine("Hello " + message);  

            if (Constant.keywords.Contains(message.Trim()))
            {
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord  , class :  Keyword");
            }
            else if (Constant.oopKeywords.Contains(message.Trim()))
            {

                Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord, class :  OOP Keyword");
            }
            else if (Constant.dataTypes.Contains(message.Trim()))
            {

                Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord, class :  DataType");
            }
            else if (Constant.accessModifier.Contains(message.Trim()))
            {

                Console.WriteLine("line no :" + lineNumber +" "+ message + ":  KeyWord, class :  Access Modifier");
            }
            return false;
            // No return statement  
        }
        // isKeyword Function End

        // isOperator Function Start
        public void operator_seperator(char message)
        {
            // Console.WriteLine("Hello " + message);
            if(message == '+')
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  Addition, class :  Operator");
            if(message == '-')
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  Subtraction, class :  Operator");
            if(message == '*')
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  Multiply, class :  Operator");
            if(message == '/')
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  Divide, class :  Operator");
            if(message == '%')
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  Modular, class :  Operator");
            // foreach (char c in message)
            // {
            //     if (Constant.arithematic.Contains(c))
            //     {
            //         Console.WriteLine(c + ":  Operator, class :  Operator");
            //     }
            // }

            // No return statement  
        }
        // isOperator Function End

        // isOperator Function Start
        public static bool isOperator(string message)
        {
            foreach (char c in message)
            {
                 if (Constant.arithematic.Contains(c))
                {
                    return true;
                }
            }
            return false;
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
                    Console.WriteLine("line no :" + lineNumber +" " + message + ":  Int, class :  DataType");
                }
                else if (isFloat(message))
                {
                    Console.WriteLine("line no :" + lineNumber +" " + message + ":  Float, class :  DataType");

                }
                else if (isCharacter(message))
                {
                    Console.WriteLine("line no :" + lineNumber +" " + message + ":  Character, class :  DataType");
                }
                else if (isString(message))
                {
                    Console.WriteLine("line no :" + lineNumber +" " + message + ":  String, class :  DataType");
                }
                else
                {
                    Console.WriteLine("line no :" + lineNumber +" " + message + ":  Identifier, class :  Identifier");
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
                Console.WriteLine("line no : "+ lineNumber + " " + c + ":  Punctuator, class :  Punctuator");
            }
            }
            
        }
        // isPunctuator Function End

        // lineIncrease Function Start
        public static bool lineIncrease(int lineno)
        {
            // Line Increment Function 
            lineNumber++;
            // index++;
            return true;
        }
        // lineIncrease Function End

        // singleLineComment Function Start
        public static bool singleLineComment(string input, int index)
        {
           // Single Line Comment
            while (index < input.Length)
            {
                if (input[index] == '\r')
                {
                    index++;
                    i = index;            
                    lineNumber++;
                    return true;
                }
                index++;
                i = index;
            }
            return true;
        }
        // singleLineComment Function End

        // multiLineComment Function Start
        static bool multiLineComment(string input, int index)
        {
            // Multiline Comment Function
            while (index < input.Length)
            {
                if (input[index] == '\r')
                {
                    index++;
                    // i = index;            
                    lineNumber++;
                    // lineIncrease(int lineno);
                }

                if (input[index] == '*')
                {
                    if (input[index + 1] == '/')
                    {
                        index += 1;
                        i = index;
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
        public void breakWord(string text)
        {
            // for indexing through each character
            // int i = 0;
            var tem = "";
            List<string> list = new List<string>();
            while (i < text.Length)
            {
                if(isOperator(text[i].ToString())){
                    if (text[i] == '/')
                    {
                        if (text[i + 1] == '/')
                        {
                            i += 2;
                            singleLineComment(text, i);
                        }
                        else if (text[i + 1] == '*')
                        {
                            i += 2;
                            multiLineComment(text, i);
                        }
                        // else if (text[i + 1] == '=')
                        // {
                        //     tem += "/=";
                        //     i += 2;
                        //     wordList.Add(id, Tuple.Create(lineNumber, temp));
                        // }
                        // else
                        // {
                        //     string word = text[i].ToString();
                        //     i++;
                        //     wordList.Add(id, Tuple.Create(lineNumber, word));
                        // }
                        // temp = "";
                    }else if(text[i] != '/'){
                        operator_seperator(text[i]);
                        i++;
                    }
                }
                if (text[i] == ' ' || text[i] == '\n' || text[i] == '\r')
                {
                    // Console.WriteLine("i = "+i);
                    isKeyword(tem);
                    // isOperator(tem);
                    isIdentifier(tem);
                    isPunctuator(tem);

                    list.Add(tem.Trim());
                    tem = "";
                    i++;
                    try{
                        if(text[i] == '\n')
                        lineNumber++;
                    }
                    catch{}
                    // if(text[i] == '\n')
                    //     lineNumber++;
                }
                else
                {
                    tem += text[i];
                    i++;
                }
                
                // if character isOperator
                
                
                // }else{
                //     list.Add(tem.Trim());
                //     tem = "";
                // }
            }
            foreach (var item in list)
            {
                // Console.WriteLine(item + item.Length + "");
            }
        }
        // breakWord Function End

        static void Main(String[] args)
        {

            string text = File.ReadAllText(textFile);
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
            program.breakWord(text); // Calling Function    

        }
    }
}

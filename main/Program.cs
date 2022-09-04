using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Program
{
    class Program
    {
        public IDictionary<char, string> punctuators = new Dictionary<char, string>() {
            {'(', "("}, {')',")"}, {'{', "{"}, {'}', "}"}, {'[', "["}, {']', "]"}, {';',";"}, {'.', "."}, {',', ","},
            {'@', "lexical_error"}, {'$', "lexical_error"}, {'^', "lexical_error"}, {':', "lexical_error"}, {'?',"lexical_error"},
            {'`', "lexical_error"}, {'~', "lexical_error"}, {'\'', "lexical_error"}, {'_', "lexical_error"}, {'\\', "lexical_error"},
        };

        // Operators
        // dictionary for operators and its classpart
        public IDictionary<string, string> operators = new Dictionary<string, string>() {
            {"+", "PM"}, {"-", "PM"},
            { "*", "MD"}, {"/", "MD"},
            { "<", "RO"}, {">", "RO"}, {"<=", "RO"}, {">=", "RO"}, {"!=", "RO"}, {"==", "RO"},
            {"=", "AO"}, {"+=", "AO"}, {"-=", "AO"},
            {"&", "Lexeme error"}, {"|", "Lexeme error"},
            {"!", "LO"}, {"||", "LO"}, {"&&", "LO"},
        };

        // dictionary for keyword list
        public IDictionary<string, string> keywords = new Dictionary<string, string>(){
            {"int","dt"}, {"float","dt"}, {"bool","dt"}, {"string","dt"},
            {"public","access-modifier"}, {"static","static"}, {"class","class"},
            {"while","while"}, {"for","for"}, {"struct","struct" },
            {"if","if"}, {"else","else"}, {"break","break"}, {"continous","continous"},
            {"true","bool-const"}, {"false","bool-const"},
        };

        // dictionary for regex
        public IDictionary<string, string> regexs = new Dictionary<string, string>() {
            {"integer", @"^\d*$"}, {"float", @"^(\d*.\d+|\d*[^.])$"}, {"number", @"^[0-9]$"},
            {"alphabtes" , @"^[A-Za-z]$"}, {"identifier", @"^([a-zA-Z]+_[0-9])$"},
            {"punctuators", @"^,|.|;|[|]|(|)|{|}|:$"}, {"all_punctuators", @"^[\x20-\x2F]|[\x3A-\x40]|[\x5B-\x5E]|[\x7B-\x7E]|`$"}
        };

        static readonly string textFile = "assets/sample.txt";
        // Dictionary<int, List<Tuple<int, string>>> wordList = new Dictionary<int, Tuple<int, string>>();
        Dictionary<int, Tuple<int, string>> wordList = new Dictionary<int, Tuple<int, string>>();
        // var wordList = new Dictionary<int, Tuple<int, string>>();
        static int lineNumber = 1;
        static int id = 1;
        
        static int i = 0;

        // isKeyword Function Start
        public bool isKeyword(string message)
        {
            // Console.WriteLine("Hello " + message);  

            if (keywords.ContainsKey(message.Trim()))
            {
                Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord  , class :  Keyword");
            }
            // else if (Constant.oopKeywords.Contains(message.Trim()))
            // {

            //     Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord, class :  OOP Keyword");
            // }
            // else if (Constant.dataTypes.Contains(message.Trim()))
            // {

            //     Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord, class :  DataType");
            // }
            // else if (Constant.accessModifier.Contains(message.Trim()))
            // {

            //     Console.WriteLine("line no :" + lineNumber +" "+ message + ":  KeyWord, class :  Access Modifier");
            // }
            return false;
            // No return statempent  
        }
        // isKeyword Function End

        // isOperator Function Start
        public static string operator_seperator(string input, int index)
        {
            string temp = "";
            temp += input[index]; //*

            // if Character is * then 2 possibilities
            // *: Multiply operator
            // *=: multiply asgt 
            if (input[index] == '*')
            {
                if (input[index + 1] == '=')
                {
                    temp += input[index + 1];  //*=
                    index += 2;
                    return temp;
                }
                else
                {
                    // Multiply operator
                    string word = input[index].ToString();
                    index++;
                    return word;
                }
            }

            // if Character is + then 3 possibilities
            else if (input[index] == '+')
            {
                if (input[index + 1] == '+' && !isDigit(input[index + 2].ToString()))
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                else if (input[index + 1] == '=')
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                // else if (isDigit(input[index + 1].ToString()))
                // {
                //     if ((index - 1 >= 0 && index - 1 < input.Length))
                //     {
                //         if (!Char.IsLetterOrDigit(input[index - 1]))
                //         {
                //             index++;
                //             do
                //             {
                //                 temp += input[index];
                //                 index++;

                //             } while (Char.IsDigit(input[index]));
                //             return temp;
                //         }
                //         else
                //         {
                //             string word = input[index].ToString();
                //             index++;
                //             return word;
                //         }
                //     }
                //     else
                //     {
                //         index++;
                //         do
                //         {
                //             temp += input[index];
                //             index++;

                //         } while (Char.IsDigit(input[index]));
                //         return temp;
                //     }
                // }
                else
                {
                    string word = input[index].ToString();
                    index++;
                    return word;
                }
            }

             // if Character is - then 3 possibilities
            else if (input[index] == '-')
            {
                if ((input[index + 1] == '-') && !isDigit(input[index + 2].ToString()))
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                else if (input[index + 1] == '=')
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                // else if (Char.IsDigit(input[index + 1]))
                // {
                //     if ((index - 1 >= 0 && index - 1 < input.Length))
                //     {
                //         if (!Char.IsLetterOrDigit(input[index - 1]))
                //         {
                //             index++;
                //             do
                //             {
                //                 temp += input[index];
                //                 index++;

                //             } while (Char.IsDigit(input[index]));
                //             return temp;
                //         }
                //         else
                //         {
                //             string word = input[index].ToString();
                //             index++;
                //             return word;
                //         }
                //     }
                //     else
                //     {
                //         index++;
                //         do
                //         {
                //             temp += input[index];
                //             index++;

                //         } while (Char.IsDigit(input[index]));
                //         return temp;
                //     }

                // }
                else
                {
                    string word = input[index].ToString();
                    index++;
                    return word;
                }
            }

            // If Character is <,>,!,= then 4 possibilities
            else if (input[index] == '<' || input[index] == '>' || input[index] == '!' || input[index] == '=')
            {
                if (input[index + 1] == '=')
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                else
                {
                    string word = input[index].ToString();
                    index++;
                    return word;
                }
            }

            // If Character is & then 2 possibilities
            else if (input[index] == '&')
            {
                if (input[index + 1] == '&')
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                else
                {
                    string word = input[index].ToString();
                    index++;
                    return word;
                }
            }


            // If Character  | then 2 possibilities
            else if (input[index] == '|')
            {

                if (input[index + 1] == '|')
                {
                    temp += input[index + 1];
                    index += 2;
                    return temp;
                }
                else
                {
                    string word = input[index].ToString();
                    index++;
                    return word;
                }
            }
            return temp;
        
        }
        // isOperator Function End

        // isOperator Function Start
        // public static bool isOperator(string message)
        // {
        //     if (operators.ContainsKey(message.Trim()))
        //     {
        //         return true;
        //         // Console.WriteLine("line no :" + lineNumber +" " + message + ":  KeyWord  , class :  Keyword");
        //     }
        //     return false;
        // }
        // isOperator Function End

        // isIdentifier Function Start
        public bool isIdentifier(string message)
        {
            var isIdentifier = @"^@?[\p{L}\p{Nl}_][\p{Cf}\p{L}\p{Mc}\p{Mn}\p{Nd}\p{Nl}\p{Pc}]*$";
            if (Regex.IsMatch(message, isIdentifier, RegexOptions.CultureInvariant))
                return true;
            else
                return false;

            // No return statempent  
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
        public static bool isDigit(string message)
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
            // No return statempent  
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
            // No return statempent  
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
        public bool isPunctuator(string message)
        {
            return true;
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
            var temp = "";
            List<string> list = new List<string>();
            while (i < text.Length)
            {
                if(operators.ContainsKey(text[i].ToString())){
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
                        //     temp += "/=";
                        //     i += 2;
                        //     wordList.Add(id, Tuple.Create(lineNumber, tempp));
                        
                        // }
                        // else
                        // {
                        //     string word = text[i].ToString();
                        //     i++;
                        //     wordList.Add(id, Tuple.Create(lineNumber, word));
                        // }
                        // tempp = "";
                    }else if(text[i] != '/'){
                        // i++;
                        string txt = operator_seperator(text, i);
                        wordList.Add(id++, Tuple.Create(lineNumber, txt));
                        // wordList.Add(id, Tuple.Create(lineNumber, text));
                    }
                    else{
                        // string txt = operator_seperator(text, i);
                        // wordList.Add(id++, Tuple.Create(lineNumber, text[i].ToString));
                    }
                }
                if (text[i] == ' ' || text[i] == '\n' || text[i] == '\r')
                {
                    // Console.WriteLine("i = "+i);
                    if(isDigit(temp)){
                        wordList.Add(id++, Tuple.Create(lineNumber, temp));
                    }
                    else if(isIdentifier(temp)){
                        wordList.Add(id++, Tuple.Create(lineNumber, temp));
                    }
                    else if(isIdentifier(temp)){
                        wordList.Add(id++, Tuple.Create(lineNumber, temp));
                    }
                    else if(isPunctuator(temp)){
                        wordList.Add(id++, Tuple.Create(lineNumber, temp));
                    }
                    // isKeyword(temp);
                    // isOperator(temp);
                    // isIdentifier(temp);
                    // isPunctuator(temp);

                    list.Add(temp.Trim());
                    temp = "";
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
                    temp += text[i];
                    i++;
                }
                
                // if character isOperator
                
                
                // }else{
                //     list.Add(temp.Trim());
                //     temp = "";
                // }
            }
        }
        // breakWord Function End

        static void Main(String[] args)
        {

            string text = File.ReadAllText(textFile);
            // var wordList = new Dictionary<int, Tuple<int, string>>();
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

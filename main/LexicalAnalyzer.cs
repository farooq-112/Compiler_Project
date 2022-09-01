using System.Text.RegularExpressions;
namespace Program
{
    class LexicalAnalyzer
    {

        static int lineNumber = 1;

         private static string operator_separator(ref string input, ref int index)
        {
            // operator handler
            string temp = "";
            temp += input[index];

            // if Character is * then 2 possibilities
            // *: Multiply operator
            // *=: multiply asgt 
            if (input[index] == '*')
            {
                if (input[index + 1] == '=')
                {
                    temp += input[index + 1];
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
                if ((input[index + 1] == '+') && !Char.IsDigit(input[index + 2]))
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
                else if (Char.IsDigit(input[index + 1]))
                {
                    if ((index - 1 >= 0 && index - 1 < input.Length))
                    {
                        if (!Char.IsLetterOrDigit(input[index - 1]))
                        {
                            index++;
                            do
                            {
                                temp += input[index];
                                index++;

                            } while (Char.IsDigit(input[index]));
                            return temp;
                        }
                        else
                        {
                            string word = input[index].ToString();
                            index++;
                            return word;
                        }
                    }
                    else
                    {
                        index++;
                        do
                        {
                            temp += input[index];
                            index++;

                        } while (Char.IsDigit(input[index]));
                        return temp;
                    }

                }
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
                if ((input[index + 1] == '-') && !Char.IsDigit(input[index + 2]))
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
                else if (Char.IsDigit(input[index + 1]))
                {
                    if ((index - 1 >= 0 && index - 1 < input.Length))
                    {
                        if (!Char.IsLetterOrDigit(input[index - 1]))
                        {
                            index++;
                            do
                            {
                                temp += input[index];
                                index++;

                            } while (Char.IsDigit(input[index]));
                            return temp;
                        }
                        else
                        {
                            string word = input[index].ToString();
                            index++;
                            return word;
                        }
                    }
                    else
                    {
                        index++;
                        do
                        {
                            temp += input[index];
                            index++;

                        } while (Char.IsDigit(input[index]));
                        return temp;
                    }

                }
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

        private static bool singleLineComment(ref string input, ref int index)
        {
            // Single Line Comment
            while (index < input.Length)
            {
                if (input[index] == '\r')
                {
                    index++;
                    line_increase(ref index);
                    return true;
                }
                index++;
            }
            return true;
        }

        static bool multiLineComment(ref string input, ref int index)
        {
            // Multiline Comment Function
            while (index < input.Length)
            {
                if (input[index] == '\r')
                {
                    index++;
                    line_increase(ref index);
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
            }
            return true;
        }
        private static bool line_increase(ref int index)
        {
            // Line Increment Function 
            lineNumber++;
            index++;
            return true;
        }


        private static bool IsAllDigits(string s)
        {
            // Checking if string is all digits
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private static string double_quote(ref string input, ref int index)
        {
            // String Handler Function
            string temp = "";
            temp += input[index];
            index++;
            while (index < input.Length)
            {
                if (input[index] == '\r')
                {
                    index++;
                    line_increase(ref index);
                    return temp;
                }
                if (input[index] == '\"')
                {
                    if (input[index - 1] == '\\')
                    {
                        //included
                        temp += input[index];
                        temp += input[index + 1];
                        index += 2;
                    }
                    else
                    {
                        temp += input[index];
                        index++;
                        return temp;
                    }
                }
                else
                {
                    temp += input[index];
                    index++;
                }
            }
            return temp;
        }

        public Dictionary<int, Tuple<int, string>>  BreakWord(string input)
        {
            // Dictionary for word and line number
            var wordList = new Dictionary<int, Tuple<int, string>>();

            // Dictionary Key
            int id = 1;

            // for indexing through each character
            int i = 0;

            // Empty String for concatenation of characters
            string temp = "";

            while (i < input.Length)
            {
                Console.WriteLine(i);
                // Console.WriteLine(input.Trim().Length);
                // Console.WriteLine(input.Length);
                // if Char is operator
                if (Constant.operators.ContainsKey(input[i].ToString()) || input[i] == '&' || input[i] == '|')
                {
                    // if character is / then 3 possibilities 
                    // Single line comment //
                    // multi line comment /*
                    // divide /
                    if (input[i] == '/')
                    {
                        if (input[i + 1] == '/')
                        {
                            i += 2;
                            singleLineComment(ref input, ref i);
                        }
                        else if (input[i + 1] == '*')
                        {
                            i += 2;
                            multiLineComment(ref input, ref i);
                        }
                        else if (input[i + 1] == '=')
                        {
                            temp += "/=";
                            i += 2;
                            wordList.Add(id, Tuple.Create(lineNumber, temp));
                        }
                        else
                        {
                            string word = input[i].ToString();
                            i++;
                            wordList.Add(id, Tuple.Create(lineNumber, word));
                        }
                        temp = "";
                    }

                    // if Char is operator other than /
                    // it will call operator separator 
                    else if (input[i] != '/')
                    {
                        Console.WriteLine("090909"+input[i]);
                        string text = operator_separator(ref input, ref i);
                        wordList.Add(id, Tuple.Create(lineNumber, text));
                    }
                }

                // // if Character is Char or String 
                // // it will call double_quote function  
                 if (input[i] == '\"')
                {
                    string text = double_quote(ref input, ref i);
                    wordList.Add(id, Tuple.Create(lineNumber, text));
                            Console.WriteLine("hell6o"+id);
                    
                }

                //  if Character is letter or digit
                else if (Char.IsLetterOrDigit(input[i]))
                {
                    temp += input[i];
                    if (!Char.IsLetterOrDigit(input[i + 1]) && input[i + 1] != '.')
                    {
                        wordList.Add(id, Tuple.Create(lineNumber, temp));
                            Console.WriteLine("he4llo"+id);
                        temp = "";
                        i++;
                    }
                    else if (input[i + 1] == '.')
                    {
                        if (IsAllDigits(temp) && Char.IsDigit(input[i + 2]))
                        {
                            Console.Write("Yes");
                            i++;
                            temp += input[i];
                            i++;
                            do
                            {
                                temp += input[i];
                                i++;

                            } while (Char.IsDigit(input[i]));
                            wordList.Add(id, Tuple.Create(lineNumber, temp));
                            Console.WriteLine("hel3lo"+id);
                            temp = "";
                        }
                        else if (!IsAllDigits(temp))
                        {

                            wordList.Add(id, Tuple.Create(lineNumber, temp));
                            
                            Console.WriteLine("hell2o"+id);
                            temp = "";
                        }
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }

                // if Character is punctuator it will check through dictionary and add word to wordlist and handle .(integer) part too
                else if (Constant.punctuators.ContainsKey(input[i]))
                {

                    if (input[i] == '.')
                    {
                        temp += input[i];
                        if (Char.IsDigit(input[i + 1]))
                        {
                            i++;
                            temp += input[i];
                            i++;
                        }
                        else
                        {

                            wordList.Add(id, Tuple.Create(lineNumber, temp));
                            i++;
                            Console.WriteLine("hello"+id);
                        }

                    }
                    else if (input[i] != '.')
                    {
                        string word = input[i].ToString();
                            Console.WriteLine("hel12lo"+id);
                            if(wordList.ContainsKey(id)){  
                            Console.WriteLine("dict"+wordList[id]);
                            id++;
                            }
                        wordList.Add(id, Tuple.Create(lineNumber, word));
                        i++;
                    }

                }

                // Line break Checker
                else if (input[i] == '\r')
                {
                    if (input[i + 1] == '\n')
                    {
                        i++;
                        line_increase(ref i);
                    }
                    else
                    {
                        i++;
                    }
                }

                // if Character is Space
                else if (input[i] == ' ')
                {
                    temp = "";
                    i++;
                }

                // else
                else
                {
                    Console.WriteLine("error" + i) ;
                    i++;
                }

                // dictionary id increment
                id++;

                // loop end
                if (input.Length == 0)
                    break;
            }

            return wordList;
        }

    

    public Dictionary<int, Tuple<int, string, string>> classPart(ref Dictionary<int, Tuple<int, string>> list)
        {
            // Dictionary for word and line number
            var wordList = new Dictionary<int, Tuple<int, string, string>>();

            // looping through wordlist dictionary
            foreach (KeyValuePair<int, Tuple<int, string>> data in list)
            {
                if (data.Value.Item2.Equals("int") || data.Value.Item2.Equals("float") || data.Value.Item2.Equals("string")) {
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "data_type", data.Value.Item2));
                }

                else if( data.Value.Item2.Equals("true")  ||  data.Value.Item2.Equals("false") ) { 
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "bool", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("public")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "access-modifier", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("static")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "static", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("while")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "while", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("for")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "for", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("struct")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "struct", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("if")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "if", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("else")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "else", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("break")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "break", data.Value.Item2));
                }

                else if (data.Value.Item2.Equals("continue")){
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "continue", data.Value.Item2));
                }

                switch (data.Value.Item2)
                {
                    case string someVal when new Regex(Constant.regexs["integer"]).IsMatch(data.Value.Item2):
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "integer", data.Value.Item2));
                        break;

                    case var someVal when new Regex(Constant.regexs["float"]).IsMatch(data.Value.Item2):
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "float", data.Value.Item2));
                        break;

                    case var someVal when new Regex(Constant.regexs["alphabtes"]).IsMatch(data.Value.Item2):
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "str", data.Value.Item2));
                        break;

                    case var someVal when new Regex(Constant.regexs["identifier"]).IsMatch(data.Value.Item2):
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "identifier", data.Value.Item2));
                        break;

                    case var someVal when new Regex(Constant.regexs["all_punctuators"]).IsMatch(data.Value.Item2):
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "punctuator", data.Value.Item2));
                        break;

                    default:
                        // wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "Unhandled", data.Value.Item2));
                        Console.WriteLine(data.Value.Item2);
                        break;
                };
            }
            return wordList;
        }
    }
}
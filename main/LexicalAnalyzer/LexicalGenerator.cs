
using System.Text.RegularExpressions;


class LexicalGenerartor
{

    static int lineNumber = 1;


    private static string getString(ref string text, ref int i)
    {
        string tem = "";
        tem += text[i];
        i++;
        while (i < text.Length)
        {
            if (text[i] == '\n')
            {
                i++;
                lineIncrease(ref i);
                return tem;
            }
            if (text[i] == '\"')
            {
                if (text[i - 1] == '\\')
                {
                    tem += text[i];
                    tem += text[i + 1];
                    i += 2;
                }
                else
                {
                    tem += text[i];
                    i++;
                    return tem;
                }
            }
            else
            {
                tem += text[i];
                i++;
            }

        }
        return tem;
    }


    private static bool isAllDigit(string s)
    {
        foreach (char item in s)
        {
            if (!char.IsDigit(item))
            {
                return false;
            }
        }
        return true;
    }
    private static string operatorSeparator(ref string input, ref int index)
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

            }else if (input[index + 1] == '>'){
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
            if (input[index] == '\n')
            {
                index++;
                lineNumber++;
                return true;
            }
            index++;
        }
        return true;
    }
    // singleLineComment Function End

    // multiLineComment Function Start
    // multiLineComment Function Start
    // static bool multiLineComment(ref string input, ref int index)
    // {
    //     // Multiline Comment Function
    //     while (index < input.Length)
    //     {
    //         if (input[index] == '\n')
    //         {
    //             index++;
    //             // i = index;            
    //             lineNumber++;
    //             // lineIncrease(int lineno);
    //         }

    //         if (input[index] == '*')
    //         {
    //             if (input[index + 1] == '/')
    //             {
    //                 index += 1;

    //                 return true;
    //             }
    //         }
    //         index++;
    //         // i = index;
    //     }
    //     return true;
    // }
    // multiLineComment Function End

    // breakWord Function Start
    public Dictionary<int, Tuple<int, string>> breakWord(ref string text)
    {
        int id = 1;
        var breakWords = new Dictionary<int, Tuple<int, string>>();
        text = text.Trim();



        var list = new List<String>();

        if (text.Contains("*/"))
        {

        }

        var split = text.Split("\n");

        //  foreach (var i in split)
        for (int i = 0; i < split.Length; i++)

        {
            if (split[i].Contains("/*"))
            {
                lineNumber++;
                while (!split[i + 1].Contains("*/"))
                {
                    i++;
                    lineNumber++;
                }
                if (split[i + 1].Contains("*/"))
                {
                    i++;
                    lineNumber++;
                }
            }
            else
            {
                wordBreaking(split[i] + "\n", ref breakWords, ref id);
            }
        }

        return breakWords;
    }




    void wordBreaking(string text, ref Dictionary<int, Tuple<int, string>> breakWords, ref int id)
    {

        var tem = "";
        int i = 0;
        while (i < text.Length)
        {

            if (i < text.Length && Constant.operators.ContainsKey(text[i].ToString()))
            {
                if (i < text.Length && text[i] == '/')
                {
                    if (i < text.Length && text[i + 1] == '/')
                    {
                        i += 2;
                        singleLineComment(ref text, ref i);
                    }
                    // else if (i < text.Length && text[i + 1] == '*')
                    // {
                    //     i += 2;
                    //     multiLineComment(ref text, ref i);
                    // }
                    else if (i < text.Length && text[i + 1] == '=')
                    {
                        tem += "/=";
                        i += 2;
                        breakWords.Add(id++, Tuple.Create(lineNumber, tem));
                        i++;
                    }
                    else
                    {
                        string word = text[i].ToString();
                        breakWords.Add(id++, Tuple.Create(lineNumber, word));
                        i++;

                    }
                    tem = "";
                }
                else if (i < text.Length && text[i] != '/')
                {
                    string val = operatorSeparator(ref text, ref i);
                    breakWords.Add(id, Tuple.Create(lineNumber, val));
                    id++;
                    i++;
                }

            }

            if (i < text.Length && text[i] == '\"')
            {
                string word = getString(ref text, ref i);
                breakWords.Add(id, Tuple.Create(lineNumber, word));
                id++;
            }
            else if (i < text.Length && Char.IsLetterOrDigit(text[i]))
            {
                tem += text[i];
                if (!Char.IsLetterOrDigit(text[i + 1]) && text[i + 1] != '.')
                {
                    breakWords.Add(id, Tuple.Create(lineNumber, tem));
                    id++;
                    tem = "";
                    i++;
                }
                else if (i < text.Length && text[i + 1] == '.')
                {

                    if (isAllDigit(tem) && Char.IsDigit(text[i + 1]))
                    {
                        i++;
                        tem += text[i];
                        i++;
                        do
                        {
                            tem += text[i];
                            i++;
                        } while (Char.IsDigit(text[i + 2]));
                        breakWords.Add(id, Tuple.Create(lineNumber, tem));
                        id++;
                        tem = "";
                    }
                    else if (i < text.Length && !isAllDigit(tem))
                    {
                        breakWords.Add(id, Tuple.Create(lineNumber, tem));
                        i++;
                        id++;
                        tem = "";
                    }
                    else
                    {
                        i++;
                    }


                    Console.WriteLine(".");
                }
                else
                {
                    i++;
                }
            }
            else if (i < text.Length && Constant.punctuators.ContainsKey(text[i].ToString()))
            {

                if (text[i] == '.')
                {
                    tem += text[i];
                    if (Char.IsDigit(text[i + 1]))
                    {
                        i++;
                        tem += text[i];
                        i++;
                    }
                    else
                    {
                        breakWords.Add(id, Tuple.Create(lineNumber, tem));
                        tem = "";
                        id++;
                        i++;
                    }
                }
                else if (text[i] != '.')
                {
                    if (tem != null && tem != "")
                    {
                        breakWords.Add(id, Tuple.Create(lineNumber, tem));
                        id++;
                    }
                    string word = text[i].ToString();
                    breakWords.Add(id, Tuple.Create(lineNumber, word));
                    i++;
                    id++;
                }
            }
            // Agar Line break hai
            else if (i < text.Length && text[i] == '\n')
            {
                // if (text[i + 1] == '\n')
                // {
                i++;
                lineIncrease(ref i);
                // }
                // else
                // {
                //     i++;
                // }
            }
            // agar Character = ' '
            else if (i < text.Length && text[i] == ' ')
            {
                tem = "";
                i++;
            }


            else
            {
                if (i == text.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(tem);
                    Console.WriteLine(i);
                    tem += text[i];
                    i++;
                }

            }
            // loop end
            if (text.Length == 0)
                break;

        }
    }





















    // breakWord Function End

    public Dictionary<int, Tuple<int, string, string>> classPart(ref Dictionary<int, Tuple<int, string>> list)
    {
        // Dictionary for word and line number
        var wordList = new Dictionary<int, Tuple<int, string, string>>();


        // looping through wordlist dictionary
        foreach (KeyValuePair<int, Tuple<int, string>> data in list)
        {
            foreach (var item in Constant.keywords)
            {
                if (data.Value.Item2.Equals(item.Key))
                {
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, item.Value, data.Value.Item2));
                }
            }
            foreach (var item in Constant.accessModifier)
            {
                if (data.Value.Item2.Equals(item.Key))
                {
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, item.Value, data.Value.Item2));
                }
            }
            foreach (var item in Constant.dataTypes)
            {
                if (data.Value.Item2.Equals(item.Key))
                {
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, item.Value, data.Value.Item2));
                }
            }

            if (data.Value.Item2.StartsWith("\"") && data.Value.Item2.EndsWith("\""))
            {
                wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "string", data.Value.Item2));

            }


            switch (data.Value.Item2)
            {

                case string someVal when new Regex(Constant.regexs["int"]).IsMatch(data.Value.Item2):
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "int", data.Value.Item2));
                    break;

                case var someVal when new Regex(Constant.regexs["float"]).IsMatch(data.Value.Item2):
                    wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "float", data.Value.Item2));
                    break;



                case var someVal when new Regex(Constant.regexs["identifier"]).IsMatch(data.Value.Item2):

                    if (wordList.Keys.Contains(data.Key))
                    {

                    }
                    else
                    {
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "identifier", data.Value.Item2));
                    }
                    break;

                case var someVal when new Regex(Constant.regexs["all_punctuators"]).IsMatch(data.Value.Item2):

                    if (Constant.punctuators.Keys.Contains(data.Value.Item2))
                    {
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, Constant.punctuators[data.Value.Item2], data.Value.Item2));
                    }
                    else if (Constant.operators.Keys.Contains(data.Value.Item2))
                    {
                        wordList.Add(data.Key, Tuple.Create(data.Value.Item1, Constant.operators[data.Value.Item2], data.Value.Item2));


                    }
                    else
                    {
                        if (wordList.Keys.Contains(data.Key))
                        {
                            // wordList.Add(i++, Tuple.Create(data.Value.Item1, "punctuator", data.Value.Item2));
                        }
                        else
                        {
                            wordList.Add(data.Key, Tuple.Create(data.Value.Item1, "punctuator", data.Value.Item2));
                        }
                    }
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
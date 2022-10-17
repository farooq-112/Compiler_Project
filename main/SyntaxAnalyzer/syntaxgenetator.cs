class SyntaxGenerator
{
    // List<String> token = new List<String>();
    //Dictionary<int, Tuple<int, string, string>> token; chala isko k
    static int index = 1;
    public void starting(ref Dictionary<int, Tuple<int, string, string>> text)
    {
        Console.WriteLine(text);
        checkRule(ref text);
    }

    public bool checkRule(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (Start(ref token))
        {
            if (token[index].Item2 == "class"
            )
            {
                return CLASS_SET(ref token);
            }
            else if (token[index].Item2 == "func")
            {
                Console.WriteLine($"{token[index].Item2} {token[index].Item1}");

                index++;
                return true;
            }
            else if (token[index].Item2 == "enum")
            {
                Console.WriteLine($"{token[index].Item2} {token[index].Item1}");
                index++;
                return true;
            }
            else if (token[index].Item2 == "struct")
            {
                Console.WriteLine($"{token[index].Item2} {token[index].Item1}");
                index++;
                return true;
            }
            else if (token[index].Item2 == "main")
            {
                Console.WriteLine($"{token[index].Item2} {token[index].Item1}");
                index++;
                return true;
            }
            else
            {
                Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
                return true;
            }
        }
        else
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }
    }

    public bool Start(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item3 == "$")
        {
            index++;
            return true;
        }
        else
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }
    }


    //    class CFG SELECTION SET
    bool CLASS_SET(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "public" || token[index].Item2 == "class" || token[index].Item2 == "private" || token[index].Item2 == "filePrivate" || token[index].Item2 == "open" || token[index].Item2 == "internal")
            index++;
            if (AM(ref token))
            {
                if (token[index].Item2 == "class")
                {
                    index++;
                    if (token[index].Item2 == "identifier")
                    {
                        index++;
                        if (INH(ref token))
                        {
                            if (token[index].Item2 == "{")
                            {
                                index++;
                                if (CBODY(ref token))
                                {
                                    if(token[index].Item2 == "}")
                                    {
                                        index++;
                                        return true;
                                    }

                                }

                            }
                        }else{
                            
                        }
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
                return false;
            }

    }

    private bool CBODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        throw new NotImplementedException();
    }

    private bool INH(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        throw new NotImplementedException();
    }

    bool AM(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "public" || token[index].Item2 == "private" || token[index].Item2 == "filePrivate" ||
            token[index].Item2 == "open" || token[index].Item2 == "internal" || token[index].Item2 == "abstact" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            index++;
            if (ACCM(ref token))
            {
                if (CLASSM(ref token))
                {
                    return true;
                }
            }
        }
        else if(token[index].Item2 == "class")
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return true;
        }
        return false;
    }

    bool ACCM(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "public" || token[index].Item2 == "private" || token[index].Item2 == "filePrivate" ||
            token[index].Item2 == "open" || token[index].Item2 == "internal")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "abstact" || token[index].Item2 == "final" || token[index].Item2 == "static" || token[index].Item2 == "class")
        {
            index++;
            return true;
        }
        else
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }
    }

    bool CLASSM(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "abstact" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            index++;
            return true;
        }
        else
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }
    }

    //WHILE STATEMENT
    // bool WHILE_ST(ref Dictionary<int, Tuple<int, string, string>> token)
    // {
    //     if (token[index].Item2 == "while")
    //     {
    //         index++;
    //         if (token[index].Item2 == "(")
    //         {
    //             index++;
    //             if (OE())
    //             {
    //                 if (token[index].Item2 == ")")
    //                 {
    //                     index++;
    //                     if (BODY())
    //                     {
    //                         return true;
    //                     }
    //                 }
    //             }

    //         }
    //     }
    //     return false;
    // }



    bool BODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == ";" || token[index].Item2 == "{" || token[index].Item2 == "while" || token[index].Item2 == "for"
        || token[index].Item2 == "do" || token[index].Item2 == "if" || token[index].Item2 == "switch" || token[index].Item2 == "identifier" ||
         token[index].Item2 == "try" || token[index].Item2 == "var" || token[index].Item2 == "let" || token[index].Item2 == "return" || token[index].Item2 == "break" ||
          token[index].Item2 == "continue" || token[index].Item2 == "[" || token[index].Item2 == "public" || token[index].Item2 == "private" ||
           token[index].Item2 == "open" || token[index].Item2 == "internal" ||
          token[index].Item2 == "func")
        {
            index++;
            return true;
        }
        else
        {
            Console.WriteLine("Lexical Error :: " + token[index]);
            return false;
        }
    }

    bool SST(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == ";")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "{")
        {
            index++;
            return true;

        }
        else if (token[index].Item2 == "while")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "for")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "do")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "for")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "if")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "switch")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "identifier")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "try")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "var")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "let")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "return")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "break")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "continue")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "public")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "[")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "private")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "open")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "internal")
        {
            index++;
            return true;
        }
        else if (token[index].Item2 == "func")
        {
            index++;
            return true;
        }
        else
        {
            Console.WriteLine("Lexical Error :: " + token[index]);
            return false;
        }
    }

    //OE Expression
    public bool OE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
        token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int-const") || token[index].Item2.Equals("bool-const") ||
        token[index].Item2.Equals("string-const") || token[index].Item2.Equals("float-const"))
        {
            if (AE(ref token))
            {
                if (OE1(ref token))
                    return true;
            }
        }

        return false;
    }

    public bool OE1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("OR"))
        {
            index++;
            if (AE(ref token))
            {
                if (OE1(ref token))
                    return true;
            }
        }
        else if (token[index].Item2.Equals(";") || token[index].Item2.Equals(")") || token[index].Item2.Equals(":"))
        {
            return true;
        }

        return false;
    }
    // void recognizeCFG(ref Dictionary<int, Tuple<int, string, string>> text, List<string> listofSelectionsSet)
    // {
    //     for (int i = 1; i < text.Count; i++)
    //     {
    //         foreach (var item in listofSelectionsSet)
    //         {
    //             if (text[i].Item3 == item)
    //             {
    //                 Console.WriteLine("Yes");
    //             }
    //             else
    //             {
    //             }
    //             i++;
    //         }

    //     }
    // }


    public bool AE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
        token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int-const") || token[index].Item2.Equals("bool-const") ||
        token[index].Item2.Equals("string-const") || token[index].Item2.Equals("float-const"))
        {
            if (RE(ref token))
            {
                if (AE1(ref token))
                    return true;
            }

        }
        return false;
    }

    public bool AE1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("AND"))
        {
            index++;
            if (RE(ref token))
            {
                if (AE1(ref token))
                    return true;
            }
        }
        else if (token[index].Item2.Equals("OR") || token[index].Item2.Equals(")") || token[index].Item2.Equals(";") || token[index].Item2.Equals(":"))
        {
            return true;
        }

        return false;
    }

    public bool RE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
        token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int-const") || token[index].Item2.Equals("bool-const") ||
        token[index].Item2.Equals("string-const") || token[index].Item2.Equals("float-const"))
        {
            if (E(ref token))
            {
                if (RE1(ref token))
                    return true;
            }

        }
        return false;
    }

    public bool RE1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("RelationalOperator"))
        {
            index++;
            if (E(ref token))
            {
                if (RE1(ref token))
                    return true;
            }
        }
        else if (token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") || token[index].Item2.Equals(")") ||
                token[index].Item2.Equals(":") || token[index].Item2.Equals(";"))
        {
            return true;
        }

        return false;
    }

    public bool E(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
            token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int-const") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string-const") || token[index].Item2.Equals("float-const"))
        {
            if (T(ref token))
            {
                if (E1(ref token))
                    return true;

            }
        }

        return false;
    }

    public bool E1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("PM"))
        {
            index++;
            if (T(ref token))
            {
                if (E1(ref token))
                    return true;
            }
        }
        else if (token[index].Item2.Equals("RelationalOperator") || token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") ||
                token[index].Item2.Equals(")") || token[index].Item2.Equals(";") || token[index].Item2.Equals(":"))
        {
            Console.WriteLine($"E1 NULL {token[index].Item2}");
            return true;
        }

        return false;
    }

    public bool T(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
            token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int-const") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string-const") || token[index].Item2.Equals("float-const"))
        {
            if (F(ref token))
            {
                if (T1(ref token))
                    return true;
            }

        }
        return false;
    }

    public bool T1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("MDM"))
        {
            index++;
            if (F(ref token))
            {
                if (T1(ref token))
                    return true;
            }

        }
        if (token[index].Item2.Equals("PM") || token[index].Item2.Equals("RelationalOperator") || token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") ||
                token[index].Item2.Equals(")") || token[index].Item2.Equals(";") || token[index].Item2.Equals(":"))
        {
            return true;
        }

        return false;
    }


    public bool F(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier"))
        {
            index++;
            if (LHS(ref token))
            {
                if (F1(ref token))
                {
                    return true;
                }
            }
        }
        else if (token[index].Item2.Equals("this"))
        {
            index++;
            if (token[index].Item2.Equals("."))
            {
                index++;
                if (token[index].Item2.Equals("identifier"))
                {
                    index++;
                    if (LHS(ref token))
                    {
                        if (Inc_Dec(ref token))
                        {
                            return true;
                        }
                    }
                }

            }
        }
        else if (token[index].Item2.Equals("int-const") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string-const") || token[index].Item2.Equals("float-const"))
        {
            return true;
        }
        else if (Inc_Dec(ref token))
        {
            return true;
        }
        else if (token[index].Item2.Equals("!"))
        {
            index++;
            if (LHS(ref token))
                return true;
        }

        return false;
    }

    public bool F1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("MDM") || token[index].Item2.Equals("PM") || token[index].Item2.Equals("RelationalOperator") ||
            token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") || token[index].Item2.Equals(")") || token[index].Item2.Equals(";") ||
            token[index].Item2.Equals(":"))
        {
            return true;
        }
        else if (Inc_Dec(ref token))
        {
            index++;
            return true;
        }

        return false;
    }

    // LHS NON TERMINAL
    bool LHS(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("."))
        {
            index++;
            if (token[index].Item2.Equals("identifier"))
            {
                index++;
                if (LHS(ref token))
                    return true;
            }
            else if (token[index].Item2.Equals("("))
            {
                index++;
                if (PARAMS(ref token))
                    if (token[index].Item2.Equals(")"))
                        return true;
            }
        }
        return false;
    }

    // Icrement Decrement NON TERMINAL
    bool Inc_Dec(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("inc-dec"))
        {
            index++;
            if (THIS_ST(ref token))
            {
                if (token[index].Item2.Equals("identifier"))
                {
                    if (LHS(ref token))
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        else if (token[index].Item2.Equals("this"))
        {
            index++;
            if (token[index].Item2.Equals("."))
            {
                index++;
                if (token[index].Item2.Equals("identifier"))
                {
                    index++;
                    if (LHS(ref token))
                    {
                        if (token[index].Item2.Equals("inc-dec"))
                        {
                            index++;
                            return true;
                        }
                    }
                }

            }
        }
        return false;
    }

    // THIS STATEMENT 
    public bool THIS_ST(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("this"))
        {
            index++;
            if (token[index].Item2.Equals("."))
            {
                index++;
                return true;
            }

        }
        else if (token[index].Item2.Equals("identifier"))
        {
            return true;
        }
        return false;
    }

    public bool PARAMS(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        return true;
    }
}

class SyntaxGenerator{
    
    // List<String> token = new List<String>();
    //Dictionary<int, Tuple<int, string, string>> token; chala isko k
    static int index = 0;

    public void starting(ref Dictionary<int, Tuple<int, string, string>> text){
        Console.WriteLine(text);
        checkRule(ref text);
    }

    public bool checkRule(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (Start())
        {
            //Console.WriteLine(token[index].Item2);
            Console.WriteLine("No syntax Error");
            //return true;
            if (token[index].Item3 == "$")
            {
                Console.WriteLine("No syntax Error");
                return true;
            }
        }
        Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
        return false;
    }
    
    public bool Start()
    {
        return true;
    }

    
    // IF ELSE STATEMENT;
    bool IFELSE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "if")
        {
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (OE(ref token))
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (BODY())
                        {
                            if (ELSE(ref token))
                            {
                                return true;
                            }

                        }
                    }
                }
            }
        }
        return false;
    }

    bool ELSE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "else")
        {
            index++;
            if (BODY())
            {
                return true;
            }
        }
        else
        {
            if (token[index].Item2 == " ") //follow(BODY) & follow(IFELSE)
            {
                return true;
            }
        }
        return false;
    }


    //WHILE STATEMENT
    bool WHILE_ST(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "while")
        {
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (OE(ref token))
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (BODY())
                        {
                            return true;
                        }
                    }
                }

            }
        }
        return false;
    }



    bool BODY(){
        return true;
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
            if(LHS(ref token)){
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
                    if(LHS(ref token)){
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
            token[index].Item2.Equals(":") )
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
    bool LHS(ref Dictionary<int, Tuple<int, string, string>> token){
        if (token[index].Item2.Equals("."))
        {
            index++;
            if (token[index].Item2.Equals("identifier"))
            {
                index++;
                if(LHS(ref token))
                    return true;
            }
            else if(token[index].Item2.Equals("("))
            {
                index++;
                if(PARAMS(ref token))
                    if(token[index].Item2.Equals(")"))
                        return true;
            }
        }
        return false;
    }

    // Icrement Decrement NON TERMINAL
    bool Inc_Dec(ref Dictionary<int, Tuple<int, string, string>> token){
        if (token[index].Item2.Equals("inc-dec"))
        {
            index++;
            if(THIS_ST(ref token))
            {
                if (token[index].Item2.Equals("identifier"))
                {
                    if(LHS(ref token))
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
                    if(LHS(ref token)){
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

    public bool PARAMS(ref Dictionary<int, Tuple<int, string, string>> token){
        return true;
    }
}

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
                if (OE())
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
                if (OE())
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

    bool OE(){
        return true;
    }



}
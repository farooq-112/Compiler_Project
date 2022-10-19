class SyntaxGenerator
{
    // List<String> token = new List<String>();
    //Dictionary<int, Tuple<int, string, string>> token; chala isko k
    static int index = 1;
    public void starting(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        Console.WriteLine(token);
        if (checkRule(ref token))
        {
            End(ref token);
        }
        else
        {
            End(ref token);
        }
    }

    public bool checkRule(ref Dictionary<int, Tuple<int, string, string>> token)
    {

        if (token[index].Item2 == "access-modifier" || token[index].Item2 == "class" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static" || token[index].Item2 == "func" || token[index].Item2 == "enum" || token[index].Item2 == "struct" || token[index].Item2 == "Main" || token[index].Item2 == "interface")
        {
            if (token[index].Item2 == "access-modifier")
            {
                index++;
                if (CLASSM(ref token))
                {
                    if (token[index].Item2 == "class")
                    {
                        if (CLASS_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "struct")
                    {
                         if (STRUCT_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "func")
                    {
                        if (FUNC_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    if (token[index].Item2 == "class")
                    {
                        if (CLASS_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "struct")
                    {
                        if (STRUCT_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "func")
                    {
                        if (FUNC_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "enum")
                    {
                       
                        if (ENUM_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else
            {
                if (token[index].Item2 == "class")
                {
                    if (CLASS_SET(ref token))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "struct")
                {
                    if (STRUCT_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                }
                else if (token[index].Item2 == "func")
                {
                    if (FUNC_SET(ref token))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "enum")
                {
                     if (ENUM_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                }
                else if (token[index].Item2 == "Main")
                {
                     if (MAIN_SET(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                }
                 else if (token[index].Item2 == "interface")
                {
                     if (PROTOCOL(ref token))
                        {
                            checkRule(ref token);
                            return true;
                        }
                }
                else
                {
                    return false;
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

    private bool PROTOCOL(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item2 == "interface"){
            index++;
            if(token[index].Item2 == "identifier"){
                index++;
                if(token[index].Item2 == "{"){
                    index++;
                    if(BODY(ref token)){
                        return true;
                    }
                }
            }
            return false;
        }else{
            return false;
        }
    }

    private bool MAIN_SET(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item2 == "Main"){
            index++;
            if(token[index].Item2 == "("){
            index++;
            if(token[index].Item2 == ")"){
            index++;
            if(token[index].Item2 == "{"){
            index++;
            if(MST(ref token)){
                return true;
        }
        }
        }
        }
        return false;
        }
        else{
            return false;
        }
    }

    private bool ENUM_SET(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item2 == "enum"){
            index++;
            if(token[index].Item2 == "identifier"){
                index++;
                if(TYPE(ref token)){
                    if(token[index].Item2 == "{"){
                        index++;
                        if(E_BODY(ref token)){
                            return true;
                        }else{
                            if(token[index].Item2 == "}"){
                                index++;
                                return true;
                            }
                        }
                    }
                }else{
                    if(token[index].Item2 == "{"){
                        index++;
                        if(E_BODY(ref token)){
                            return true;
                        }else{
                            if(token[index].Item2 == "}"){
                                index++;
                            }
                        }
                    }
                }
            }
            return false;
        }else{
            return false;
        }
    }

    private bool E_BODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item3 == "case"){
            index++;
            if(token[index].Item2 == "identifier"){
                index++;
                E_BODY(ref token);
            }
            return false;
        }else{
            return false;
        }
    }

    private bool TYPE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item2 == "colon"){
            index++;
            if(token[index].Item2 == "data-type"){
                index++;
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }

    private bool FUNC_SET(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            if (token[index].Item2 == "access-modifier")
            {
                index++;
                if (CLASSM(ref token))
                {
                    if (token[index].Item2 == "func")
                    {
                        index++;
                        return FUNC_ELABORATE(ref token);

                    }
                }
                else if (token[index].Item2 == "func")
                {
                    return FUNC_ELABORATE(ref token);
                }
            }
            else if (token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
            {
                if (token[index].Item2 == "func")
                {
                    return FUNC_ELABORATE(ref token);
                }
            }
            else if (token[index].Item2 == "func")
            {
                index++;
                return FUNC_ELABORATE(ref token);
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    bool FUNC_ELABORATE(ref Dictionary<int, Tuple<int, string, string>> token)
    {

        if (token[index].Item2 == "identifier")
        {
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (PARAMS(ref token))
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (RET_TYPE(ref token))
                        {
                            if (token[index].Item2 == "{")
                            {
                                index++;
                                if (BODY(ref token))
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (token[index].Item2 == "{")
                            {
                                index++;
                                if (BODY(ref token))
                                {
                                    return true;
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        index++;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (RET_TYPE(ref token))
                        {
                            if (token[index].Item2 == "{")
                            {
                                index++;
                                if (BODY(ref token))
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        index++;
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        index++;
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (token[index].Item2 == "{")
                            {
                                index++;
                                if (BODY(ref token))
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        index++;
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        index++;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    private bool RET_TYPE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "ret-type")
        {
            index++;
            if (token[index].Item2 == "data-type")
            {
                index++;
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    private bool STRUCT_SET(ref Dictionary<int, Tuple<int, string, string>> token)
    {
         // if (token[index].Item2 == "access-modifier" || token[index].Item2 == "class" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        // {
        // if (AM(ref token))
        // {
        if (token[index].Item2 == "struct")
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
                        if (SBODY(ref token))
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }
                        }

                    }
                }
                else
                {
                    if (token[index].Item2 == "{")
                    {
                        index++;
                        if (SBODY(ref token))
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }
                        }

                    }
                }
            }
            // }

            // }else{

            // }
            return false;
        }
        else
        {
            return false;
        }

    }

    public bool End(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item3 == "$")
        {
            Console.WriteLine($"No Syntax Error");
            return true;
        }
        else
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item2.ToString()} {token[index].Item1.ToString()}");
            return false;
        }
    }


    //    class CFG SELECTION SET
    bool CLASS_SET(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        // if (token[index].Item2 == "access-modifier" || token[index].Item2 == "class" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        // {
        // if (AM(ref token))
        // {
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
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }
                        }

                    }
                }
                else
                {
                    if (token[index].Item2 == "{")
                    {
                        index++;
                        if (CBODY(ref token))
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                index++;
                                return true;
                            }
                        }

                    }
                }
            }
            // }

            // }else{

            // }
            return false;
        }
        else
        {
            return false;
        }

    }

   private bool SBODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "func" || token[index].Item2 == "init")
        {
            if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant")
            {
                index++;
                if (ATTR(ref token))
                {
                    SBODY(ref token);
                }
            }
            else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
            {
                if (FUNC_SET(ref token))
                {
                    SBODY(ref token);
                }
            }
             else if (token[index].Item2 == "init" )
            {
                if (INIT_C(ref token))
                {
                    SBODY(ref token);
                }
            }

            return false;

        }
        else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
             if (FUNC_SET(ref token))
                {
                    CBODY(ref token);
                }
            return false;
        }
        else
        {
            return false;
        }
    }
    private bool CBODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "func" || token[index].Item2 == "init" || token[index].Item2 == "deinit")
        {
            if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant")
            {
                index++;
                if (ATTR(ref token))
                {
                    CBODY(ref token);
                }
            }
            else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
            {
                if (FUNC_SET(ref token))
                {
                    CBODY(ref token);
                }
            }
             else if (token[index].Item2 == "init" )
            {
                if (INIT_C(ref token))
                {
                    CBODY(ref token);
                }
            }
             else if (token[index].Item2 == "deinit" )
            {
                if (DEINIT(ref token))
                {
                    CBODY(ref token);
                } 
            }

            return false;

        }
        else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
             if (FUNC_SET(ref token))
                {
                    CBODY(ref token);
                }
            return false;
        }
        else
        {
            return false;
        }
    }

    private bool INIT_C(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item2 == "init"){
            index ++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (PARAMS(ref token))
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (token[index].Item2 == "{")
                        {
                            index++;
                            if (MST(ref token))
                        {
                         return true;   
                        }
                        }
                    }
                }else{
                     if (token[index].Item2 == ")")
                    {
                        index++;
                        if (token[index].Item2 == "{")
                        {
                            index++;
                            if (MST(ref token))
                        {
                         return true;   
                        }
                        }
                    }
                }
            }
            return false;
        }else{
            return false;
        }
    }

    private bool DEINIT(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if(token[index].Item2 == "deinit"){
            index++;
            if(token[index].Item2 == "{"){
                index++;
                 
                        
                            if (MST(ref token))
                        {
                         return true;   
                        }
                        
            
            }
            return false;
        }
        else{
            return  false;
        }
    }

    private bool ATTR(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "identifier")
        {
            index++;
            if (token[index].Item2 == "comma")
            {
                index++;
                ATTR(ref token);
                return true;
            }
            else
            {
                if (token[index].Item2 == "colon")
                {
                    index++;
                    if (token[index].Item2 == "data-type")
                    {
                        index++;
                        if (token[index].Item2 == "UnaryOperator")
                        {
                            index++;
                            if (token[index].Item2 == "integer" || token[index].Item2 == "float" || token[index].Item2 == "char" || token[index].Item2 == "string" || token[index].Item2 == "identifier")
                            {
                                index++;
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    bool INH(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "keyword")
        {
            if (token[index].Item3 == "extends")
            {
                index++;
                if (token[index].Item2 == "identifier")
                {
                    index++;
                    if (IMP(ref token))
                    {

                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (token[index].Item2 == "implements")
            {
                index++;
                if (token[index].Item2 == "identifier")
                {
                    index++;
                    if (OTHER(ref token))
                    {

                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        else
        {
            return false;
        }
    }

    private bool IMP(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "comma")
        {
            index++;
            if (token[index].Item3 == "implements")
            {
                index++;
                if (token[index].Item2 == "identifier")
                {
                    index++;
                    if (OTHER(ref token))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool OTHER(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "comma")
        {
            index++;
            if (token[index].Item2 == "identifier")
            {
                index++;
                if (OTHER(ref token))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool FOR(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "for")
        {
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (PARAMS(ref token))
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (BODY(ref token))
                        {
                            return true;
                        }
                    }
                }
            }

        }
        Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
        return false;

    }

    bool AM(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "access-modifier" || token[index].Item2 == "abstact" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            if (ACCM(ref token))
            {
                if (CLASSM(ref token))
                {
                    return true;
                }
            }
            else if (CLASSM(ref token))
            {
                return true;
            }
        }

        return false;
    }

    bool ACCM(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item3 == "public" || token[index].Item3 == "private" || token[index].Item3 == "filePrivate" ||
            token[index].Item3 == "open" || token[index].Item3 == "internal")
        {
            index++;
            return true;
        }
        else if (CLASSM(ref token))
        {
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

    // WHILE STATEMENT
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
                        if (BODY(ref token))
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
            if (BODY(ref token))
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
                        if (token[index].Item2.Equals("{")){
                            index++;
                            if (BODY(ref token))
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


    bool BODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (MST(ref token))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // bool SSTfarooq(ref Dictionary<int, Tuple<int, string, string>> token)
    // {
    //     if (token[index].Item2 == ";")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "{")
    //     {
    //         index++;
    //         return true;

    //     }
    //     else if (token[index].Item2 == "while")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "for")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "do")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "for")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "if")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "switch")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "identifier")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "try")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "var")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "let")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "return")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "break")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "continue")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "public")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "[")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "private")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "open")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "internal")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else if (token[index].Item2 == "func")
    //     {
    //         index++;
    //         return true;
    //     }
    //     else
    //     {
    //         Console.WriteLine("Lexical Error :: " + token[index]);
    //         return false;
    //     }
    // }

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
                token[index].Item2.Equals("colon") || token[index].Item2.Equals("semi-colon"))
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
            }else if(F1(ref token)){
                return true;
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
        if (token[index].Item2 == "identifier")
        {
            index++;
            if (token[index].Item2 == "colon")
            {
                index++;
                if (token[index].Item2 == "data-type")
                {
                    index++;
                    PARAMS(ref token);
                }
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    //SST
    bool SST(ref Dictionary<int, Tuple<int, string, string>> token)
    {

        if (token[index].Item2.Equals("while"))
        {
            if (WHILE_ST(ref token))
                return true;
        }

        // else if (token[index].Item2.Equals("for"))
        // {
        //     if (FOR(ref token))
        //         return true;
        // }

        // else if (token[index].Item2.Equals("do"))
        // {
        //     if (DO(ref token))
        //         return true;
        // }

        else if (token[index].Item2.Equals("if"))
        {
            if (IFELSE(ref token))
                return true;
        }

        else if (token[index].Item2.Equals("try"))
        {
            index++;
            if (token[index].Item2.Equals("{"))
            {
                index++;
                if (MST(ref token))
                {
                    if (token[index].Item2.Equals("}"))
                    {
                        index++;
                        if (token[index].Item2.Equals("catch"))
                        {
                            if (token[index].Item2.Equals("("))
                            {
                                index++;
                                if (token[index].Item2.Equals("e"))
                                {
                                    if (token[index].Item2.Equals(")"))
                                    {
                                        index++;
                                        if (token[index].Item2.Equals("{"))
                                        {
                                            index++;
                                            if (MST(ref token))
                                            {
                                                if (token[index].Item2.Equals("}"))
                                                {
                                                    index++;
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        else if (token[index].Item2.Equals("return"))
        {
            index++;
            if (OE(ref token))
            {
                if (token[index].Item2.Equals(";"))
                {
                    index++;
                    return true;
                }
            }
        }

        else if (token[index].Item2.Equals("continue"))
        {
            index++;
            if (token[index].Item2.Equals(";"))
            {
                index++;
                return true;
            }
        }

        else if (token[index].Item2.Equals("break"))
        {
            index++;
            if (token[index].Item2.Equals(";"))
            {
                index++;
                return true;
            }
        }

        else if (token[index].Item2.Equals("identifier"))
        {
            index++;
            if (LHS(ref token))
            {
                if (SST1(ref token))
                {
                    return true;
                }
            }
        }

        else if (token[index].Item2.Equals("["))
        {
            if (ARRAY(ref token))
            {
                return true;
            }
        }
        else if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant")
        {
            index++;
            if (ATTR(ref token))
            {
                return true;
            }

        }
        return false;
    }


    bool SST1(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("mutable-constant") || token[index].Item2.Equals("immutable-constant"))
        {
            index++;
            if (token[index].Item2.Equals("identifier"))
            {
                index++;
                if (token[index].Item2.Equals(":"))
                {
                    if (SST2(ref token))
                    {
                        return true;
                    }
                }
            }
        }
        else if (token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("this"))
        {
            if (Inc_Dec(ref token))
            {
                return true;
            }
        }
        else if (token[index].Item2.Equals("+") || token[index].Item2.Equals("-") || token[index].Item2.Equals("*") || token[index].Item2.Equals("/"))
        {
            if (OE(ref token))
            {
                return true;
            }
        }
        else if (token[index].Item2.Equals("="))
        {
            index++;
            if (OE(ref token))
            {
                return true;
            }
        }
        return false;
    }

    bool SST2(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("data-type"))
        {
            if (DEC(ref token))
            {
                return true;
            }
        }
        else if (token[index].Item2.Equals("identifier"))
        {
            if (OBJ_DEC(ref token))
            {
                return true;
            }
        }
        else if (token[index].Item2.Equals("["))
        {
            if (ARRAY(ref token))
            {
                return true;
            }
        }
        else if (token[index].Item2.Equals("="))
        {
            index++;
            if (OE(ref token))
            {
                return true;
            }
        }
        return false;
    }

    //Declaration
    bool DEC(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("data-type") || token[index].Item2.Equals("identifier"))
        {
            if (DATA_TYPE(ref token))
            {
                if (INIT(ref token))
                {
                    return true;
                }
            }
        }
        return false;
    }

    //Object Declaration
    bool OBJ_DEC(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier"))
        {
            index++;
            if (token[index].Item2.Equals("="))
            {
                index++;
                if (token[index].Item2.Equals("identifier"))
                {
                    index++;
                    if (token[index].Item2.Equals("dot"))
                    {
                        index++;
                        if (token[index].Item2.Equals("init"))
                        {
                            index++;
                            if (token[index].Item2.Equals("("))
                            {
                                index++;
                                if (OE(ref token))
                                {
                                    index++;
                                    if (token[index].Item2.Equals(")"))
                                    {
                                        index++;
                                        if (token[index].Item2.Equals(";"))
                                        {
                                            index++;
                                            return true;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }
        }
        return false;
    }

    //Data Type
    bool DATA_TYPE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("data-type") || token[index].Item2.Equals("identifier"))
        {
            index++;
            return true;
        }
        return false;
    }

    bool INIT(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("="))
        {
            index++;
            if (OE(ref token))
            {
                if (token[index].Item2.Equals(";"))
                {
                    index++;
                    return true;
                }
            }
        }
        else if (token[index].Item2.Equals(";"))
        {
            index++;
            return true;
        }
        return false;
    }

    // MST Multiline Statement
    bool MST(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "if" || token[index].Item2 == "while" || token[index].Item2 == "for" || token[index].Item2 == "try" ||
            token[index].Item2 == "inc-dec" || token[index].Item2 == "return" || token[index].Item2 == "continue" || token[index].Item2 == "break" ||
            token[index].Item2 == "access-modifier" || token[index].Item2 == "func" ||
            token[index].Item2 == "DT" || token[index].Item2 == "identifier" || token[index].Item2 == "this" || token[index].Item2 == "[" || token[index].Item2.Equals("mutable-constant") || token[index].Item2.Equals("immutable-constant"))
        {
            if (SST(ref token))
                if (MST(ref token))
                    return true;
        }
        else if (token[index].Item2 == "}")
        {
            index++;
            return true;
        }
        return false;
    }

    //Array
    bool ARRAY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("["))
        {
            index++;
            if (ARR(ref token))
            {
                if (token[index].Item2.Equals(";"))
                {
                    index++;
                    return true;
                }
            }
        }
        return false;
    }

    bool ARR(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("["))
        {
            index++;
            if (DATA_TYPE(ref token))
            {
                if (token[index].Item2.Equals("]"))
                {
                    index++;
                    return true;
                }
            }
        }
        else
        {
            if (DATA_TYPE(ref token))
            {
                return true;
            }
        }
        return false;
    }
}

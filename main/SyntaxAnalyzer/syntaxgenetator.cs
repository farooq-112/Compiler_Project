class SyntaxGenerator
{
    SemanticAnalyzer semanticAnalyzer = new SemanticAnalyzer();
    static int index = 1;
    public void starting(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        // Console.WriteLine(token);
        if (checkRule(ref token))
        {
            End(ref token);
        }
        else
        {
            //End(ref token);
        }
    }

    public bool checkRule(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        MainTable dummyTable = new MainTable();
        if (token[index].Item2 == "access-modifier" || token[index].Item2 == "identifier" || token[index].Item2 == "class" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static" || token[index].Item2 == "func" || token[index].Item2 == "enum" || token[index].Item2 == "struct" || token[index].Item2 == "Main" || token[index].Item2 == "interface")
        {
            if (token[index].Item2 == "access-modifier")
            {
                dummyTable.accessModifier = token[index].Item3;
                index++;
                if (CLASSM(ref token, ref dummyTable))
                {
                    if (token[index].Item2 == "class")
                    {
                        if (CLASS_SET(ref token, ref dummyTable))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "struct")
                    {
                        dummyTable.accessModifier = token[index].Item3;
                        if (STRUCT_SET(ref token, ref dummyTable))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "func")
                    {
                        dummyTable.accessModifier = token[index].Item3;
                        if (FUNC_SET(ref token, ref dummyTable))
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
                        if (CLASS_SET(ref token, ref dummyTable))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "struct")
                    {
                        if (STRUCT_SET(ref token, ref dummyTable))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "func")
                    {
                        if (FUNC_SET(ref token, ref dummyTable))
                        {
                            checkRule(ref token);
                            return true;
                        }
                    }
                    else if (token[index].Item2 == "enum")
                    {

                        if (ENUM_SET(ref token, ref dummyTable))
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
                    if (CLASS_SET(ref token, ref dummyTable))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "struct")
                {
                    if (STRUCT_SET(ref token, ref dummyTable))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "func")
                {
                    if (FUNC_SET(ref token, ref dummyTable))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "enum")
                {
                    if (ENUM_SET(ref token, ref dummyTable))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "Main")
                {
                    if (MAIN_SET(ref token, ref dummyTable))
                    {
                        checkRule(ref token);
                        return true;
                    }
                }
                else if (token[index].Item2 == "interface")
                {
                    if (PROTOCOL(ref token, ref dummyTable))
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
            // Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }


    }

    private bool PROTOCOL(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "interface")
        {
            dummyTable.type = token[index].Item3;
            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    Console.WriteLine("Already Exist at path");
                    return false;
                }
                else
                {
                    dummyTable.name = token[index].Item3;
                }
                index++;
                if (P_IMP(ref token, ref dummyTable))
                {
                    if (token[index].Item2 == "{")
                    {
                        semanticAnalyzer.insertMT(ref dummyTable);
                        semanticAnalyzer.createScope();
                        index++;
                        if (BODY(ref token, ref dummyTable))
                        {
                            return true;
                        }
                    }
                }
                if (token[index].Item2 == "{")
                {
                    semanticAnalyzer.insertMT(ref dummyTable);
                    semanticAnalyzer.createScope();
                    index++;
                    if (BODY(ref token, ref dummyTable))
                    {
                        return true;
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

    private bool MAIN_SET(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "Main")
        {
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (token[index].Item2 == ")")
                {
                    index++;
                    if (token[index].Item2 == "{")
                    {
                        semanticAnalyzer.createScope();
                        index++;
                        if (MST(ref token, ref dummyTable))
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

    private bool ENUM_SET(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "enum")
        {
            dummyTable.type = token[index].Item3;
            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    Console.WriteLine("Already Exist at path");
                    return false;
                }
                else
                {
                    dummyTable.name = token[index].Item3;
                }
                index++;
                if (TYPE(ref token))
                {
                    semanticAnalyzer.insertMT(ref dummyTable);
                    if (token[index].Item2 == "{")
                    {
                        semanticAnalyzer.createScope();
                        index++;
                        if (E_BODY(ref token))
                        {
                            return true;
                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
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
                        semanticAnalyzer.createScope();
                        index++;
                        if (E_BODY(ref token))
                        {
                            return true;
                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
                                index++;
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

    private bool E_BODY(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item3 == "case")
        {
            index++;
            if (token[index].Item2 == "identifier")
            {
                index++;
                E_BODY(ref token);
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    private bool TYPE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "colon")
        {
            index++;
            if (token[index].Item2 == "data-type")
            {
                index++;
                return true;
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

    private bool FUNC_SET(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            if (token[index].Item2 == "access-modifier")
            {
                index++;
                if (CLASSM(ref token, ref dummyTable))
                {
                    if (token[index].Item2 == "func")
                    {
                        index++;
                        return FUNC_ELABORATE(ref token, ref dummyTable);

                    }
                }
                else if (token[index].Item2 == "func")
                {
                    return FUNC_ELABORATE(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
            {
                if (token[index].Item2 == "func")
                {
                    return FUNC_ELABORATE(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "func")
            {
                index++;
                return FUNC_ELABORATE(ref token, ref dummyTable);
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    bool FUNC_ELABORATE(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        ClassTable ctable = new ClassTable();
        if (token[index].Item2 == "identifier")
        {
            ctable.name = token[index].Item3;
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (PARAMS(ref token, ref ctable))
                {

                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (RET_TYPE(ref token, ref ctable))
                        {
                            var data = semanticAnalyzer.lookupCT(dummyTable.name ?? "", ctable.name);
                            if (data == null)
                            {
                                semanticAnalyzer.insertCT(ctable, dummyTable.name ?? "");
                            }
                            else
                            {
                                Console.WriteLine("Variable Already Exist");
                            }
                            if (token[index].Item2 == "{")
                            {
                                semanticAnalyzer.createScope();
                                index++;
                                if (BODY(ref token, ref dummyTable))
                                {
                                    // if (token[index].Item2 == "}")
                                    // {
                                    return true;
                                    // }
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        semanticAnalyzer.destroyScope();
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            var data = semanticAnalyzer.lookupCT(dummyTable.name ?? "", ctable.name);
                            if (data == null)
                            {
                                semanticAnalyzer.insertCT(ctable, dummyTable.name ?? "");
                            }
                            else
                            {
                                Console.WriteLine("Variable Already Exist");
                            }
                            if (token[index].Item2 == "{")
                            {
                                semanticAnalyzer.createScope();
                                index++;
                                if (BODY(ref token, ref dummyTable))
                                {
                                    return true;
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        semanticAnalyzer.destroyScope();
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
                        if (RET_TYPE(ref token, ref ctable))
                        {
                            if (token[index].Item2 == "{")
                            {
                                semanticAnalyzer.createScope();
                                index++;
                                if (BODY(ref token, ref dummyTable))
                                {
                                    // if (token[index].Item2 == "}")
                                    // {
                                    // index++;
                                    return true;
                                    // }
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        semanticAnalyzer.destroyScope();
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
                                semanticAnalyzer.createScope();
                                index++;
                                if (BODY(ref token, ref dummyTable))
                                {
                                    // if (token[index].Item2 == "}")
                                    // {
                                    // index++;
                                    return true;
                                    // }
                                }
                                else
                                {
                                    if (token[index].Item2 == "}")
                                    {
                                        semanticAnalyzer.destroyScope();
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

    private bool RET_TYPE(ref Dictionary<int, Tuple<int, string, string>> token, ref ClassTable ctable)
    {
        if (token[index].Item2 == "ret-type")
        {
            ctable.type += token[index].Item3;
            index++;
            if (token[index].Item2 == "data-type")
            {
                ctable.type += token[index].Item3;
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

    private bool STRUCT_SET(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        // if (token[index].Item2 == "access-modifier" || token[index].Item2 == "class" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        // {
        // if (AM(ref token))
        // {
        if (token[index].Item2 == "struct")
        {
            dummyTable.type = token[index].Item3;
            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    Console.WriteLine("Already Exist at path");
                    return false;
                }
                else
                {
                    dummyTable.name = token[index].Item3;
                }
                index++;
                if (INH(ref token, ref dummyTable))
                {
                    semanticAnalyzer.insertMT(ref dummyTable);
                    if (token[index].Item2 == "{")
                    {
                        semanticAnalyzer.createScope();
                        index++;
                        if (SBODY(ref token, ref dummyTable))
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
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
                        semanticAnalyzer.createScope();
                        index++;
                        if (SBODY(ref token, ref dummyTable))
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
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
           foreach (var item in semanticAnalyzer.mainTableList)
          
            {
                Console.WriteLine($" Generated Class -> {item.name} | {item.type} | {item.accessModifier} | {item.typeModifier} ");
                 if(item.parent != null){
                    foreach (var j in item.parent)
                {
                    Console.WriteLine($" parent  of : {item.name} -> {j}");
                }
                }
               if (item.refDT != null)
               {
                 foreach (var i in item.refDT)
                {
                    Console.WriteLine($" Attributes of Class : {item.name} is -> {i.name} | {i.type} | {i.accessModifier} | {i.mutableConst} ");
                }
               }
               
            }
            return true;
        }
        else
        {
            Console.WriteLine($"RETURN FALSE {token[index].Item3.ToString()} {token[index].Item1.ToString()}");
            return false;
        }
    }


    //    class CFG SELECTION SET
    bool CLASS_SET(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        // if (token[index].Item2 == "access-modifier" || token[index].Item2 == "class" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        // {
        // if (AM(ref token))
        // {
        if (token[index].Item2 == "class")
        {
            dummyTable.type = token[index].Item3;
            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    Console.WriteLine("Already Exist at path");
                    return false;
                }
                else
                {
                    dummyTable.name = token[index].Item3;
                }
                index++;
                if (INH(ref token, ref dummyTable))
                {
                    semanticAnalyzer.insertMT(ref dummyTable);
                    if (token[index].Item2 == "{")
                    {
                        semanticAnalyzer.createScope();

                        index++;
                        if (CBODY(ref token, ref dummyTable))
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
                                index++;
                                return true;
                            }
                        }

                    }
                }
                else
                {
                    semanticAnalyzer.insertMT(ref dummyTable);
                    if (token[index].Item2 == "{")
                    {
                        semanticAnalyzer.createScope();
                        index++;
                        if (CBODY(ref token, ref dummyTable))
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
                                index++;
                                return true;
                            }

                        }
                        else
                        {
                            if (token[index].Item2 == "}")
                            {
                                semanticAnalyzer.destroyScope();
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

    private bool SBODY(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "func" || token[index].Item2 == "init")
        {
            if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant")
            {
                string mutableConst = token[index].Item3;
                index++;
                if (ATTR(ref token, ref dummyTable, ref mutableConst))
                {
                    SBODY(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
            {
                if (FUNC_SET(ref token, ref dummyTable))
                {
                    SBODY(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "init")
            {
                if (INIT_C(ref token, ref dummyTable))
                {
                    SBODY(ref token, ref dummyTable);
                }
            }

            return false;

        }
        else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            if (FUNC_SET(ref token, ref dummyTable))
            {
                CBODY(ref token, ref dummyTable);
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    private bool CBODY(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "immutable-constant" || token[index].Item2 == "func" || token[index].Item2 == "init" || token[index].Item2 == "deinit")
        {

            if (token[index].Item2 == "mutable-constant" || token[index].Item2 == "immutable-constant")
            {
                // ClassTable ctable = new ClassTable();
                string mutableConst = token[index].Item3;
                index++;
                if (ATTR(ref token, ref dummyTable, ref mutableConst))
                {
                    CBODY(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
            {
                if (FUNC_SET(ref token, ref dummyTable))
                {
                    CBODY(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "init")
            {
                if (INIT_C(ref token, ref dummyTable))
                {
                    CBODY(ref token, ref dummyTable);
                }
            }
            else if (token[index].Item2 == "deinit")
            {
                if (DEINIT(ref token, ref dummyTable))
                {
                    CBODY(ref token, ref dummyTable);
                }
            }

            return false;

        }
        else if (token[index].Item2 == "access-modifier" || token[index].Item2 == "func" || token[index].Item2 == "abstract" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            if (FUNC_SET(ref token, ref dummyTable))
            {
                CBODY(ref token, ref dummyTable);
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    private bool INIT_C(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        ClassTable ctable = new ClassTable();
        if (token[index].Item2 == "init")
        {
            ctable.name = token[index].Item2;
            index++;
            if (token[index].Item2 == "(")
            {
                index++;
                if (PARAMS(ref token, ref ctable))
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (token[index].Item2 == "{")
                        {
                            var data = semanticAnalyzer.lookupCT(dummyTable.name ?? "", ctable.name);
                            if (data == null)
                            {
                                semanticAnalyzer.insertCT(ctable, dummyTable.name ?? "");
                            }
                            else
                            {
                                Console.WriteLine("Variable Already Exist");
                            }
                            semanticAnalyzer.createScope();
                            index++;
                            if (MST(ref token, ref dummyTable))
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    if (token[index].Item2 == ")")
                    {
                        index++;
                        if (token[index].Item2 == "{")
                        {
                            var data = semanticAnalyzer.lookupCT(dummyTable.name ?? "", ctable.name);
                            if (data == null)
                            {
                                semanticAnalyzer.insertCT(ctable, dummyTable.name ?? "");
                            }
                            else
                            {
                                Console.WriteLine("Variable Already Exist");
                            }
                            semanticAnalyzer.createScope();
                            index++;
                            if (MST(ref token, ref dummyTable))
                            {
                                return true;
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

    private bool DEINIT(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "deinit")
        {
            index++;
            if (token[index].Item2 == "{")
            {
                semanticAnalyzer.createScope();
                index++;


                if (MST(ref token, ref dummyTable))
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

    private bool ATTR(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable, ref string mutableConst)
    {
        ClassTable ctable = new ClassTable();
        ctable.mutableConst = mutableConst;
        if (token[index].Item2 == "identifier")
        {
            ctable.name = token[index].Item3;
            index++;
            if (token[index].Item2 == "comma")
            {
                ctable.type = "-";
                var data = semanticAnalyzer.lookupCT(dummyTable.name ?? "", ctable.name);
                if (data == null)
                {
                    semanticAnalyzer.insertCT(ctable, dummyTable.name ?? "");
                }
                else
                {
                    Console.WriteLine("Variable Already Exist");
                }
                index++;

                ATTR(ref token, ref dummyTable, ref mutableConst);
                return true;
            }
            else
            {
                if (token[index].Item2 == "colon")
                {
                    index++;
                    if (token[index].Item2 == "data-type")
                    {

                        ctable.type = token[index].Item3;
                        index++;
                        if (token[index].Item2 == "UnaryOperator")
                        {
                            index++;
                            if (token[index].Item2 == "int" || token[index].Item2 == "float" || token[index].Item2 == "char" || token[index].Item2 == "string" || token[index].Item2 == "identifier")
                            {
                                if (token[index].Item2 == ctable.type){
                                     var data = semanticAnalyzer.lookupCT(dummyTable.name ?? "", ctable.name);
                                        if (data == null)
                                        {
                                            semanticAnalyzer.insertCT(ctable, dummyTable.name ?? "");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Variable Already Exist");
                                        }
                                }else{
                                    Console.WriteLine("DataType Mismatch Error at line " + token[index].Item1);
                                }
                                index++;
                                if (token[index].Item2 == "(")
                                {
                                    index++;
                                    if (PARAMS2(ref token))
                                    {
                                        if (token[index].Item2 == ")")
                                        {
                                            index++;
                                            if (token[index].Item2 == "semi-colon")
                                            {
                                                index++;
                                                return true;
                                            }
                                        }
                                    }
                                }
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

    bool INH(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "keyword")
        {
            if (token[index].Item3 == "extends")
            {
                index++;
                if (token[index].Item2 == "identifier")
                {
                    var data = semanticAnalyzer.lookupMT(token[index].Item3);
                    if (data != null)
                    {
                        if (data.type == "class")
                        {
                            dummyTable.parent?.Add(data.name ?? "");
                        }
                        else
                        {
                            Console.WriteLine("Type must be Class");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dclaration Error" + token[index].Item3 , token[index].Item1);
                    }
                    index++;
                    if (IMP(ref token, ref dummyTable))
                    {
                        return true;
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
                    if (OTHER(ref token, ref dummyTable))
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

    private bool P_IMP(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "keyword")
        {
            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    Console.WriteLine("type Already Exist at path" + data.name);
                    return false;
                }
                else
                {
                    dummyTable.name = token[index].Item3;
                }
                index++;
                if (OTHER(ref token, ref dummyTable))
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

    private bool IMP(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item3 == "implements")
        {

            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    if (data.type == "protocol")
                    {
                        dummyTable.parent?.Add(data.name ?? "");
                    }
                    else
                    {
                        Console.WriteLine("Type must be Interface" + token[index].Item3, token[index].Item1);
                    }
                }
                else
                {
                    Console.WriteLine("Dclaration Error");
                }
                index++;
                if (OTHER(ref token, ref dummyTable))
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool OTHER(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "comma")
        {
            index++;
            if (token[index].Item2 == "identifier")
            {
                var data = semanticAnalyzer.lookupMT(token[index].Item3);
                if (data != null)
                {
                    if (data.type == "protocol")
                    {
                        dummyTable.parent?.Add(data.name ?? "");
                    }
                    else
                    {
                        Console.WriteLine("Type must be Interface");
                    }
                }
                else
                {
                    Console.WriteLine("Dclaration Error");
                }
                index++;
                if (OTHER(ref token, ref dummyTable))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // private bool FOR(ref Dictionary<int, Tuple<int, string, string>> token,ref MainTable dummyTable)
    // {
    //     if (token[index].Item2 == "for")
    //     {
    //         index++;
    //         if (token[index].Item2 == "(")
    //         {
    //             index++;
    //             if (PARAMS(ref token,ref ctable))
    //             {
    //                 if (token[index].Item2 == ")")
    //                 {
    //                     index++;
    //                     if (BODY(ref token,ref dummyTable))
    //                     {
    //                         return true;
    //                     }
    //                 }
    //             }
    //         }

    //     }
    //     Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");

    bool AM(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "access-modifier" || token[index].Item2 == "abstact" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            if (ACCM(ref token, ref dummyTable))
            {
                if (CLASSM(ref token, ref dummyTable))
                {
                    return true;
                }
            }
            else if (CLASSM(ref token, ref dummyTable))
            {
                return true;
            }
        }

        return false;
    }

    bool ACCM(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item3 == "public" || token[index].Item3 == "private" || token[index].Item3 == "filePrivate" ||
            token[index].Item3 == "open" || token[index].Item3 == "internal")
        {
            index++;
            return true;
        }
        else if (CLASSM(ref token, ref dummyTable))
        {
            return true;
        }
        else
        {
            // Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }
    }

    bool CLASSM(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "abstact" || token[index].Item2 == "final" || token[index].Item2 == "static")
        {
            dummyTable.typeModifier = token[index].Item3;
            index++;
            return true;

        }
        else
        {
            // Console.WriteLine($"RETURN FALSE {token[index].Item2} {token[index].Item1}");
            return false;
        }
    }


    // IF ELSE STATEMENT;
    bool IFELSE(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
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

                        if (token[index].Item2 == "{")
                        {
                            semanticAnalyzer.createScope();
                            index++;
                            if (BODY(ref token, ref dummyTable))
                            {
                                if (ELSE(ref token, ref dummyTable))
                                {
                                    return true;
                                }
                                return true;

                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    bool ELSE(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "else")
        {
            index++;

            if (token[index].Item2 == "{")
            {
                semanticAnalyzer.createScope();
                index++;
                if (BODY(ref token, ref dummyTable))
                {
                    // if (token[index].Item2 == "}")
                    // {
                    // index++;
                    return true;
                    // }
                }
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
    bool WHILE_ST(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
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
                        if (token[index].Item2.Equals("{"))
                        {
                            semanticAnalyzer.createScope();
                            index++;
                            if (BODY(ref token, ref dummyTable))
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


    bool BODY(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {

        if (MST(ref token, ref dummyTable))
        {

            return true;

        }

        return false;
    }


    //OE Expression

    public bool OE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
        token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
        token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
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
        else if (token[index].Item2.Equals("semi-colon") || token[index].Item2.Equals(")") || token[index].Item2.Equals("colon"))
        {
            return true;
        }

        return false;
    }



    public bool AE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
        token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
        token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
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
        else if (token[index].Item2.Equals("OR") || token[index].Item2.Equals(")") || token[index].Item2.Equals("semi-colon") || token[index].Item2.Equals("colon"))
        {
            return true;
        }

        return false;
    }

    public bool RE(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
        token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
        token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
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
            token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
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
        if (token[index].Item2.Equals("PlusMinus"))
        {
            index++;
            if (T(ref token))
            {
                if (E1(ref token))
                    return true;
            }
        }
        else if (token[index].Item2.Equals("RelationalOperator") || token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") ||
                token[index].Item2.Equals(")") || token[index].Item2.Equals("semi-colon") || token[index].Item2.Equals("colon"))
        {
            // Console.WriteLine($"E1 NULL {token[index].Item2}");
            return true;
        }

        return false;
    }

    public bool T(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("identifier") || token[index].Item2.Equals("this") || token[index].Item2.Equals("!") ||
            token[index].Item2.Equals("inc-dec") || token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
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
        if (token[index].Item2.Equals("MultipyDivide"))
        {
            index++;
            if (F(ref token))
            {
                if (T1(ref token))
                    return true;
            }

        }
        if (token[index].Item2.Equals("PlusMinus") || token[index].Item2.Equals("RelationalOperator") || token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") ||
                token[index].Item2.Equals(")") || token[index].Item2.Equals("semi-colon") || token[index].Item2.Equals("colon"))
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
            else if (F1(ref token))
            {
                return true;
            }
            else{
                return true;
            }
        }
        else if (token[index].Item2.Equals("this"))
        {
            index++;
            if (token[index].Item2.Equals("dot"))
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
        else if (token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
        {
            index++;
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
        if (token[index].Item2.Equals("MultipyDivide") || token[index].Item2.Equals("PlusMinus") || token[index].Item2.Equals("RelationalOperator") ||
            token[index].Item2.Equals("AND") || token[index].Item2.Equals("OR") || token[index].Item2.Equals(")") || token[index].Item2.Equals("semi-colon") ||
            token[index].Item2.Equals("colon"))
        {
            return true;
        }
        else if (Inc_Dec(ref token))
        {
            return true;
        }

        return false;
    }

    // LHS NON TERMINAL
    bool LHS(ref Dictionary<int, Tuple<int, string, string>> token)
    {

        if (token[index].Item2.Equals("dot"))
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
                if (CPARAMS(ref token))
                {
                    if (token[index].Item2.Equals(")"))
                    {
                        index++;
                        if (LHS(ref token))
                        {
                            return true;
                        }
                        return true;
                    }
                }
                else
                {
                    if (token[index].Item2.Equals(")"))
                    {
                        index++;
                        return true;
                    }
                }

            }
        }
        else if (token[index].Item2.Equals("("))
        {
            index++;
            if (CPARAMS(ref token))
            {
                if (token[index].Item2.Equals(")"))
                {
                    index++;
                    if (LHS(ref token))
                    {
                        return true;
                    }
                    return true;
                }
            }
            else
            {
                if (token[index].Item2.Equals(")"))
                {
                    index++;
                    return true;
                }
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
            if (token[index].Item2.Equals("dot"))
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
            if (token[index].Item2.Equals("dot"))
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

    public bool PARAMS(ref Dictionary<int, Tuple<int, string, string>> token, ref ClassTable ctable)
    {
        if (token[index].Item2 == "identifier")
        {
            // ctable. = token[index].Item3;
            index++;
            if (token[index].Item2 == "colon")
            {
                index++;
                if (token[index].Item2 == "data-type")
                {
                    ctable.type = ctable.type + token[index].Item3;
                    index++;
                    if (token[index].Item2 == "comma")
                    {
                        ctable.type = ctable.type + token[index].Item3;
                        index++;
                        PARAMS(ref token, ref ctable);
                    }
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



    public bool CPARAMS(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        // if (token[index].Item2 == "identifier")
        // {
        //     ctable.name = token[index].Item3;
        //     index++;
        //     if (token[index].Item2 == "colon")
        //     {
        //         index++;
        //         if (token[index].Item2 == "data-type")
        //         {
        //             ctable.type += token[index].Item3;
        //             index++;
        //             if (token[index].Item2 == "comma")
        //             {
        //                 ctable.type += token[index].Item3;
        //                 index++;
        //                 PARAMS(ref token,ref ctable);
        //             }
        //         }
        //         return true;
        //     }
        //     return false;
        // }
        // else
        // {
        //     return false;
        // }
        return true;
    }

    public bool PARAMS2(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2 == "identifier" || token[index].Item2.Equals("int") || token[index].Item2.Equals("bool-const") ||
            token[index].Item2.Equals("string") || token[index].Item2.Equals("float"))
        {
            index++;
            if (token[index].Item2 == "colon")
            {
                index++;
                if (token[index].Item2 == "data-type")
                {
                    index++;
                    if (token[index].Item2 == "comma")
                    {
                        index++;
                        PARAMS2(ref token);
                    }
                    return true;
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
    bool SST(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {

        if (token[index].Item2.Equals("while"))
        {
            if (WHILE_ST(ref token, ref dummyTable))
                return true;
        }

        // else if (token[index].Item2.Equals("for"))
        // {
        //     if (FOR(ref token))
        //         return true;
        // }



        else if (token[index].Item2.Equals("if"))
        {
            if (IFELSE(ref token, ref dummyTable))
                return true;
        }

        // else if (token[index].Item2.Equals("try"))
        // {
        //     if (TRY(ref token))
        //     {
        //         return true;
        //     }
        // }

        else if (token[index].Item2.Equals("return"))
        {
            index++;
            if (OE(ref token))
            {
                if (token[index].Item2.Equals("semi-colon"))
                {
                    index++;
                    return true;
                }
            }
        }

        else if (token[index].Item2.Equals("continue"))
        {
            index++;
            if (token[index].Item2.Equals("semi-colon"))
            {
                index++;
                return true;
            }
        }

        else if (token[index].Item2.Equals("break"))
        {
            index++;
            if (token[index].Item2.Equals("semi-colon"))
            {
                index++;
                return true;
            }
        }
        else if (token[index].Item2.Equals("inc-dec"))
        {
            if (SST1(ref token))
                return true;
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
            else if (TRY(ref token, ref dummyTable))
            {
                return true;
            }
            else if (token[index].Item2.Equals("inc-dec"))
            {
                if (SST1(ref token))
                    return true;
            }
            else if (token[index].Item2.Equals("("))
            {
                index++;
                // if(PARAMS2(ref token)){
                //     if(token[index].Item2.Equals(")"))
                //     {
                //         index++;
                //         if(token[index].Item2.Equals("semi-colon"))
                //         {
                //             index++;
                //             return true;
                //         }
                //     }
                // }
                if (token[index].Item2.Equals(")"))
                {
                    index++;
                    if (token[index].Item2.Equals("semi-colon"))
                    {
                        index++;
                        return true;
                    }
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
            // ClassTable ctable = new ClassTable();
            string mutableConst = token[index].Item3;
            if (SST1(ref token))
            {
                return true;
            }
            else if (ARRAY(ref token))
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
                if (token[index].Item2.Equals("colon"))
                {
                    index++;
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
        else if (token[index].Item2.Equals("PlusMinus") || token[index].Item2.Equals("PlusMinus") || token[index].Item2.Equals("MultipyDivide") || token[index].Item2.Equals("/"))
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


    bool FUNC_IN(ref Dictionary<int, Tuple<int, string, string>> token)
    {

        if (token[index].Item2.Equals("identifier"))
        {
            index++;
            if (token[index].Item2.Equals("colon"))
            {
                if (SST2(ref token))
                {
                    return true;
                }
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

    //TRY_CATCH
    bool TRY(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {

        if (token[index].Item2.Equals("{"))
        {
            semanticAnalyzer.createScope();
            index++;
            if (MST(ref token, ref dummyTable))
            {
                if (token[index].Item2.Equals("identifier"))
                {
                    index++;
                    if (token[index].Item2.Equals("("))
                    {
                        index++;
                        if (token[index].Item2.Equals("identifier"))
                        {
                            index++;
                            if (token[index].Item2.Equals(")"))
                            {
                                index++;
                                if (token[index].Item2.Equals("{"))
                                {
                                    semanticAnalyzer.createScope();
                                    index++;
                                    if (MST(ref token, ref dummyTable))
                                    {
                                        // if (token[index].Item2.Equals("}"))
                                        // {
                                        //     index++;
                                        return true;
                                        // }
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
                                        if (token[index].Item2.Equals("semi-colon"))
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
            if (token[index].Item2.Equals("("))
            {
                index++;
                if (token[index].Item2.Equals(")"))
                {
                    index++;
                    return true;
                }
            }
            return true;
        }

        return false;
    }

    bool INIT(ref Dictionary<int, Tuple<int, string, string>> token)
    {
        if (token[index].Item2.Equals("UnaryOperator"))
        {
            index++;
            if (OE(ref token))
            {
                if (token[index].Item2.Equals("semi-colon"))
                {
                    index++;
                    return true;
                }
            }
        }
        else if (token[index].Item2.Equals("semi-colon"))
        {
            index++;
            return true;
        }
        return false;
    }

    // MST Multiline Statement
    bool MST(ref Dictionary<int, Tuple<int, string, string>> token, ref MainTable dummyTable)
    {
        if (token[index].Item2 == "if" || token[index].Item2 == "while" || token[index].Item2 == "for" || token[index].Item2 == "try" ||
            token[index].Item2 == "inc-dec" || token[index].Item2 == "return" || token[index].Item2 == "continue" || token[index].Item2 == "break" ||
            token[index].Item2 == "access-modifier" || token[index].Item2 == "func" ||
            token[index].Item2 == "DT" || token[index].Item2 == "identifier" || token[index].Item2 == "this" || token[index].Item2 == "[" || token[index].Item2.Equals("mutable-constant") || token[index].Item2.Equals("immutable-constant"))
        {
            if (SST(ref token, ref dummyTable))
                if (MST(ref token, ref dummyTable))
                    return true;
        }
        else if (token[index].Item2 == "}")
        {
            semanticAnalyzer.destroyScope();
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
                if (token[index].Item2.Equals("]"))
                {
                    index++;
                    if (token[index].Item2.Equals("semi-colon"))
                    {
                        index++;
                        return true;
                    }
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
        else if (DATA_TYPE(ref token))
        {
            return true;
        }
        return false;
    }
}

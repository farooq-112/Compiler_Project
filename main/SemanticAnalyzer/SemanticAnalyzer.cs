

class SemanticAnalyzer {

    public int scopenum = 0;
    public List<string> identifiers = new List<string>();
    public Stack<int> currentscope = new Stack<int>();
    
    public List<MainTable> mainTableList = new List<MainTable>();
    
    public List<FunctionTable> functionTable = new List<FunctionTable>();

public bool insertMT(ref MainTable mainTable)
{
    
    if (mainTableList.Contains(mainTable)) 
    {
        return false;
    }
    else
    {
        mainTableList.Add(mainTable);
        Console.WriteLine(mainTableList);
        return true;
    }
    
}
public MainTable? lookupMT(String name)
{
    for (int i = 0; i < mainTableList.Count; i++) 
    {
        if (mainTableList[i].name!.Equals(name)) 
        {
            return mainTableList[i];
        }
    }
    return null;
}
  public Boolean insertCT(ClassTable c, String mainTableName)
    {
        // ClassTable c = new ClassTable(name, type, AM, Fin, Static, ABS);
        for (int i = 0; i < mainTableList.Count; i++) 
        {
            MainTable m = mainTableList[i];
            if ( m.name!.Equals(mainTableName)) 
            {
                m.refDT?.Add(c);
                return true;
            }
        }
        return false;
    }

    // Class Lookup for Attributes
    public ClassTable? lookupCT(String name, String className)
    {
        for (int i = 0; i < mainTableList.Count; i++) 
        {
            MainTable m = mainTableList[i];
            if (m.name!.Equals(className)) 
            {
                for (int j = 0; j < m.refDT?.Count(); j++) 
                {

                    //Ab Kya problem hai ??   agai type bstheek ha
                    ClassTable c = m.refDT[j];
                    if (c.name.Equals(name)) 
                    {
                        return c;
                    }
                }
            }
        }
        return null;
    }
// Compatibility check
    /*  Cases: 
    1. int + int = int
    2. int + float = float
    3. float + int = float
    4. float + float = float
    */
    public String compatibilityCheck(String leftType, String rightType, String operAtor) 
    {
        if (operAtor.Equals("+") || operAtor.Equals("-") || operAtor.Equals("*") || operAtor.Equals("/") || operAtor.Equals("%")) {
            
            // String compatibility
            if ( operAtor.Equals("+") && leftType.Equals("string") && rightType.Equals("string") )
            {
                String type = "str";
                return type;
            }
            else if((operAtor.Equals("-") && leftType.Equals("string") && rightType.Equals("string")) || (operAtor.Equals("*") && leftType.Equals("string") && rightType.Equals("string")) || (operAtor.Equals("/") && leftType.Equals("string") && rightType.Equals("string")) || (operAtor.Equals("%") && leftType.Equals("string") && rightType.Equals("string"))) 
            {
                return "";
            }
            else if((leftType.Equals("float") && rightType.Equals("string")) || (leftType.Equals("int") && rightType.Equals("string")) || (leftType.Equals("string") && rightType.Equals("float")) || (leftType.Equals("string") && rightType.Equals("int"))) 
            {
                return "";
            }
            // case 1
            if (leftType.Equals("int") && rightType.Equals("int")) 
            {
                String type = "int";
                return type;
            }

            else if (leftType.Equals("int") && rightType.Equals("float") || 
                    leftType.Equals("float") && rightType.Equals("int") ||
                    leftType.Equals("float") && rightType.Equals("float") )
            {
                String type = "float";
                return type;            
            }
        }
        return "-";
    }
public bool insertFT(String name, String type, int scope)
{

        foreach(FunctionTable item in functionTable) {
            if (item.name!.Equals(name) && item.scope == scope) {
                return false;
            }
        }

        functionTable.Add(new FunctionTable(name, type, scope));
        // Console.WriteLine(name + " " + type + " " + scope);
        return true;
}
public FunctionTable? lookupFT(String name,int scope)
{
    foreach (var item in functionTable) 
    {
        if (item.name!.Equals(name) && item.scope == scope) 
        {
            return item;
        }
    }return null;
}

public void createScope()
{
    scopenum++;
    currentscope.Push(scopenum);
}
public void destroyScope()
{
    currentscope.Pop();
    // Console.WriteLine(scopenum);
}

public string convert(ref string infix)
{

    int prio = 0;
    var postfix = "";
    var array = infix.Split(' ');
    Stack<string> s1 = new Stack<string>();
    for (int i = 1; i < array.Length; i++)
    {
            string ch = array[i];
            if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
            {
                if (s1.Count <= 0)
                    s1.Push(ch);
            else
            {
                if (s1.Peek() == "*" || s1.Peek() == "/")
                    prio = 1;
                else
                    prio = 0;
                if (prio == 1)
                {
                    if (ch == "+" || ch == "-")
                    {
                        postfix += s1.Pop() + " ";
                        i--;
                    }
                    else
                    { 
                        postfix += s1.Pop() + " ";
                        i--;
                    }
                }
                else
                {
                    if (ch == "+" || ch == "-")
                    {
                        postfix += s1.Pop() + " ";
                        s1.Push(ch);

                    }
                    else
                        s1.Push(ch);
                }
            }
        }
        else
        {
            postfix += ch + " ";
        }
    }
    int len = s1.Count;
    for (int j = 0; j < len; j++)
        postfix += s1.Pop() + " ";
    return postfix;
}

}

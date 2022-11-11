

class SemanticAnalyzer {

    public int scopenum = 0;
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
    public String? compatibilityCheck(String leftType, String rightType, String operAtor) 
    {
        if (operAtor.Equals("+") || operAtor.Equals("-") || operAtor.Equals("*") || operAtor.Equals("/") || operAtor.Equals("%")) {
            
            // String compatibility
            if ( operAtor.Equals("+") && leftType.Equals("str") && rightType.Equals("str") )
            {
                String type = "str";
                return type;
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
        return null;
    }
bool insertFT(String name, String type, int scope)
{

        foreach(FunctionTable item in functionTable) {
            if (item.name.Equals(name) && item.scope == scope) {
                return false;
            }
        }

        functionTable.Append(new FunctionTable(name, type, scope));
        Console.WriteLine(name + " " + type + " " + scope);
        return true;
}
FunctionTable? lookupFT(String name,int scope, ref List<FunctionTable> functionTable)
{
    for (int i = 0; i < functionTable.Count; i++) 
    {
        if (functionTable[i].name.Equals(name) && functionTable[i].scope == scope) 
        {
            return functionTable[i];
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
    // currentscope.Pop();
}
}

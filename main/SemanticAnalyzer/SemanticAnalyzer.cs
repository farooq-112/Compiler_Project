

class SemanticAnalyzer {

    public int scopenum = 0;
    public Stack<int> currentscope = new Stack<int>();
    
    public List<MainTable> mainTableList = new List<MainTable>();
    public MainTable mainTable = new MainTable();
    public List<FunctionTable> functionTable = new List<FunctionTable>();

public bool insertMT(ref MainTable mainTable)
{
    
    if (mainTableList.Contains(mainTable)) 
    {
        return false;
    }
    else
    {
        List<ClassTable> ctable = new List<ClassTable>();
        mainTable.refDT = ctable;
        mainTableList.Append(mainTable);
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
// bool insertCT(string name,string type,string accessModifier,bool isStatic,bool isFinal,bool isAbstract)
// {
//     ClassTable c = new ClassTable( name, type, accessModifier, isStatic, isFinal, isAbstract);
//     for (int i = 0; i < mainTable.Count; i++) 
//     {
//         ClassTable ct = classTable[i];
//         if (ct.name!.Equals(name)) 
//         {
//             classTable.Append(c);
//             return true;
//         }
//     }return false;
// }
// ClassTable? LookupCT(String Name, String className )
// {
//     for (int i = 0; i < classTable.Count; i++) 
//     {
//         if(classTable[i].name.Equals(className)){
//             return classTable[i];
//         }
//     }
//     return null;
// }
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
    currentscope.Pop();
}
}

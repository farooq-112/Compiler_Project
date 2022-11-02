

class SemanticAnalyzer {

    int scopenum = 0;
    Stack<int> currentscope = new Stack<int>();
    List<ClassTable> classTable = new List<ClassTable>();
    List<MainTable> mainTable = new List<MainTable>();
    List<FunctionTable> functionable = new List<FunctionTable>();

bool insertMT(String name, String type, String TM, List<String?> extension, List<String?> implemetation, String reference, ref List<MainTable> mainTable)
{
    MainTable m = new MainTable(name, type, TM, extension, implemetation, reference);
    if (mainTable.Contains(m)) 
    {
        return false;
    }
    else
    {
        mainTable.Append(m);
        return true;
    }
}
MainTable? lookupMT(String name,ref List<MainTable> mainTable)
{
    for (int i = 0; i < mainTable.Count; i++) 
    {
        if (mainTable[i].name!.Equals(name)) 
        {
            return mainTable[i];
        }
    }
    return null;
}
bool insertCT(string name,string type,string accessModifier,bool isStatic,bool isFinal,bool isAbstract,ref List<ClassTable> classTable)
{
    ClassTable c = new ClassTable( name, type, accessModifier, isStatic, isFinal, isAbstract);
    for (int i = 0; i < mainTable.Count; i++) 
    {
        ClassTable ct = classTable[i];
        if (ct.name!.Equals(name)) 
        {
            classTable.Append(c);
            return true;
        }
    }return false;
}
ClassTable? LookupCT(String Name, String className,ref List<ClassTable> classTable)
{
    for (int i = 0; i < classTable.Count; i++) 
    {
        if(classTable[i].name.Equals(className)){
            return classTable[i];
        }
    }
    return null;
}
bool insertFT(String name, String type, int scope,ref List<FunctionTable> functionTable)
{

        foreach(FunctionTable item in functionable) {
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

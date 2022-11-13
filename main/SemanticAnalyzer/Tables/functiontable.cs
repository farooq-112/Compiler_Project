public struct FunctionTable
{
    public string name;
    public string type;
    public int scope;


    public FunctionTable(string name,string type,int scope)
   {
    this.name = name;
    this.type = type;
    this.scope = scope;

   }
}

//  var data = semanticAnalyzer.lookupFT(token[index].Item3,semanticAnalyzer.scopenum);
//             if (data != null){
//                 Console.WriteLine($"Already Exist in table : {data}");
//             }else{
//                 semanticAnalyzer.insertFT(token[index].Item3,token[index].Item2,semanticAnalyzer.scopenum);
//             }
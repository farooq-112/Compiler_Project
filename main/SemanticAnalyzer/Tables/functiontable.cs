public struct FunctionTable
{
    public string? name;
    public string? type;
    public int? scope;


    public FunctionTable(string? name,string? type,int? scope)
   {
    this.name = name;
    this.type = type;
    this.scope = scope;

   }
}
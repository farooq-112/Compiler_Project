public struct ClassTable
{
    public string name;
    public string type;
    public string accessModifier;
    public bool isStatic;
    public bool isFinal;
    public bool isAbstract;

    public ClassTable(string name,string type,string accessModifier,bool isStatic,bool isFinal,bool isAbstract)
   {
    this.name = name;
    this.type = type;
    this.accessModifier = accessModifier;
    this.isStatic = isStatic;
    this.isFinal = isFinal;
    this.isAbstract = isAbstract;

   }
}
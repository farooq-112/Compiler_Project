struct ClassTable
{
    string name;
    string type;
    string accessModifier;
    bool isStatic;
    bool isFinal;
    bool isAbstract;


    ClassTable(string name,string type,string accessModifier,bool isStatic,bool isFinal,bool isAbstract)
   {
    this.name = name;
    this.type = type;
    this.accessModifier = accessModifier;
    this.isStatic = isStatic;
    this.isFinal = isFinal;
    this.isAbstract = isAbstract;

   }
}
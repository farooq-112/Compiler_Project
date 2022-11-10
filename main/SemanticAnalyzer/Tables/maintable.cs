public class MainTable
{
    public string? name;
    public string? type;
    public string? accessModifier;
    public string? typeModifier;
    public List<String>? parent;
    public List<ClassTable>? refDT;

    public MainTable()
    {
    }

    public MainTable(string name,string type,string accessModifier,string typeModifier, List<String>? parent)
   {
    this.name = name;
    this.type = type;
    this.accessModifier = accessModifier;
    this.typeModifier = typeModifier;
    this.parent = parent;
   }
}
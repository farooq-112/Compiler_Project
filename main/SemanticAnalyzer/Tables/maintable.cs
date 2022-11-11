public class MainTable
{
    public string? name;
    public string? type;
    public string? accessModifier;
    public string? typeModifier;
    public List<string>? parent = new List<string>();
    public List<ClassTable>? refDT = new List<ClassTable>();

    public MainTable()
    {
    }

    public MainTable(string name,string type,string accessModifier,string typeModifier, List<string>? parent)
   {
    this.name = name;
    this.type = type;
    this.accessModifier = accessModifier;
    this.typeModifier = typeModifier;
    this.parent = parent;
   }
}
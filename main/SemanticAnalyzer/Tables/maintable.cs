public struct MainTable
{
    public string? name;
    public string? type;
    public string? typeModifier;
    public List<String?> extension = new List<String?>();
    public List<String?> implementation = new List<String?>();
    public string? reference;
    public MainTable(string name,string type,string typeModifier, List<String?> extension,List<String?> implementation,string reference)
   {
    this.name = name;
    this.type = type;
    this.typeModifier = typeModifier;
    this.extension = extension;
    this.implementation = implementation;
    this.reference = reference;

   }
}
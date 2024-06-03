namespace SimpleDapperApp.Entities
{
  public class PetType : BaseEntity
  {
    public PetType(int? id, string name) : base(id)
    {
      Name = name;
    }
    public string Name { get; set; }
  }
}
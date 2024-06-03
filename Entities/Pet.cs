namespace SimpleDapperApp.Entities
{
  public class Pet : BaseEntity
  {
    public Pet(int? id, int personId, string name, int petTypeId, int age, string color) : base(id)
    {
      PersonId = personId;
      Name = name;
      PetTypeId = petTypeId;
      Age = age;
      Color = color;
    }

    public int PersonId { get; set; }
    public string Name { get; set; }
    public int PetTypeId { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
      return $"Name: {Name} | Pet Type: {PetTypeId} | Age: {Age} | Color: {Color}";
    }
  }
}
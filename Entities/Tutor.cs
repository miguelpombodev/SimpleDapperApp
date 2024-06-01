namespace SimpleDapperApp.Models
{
  public class Tutor
  {
    public Tutor(string name, string address, string city)
    {
      Name = name;
      Address = address;
      City = city;
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }


    public override string ToString() {
      return $"Name: {Name} | Address: {Address} | City: {City}";
    }
  }
}
namespace SimpleDapperApp.Entities
{
  public class BaseEntity
  {
    public BaseEntity(int? id = null)
    {
      Id = id;
    }

    public int? Id { get; set; }
  }
}
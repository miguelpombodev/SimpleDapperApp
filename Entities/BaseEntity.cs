namespace SimpleDapperApp.Entities
{
    public class BaseEntity
    {
        public BaseEntity (int? id) {
          Id = id;
        }

        public int? Id { get; set; }
    }
}
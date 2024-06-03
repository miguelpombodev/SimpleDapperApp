using SimpleDapperApp.Entities;

namespace SimpleDapperApp.Services
{
  public class PetTypesService
  {
    public PetTypesService()
    {
      DatabaseConnection = new DatabaseConnection<PetType>(
        "PetTypes"
      );
    }

    private readonly DatabaseConnection<PetType> DatabaseConnection;
    private string GetOnePetTypeByNameEntitySqlFile { get; set; } = "get-one-pet-type-by-name";


    public PetType? GetOnePetTypeByName(string name)
    {
      PetType? ExistedPetType = this.DatabaseConnection.GetOneFromDatabase(this.GetOnePetTypeByNameEntitySqlFile, new
      {
        Name = name
      });

      if (ExistedPetType == null)
      {
        return null;
      }

      return ExistedPetType;
    }
  }
}
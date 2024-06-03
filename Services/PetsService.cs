using SimpleDapperApp.DTOs;
using SimpleDapperApp.Entities;
using SimpleDapperApp.Models;
using SimpleDapperApp.Utils;

namespace SimpleDapperApp.Services
{
  public class PetsService
  {
    public PetsService()
    {
      DatabaseConnection = new DatabaseConnection<Pet>(
        "Pets"
      );
      TutorService = new TutorService();
      PetTypesService = new PetTypesService();
    }
    private readonly DatabaseConnection<Pet> DatabaseConnection;
    private readonly TutorService TutorService;
    private readonly PetTypesService PetTypesService;
    private string GetPetsListSqlFile { get; set; } = "get-pets-list";
    private string InsertPetEntitySqlFile { get; set; } = "add-pet";
    private string UpdatePetEntitySqlFile { get; set; } = "update-pet";
    private string DeletePetEntitySqlFile { get; set; } = "delete-pet";
    private string GetOnePetByNameEntitySqlFile { get; set; } = "get-one-pet-type-by-name";

    public IEnumerable<Pet> GetPetsList()
    {
      var PetsList = this.DatabaseConnection.SelectRowsFromDatabase(this.GetPetsListSqlFile);

      foreach (var pet in PetsList)
      {
        Console.WriteLine(pet.ToString());
      }

      return PetsList;
    }

    public string InsertPet()
    {
      CreatePetDTO PetToInput = this.GetInputtedPet();

      Tutor? ExistedTutor = TutorService.GetOneTutorByName(PetToInput.PetTutorName);

      if (ExistedTutor == null)
      {
        return "There's no tutor with the searched name";
      }

      PetType? ExistedPetType = PetTypesService.GetOnePetTypeByName(PetToInput.PetType);

      if (ExistedPetType == null)
      {
        return "There's no pet type with the searched name";
      }

      int InsertResult = this.DatabaseConnection.ExecuteParameterizedInDatabase(this.InsertPetEntitySqlFile, new
      {
        TutorId = ExistedTutor.Id,
        PetName = PetToInput.PetName,
        PetTypeId = ExistedPetType.Id,
        PetAge = PetToInput.PetAge,
        PetColor = PetToInput.PetColor
      });

      if (InsertResult == 0)
      {
        return "No pet was inserted";
      }

      return "The tutor was inserted successfully!";
    }

    private CreatePetDTO GetInputtedPet()
    {
      Console.WriteLine("Type the pet name");
      string PetName = Console.ReadLine().Trim();
      Console.Clear();

      Console.WriteLine("Type the pet's tutor name");
      string PetTutorName = Console.ReadLine().Trim();
      Console.Clear();

      Console.WriteLine("Type the pet type");
      string PetType = Console.ReadLine().Trim();
      Console.Clear();

      Console.WriteLine("Type the pet age");
      int PetAge = int.Parse(Console.ReadLine().Trim());
      Console.Clear();

      Console.WriteLine("Type the pet color");
      string PetColor = Console.ReadLine().Trim();
      Console.Clear();

      return new CreatePetDTO(
        StringUtils.CapitalizeString(PetName),
        StringUtils.CapitalizeString(PetTutorName),
        StringUtils.CapitalizeString(PetType),
        PetAge,
        StringUtils.CapitalizeString(PetColor)
      );
    }
  }
}
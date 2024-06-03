using Org.BouncyCastle.Asn1.Misc;
using SimpleDapperApp.Models;

namespace SimpleDapperApp.Services
{
  class TutorService
  {
    public TutorService()
    {
      connectionDatabase = new DatabaseConnection<Tutor>(
        "Tutor"
      );
    }
    private readonly DatabaseConnection<Tutor> connectionDatabase;
    private string GetTutorsListSqlFile { get; set; } = "get-tutors-list";
    private string InsertTutorEntitySqlFile { get; set; } = "add-tutor";
    private string UpdateTutorEntitySqlFile { get; set; } = "update-tutor";
    private string DeleteTutorEntitySqlFile { get; set; } = "delete-tutor";
    private string GetOneTutorByNameEntitySqlFile { get; set; } = "get-one-tutor-by-name";

    public IEnumerable<Tutor> GetTutorsList()
    {
      var personsList = this.connectionDatabase.SelectRowsFromDatabase(this.GetTutorsListSqlFile);

      foreach (var person in personsList)
      {
        Console.WriteLine(person.ToString());
      }

      return personsList;
    }

    public Tutor? GetOneTutorByName(string name)
    {
      Tutor? ExistedTutor = this.connectionDatabase.GetOneFromDatabase(this.GetOneTutorByNameEntitySqlFile, new
      {
        Name = name
      });

      if (ExistedTutor == null)
      {
        return null;
      }

      return ExistedTutor;
    }

    public string InsertTutor()
    {
      Tutor TutorToInput = this.GetInputtedTutor();

      var InsertResult = this.connectionDatabase.ExecuteParameterizedInDatabase(this.InsertTutorEntitySqlFile, new
      {
        Name = TutorToInput.Name,
        Address = TutorToInput.Address,
        City = TutorToInput.City
      });

      if (InsertResult == 0)
      {
        return "No tutor was inserted";
      }

      return "The tutor was inserted successfully!";
    }
    public string UpdateTutor()
    {
      Console.WriteLine("Type the tutor's name to be updated");
      string ToBeUpdatedTutorName = Console.ReadLine().Trim();

      var ToBeUpdatedTutor = this.GetOneTutorByName(ToBeUpdatedTutorName);

      if (ToBeUpdatedTutor == null)
      {
        return "There's no tutor with the searched name";
      }

      Tutor UpdatedTutorInformations = this.GetInputtedTutor();
      UpdatedTutorInformations.Id = ToBeUpdatedTutor.Id;

      int UpdateResult = this.connectionDatabase.ExecuteParameterizedInDatabase(this.UpdateTutorEntitySqlFile, new
      {
        Name = UpdatedTutorInformations.Name,
        Address = UpdatedTutorInformations.Address,
        City = UpdatedTutorInformations.City,
        Id = UpdatedTutorInformations.Id
      });

      if (UpdateResult == 0)
      {
        return "No tutor was updated";
      }

      return "The tutor was updated successfully!";
    }

    public string DeleteTutor()
    {
      Console.WriteLine("Type the tutor's name to be deleted");
      string ToBeDeletedTutorName = Console.ReadLine().Trim();

      var ToBeDeletedTutor = this.GetOneTutorByName(ToBeDeletedTutorName);

      if (ToBeDeletedTutor == null)
      {
        return "There's no tutor with the searched name";
      }

      int DeletionResult = this.connectionDatabase.ExecuteParameterizedInDatabase(this.DeleteTutorEntitySqlFile, new
      {
        Id = ToBeDeletedTutor.Id
      });

      if (DeletionResult == 0)
      {
        return "No tutor was deleted";
      }

      return "The tutor was deleted successfully!";
    }

    private Tutor GetInputtedTutor()
    {
      Console.WriteLine("Type the tutor name");
      string TutorName = Console.ReadLine().Trim();
      Console.Clear();

      Console.WriteLine("Type the tutor address");
      string TutorAddress = Console.ReadLine().Trim();
      Console.Clear();

      Console.WriteLine("Type the tutor city");
      string TutorCity = Console.ReadLine().Trim();
      Console.Clear();

      return new Tutor(
        TutorName,
        TutorAddress,
        TutorCity
      );
    }
  }
}
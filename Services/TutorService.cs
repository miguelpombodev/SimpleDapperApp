using SimpleDapperApp.Models;

namespace SimpleDapperApp.Services {
  class TutorService {
    public TutorService() {
      connectionDatabase = new DatabaseConnection<Tutor>(
        "Tutor"
      );
    }
    private readonly DatabaseConnection<Tutor> connectionDatabase;
    private string GetTutorsListSqlFile { get; set; } = "get-tutors-list";
    private string InsertTutorEntitySqlFile { get; set; } = "add-tutor";
    
    public IEnumerable<Tutor> GetTutorsList () {
      var personsList = this.connectionDatabase.SelectRowsFromDatabase(this.GetTutorsListSqlFile);

      foreach (var person in personsList) {
        Console.WriteLine(person.ToString());
      }
      
      return personsList;
    }

    public string InsertTutor () {
      Tutor TutorToInput = this.GetInputtedTutor();

      var insertResult = this.connectionDatabase.ExecuteParameterizedInDatabase(this.InsertTutorEntitySqlFile, new {
        Name = TutorToInput.Name,
        Address = TutorToInput.Address,
        City = TutorToInput.City
      });

      if (insertResult == 0) {
        return "No tutor was inserted";
      }

      return "The tutor was inserted successfully!";
    }

    public void DeletePersons () {}

    public void UpdatePersons () {}

    private Tutor GetInputtedTutor () {
      Console.WriteLine("Type the tutor name");
      string TutorName = Console.ReadLine();
      Console.Clear();

      Console.WriteLine("Type the tutor address");
      string TutorAddress = Console.ReadLine();
      Console.Clear();

      Console.WriteLine("Type the tutor city");
      string TutorCity = Console.ReadLine();
      Console.Clear();

      return new Tutor(
        TutorName,
        TutorAddress,
        TutorCity
      );
    }
  }
}
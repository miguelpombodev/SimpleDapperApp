using SimpleDapperApp.Services;

namespace SimpleDapperApp
{
  class Program
  {

    static void SelectTutors() {
      var tutorService = new TutorService();
      Console.WriteLine("--------------------------- PLEASE CHOOSE YOUR OPTION ---------------------------");
      Console.WriteLine("1 - Get Tutors List");
      Console.WriteLine("2 - Insert a Tutor");
      Console.WriteLine("3 - Update a Tutor");
      Console.WriteLine("4 - Delete a Tutor");
      
      int userOptionChoosed = Convert.ToInt32(Console.ReadLine());

      switch (userOptionChoosed) {
        case 1: 
              tutorService.GetTutorsList();
              break;
        case 2:
              Console.WriteLine(tutorService.InsertTutor());
              break;
        default: 
              Console.WriteLine("ERROR - INPUTTED VALUE NOT ACCEPTED");
              break;
      }
    }

    static void SelectPets() {
      Console.WriteLine("--------------------------- PLEASE CHOOSE YOUR OPTION ---------------------------");
      Console.WriteLine("1 - Get Persons List");
      Console.WriteLine("2 - Insert a Pet");
      Console.WriteLine("3 - Update a Pet");
      Console.WriteLine("4 - Delete a Pet");
      
      int userOptionChoosed = Convert.ToInt32(Console.ReadLine());

      // switch (userOptionChoosed) {
      //   case 1: 
      //         GetRows(connection, "SELECT * FROM Persons");
      //         break;
      //   case 2:
      //         InsertRow(insertParams);
      //         break;
      //   default: 
      //         Console.WriteLine("ERROR - INPUTTED VALUE NOT ACCEPTED");
      //         break;
      // }
    }
    static void Main(string[] args)
    {
      Console.WriteLine("--------------------------- PLEASE CHOOSE YOUR OPTION ---------------------------");
      Console.WriteLine("1 - Get Into Person");
      Console.WriteLine("2 - Get Into Pets");
      Console.Clear();

      int menuSelectedOption = Convert.ToInt32(Console.ReadLine());

      switch (menuSelectedOption) {
        case 1: 
              SelectTutors();
              break;
        case 2:
              SelectPets();
              break;
        default: 
              Console.WriteLine("ERROR - INPUTTED VALUE NOT ACCEPTED");
              break;
      }
    }
  }
}

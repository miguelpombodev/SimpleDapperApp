namespace SimpleDapperApp.DTOs
{
  public class CreatePetDTO
  {
    public CreatePetDTO(string petName, string petTutorName, string petType, int petAge, string petColor)
    {
      PetName = petName;
      PetTutorName = petTutorName;
      PetType = petType;
      PetAge = petAge;
      PetColor = petColor;
    }

    public string PetName { get; set; }
    public string PetTutorName { get; set; }
    public string PetType { get; set; }
    public int PetAge { get; set; }
    public string PetColor { get; set; }
  }
}
namespace SimpleDapperApp.Utils
{
  public class StringUtils
  {
    public static string CapitalizeString(string stringToCapitalize)
    {
      string capitalizedString = string.Concat(char.ToUpper(stringToCapitalize[0]) + stringToCapitalize.Substring(1));

      return capitalizedString;
    }
  }
}
namespace FinalProject
{
    public interface IStringUtilities
    {
        static String Proper(String improper, char? delimiter = ' ')
        {
            if(delimiter is null)
            {
                if (improper.Length > 1) return char.ToUpper(improper[0]) + improper[1..].ToLower();
                else return improper.ToUpper();
            }
            else
            {
                string[] parts = improper.Split((char)delimiter);
                List<String> partsList = new(parts);
                List<String> newPartsList = new();
                partsList.ForEach(part => {
                    newPartsList.Add(Proper(part, null));
                });
                return String.Join((char)delimiter, newPartsList);
            }
        }
        static String ProperKey(String improper, char? delimiter = ' ')
        {
            if (delimiter is null) return Proper(improper);
            else
            {
                string[] parts = improper.Split((char)delimiter);
                List<String> partsList = new(parts);
                List<String> newPartsList = new();
                partsList.ForEach(part => {
                    newPartsList.Add(Proper(part, null));
                });
                return String.Join(string.Empty, newPartsList);
            }
        }
    }
}
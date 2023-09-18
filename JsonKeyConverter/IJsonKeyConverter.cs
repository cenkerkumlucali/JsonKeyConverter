public interface IJsonKeyConverter
{
    string ConvertToJsonWithKebabCaseKeys(string inputObject);
    string ConvertToJsonWithPascalCaseKeys(string inputObject);
}
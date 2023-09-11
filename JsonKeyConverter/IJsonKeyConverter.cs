public interface IJsonKeyConverter
{
    string ConvertToJsonWithKebabCaseKeys(object inputObject);
    string ConvertToJsonWithPascalCaseKeys(object inputObject);
}
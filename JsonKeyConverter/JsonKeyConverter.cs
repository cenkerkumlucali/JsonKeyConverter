using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonKeyConverter : IJsonKeyConverter
{
    public string ConvertToJsonWithKebabCaseKeys(object inputObject)
    {
        JObject original = JObject.Parse(JsonConvert.SerializeObject(inputObject));
        JObject updated = ConvertKeys(original, ConvertToKebabCase);
        return updated.ToString();
    }

    public string ConvertToJsonWithPascalCaseKeys(object inputObject)
    {
        JObject original = JObject.Parse(inputObject.ToString());
        JObject updated = ConvertKeys(original, ConvertToPascalCase);
        return updated.ToString();
    }

    public JObject ConvertKeys(JObject original, Func<string, string> keyConverter)
    {
        var updatedObject = new JObject();
        foreach (var property in original.Properties())
        {
            var updatedName = keyConverter(property.Name);
            switch (property.Value.Type)
            {
                case JTokenType.Object:
                    updatedObject[updatedName] = ConvertKeys((JObject)property.Value, keyConverter);
                    break;
                case JTokenType.Array:
                    updatedObject[updatedName] = ProcessArray((JArray)property.Value, keyConverter);
                    break;
                default:
                    updatedObject[updatedName] = property.Value;
                    break;
            }
        }
        return updatedObject;
    }

    private JArray ProcessArray(JArray originalArray, Func<string, string> keyConverter)
    {
        var newArray = new JArray();
        foreach (var item in originalArray)
        {
            switch (item.Type)
            {
                case JTokenType.Object:
                    newArray.Add(ConvertKeys((JObject)item, keyConverter));
                    break;
                default:
                    newArray.Add(item);
                    break;
            }
        }
        return newArray;
    }

    private string ConvertToKebabCase(string input)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsUpper(c) && i > 0)
            {
                builder.Append("-");
            }
            builder.Append(char.ToLowerInvariant(c));
        }
        return builder.ToString();
    }

    private string ConvertToPascalCase(string input)
    {
        var parts = input.Split(new[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder builder = new StringBuilder();
        foreach (var part in parts)
        {
            if (string.IsNullOrEmpty(part)) continue;
            builder.Append(char.ToUpperInvariant(part[0]) + part.Substring(1).ToLowerInvariant());
        }
        return builder.ToString();
    }
}
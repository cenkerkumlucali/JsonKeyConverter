using Newtonsoft.Json.Linq;

IJsonKeyConverter jsonKeyConverter = new JsonKeyConverter();

// Test object
var testObject = new
{
    FirstName = "Cenker",
    LastName = "Kumlucalı",
    Age = 21,
    Address = new
    {
        City = "İstanbul"
    },
    PhoneNumbers = new[]
    {
        new { Type = "home", Number = "555-5555" },
        new { Type = "work", Number = "555-5556" }
    }
};

// Convert to kebab-case
string kebabCaseJson = jsonKeyConverter.ConvertToJsonWithKebabCaseKeys(testObject);
Console.WriteLine("Kebab-case JSON:");
Console.WriteLine(kebabCaseJson);

// Convert to PascalCase
JObject originalObject = JObject.Parse(kebabCaseJson); // Using kebab-case JSON as the source
string pascalCaseJson = jsonKeyConverter.ConvertToJsonWithPascalCaseKeys(originalObject);
Console.WriteLine("\nPascalCase JSON:");
Console.WriteLine(pascalCaseJson);
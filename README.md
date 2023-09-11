# JSON Key Converter Library

## Overview

This C# library allows you to convert the keys in a JSON object to different cases, such as kebab-case or PascalCase.

## Requirements

- .NET SDK 5.0 or higher

## Installation

```bash
git clone https://github.com/your-username/JsonKeyConverter.git
cd JsonKeyConverter
dotnet run
```

## Usage

### Convert to Kebab-case JSON
```csharp
IJsonKeyConverter jsonKeyConverter = new JsonKeyConverter();
var testObject = new
{
    FirstName = "Cenker",
    LastName = "Kumlucalı",
};
string kebabCaseJson = jsonKeyConverter.ConvertToJsonWithKebabCaseKeys(testObject);
```
### Convert to PascalCase JSON
```csharp
IJsonKeyConverter jsonKeyConverter = new JsonKeyConverter();
JObject originalObject = JObject.Parse("{\"first-name\": \"Cenker\", \"last-name\": \"Kumlucalı\"}");
string pascalCaseJson = jsonKeyConverter.ConvertToJsonWithPascalCaseKeys(originalObject);
```
## Contributing

Pull requests and stars are always welcome. For bugs and feature requests, please create an issue.

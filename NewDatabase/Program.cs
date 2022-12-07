// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using NewDatabase;
using NewDatabase.Models;
using NewDatabase.Util;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml;

Console.WriteLine("Hello, World!");

DbwApiHelper.InitializeDwbApiClient();
var dbwApi = new DbwApiProcessor();

string currentDirectory = Directory.GetCurrentDirectory();
string[] files = Directory.GetDirectories(currentDirectory);
string schemaFilePath = Path.Combine(files.FirstOrDefault(c => c.Contains("Models")), @"Schemas.json");

var result = string.Empty;

using (StreamReader klops = new StreamReader(schemaFilePath))
{
    result = klops.ReadToEnd();

}

var classGenerator = new ClassGenerator(result);

var listOfClasses = new List<List<string>>();
var dir = Path.Combine(classGenerator.ModelsDirectory, "Test");
if (!Directory.Exists(dir))
{
    Directory.CreateDirectory(dir);
}
foreach (var item in classGenerator.classGeneratorSchemas)
{
    var classToWrite = classGenerator.CreateClassAsString(item);
    var className = ClassGenerator.CreateCorrectNameForClass(item.ClassName);
    var dirOfClass = Path.Combine(dir, string.Format("{0}.cs", className));

    using (StreamWriter write = new StreamWriter(dirOfClass))
    {
        foreach (var line in classToWrite)
        {
            write.WriteLine(line);
        }
    }

}


foreach (var item in listOfClasses)
{
    var dirOfClass = Path.Combine(dir, string.Format("{}.cs"));

}

Console.WriteLine();

/*Console.WriteLine("Wpisz liczbę");
var chooseObszarTematyczny = Console.ReadLine();

var reult = await dbwApi.LoadDbwDataObszarTematyczny(Int32.Parse(chooseObszarTematyczny));
foreach (var item in reult)
{
    Console.WriteLine(item.ToString());
}
*/
/*using (NewDatabaseContext newDatabase = new NewDatabaseContext())
{
    newDatabase.Database.EnsureCreated();
    newDatabase.SaveChanges();
}
*/
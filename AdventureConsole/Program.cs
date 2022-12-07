// See https://aka.ms/new-console-template for more information
using AdventureConsole.Models;
using AdventureConsole.Something;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewDatabase.Util;

Console.WriteLine("Hello, World!");

List<string> address = new List<string>();

/*
var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
IConfiguration _configuration = builder.Build();
var myConnectionString1 = _configuration.GetConnectionString("AdventureWorks2019");
Console.WriteLine(myConnectionString1);

var builder2 = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddXmlFile("App.config", optional: true, reloadOnChange: true);
IConfiguration _configuration2 = builder2.Build();
var myConnectionString2 = _configuration.GetConnectionString("AdventureWorks2019");
Console.WriteLine(myConnectionString2);*/

/*using (var adventure = new AdventureWorks2019Context())
{
    address = (from s in adventure.Addresses
               select s.City).ToList();
}

foreach (var item in address)
{
    Console.WriteLine(item);
}
*/
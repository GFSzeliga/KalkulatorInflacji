using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase.Util
{
    public class ClassGenerator
    {
        public IEnumerable<ClassGeneratorSchema> classGeneratorSchemas;
        private IEnumerable<string> NecessaryLibraries = new List<string> 
        {
        "using System.Text.Json.Serialization;"
        };

        private string LeftCurlyBrace = "{";
        private string RightCurlyBrace = "}\r\n";
        private static DirectoryInfo ProjectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
        private static string ProjectDirectoryRooted = ProjectDirectory.FullName;
        private static string ProjectDirectoryName = ProjectDirectory.Name;
        private static string DefaultModelsFolderName = "Models";

        public string ModelsDirectory = Path.Combine(ProjectDirectoryRooted, DefaultModelsFolderName);
        private string Namespace = string.Format("{0}.{1}", ProjectDirectoryName, DefaultModelsFolderName);

        public ClassGenerator(string jsonPath)
        {
            NewSchemaCreator._jsonStringToDeserialize = jsonPath;
            classGeneratorSchemas = NewSchemaCreator.JsonSchemaDeserializer();
        }

        public List<string> CreateClassAsString(ClassGeneratorSchema generatorSchema)
        {
            var classAsStringList = new List<string>();

            // import potrzebnych bibliotek
            classAsStringList.AddRange(NecessaryLibraries);

            CreateNamespace(generatorSchema, classAsStringList);

            return classAsStringList;
        }

        private void CreateNamespace(ClassGeneratorSchema generatorSchema, List<string> classBuilder)
        {
            var namespaceString = new StringBuilder()
                .Append("namespace ")
                .Append(Namespace)
                .Append(string.Format("\r\n{0}\r\n\r\n",LeftCurlyBrace))
                .ToString();
            classBuilder.Add(namespaceString);
            CreateClass(generatorSchema, classBuilder);
            classBuilder.Add(RightCurlyBrace);
        }

        private string GetClassName(ClassGeneratorSchema generatorSchema)
        {
            return generatorSchema.ClassName;
        }

        private void CreateClass(ClassGeneratorSchema generatorSchema, List<string> classBuilder)
        {
            var firstLineOfClass = new StringBuilder()
                .Append("\tpublic class ")
                .Append(CreateCorrectNameForClass(GetClassName(generatorSchema)))
                .Append(" : BaseModel")
                .Append(String.Format("\r\n{0}\r\n", LeftCurlyBrace))
                .ToString();
            classBuilder.Add(firstLineOfClass);

            foreach (var property in generatorSchema.Properties)
            {
                CreateProperty(property, GetValue(property, generatorSchema.PropertiesAttributes), classBuilder);
            }
            classBuilder.Add(string.Format("\t{0}", RightCurlyBrace));

        }

        private void CreateProperty(string property, Dictionary<string, string> propertyAttributes, List<string> classBuilder)
        {
            var type = GetValue("type", propertyAttributes);
            var format = GetValue("format", propertyAttributes);
            var nullable = GetValue("nullable", propertyAttributes);
            var isQuestionMark = !string.IsNullOrEmpty(nullable) && Boolean.Parse(nullable) ? 
                "?" : 
                string.Empty;
            var questionMark = isQuestionMark.IsNullOrEmpty() ? "" : "?";

            var items = GetValue("items", propertyAttributes);

            var firstLine = new StringBuilder()
                .Append("\t\t[JsonPropertyName(\"")
                .Append(property)
                .Append("\")]")
                .ToString();
            var secondLIne = new StringBuilder()
                .Append("\t\tpublic ")
                .Append(GetTypeDescriptor(type, format))
                .Append(CreateCorrectName(property, type,questionMark))
                .Append(" { get; set; }\r\n")
                .ToString();

            classBuilder.Add(firstLine);
            classBuilder.Add(secondLIne);
        }

        private string GetValue(string valueName, Dictionary<string, string> propertyAttributes)
        {
            var value = string.Empty;
            if (propertyAttributes.TryGetValue(valueName, out value))
            {
                return value == "data" ? "data-property" : value;
            }
            else
            {
                return string.Empty;
            }
        }

        private Dictionary<string, string> GetValue(string property, Dictionary<string, Dictionary<string, string>> propertyAttributes)
        {
            Dictionary<string, string> value;
            if (propertyAttributes.TryGetValue(property, out value))
            {
                return value;
            }
            return null;
        }

        private string GetTypeDescriptor(string type, string format)
        {
            if (type.ToLower() == "integer")
            {
                return format.IsNullOrEmpty() ? "int" : string.Concat(format.Substring(0,1).ToUpper().Concat(format.Substring(1)));
            }
            if (type.ToLower() == "string")
            {
                return type;
            }
            if (type.ToLower() == "array")
            {
                return "IEnumerable<";
            }
            if (type.ToLower() == "number" && format == "double")
            {
                return format;
            }
            if (type.ToLower() == "boolean")
            {
                return "bool";
            }


            return string.Empty;
        }

        public static string CreateCorrectName(string property, string type, string questionMark)
        {
            var properName = property;

            if (property.Contains("'") || property.Contains("[") || property.Contains("]"))
            {
                properName = properName.Substring(2, properName.Length - 4).Replace(".","");
            }

            var editedProperName = string.Concat(properName
            .Split("-")
            .Select(name => string.Concat(name.Substring(0, 1).ToUpper().Concat(name.Substring(1)))));

            if (type.ToLowerInvariant() != "array".ToLowerInvariant())
            {
                editedProperName = questionMark + " " + editedProperName;
            }

            return string.Concat(editedProperName, type.ToLowerInvariant().Contains("array") ? string.Format(">{1} {0}", editedProperName, questionMark) : "");
        }

        public static string CreateCorrectNameForClass(string property)
        {
            var properName = property;
            if (property.Contains("'") || property.Contains("[") || property.Contains("]"))
            {
                properName = properName.Substring(2, properName.Length - 4).Replace(".", "");
            }

            return string.Concat(properName
            .Split("-")
            .Select(name => string.Concat(name.Substring(0, 1).ToUpper().Concat(name.Substring(1)))));
        }

    }
}

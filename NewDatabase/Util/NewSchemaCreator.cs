using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewDatabase.Util
{
    public static class NewSchemaCreator
    {

        public static string _jsonStringToDeserialize;

        private static JToken DeserializedJsonSchema { get { return JsonConvert.DeserializeObject<JToken>(_jsonStringToDeserialize); } }
        private static string propertiesDescriptor = "properties";

        public static IEnumerable<ClassGeneratorSchema> JsonSchemaDeserializer()
        {
            var mainChildrens = GetAllMainChildren(DeserializedJsonSchema);

            var listClass = new List<ClassGeneratorSchema>();

            foreach (var item in mainChildrens)
            {
                var classSchema = new ClassGeneratorSchema();

                classSchema.ClassName = item.GetCurrentMainNodeName();

                var propertiesObject = item.CreateJpathForWantedNode(propertiesDescriptor)
                    .GetPropertyValuesFromObjectHierarchy();

                classSchema.Properties = propertiesObject.GetPropertiesNames().ToList();

                classSchema.PropertiesAttributes = propertiesObject
                    .GetPropertiesNames()
                    .Select(a =>
                    new
                    {
                        propName = a,
                        propValue = propertiesObject
                        .CreateJpathForWantedNode(a)
                        .GetPropertyValuesFromObjectHierarchy()
                        .Select(b => 
                        new
                        {
                            attrName = b.GetCurrentMainNodeName(),
                            attrValue = b.GetCurrentMainNodeName() != "items" ? b.Path
                            .GetPropertyValuesFromObjectHierarchy()
                            .ToString() : b.First.Path.GetPropertyValuesFromObjectHierarchy()
                            .ToString()
                        }
                        ).ToDictionary(x => x.attrName, x => x.attrValue)
                    }
                    ).ToDictionary(x => x.propName, x => x.propValue);

                listClass.Add(classSchema);

            }
            Console.WriteLine();

            return listClass;
        }
        private static IEnumerable<string> GetPropertiesNames(this JToken jToken)
        {
            return jToken.Children().Select(c => c.GetCurrentMainNodeName());
        }

        private static string GetCurrentMainNodeName(this JToken jtoken)
        {
            return jtoken.Path.SafelySplitNode().Last();
        }

        private static List<string> SafelySplitNode(this string path)
        {
            var tempPath = path;
            var splitted = new List<string>();


            while (tempPath.Contains("["))
            {
                if (tempPath.Substring(0, 1) == ".")
                {
                    tempPath = tempPath.Substring(1);
                }

                if (tempPath.Substring(0,1) == "[")
                {
                    var regex = new Regex("\\[[a-zA-Z0-9\\-\\.']*\\]").Match(tempPath);
                    splitted.Add(tempPath.Substring(0, regex.Length));
                    tempPath = tempPath.Substring(regex.Length).Length == 0 ? string.Empty : tempPath.Substring(regex.Length);
                }
                else
                {
                    splitted.Add(tempPath.Split(".", 1)[0]);
                    tempPath = tempPath.Split(".", 1).Length > 1 ? tempPath.Split(".", 1)[1] : string.Empty;
                }

            }

            if (tempPath.Contains("."))
            {
                splitted.AddRange(tempPath.Split(".").ToList());
            }

            return splitted;
        }

        private static JEnumerable<JToken> GetAllMainChildren(JToken jsonObject)
        {
            return jsonObject.First.Children();
        }

        private static JToken GetPropertyValuesFromObjectHierarchy(this string jpath)
        {
            return DeserializedJsonSchema.SelectToken(jpath);
        }

        private static string GetCurrentNodeObjectJpath(this JToken jtoken)
        {
            return jtoken.Path;
        }

        private static string CreateJpathForWantedNode(this JToken jtoken, string jpath)
        {
            return string.Join(".", new[] { jtoken.GetCurrentNodeObjectJpath(), jpath });
        }
    }



}

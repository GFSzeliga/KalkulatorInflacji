using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase.Util
{
    public class ClassGeneratorSchema
    {

        public string ClassName { get; set; }
        public List<string> Properties { get; set; }
        public Dictionary<string, Dictionary<string, string>> PropertiesAttributes { get; set; }
    }
}

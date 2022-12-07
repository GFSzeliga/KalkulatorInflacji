using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class BaseModel
    {
        public override string ToString()
        {
            string objectAsString = "{";
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            {
                string name = property.Name;
                string value = property.GetValue(this).ToString();
                objectAsString += string.Format("\n\t\"{0}\": \"{1}\", ", name, value);

            }
            objectAsString += "},";
            return objectAsString;
        }
    }
}

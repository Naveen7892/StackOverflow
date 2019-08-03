using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class JsonSerializeBoolean {
      public static void MainJsonSerializeBoolean () {
         var json = JsonConvert.SerializeObject (SomeBoolObject);
         Console.WriteLine (json);
      }

      static public Element<bool> SomeBoolObject { get; set; } = new Element<bool> (false, false, "boolean");
   }

   public class Element<T> {
      public Element (T value, T defaultValue, string name) {
         Value = value;
         DefaultValue = defaultValue;
         TypeName = name;
      }
      public T Value { get; set; }
      public T DefaultValue { get; set; }
      public string TypeName { get; set; }
   }
}

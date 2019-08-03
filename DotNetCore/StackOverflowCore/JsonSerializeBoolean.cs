using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StackOverflowCore {
   class JsonSerializeBoolean {
      public static void MainJsonSerializeBoolean () {
         // dotnet add package Newtonsoft.Json
         var serializedJson = JsonConvert.SerializeObject (SomeBoolObject, new JsonSerializerSettings {
            DefaultValueHandling = DefaultValueHandling.Include
         });
         //var json = JsonConvert.SerializeObject (SomeBoolObject, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
         Console.WriteLine (serializedJson);
         var deserializedJson = JsonConvert.DeserializeObject <Element<bool>> (serializedJson);
         Console.WriteLine (deserializedJson);
      }

      static public Element<bool> SomeBoolObject { get; set; } = new Element<bool> (false, false, "boolean");
   }

   public class Element<T> {
      public Element (T value, T defaultValue, string type) {
         Value = value;
         DefaultValue = defaultValue;
         TypeName = type;
      } 
      public T Value { get; set; }
      public T DefaultValue { get; set; }
      public string TypeName { get; set; }

      public override string ToString () {
         return $"{nameof(Value)} { Value},{nameof (DefaultValue)} {DefaultValue},{nameof (TypeName)} {TypeName}";
      }
   }
}

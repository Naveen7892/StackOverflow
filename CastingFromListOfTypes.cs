using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class CastingFromListOfTypes {
      public static void MainCastFromListOfTypes (string[] args = null) {
         try {
            var strings = new List<string> () { "hi", "123", "542342342424423", "5.1" };
            var types = new List<Type> () { typeof (string), typeof (int), typeof (long), typeof (double) };
            foreach (var s in strings.Zip (types, (x, y) => new { Value = x, DataType = y }))
               if (!IsValidType (s.DataType.ToString (), s.Value)) throw new Exception ($"{s.DataType} is not a valid type for {s.Value}");
         } catch (Exception e) {
            Console.WriteLine (e.ToString ());
         }

         
      }

      static bool IsValidType (string data_type, string value) {
         switch (data_type) {
            case "System.Int32": return int.TryParse (value, out _);
            case "System.Int64": return long.TryParse (value, out _);
            case "System.Double": return double.TryParse (value, out _);
            case "System.String": return true;
            default: return false;
         }
      }
   }
}

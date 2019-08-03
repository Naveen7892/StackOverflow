using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class UpdateArrayInDictionary {
      public static void MainUpdateArrayInDictionary() {
         string[] data = new string[] {
            "1", "2", "3", "2", "1"
         };
         DocValueModelClass docValueModelClass;
         Dictionary<string, DocValueModelClass> jsonDictionary = new Dictionary<string, DocValueModelClass> ();
         int i = 0;
         while (i++ < 2) {
            if (data.Length == 5) {
               if (jsonDictionary.ContainsKey (data[4])) {
                  var newArray = new string[] { data[0] };
                  jsonDictionary[data[4]].destinationValue = jsonDictionary[data[4]].destinationValue.Concat (newArray).ToArray ();
                  newArray = new string[] { data[1] };
                  jsonDictionary[data[4]].sourceKey = jsonDictionary[data[4]].sourceKey.Concat (newArray).ToArray ();
               } else {
                  docValueModelClass = new DocValueModelClass {
                     destinationValue = new string[] { "nothing" },
                     sourceKey = new string[] { "nothing" }
                  };
                  jsonDictionary.Add (data[4], docValueModelClass);
               }
            }
            Console.WriteLine ($"-------------Iteration {i}-------------------");
            foreach(string s in jsonDictionary[data[4]].destinationValue) Console.Write ($"{s}, ");
            Console.WriteLine ();
            foreach(string s in jsonDictionary[data[4]].sourceKey) Console.Write ($"{s}, ");
            Console.WriteLine ();
         }
      }
   }

   public class DocValueModelClass {
      public string[] destinationValue;
      public string[] sourceKey;
   }
}

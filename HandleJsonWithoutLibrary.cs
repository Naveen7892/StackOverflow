using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace StackOverflow {
   /* REFERENCES:
    * https://www.codeproject.com/Questions/1179267/How-do-you-serialize-and-deserialize-without-newto
    * https://stackoverflow.com/questions/15818225/asp-net-c-javascriptserializer-could-not-be-found
    * https://docs.microsoft.com/en-us/dotnet/api/system.web.script.serialization.javascriptserializer?redirectedfrom=MSDN&view=netframework-4.8
    * 
    */
   class HandleJsonWithoutLibrary {
      public static void MainHandleJsonWithoutLibrary () {
         var serializer = new JavaScriptSerializer ();
         var json1 = "{count:[{first:1,second:2,third:3},{first:11,second:22,third:33},{first:111,second:222,third:333}]}";

         var jsonString = "{\"results\": [ {\"alternatives\": [ {\"transcript\": \"how old are you\", \"confidence\": 0.66882694 } ] }  ]}";
         var jsonDeserialized = serializer.Deserialize<dynamic> (jsonString);
         Console.WriteLine (jsonDeserialized["results"][0]["alternatives"][0]["transcript"]);

         MyClass jsona = (MyClass)serializer.Deserialize (json1, typeof (MyClass));
         foreach (Number item in jsona.count) {
            var first = item.first;
            var second = item.second;
            var third = item.third;
         }

      }
   }

   public class Number {
      public int first { get; set; }
      public int second { get; set; }
      public int third { get; set; }
   }

   public class MyClass {
      public Number[] count { get; set; }

   }
}

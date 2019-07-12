using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class GetEnumValue {

      public enum EFileTag { Clean, Modified }

      public enum EHgFileTag { Modified = 'M', Clean = 'C' }

      public enum EGitFileTag { Modified = 'M', Clean = 'X' }

      public static void MainGetEnumValue () {

         //var a = EFileTag.Clean; Console.WriteLine ((int)a);
         //a = EFileTag.Clean; Console.WriteLine ((char)a);
         //a = EFileTag.Modified; Console.WriteLine ((int)a);
         //a = EFileTag.Modified; Console.WriteLine ((char)a);

         //var b = EHgFileTag.Clean; Console.WriteLine ((int)b);
         //b = EHgFileTag.Clean; Console.WriteLine ((char)b);
         //b = EHgFileTag.Modified; Console.WriteLine ((int)b);
         //b = EHgFileTag.Modified; Console.WriteLine ((char)b);

         var eTag = Enum.GetName (typeof (EFileTag), EFileTag.Clean);
         Enum.TryParse (eTag, out EGitFileTag c);
         Console.WriteLine ((int)c);
         Console.WriteLine ((char)c);

         int enumValue = 2; // The value for which you want to get string 
         string enumName = Enum.GetName (typeof (EHgFileTag), enumValue);

         Console.ReadKey ();
      }
   }
}

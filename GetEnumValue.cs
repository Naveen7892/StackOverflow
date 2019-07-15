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

      static public string typeName { get; set; }

      public static void MainGetEnumValue (string[] args) {

         if (args.Length >= 1) {
            if (args[0].Equals ("-git")) typeName = "git";
            if (args[0].Equals ("-hg")) typeName = "hg";
         }
         //var a = EFileTag.Clean; Console.WriteLine ((int)a);
         //a = EFileTag.Clean; Console.WriteLine ((char)a);
         //a = EFileTag.Modified; Console.WriteLine ((int)a);
         //a = EFileTag.Modified; Console.WriteLine ((char)a);

         //var b = EHgFileTag.Clean; Console.WriteLine ((int)b);
         //b = EHgFileTag.Clean; Console.WriteLine ((char)b);
         //b = EHgFileTag.Modified; Console.WriteLine ((int)b);
         //b = EHgFileTag.Modified; Console.WriteLine ((char)b);

         // Original Poster's current solution
         //var eTag = Enum.GetName (typeof (EFileTag), EFileTag.Clean);
         //Enum.TryParse (eTag, out EHgFileTag c);
         //Console.WriteLine ((int)c);
         //Console.WriteLine ((char)c);

         //int enumValue = 2; // The value for which you want to get string 
         //string enumName = Enum.GetName (typeof (EHgFileTag), enumValue);

         // Other better ways
         try {
            var d = Enum.Parse (GetRepoType (), nameof (EFileTag.Clean));
            // using (char)d throws specified cast is not valid
            Console.WriteLine ($"USAGE: {d} - {Convert.ToChar (d)} - {(int)d}");
            typeName = "git";
            d = Enum.Parse (GetRepoType (), nameof (EFileTag.Clean));
            Console.WriteLine ($"USAGE: {d} - {Convert.ToChar (d)} - {(int)d}");
         } catch (Exception e) {
            Console.WriteLine (e);
         }

         Console.ReadKey ();
      }

      static Type GetRepoType () {
         switch (typeName) {
            case "hg": return typeof (EHgFileTag);
            case "git": return typeof (EGitFileTag);
            default: return typeof (EHgFileTag);
         }
      }
   }
}

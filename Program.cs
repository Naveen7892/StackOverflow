using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StackOverflow {
   public partial class Program {

      static Window win;
      static TextBlock tb;
      static Point lastPosition;

      public string TestGetter  { get; set; }
      public string TestPrivateSetter { get; set; }

      [STAThread]
      public static void Main (string[] args) {
         //Console.WriteLine ("Index out of bounds");
         //IndexOutOfBounds.MainIndexOutOfBounds ();
         //Console.WriteLine ("Json to Object");
         //JsonToObject.MainJsonToObject ();
         //Console.WriteLine ("Get Enum Value");
         //GetEnumValue.MainGetEnumValue (new[] { "-hg" });
         //Console.WriteLine ("Ghost Mouse Move");
         //RunApplication ();
         //Console.WriteLine ("Casting from list of types:");
         //CastingFromListOfTypes.MainCastFromListOfTypes ();
         //Console.WriteLine ("Parsing Very Large Numbers");
         //ParseVeryLargeNumber.MainParseVeryLargeNumber ();
         //Console.WriteLine ("ReflectionForGetterMethods");
         //ReflectionForGetterMethods.MainReflectionForGetterMethods ();
         //Console.WriteLine ("CompareTwoListObjects");
         //CompareTwoListObjects.MainCompareTwoListObjects ();
         //Console.WriteLine ("ListView disable repaint");
         //ListViewRepaint lwr = new ListViewRepaint ();
         //lwr.ShowDialog ();
         //Console.WriteLine ("Parsing string");
         //ParsingString.MainParsingString ();
         Console.WriteLine ("Json Serialized Boolean");
         JsonSerializeBoolean.MainJsonSerializeBoolean ();
         Console.ReadKey ();
      }      
   }
}

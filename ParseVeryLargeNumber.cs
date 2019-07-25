using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class ParseVeryLargeNumber {
      public static void MainParseVeryLargeNumber () {
         // BigInteger requires - System.Numerics namespace
         var value = BigInteger.Pow (2, 1000); // note: BigInteger.One << 1000 may be faster?
         Console.WriteLine (value);

         int[] digitsArray = BigInteger.Pow (2, 1000).ToString ().Select (d => d - '0').ToArray ();
         Console.WriteLine ();
         foreach (int i in digitsArray) Console.Write(i);

         Console.WriteLine ();
         digitsArray = value.ToString ().Select (d => Convert.ToInt32 (d) - '0'  ).ToArray ();
         Console.WriteLine ();
         foreach (int i in digitsArray) Console.Write (i);
         return;

         // Solution 1
         string s = value.ToString (); Console.WriteLine ($"Solution 1: {s}");
         int[] digits = new int[s.Length];
         for (int i = 0; i < digits.Length; i++) digits[i] = s[i] - '0';
         Console.WriteLine ();
         foreach (int i in digits) Console.Write (i);
         Console.WriteLine ();

         // Solution 2 - to get sum
         int sum = 0;
         foreach (char c in s) sum += c - '0';
         Console.WriteLine ();
         Console.WriteLine (sum);

         var v = Math.Pow (2, 1000);
         Console.WriteLine (v);
      }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {

   /* References:
    * https://dotnetfiddle.net/txr4Qz
    */
   class ReadTextFileWithNumbers {

      static char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
      static Dictionary<string, string> dict = new Dictionary<string, string> ();
      public static void MainReadTextFileWithNumbers() {
         string text = "one\ttwo three:four,five six seven";
         ProcessWords (text);
         text = "one\t2 three:4,five 6 seven";
         ProcessWords (text);
         text = "00\t0000000  0120:0111111111 ,0120 0120 0120";
         ProcessWords (text);
      }

      static void ProcessWords (string text) {
         // Console.WriteLine ($"Original text: '{text}'");
         string[] words = text.Split (delimiterChars);
         // Console.WriteLine ($"{words.Length} words in text!");
         dict.Clear ();
         // Checks words in pair
         for (int i = 0; i + 1 < words.Length; i+=2) {
            // Checks if word is of number (change it as per your requirement)
            if (int.TryParse (words[i], out int _) && int.TryParse (words[i+1], out int _)) {
               dict.Add (words[i], words[i+1]);
               // process the word
            }
         }
         if (dict.Count == 0) Console.WriteLine ("No pair with Integer values");
         foreach (var d in dict) {
            // Process the data
            Console.WriteLine ($"{d.Key} - {d.Value}");
         }
         Console.WriteLine ();
      }
   }
}

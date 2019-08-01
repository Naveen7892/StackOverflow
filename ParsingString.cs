using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class ParsingString {
      public static void MainParsingString () {
         string teststring = "Dev_Audio_S1_M1.wav";
         ParseString (teststring);
         teststring = "Dev_Audio_M123_S321.wav";
         ParseString (teststring);
         teststring = "M123_S321.wav";
         ParseString (teststring);
      }

      static void ParseString (string teststring) {
         string valueS = "", valueM = "";
         int i = 0;
         int limit = teststring.Length - 1;
         while (i < limit) {
            if ((teststring[i] == '_' && teststring[i + 1] == 'S') || (i == 0 && teststring[i] == 'S')) {
               int currentIndex = i == 0 ? i + 1 : i + 2;
               while (currentIndex <= limit && (teststring[currentIndex] != '_' && teststring[currentIndex] != '.')) valueS += teststring[currentIndex++];
               i = currentIndex;
            } else if ((teststring[i] == '_' && teststring[i + 1] == 'M') || (i == 0 && teststring[i] == 'M')) {
               int currentIndex = i == 0 ? i + 1 : i + 2;
               while (currentIndex <= limit && (teststring[currentIndex] != '_' && teststring[currentIndex] != '.')) valueM += teststring[currentIndex++];
               i = currentIndex;
            } else {
               i++;
            }
         }

         Console.WriteLine (valueS);
         Console.WriteLine (valueM);
      }
   }
}

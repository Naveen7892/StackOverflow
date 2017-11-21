using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {

   #region References

   // https://stackoverflow.com/questions/47407102/index-array-errors#47407102
   // https://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file
   // https://stackoverflow.com/questions/6416564/how-to-read-a-text-file-in-projects-root-directory

   #endregion References
   class IndexOutOfBounds {
      static void MainIndexOutOfBounds (string[] args) {

         var cbListStudents = new List<String> ();
         var cbListCourses = new List<String> ();

         var d = File.ReadAllLines (@"res/TestFile.txt");
         var t = d.Where (g => g.Contains ("Student Name"));
         string[] splited;
         foreach (var item in t) {
            splited = item.Split (new string[] { "Student Name:" }, StringSplitOptions.None);
            cbListStudents.Add (splited[1]);
         }

         var cour = File.ReadAllLines (@"res/TestFile2.txt");
         var courFind = cour.Where (g => g.Contains ("Course"));
         string[] splited2;
         foreach (var item in courFind) {
            splited2 = item.Split (new string[] { "Course:" }, StringSplitOptions.None);
            cbListCourses.Add (splited2[1]); //here is where the issues starts
         }

         Console.ReadKey ();
      }
   }
}

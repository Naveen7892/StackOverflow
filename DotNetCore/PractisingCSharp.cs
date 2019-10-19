using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace PracticingCSharp {
   class Program {
      static void Main (string[] args) {
         Console.WriteLine ("Hello World!");

         // TestGZipCompression (); return;

         Console.WriteLine (new Decimal (10.000).ToString ("G"));
         Console.WriteLine (new Decimal (0.000000).ToString ("G"));
         Console.WriteLine (new Decimal (30000).ToString ("G"));

         Console.WriteLine (Convert.ToDecimal ("10.000").ToString ("G"));
         Console.WriteLine (Convert.ToDecimal ("0.000000").ToString ("G"));
         Console.WriteLine (Convert.ToDecimal ("30000").ToString ("G"));

         Console.WriteLine (Decimal.Parse ("10.000").ToString ("G"));
         Console.WriteLine (Decimal.Parse ("0.000000").ToString ("G"));
         Console.WriteLine (Decimal.Parse ("30000").ToString ("G"));

         Dictionary<string, int> d = new Dictionary<string, int> ();
         //d.Add ("a", 1);
         //d.Add ("a", 1); // Throws error
         d["a"] = 1;
         d["a"] = 2;
         d["a"] = 3;


         string a = null;

         // Throws error
         //if (a.Equals (b)) Console.WriteLine ("Check passed");
         //else Console.WriteLine ("Check failed");

         // compare safely
         if (!string.IsNullOrEmpty (a) && a.Equals ("abc")) Console.WriteLine ("Check passed");
         else Console.WriteLine ("Check failed");

         // no error. Yoda Conditioning
         if ("abc".Equals (null)) Console.WriteLine ("Check passed");
         else Console.WriteLine ("Check failed");

         // no error
         if (string.Equals (a, "abc")) Console.WriteLine ("Check passed");
         else Console.WriteLine ("Check failed");

         // no error. Yoda Conditioning
         if (a.Equals (null)) Console.WriteLine ("Check passed");
         else Console.WriteLine ("Check failed");

         Console.ReadKey ();
      }

      private void ConvertTextToInt (object sender, EventArgs e) {
         try {
            //int.TryParse ("11-22-33", out int telNumber);
            //if (telNumber == 0) throw new Exception ("Numero de telephone invalide");
            if (!int.TryParse ("11-22-33", out int telNumber)) throw new Exception ("Numero de telephone invalide");
         } catch (Exception ex) {
            Console.WriteLine (ex);
         }
      }

      private void CheckRangeOfTime () {
         int i = 10;
         string a = i.ToString ();

         Console.WriteLine (DateTime.UtcNow.Hour);
         Console.WriteLine (DateTime.Now.Hour);
         int hour = DateTime.Now.Hour;
         if ((hour > 8 && hour <= 23) || hour == 0) Console.WriteLine ("Work time");
         if (hour > 0 && hour <= 8) Console.WriteLine ("Sleep time");
      }

      private void CheckTypeAndAssign () {
         Int64 i = 0;
         dynamic j = 1234567890123;
         Console.WriteLine (i.GetType ().ToString ());
         Console.WriteLine (i is System.Int64);
         if (i is System.Int64 _x) {
            Console.WriteLine ($"_x: {_x}");
            Console.WriteLine ($"_x type: {i.GetType ().ToString ()}");
         }
         if (j is System.Int64 _y) {
            Console.WriteLine ($"_y: {_y}");
         } else if (j is System.Int32 _z) {
            Console.WriteLine ($"_z: {_z}");
         } else {
            Console.WriteLine ($"j type: {j.GetType ()}");
         }
      }

      private static void TestGZipCompression () {
         try {
            // 1.
            // Starting file is 26,747 bytes.
            string sourceFilename = @"D:\Work\Practice\Resources\Images\test1.txt";
            string anyString = File.ReadAllText (sourceFilename);

            // 2.
            // Output file is 7,388 bytes.
            CompressStringToFile (sourceFilename + ".gz", anyString);
         } catch (Exception e){
            Console.WriteLine (e.Message);
            // Could not compress.
         }
      }

      public static void CompressStringToFile (string fileName, string value) {
         // Write string to temporary file.
         string temp = Path.GetTempFileName ();
         File.WriteAllText (temp, value);

         // Read file into byte array buffer.
         byte[] b;
         using (FileStream f = new FileStream (temp, FileMode.Open)) {
            b = new byte[f.Length];
            f.Read (b, 0, (int)f.Length);
         }

         // Use GZipStream to write compressed bytes to target file.
         using (FileStream f2 = new FileStream (fileName, FileMode.Create))
         using (GZipStream gz = new GZipStream (f2, CompressionMode.Compress, false)) {
            gz.Write (b, 0, b.Length);
         }
      }
   }
}

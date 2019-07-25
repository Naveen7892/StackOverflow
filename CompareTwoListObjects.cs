using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class CompareTwoListObjects {
      public static void MainCompareTwoListObjects () {
         List<DataDictionary> ColumnsDataDict = new List<DataDictionary> () {
            new DataDictionary () {
               TableName = "Table1",
               Description = "Abcd"
            },
            new DataDictionary () {
               TableName = "Table2",
               Description = "Abcd"
            },
            new DataDictionary () {
               TableName = "Table3",
               Description = "Abcd"
            },
         };
         List<DataDictionary> ColumnsWizard = new List<DataDictionary> () {
            new DataDictionary () {
               TableName = "Table3",
               Description = "Abcd"
            },
            new DataDictionary () {
               TableName = "Table4",
               Description = "Abcd"
            },
            new DataDictionary () {
               TableName = "Table5",
               Description = "Abcd"
            },
         };
         //var newlist = ColumnsWizard.Except (ColumnsDataDict); // returns right join
         //string tableName = "Table3";
         //var left = ColumnsDataDict.Where (x => x.TableName != tableName).ToList ();
         //var right = ColumnsWizard.Where (x => x.TableName != tableName).ToList ();
         //var unmatchedObjects = left.Concat (right);
         //foreach (DataDictionary item in unmatchedObjects) {
         //   Console.WriteLine (item.TableName);
         //}

         List<DataDictionary> duplicatesRemovedLists = ColumnsDataDict.Concat (ColumnsWizard).ToList ();
         //duplicatesRemovedLists = duplicatesRemovedLists. (new DistinctComparer ()).ToList ();
         foreach (DataDictionary item in duplicatesRemovedLists) {
            Console.WriteLine (item.TableName);
         }

         foreach (var cddProp in ColumnsDataDict) {
            foreach (var cwProp in ColumnsWizard) {
               if ((cddProp.TableName == cwProp.TableName)) {
                  duplicatesRemovedLists.Remove (cddProp);
                  duplicatesRemovedLists.Remove (cwProp);
               }
            }
         }

         foreach (DataDictionary item in duplicatesRemovedLists) Console.WriteLine (item.TableName);
      }

      public class DistinctComparer: IEqualityComparer<DataDictionary> {
         public bool Equals (DataDictionary x, DataDictionary y) => x.TableName == y.TableName;

         public int GetHashCode (DataDictionary obj) => (null == obj) ? 0: 1;
      }
   }

   class DataDictionary {
      public string TableName {
         get;
         set;
      }
      public string Description {
         get;
         set;
      }
      public string TableID {
         get;
         set;
      }
      public string ColumnDesc {
         get;
         set;
      }
      public string ColumnName {
         get;
         set;
      }
   }
}

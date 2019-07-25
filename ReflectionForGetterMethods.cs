using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow {
   class ReflectionForGetterMethods {
      public static void MainReflectionForGetterMethods () {
         Console.WriteLine (CollectGettersAndSetters ("StackOverflow.Program"));
      }
      static string CollectGettersAndSetters (string className) {
         Type classType = Type.GetType (className);

         MethodInfo[] getters = classType
             .GetMethods (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
             .Where (m => m.Name.StartsWith ("get"))
             .ToArray ();

         //MethodInfo[] setters = classType
         //    .GetMethods (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
         //    .Where (m => m.Name.StartsWith ("set"))
         //    .ToArray ();

         MethodInfo[] setters = classType.GetProperties ().Select (x => x.GetSetMethod ()).ToArray ();

         StringBuilder sb = new StringBuilder ();

         foreach (MethodInfo getter in getters) {
            sb.AppendLine ($"{getter.Name} will return {getter.ReturnType}");
         }
         sb.AppendLine ();

         foreach (MethodInfo setter in setters) {
            //ParameterInfo pi = setter.GetParameters ()[0];
            sb.AppendLine ($"{setter.Name} will set field of {setter.GetParameters()[0]}");
            sb.AppendLine ();
         }

         return sb.ToString ().TrimEnd ();
      }
   }
}

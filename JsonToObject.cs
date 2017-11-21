using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StackOverflow {

   #region References

   // https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Objects/JSON

   #endregion References

   class JsonToObject {
      static void Main (string[] args) {

         string url = "http://ticlotel.com/layered-medium-curly-hairstyles-2017.html";
         string QUrl = "https://api.pinterest.com/v1/urls/count.json?callback=receiveCount&url=" + url;
         System.Net.HttpWebRequest Request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create (QUrl);
         Request.ContentType = "application/json";
         Request.Timeout = 10000;
         Request.Method = "GET";
         string content;
         using (WebResponse myResponse = Request.GetResponse ()) {
            using (System.IO.StreamReader sr = new System.IO.StreamReader (myResponse.GetResponseStream (), System.Text.Encoding.UTF8)) {
               content = sr.ReadToEnd ();
            }
         };

         content = content.Replace ("receiveCount(", "");
         content = content.Remove (content.Length - 1);

         // receiveCount ({\"url\":\"http://www.google.com\",\"count\":75108})

         #region RoughTry

         //dynamic jsonObject = new JObject ();
         //string workingFormat = @"{
         //   'CPU': 'Intel',
         //   'Drives': [
         //      'DVD read/writer',
         //      '500 gigabyte hard drive'
         //   ]
         //}";

         //string workingFormat2 = "{\'CPU\': \'Intel\',\'Drives\': [\'DVD read/writer\',\'500 gigabyte hard drive\']}";

         //jsonObject.data = JsonConvert.DeserializeObject (workingFormat2);
         //var d = jsonObject["data"]["CPU"].ToString ();


         //JToken token = JToken.Parse (content2);
         //jsonObject.data = JObject.Parse ((string)token);


         //dynamic jsonObject = JsonConvert.DeserializeObject (content);
         //var share_count2 = jsonObject["count"].ToString ();
         //Console.WriteLine ("Share Count :" + share_count2);

         //var json = JObject.Parse (content);
         //var share_count = json["receiveCount"]["count"].ToString ();
         //Console.WriteLine ("Share Count :" + share_count);

         #endregion RoughTry

         //string content = "{\"url\":\"http://www.google.com\",\"count\":75108}";

         var json = JObject.Parse (content);
         var share_url = json["url"];
         Console.WriteLine ("Share URL:" + share_url);
         var share_count = json["count"];
         Console.WriteLine ("Share Count:" + share_count);

         Console.ReadKey ();

      }
   }
}

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
      public static void RunApplication () {
         Console.WriteLine ("Ghost Mouse Move event");
         //var application = new System.Windows.Application ();
         //application.Run (new GhostMouseMove ());
         //GhostMouseMove eDoc = new GhostMouseMove ();
         win = new Window ();
         tb = new TextBlock () {
            Text = "Started"
         };
         ScrollViewer sv = new ScrollViewer {
            Content = tb,
            Height = win.Height,
            Width = win.Width
         };
         win.MouseRightButtonDown += Win_MouseDown;
         win.MouseRightButtonUp += Win_MouseUp;
         win.MouseMove += Win_MouseMove;
         win.Loaded += Win_Loaded;
         win.Content = sv; win.Title = "GhostMouseMove"; win.ShowDialog ();
      }

      private static void Win_Loaded (object sender, RoutedEventArgs e) {
         lastPosition = win.PointFromScreen (new Point (System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y));
      }

      private static void Win_MouseMove (object sender, System.Windows.Input.MouseEventArgs e) {
         if (lastPosition != e.GetPosition (e.Device.Target)) {
            Debug.WriteLine ($"=> Form1_MouseMove, Location: {e.GetPosition (e.Device.Target)}");
            UpdateContent ($"=> Form1_MouseMove, Location: {e.GetPosition (e.Device.Target)}");
         }
      }

      private static void Win_MouseDown (object sender, System.Windows.Input.MouseButtonEventArgs e) {
         Debug.WriteLine ($"=> Form1_MouseDown, Clicks: {e.ClickCount}, Location: {e.GetPosition (e.Device.Target)}");
         UpdateContent ($"=> Form1_MouseDown, Clicks: {e.ClickCount}, Location: {e.GetPosition (e.Device.Target)}");
      }

      private static void Win_MouseUp (object sender, System.Windows.Input.MouseButtonEventArgs e) {
         Debug.WriteLine ($"=> Form1_MouseUp, Clicks: {e.ClickCount}, Location: {e.GetPosition (e.Device.Target)}");
         UpdateContent ($"=> Form1_MouseUp, Clicks: {e.ClickCount}, Location: {e.GetPosition (e.Device.Target)}");
      }

      private static void UpdateContent (string c) {
         tb.Text += Environment.NewLine + c;
      }
   }
}

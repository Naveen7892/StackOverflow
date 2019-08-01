using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace StackOverflow {
   public partial class ListViewRepaint : Form {

      static ListView ListView1;
      static bool IsFormOpened = false;

      public ListViewRepaint () {
         InitializeComponent ();

         ListView1 = new ListView {
            Name = "ListView1",
            Bounds = new Rectangle (new System.Drawing.Point (10, 10), new System.Drawing.Size (300, 200)),
            View = View.Details,
            BackColor = System.Drawing.Color.Orange,
            ForeColor = System.Drawing.Color.Black,
            BorderStyle = BorderStyle.FixedSingle,
            CheckBoxes = true,
            GridLines = true,
            FullRowSelect = true,
            AllowColumnReorder = true,
         };
         ListView1.ItemCheck += ListView1_ItemCheck;
         Controls.Add (ListView1);

         ListView1.Columns.Add ("Column 1", 50, System.Windows.Forms.HorizontalAlignment.Right);
         ListView1.Columns.Add ("Column 2", 50, System.Windows.Forms.HorizontalAlignment.Right);
         ListViewItem lvi = new ListViewItem ("Colleen", 0);
         lvi.SubItems.Add ("1");
         ListView1.Items.Add (lvi);
         lvi = new ListViewItem ("Peter", 0);
         lvi.SubItems.Add ("2");
         ListView1.Items.Add (lvi);
         lvi = new ListViewItem ("Colleen", 0);
         lvi.SubItems.Add ("3");
         ListView1.Items.Add (lvi);
         lvi = new ListViewItem ("Peter", 0);
         lvi.SubItems.Add ("4");
         ListView1.Items.Add (lvi);


         //CreateMyListView ();
      }

      private static void ListView2_ItemCheck (object sender, ItemCheckEventArgs e) {
         
      }

      private void CreateMyListView () {
         // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listview.checkboxes?redirectedfrom=MSDN&view=netframework-4.8#System_Windows_Forms_ListView_CheckBoxes

         // Create a new ListView control.
         ListView listView1 = new ListView ();
         listView1.Bounds = new Rectangle (new System.Drawing.Point (10, 10), new System.Drawing.Size (300, 200));

         // Set the view to show details.
         listView1.View = View.Details;
         // Allow the user to edit item text.
         listView1.LabelEdit = true;
         // Allow the user to rearrange columns.
         listView1.AllowColumnReorder = true;
         // Display check boxes.
         listView1.CheckBoxes = true;
         // Select the item and subitems when selection is made.
         listView1.FullRowSelect = true;
         // Display grid lines.
         listView1.GridLines = true;
         // Sort the items in the list in ascending order.
         listView1.Sorting = SortOrder.Ascending;

         // Create three items and three sets of subitems for each item.
         ListViewItem item1 = new ListViewItem ("item1", 0);
         // Place a check mark next to the item.
         item1.Checked = true;
         item1.SubItems.Add ("1");
         item1.SubItems.Add ("2");
         item1.SubItems.Add ("3");
         ListViewItem item2 = new ListViewItem ("item2", 1);
         item2.SubItems.Add ("4");
         item2.SubItems.Add ("5");
         item2.SubItems.Add ("6");
         ListViewItem item3 = new ListViewItem ("item3", 0);
         // Place a check mark next to the item.
         item3.Checked = true;
         item3.SubItems.Add ("7");
         item3.SubItems.Add ("8");
         item3.SubItems.Add ("9");

         // Create columns for the items and subitems.
         // Width of -2 indicates auto-size.
         listView1.Columns.Add ("Item Column", -2, System.Windows.Forms.HorizontalAlignment.Left);
         listView1.Columns.Add ("Column 2", -2, System.Windows.Forms.HorizontalAlignment.Left);
         //listView1.Columns.Add ("Column 3", -2, System.Windows.Forms.HorizontalAlignment.Left);
         //listView1.Columns.Add ("Column 4", -2, System.Windows.Forms.HorizontalAlignment.Center);

         //Add the items to the ListView.
         listView1.Items.AddRange (new ListViewItem[] { item1, item2, item3 });

         // Create two ImageList objects.
         ImageList imageListSmall = new ImageList ();
         ImageList imageListLarge = new ImageList ();

         // Initialize the ImageList objects with bitmaps.
         imageListSmall.Images.Add (Bitmap.FromFile (@"D:\Work\Practice\Resources\Images\sample1.jpg"));
         imageListSmall.Images.Add (Bitmap.FromFile (@"D:\Work\Practice\Resources\Images\sample2.jpg"));
         imageListLarge.Images.Add (Bitmap.FromFile (@"D:\Work\Practice\Resources\Images\sample1.jpg"));
         imageListLarge.Images.Add (Bitmap.FromFile (@"D:\Work\Practice\Resources\Images\sample2.jpg"));

         //Assign the ImageList objects to the ListView.
         listView1.LargeImageList = imageListLarge;
         listView1.SmallImageList = imageListSmall;

         // Add the ListView to the control collection.
         this.Controls.Add (listView1);
      }

      private static void ListView1_ItemCheck (object sender, ItemCheckEventArgs e) {
         ListView1.BeginUpdate ();
         foreach (ListViewItem item in ListView1.Items) {

         }

         if (e.CurrentValue == CheckState.Unchecked &&
         ListView1.Items[e.Index].SubItems[0].Text == ("Colleen")) {
            if (!IsFormOpened) {
               Window f2 = new Window ();
               f2.Closed += F2_Closed;
               f2.Show ();
               IsFormOpened = true;
            }
         } else if (e.CurrentValue == CheckState.Checked) {

         }
         ListView1.EndUpdate ();
      }

      private static void F2_Closed (object sender, EventArgs e) {
         IsFormOpened = false;
      }
   }
}

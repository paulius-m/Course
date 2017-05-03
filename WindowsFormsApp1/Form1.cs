using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var listViewItem = new ListViewItem { };
            listViewItem.SubItems.Add("1");
            listViewItem.SubItems.Add("test");

            listView1.Items.Add(listViewItem);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

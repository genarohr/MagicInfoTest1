using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicInfoTest1
{
    public partial class frmSelectDays : Form
    {
        public string dias;
        public frmSelectDays()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var texts = this.checkedListBox1.CheckedItems.Cast<object>().Select(x => this.checkedListBox1.GetItemText(x));

            dias = string.Join(",", texts);

            Form1.selectedDdays = dias;
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

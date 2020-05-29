using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesserScheduler
{
    public partial class MemoryInitForm : Form
    {
        public int Request { set; get; }
        public MemoryInitForm()
        {
            InitializeComponent();
            this.Data_textBox.DataBindings.Add("Text", this, "Request");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new MemoryMain(Request).Show();
        }
    }
}

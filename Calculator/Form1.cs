using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Operations Operations = new Operations();
        public Form1()
        {
            InitializeComponent();
            Operations.parentTextBox = this.textBox1;
            Operations.parentMenuButton = this.button23;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;
                Operations.whatToDo(btnPressed.Text.ToString());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Visible = false;
        }
    }
}

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
        Dictionary<Button, string> Buttons = new Dictionary<Button, string>();
        public Form1()
        {
            InitializeComponent();
            Buttons = Operations.PrepareDictionary(this);
            Operations.parentTextBox = this.textBox1;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;
            if (Buttons.ContainsValue(btnPressed.Text))
            {
                Operations.whatToDo("aaa");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Visible = false;
        }
    }
}

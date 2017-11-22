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
        Dictionary<string, string> Buttons = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            Buttons = Operations.PrepareDictionary(this);
            Operations.parentTextBox = this.textBox1;
            Operations.parentMenuButton = this.button23;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;

            if (Buttons.ContainsKey(btnPressed.Text))
            {
                Operations.whatToDo(Buttons[btnPressed.Text]);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Visible = false;
        }
    }
}

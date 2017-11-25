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
            Operations.parentTextBox1 = this.textBox1;
            Operations.parentTextBox2 = this.textBox2;
            Operations.parentMenuButton = this.button23;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                Operations.whatToDo(e.KeyChar.ToString());
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;
                Operations.whatToDo(btnPressed.Text.ToString());
        }
    }
}

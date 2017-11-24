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
    public partial class History : Form
    {
        public string[] historia;
        public History()
        {
            InitializeComponent();
        }

        public void show()
        {
            if (historia.Length != 1)
            {
                textBox1.Text = "";
                for (int i = 0; i < historia.Length; i++)
                {
                    if (i % 2 != 0) textBox1.Text += "\r\n" + historia[i].ToString(); else textBox1.Text += historia[i].ToString();
                }
            }
        }
    }
}

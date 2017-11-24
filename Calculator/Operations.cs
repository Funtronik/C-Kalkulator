using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class Operations
    {
        public TextBox parentTextBox1;
        public TextBox parentTextBox2;
        public Button parentMenuButton;
        private float wynik = 0;
        private string operacje = "";
        private string[] historia;
        bool needRefreshness = false;

        public void whatToDo(string Operation,bool refresh)
        {
            if (Operation != "∴" && parentMenuButton.Visible == true) parentMenuButton.Visible = false;

            if (refresh || needRefreshness)
            {
                needRefreshness = false;
                whatToDo("CE", false);
            }

            int parsableInt;
            if (int.TryParse(Operation, out parsableInt))
            {
                if (parentTextBox1.Text.Length < 10)
                {
                    if (parentTextBox1.Text == "0") parentTextBox1.Text = "";
                    parentTextBox1.Text += Operation;
                }
            }

            if (operacje == "")
            {
                wynik = 
                operacje += 
            }
            //reszta normalnie jako operacje
            switch (Operation)
            {
                case "∴":
                    {
                        if (!parentMenuButton.Visible) parentMenuButton.Visible = true; else parentMenuButton.Visible = false;
                        break;
                    }
                case ",":
                    {
                        if (parentTextBox1.Text != "" && parentTextBox1.Text.Length < 9)
                            parentTextBox1.Text = parentTextBox1.Text.ToString() + ",";
                        break;
                    }
                case "+":
                    {
                        if (parentTextBox1.Text != "")
                        {
                            wynik += float.Parse(parentTextBox1.Text);
                            operacje += parentTextBox1.Text + " + ";
                            aktualizacja("operant");
                        }
                        break;
                    }
                case "-":
                    {
                        if (parentTextBox2.Text != "")
                        {
                            wynik -= float.Parse(parentTextBox1.Text);
                            operacje += parentTextBox1.Text + " - ";
                            aktualizacja("operant");
                        }
                        else
                        {
                            clearWynik();
                        }
                        break;
                    }
                case "X":
                    {
                        if (parentTextBox2.Text != "")
                        {
                            wynik *= float.Parse(parentTextBox1.Text);
                            operacje += parentTextBox1.Text + " X ";
                            aktualizacja("operant");
                        }
                        else
                        {
                            clearWynik();
                        }
                        break;
                    }
                case "=":
                    {
                        if (parentTextBox1.Text != "")
                        {
                            var sign = operacje.Substring(operacje.Length - 2, 1);
                            whatToDo(sign,false);
                            operacje = operacje.Substring(0, operacje.Length - 2);
                            parentTextBox1.Text = wynik.ToString();
                        }
                        aktualizacja("equals");
                        needRefreshness = true;
                        break;
                    }
                case "%":
                    {
                        wynik %= float.Parse(parentTextBox1.Text);
                        operacje += parentTextBox1.Text + " % ";
                        aktualizacja("operant");
                        break;
                    }
                case "÷":
                    {
                        wynik /= float.Parse(parentTextBox1.Text);
                        operacje += parentTextBox1.Text + " ÷ ";
                        aktualizacja("operant");
                        break;
                    }
                case "<x":
                    {
                        if (parentTextBox1.Text.Length > 0)
                            parentTextBox1.Text = parentTextBox1.Text.Substring(0, parentTextBox1.Text.Length - 1);
                        break;
                    }
                case "C":
                    {
                        aktualizacja("softclear");
                        break;
                    }
                case "CE":
                    {
                        aktualizacja("hardclear");
                        break;
                    }

                case "√":
                    {
                        double buff = double.Parse(parentTextBox1.Text);
                        double sqrt = Math.Sqrt(buff);
                        wynik = float.Parse(sqrt.ToString());
                        operacje += parentTextBox1.Text + " √ ";
                        aktualizacja("equals");
                        needRefreshness = true;
                        break;
                    }
                case "History":
                    {

                        break;
                    }
            }
        }
        private void aktualizacja(string co)
        {
            if (co == "operant")
            {
                parentTextBox2.Text = this.operacje;
                parentTextBox1.Text = "";
            }
            else if (co == "softclear")
            {
                if (parentTextBox1.Text != "") parentTextBox1.Text = "0"; else parentTextBox1.Text = "";
            }
            else if (co == "hardclear")
            {
                parentTextBox1.Text = "0";
                parentTextBox2.Clear();
                operacje = "";
                wynik = 0;
            }
            else if (co == "equals")
            {
                operacje += " =";
                parentTextBox2.Text = operacje;
                parentTextBox1.Text = wynik.ToString();
                wynik = 0;
            }
        }
        void clearWynik()
        {
            wynik = float.Parse(parentTextBox1.Text);
        }
    }
}


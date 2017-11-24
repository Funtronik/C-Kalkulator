using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class Operations : History
    {
        public TextBox parentTextBox1;
        public TextBox parentTextBox2;
        public Button parentMenuButton;
        private float wynik = 0;
        private string operacje = "";
        private bool hitCE = false;
        int operationscount = 0;
        public void whatToDo(string Operation)
        {

            if (Operation != "∴" && parentMenuButton.Visible == true) parentMenuButton.Visible = false;

            if (OperacjeMenu(Operation)) return;
            if (hitCE)
            {
                OperacjeMenu("CE");
                hitCE = false;
            }

            int parsableInt;
            if (int.TryParse(Operation, out parsableInt))
            {
                if (parentTextBox1.Text.Length < 10)
                {
                    if (parentTextBox1.Text == "0") parentTextBox1.Text = "";
                    parentTextBox1.Text += Operation;
                }
                return;
            }

            operationscount++;
            var tempstring = " ";
            if (parentTextBox2.Text == "")
            {
                wynik = float.Parse(parentTextBox1.Text);
                operacje = wynik.ToString();
                if (Operation == "√")
                {
                    OperacjeArytmetyczne("√", 0);
                    return;
                }
                if (operationscount > 0) tempstring = " " + Operation + " ";// spacja
                else tempstring = " " + Operation;// spacja

                operacje += tempstring;
            }
            else
            {
                if (operacje.Substring(operacje.Length - 1, 1) != " ") operacje += " ";
                if (parentTextBox1.Text == "") { tempstring = "0" + " " + Operation; }
                else if (Operation == "=") tempstring = parentTextBox1.Text + " " + Operation;
                else
                {
                    tempstring = parentTextBox1.Text + " " + Operation;
                }
                
                operacje += tempstring;
                obliczanieWyniku();
            }
            if (Operation != "=") aktualizacja("operant");
        }
        private void obliczanieWyniku()
        {

            var spaceCount = operacje.Split(' ');
            wynik = float.Parse(spaceCount[0]);
            float tempParsable = 0;
            bool liczbaJest = false;
            bool operantJest = false;
            string operantDoPrzekazania = "";
            float liczbaDoPrzekazania = 0;

            for (int i = 1; i < spaceCount.Length; i++)
            {
                var pobrane = spaceCount[i].ToString();

                    if (float.TryParse(pobrane, out tempParsable))
                    {
                        liczbaDoPrzekazania = tempParsable;
                        liczbaJest = true;
                    }
                    else
                    {
                        operantDoPrzekazania = pobrane;
                        if (operantDoPrzekazania == "=") OperacjeArytmetyczne("=", 0);
                        else
                        {
                        operantJest = true;
                        }
                    }
                if (liczbaJest && operantJest)
                {
                    OperacjeArytmetyczne(operantDoPrzekazania, liczbaDoPrzekazania);
                    operantJest = false;
                    liczbaJest = false;
                }
            }
        }
        private bool OperacjeMenu(string Operation)
        {

            switch (Operation)
            {
                case "∴":
                    {
                        if (!parentMenuButton.Visible) parentMenuButton.Visible = true; else parentMenuButton.Visible = false;
                        return true;
                    }
                case ",":
                    {
                        if (parentTextBox1.Text != "" && parentTextBox1.Text.Length < 9)
                            parentTextBox1.Text = parentTextBox1.Text.ToString() + ",";
                        return true;
                    }
                case "<x":
                    {
                        if (parentTextBox1.Text.Length > 0)
                            parentTextBox1.Text = parentTextBox1.Text.Substring(0, parentTextBox1.Text.Length - 1);
                        return true;
                    }
                case "C":
                    {
                        aktualizacja("softclear");
                        return true;
                    }
                case "CE":
                    {
                        aktualizacja("hardclear");
                        return true;
                    }
                case "History":
                    {
                                 History history = new History();
                                 history.historia = operacje.Split(' ');
                                 history.show();
                                 history.Show();
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }

        }

        private void OperacjeArytmetyczne(string Operation, float wartoscOperacji)
        {
            //reszta normalnie jako operacje
            switch (Operation)
            {
                case "+":
                    {
                        wynik += wartoscOperacji;
                        break;
                    }
                case "-":
                    {
                        wynik -= wartoscOperacji;
                        break;
                    }
                case "X":
                    {
                        wynik *= wartoscOperacji;
                        break;
                    }
                case "=":
                    {
                        parentTextBox2.Text = operacje;
                        parentTextBox1.Text = wynik.ToString();
                        wynik = 0;
                        hitCE = true;
                        break;
                    }
                case "%":
                    {
                        break;
                    }
                case "÷":
                    {
                        wynik /= wartoscOperacji;
                        break;
                    }
                case "√":
                    {
                        double tempwynik = double.Parse(wynik.ToString());
                        tempwynik = Math.Sqrt(tempwynik);
                        wynik = float.Parse(tempwynik.ToString());
                        parentTextBox2.Text = operacje;
                        parentTextBox1.Text = wynik.ToString();
                        hitCE = true;
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
                operationscount = 0;
                wynik = 0;
            }
        }
    }
}


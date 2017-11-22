using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class Operations
    {
        public TextBox parentTextBox;
        public Button parentMenuButton;

        public void whatToDo(string Operation)
        {
            if (Operation != "∴" && parentMenuButton.Visible == true) parentMenuButton.Visible = false;

            int parsableInt;
            if (int.TryParse(Operation, out parsableInt))
            {
                //liczba = parsableInt.ToString();
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
                       
                        break;
                    }
                case "+":
                    {
                   
                        break;
                    }
                case "-":
                    {
                       
                        break;
                    }
                case "X":
                    {
                       
                        break;
                    }
                case "=":
                    {
                       
                        break;
                    }
                case "%":
                    {
                       
                        break;
                    }
                case "÷":
                    {
                       
                        break;
                    }
                case "<x":
                    {
                       
                        break;
                    }
                case "C":
                    {
                       
                        break;
                    }
                case "CE":
                    {
                        
                        break;
                    }

                case "√":
                    {
                       
                        break;
                    }
                case "History":
                    {
                       
                        break;
                    }
            }
        }
    }
}


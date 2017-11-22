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
        
        static public Dictionary<Button, string> PrepareDictionary(Control callForm)
        {
            var returnDictionary = new Dictionary<Button, string>();
            var controlsList = new List<Control>();

            void GetAllControl(Control c, List<Control> list)
            {
                foreach (Control control in c.Controls)
                {
                    list.Add(control);

                    if (control.GetType() == typeof(Panel))
                        GetAllControl(control, list);
                }
            }

            GetAllControl(callForm, controlsList);

            foreach (Control control in controlsList)
            {
                var operators = "";
                if (control.GetType() == typeof(Button))
                {
                    int parsableInt;
                    if (int.TryParse(control.Text.ToString(), out parsableInt))
                    {
                        returnDictionary.Add((Button)control, parsableInt.ToString());
                    }
                    else
                        switch (control.Text.ToString())
                        {
                            case ",":
                                {
                                    operators = control.Text;
                                    break;
                                }
                            case "+":
                                {
                                    operators = control.Text;
                                    break;
                                }
                            case "-":
                                {
                                    operators = control.Text;
                                    break;
                                }
                            case "X":
                                {
                                    operators = "*";
                                    break;
                                }
                            case "=":
                                {
                                    operators = control.Text;
                                    break;
                                }
                            case "%":
                                {
                                    operators = control.Text;
                                    break;
                                }
                            case "÷":
                                {
                                    operators = "/";
                                    break;
                                }
                            case "<x":
                                {
                                    operators = "backspace";
                                    break;
                                }
                            case "C":
                                {
                                    operators = "clear";
                                    break;
                                }
                            case "CE":
                                {
                                    operators = "clearelse";
                                    break;
                                }
                            
                            case "√":
                                {
                                    operators = "sqrt";
                                    break;
                                }
                            case "∴":
                                {
                                    operators = "menu";
                                    break;
                                }
                                //(     Button    ,      Operacja buttona     )
                                returnDictionary.Add((Button)control, operators);
                        }
                }
            }
            return returnDictionary;
        }

        public void whatToDo(string Operation)
        {
           // this.parentTextBox.Text = "udało się";
            switch (Operation)
            {
                case "menu":
                    {

                        break;
                    }
            }
        }
    }
}


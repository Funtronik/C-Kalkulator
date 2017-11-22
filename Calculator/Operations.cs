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
        
        static public Dictionary<String, string> PrepareDictionary(Control callForm)
        {
            var returnDictionary = new Dictionary<String, string>();
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
                        operators = parsableInt.ToString();
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
                            case "History":
                                {
                                    operators = "history";
                                    break;
                                }
                                //(     Button    ,      Operacja buttona     )
                                
                        }
                    returnDictionary.Add(control.Text, operators);
                }
            }
            return returnDictionary;
        }

        public void whatToDo(string Operation)
        {
            if (Operation != "menu") parentMenuButton.Visible = false;
            switch (Operation)
            {
                case "menu":
                    {
                        if (!parentMenuButton.Visible) parentMenuButton.Visible = true; else parentMenuButton.Visible = false;
                        break;
                    }
                case 
            }
        }
    }
}


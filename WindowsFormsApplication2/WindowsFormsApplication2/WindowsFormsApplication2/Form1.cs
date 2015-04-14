using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        /*
         0=awaiting input
         1= getting first number
         2= awaiting second input
         3= getting second number
         */
        int stateControl = 0;
        String firstInput = "0";
        String secondInput = "0";
        char currentOp = '=';
        bool canDecimal = true;
        bool doingDumbShit = false;
        bool opSwitch = false;
        String permString = "";
        String notPermString = "";
        
        public Form1()
        {
          
            InitializeComponent();
            stateControl = 0;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region number buttons
        private void button14_Click(object sender, EventArgs e)
        {
            handleNumbers("7");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            handleNumbers("8");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            handleNumbers("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            handleNumbers("4");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            handleNumbers("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            handleNumbers("6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handleNumbers("1");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            handleNumbers("2");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            handleNumbers("3");
        }
        #endregion
        #region +,-,/,* buttons
        private void button7_Click(object sender, EventArgs e)
        {
           
            handleOps('+');

        }

        private void button16_Click(object sender, EventArgs e)
        {
           
            handleOps('*');

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            handleOps('-');

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            handleOps('/');

        }
        #endregion
        private void button9_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 0)
            {
                firstInput = "0";
                textBox1.Text = firstInput;
            }
            else if (stateControl == 1)
            {
                firstInput = firstInput + "0";
                textBox1.Text = firstInput;
            }
            else if (stateControl == 2)
            {
                secondInput = "0";
                textBox1.Text = secondInput;
                stateControl = 3;

            }
            else if (stateControl == 3)
            {
                if (secondInput != "0")
                {
                    secondInput = secondInput + "0";
                }
                textBox1.Text = secondInput;
            }
        }


        private void button21_Click(object sender, EventArgs e)
        {
            if (stateControl == 0)
            {
                firstInput = "0.";
                stateControl = 1;
                canDecimal = false;
                textBox1.Text = firstInput;
            }
            else if (stateControl == 1)
            {
                if (canDecimal == true)
                {
                    firstInput = firstInput + ".";
                    canDecimal = false;
                }
                textBox1.Text = firstInput;
            }
            else if (stateControl == 2)
            {
                secondInput = "0.";
                stateControl = 3;
                canDecimal = false;
                textBox1.Text = secondInput;
            }
            else if (stateControl == 3)
            {
                if (canDecimal == true)
                {
                    secondInput = secondInput + ".";
                    canDecimal = false;
                }
                textBox1.Text = secondInput;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 1 || stateControl == 0)
            {
                if (firstInput[0] != '-' && firstInput != "0")
                {
                    firstInput = "-" + firstInput;
                }
                else if (firstInput != "0")
                {
                    firstInput = firstInput.Substring(1, firstInput.Length - 1);
                }
                textBox1.Text = firstInput;
            }

            else if (stateControl == 3)
            {
                if (secondInput[0] != '-')
                {
                    secondInput = "-" + secondInput;
                }
                else
                {
                    secondInput = secondInput.Substring(1, secondInput.Length - 1);
                }
                textBox1.Text = secondInput;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            button15.Focus();
            stateControl = 0;
            firstInput = "0";
            secondInput = "0";
            currentOp = '=';
            canDecimal = true;
            textBox1.Text = "0";
            textBox2.Text = "";
            notPermString = "";
            permString = "";

         
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 0)
            {
                textBox2.Text = ReplaceLastOccurrence(textBox2.Text, notPermString, "");
                notPermString = "";
                firstInput = "0";
                canDecimal = true;
                permString = "";
                doingDumbShit = false;
                textBox1.Text = firstInput;
            }
            else if (stateControl == 1)
            {
                textBox2.Text = ReplaceLastOccurrence(textBox2.Text, notPermString, "");
                notPermString = "";
                firstInput = "0";
                canDecimal = true;
                permString = "";
                textBox1.Text = firstInput;
                stateControl = 0;
                doingDumbShit = false;
            }
            else if (stateControl == 2)
            {
                textBox2.Text = ReplaceLastOccurrence(textBox2.Text, notPermString, "");
                notPermString = "";
                permString = "";
                secondInput = "0";
                canDecimal = true;
                textBox1.Text = secondInput;
                stateControl = 3;
                doingDumbShit = false;

            }
            else if (stateControl == 3)
            {
                textBox2.Text = ReplaceLastOccurrence(textBox2.Text, notPermString, "");
                notPermString = "";
                secondInput = "0";
                canDecimal = true;
                permString = "";
                textBox1.Text = secondInput;
                stateControl = 2;
                doingDumbShit = false;
            }
        }
        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
        //to clean number stuff later
        private void handleNumbers(String number)
        {
            button15.Focus();
            if (stateControl == 0)
            {
                if (doingDumbShit)
                {
                    textBox1.Text = "";
                    firstInput = "0";
                    doingDumbShit = false;
                    permString = "";
                    notPermString = "";
                }
                firstInput = number;
                stateControl = 1;
                textBox1.Text = firstInput;
            }
            else if (stateControl == 1)
            {
                firstInput = firstInput + number;
                textBox1.Text = firstInput;
            }
            else if (stateControl == 2)
            {

                if (doingDumbShit)
                {
                    textBox1.Text = "";
                    secondInput = "0";
                    doingDumbShit = false;
                    permString = "";
                    notPermString = "";
                }
                secondInput = number;
                stateControl = 3;
                textBox1.Text = secondInput;
            }
            else if (stateControl == 3)
            {

                if (doingDumbShit)
                {
                    textBox1.Text = "";
                    secondInput = "";
                    doingDumbShit = false;
                    permString = "";
                    notPermString = "";
                }
                secondInput = secondInput + number;
                textBox1.Text = secondInput;
            }
        }
       
        private void handleOps(char op)
        {
            button15.Focus();
            if (opSwitch)
            {
                textBox1.Text = "" + compute(currentOp, firstInput, secondInput);
                firstInput = textBox1.Text;
            }
            else if (stateControl == 0)
            {

                stateControl = 2;
                currentOp = op;
                textBox2.Text = firstInput + " " + op;

            }
            else if (stateControl == 1)
            {
                secondInput = firstInput;
                stateControl = 2;
                currentOp = op;
                textBox2.Text = firstInput + " " + op;
            }
            else if (stateControl == 2)
            
            {
               
                currentOp = op;
                if (textBox2.Text.Length != 0 && textBox2.Text[textBox2.Text.Length - 1] != op)
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1) + op;
                }
            }
            else if (stateControl == 3)
            {
                stateControl = 2;
                if (!doingDumbShit)
                {
                    textBox2.Text = textBox2.Text + " " + textBox1.Text + " " + op;
                }
                else if (doingDumbShit) 
                {
                    doingDumbShit = false;
                    textBox2.Text = textBox2.Text + " " + op;
                    permString = "";
                    notPermString = "";
                }
                textBox1.Text = "" + compute(currentOp, firstInput, secondInput);
                firstInput = textBox1.Text;
                secondInput = "0";
                currentOp = op;
            }
        }
        private String compute(char op, String first, string second)
        {
            double answer = 0;
            if (op == '+') answer = double.Parse(first) + double.Parse(second);
            if (op == '-') answer = double.Parse(first) - double.Parse(second);
            if (op == '=') answer = double.Parse(first);
            if (op == '/')
            {
                if (secondInput != "0")
                {
                    answer = double.Parse(first) / double.Parse(second);
                }
                else
                {

                    stateControl = -1;
                    return "Cannot Divide by Zero";
                }
            }
            if (op == '*') answer = double.Parse(firstInput) * double.Parse(secondInput);
            opSwitch = false;
            return "" + answer;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (stateControl != -1)
            {
                stateControl = 0;
                opSwitch = true;
                handleOps(currentOp);

                textBox2.Text = "";
                notPermString = "";
                permString = "";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 1)
            {
                if (firstInput.Length == 1)
                {
                    firstInput = "0";
                    stateControl = 0;
                }
                else
                {
                    firstInput = firstInput.Substring(0, firstInput.Length - 1);

                }
                textBox1.Text = firstInput;
            }

            else if (stateControl == 3)
            {
                if (secondInput.Length == 1)
                {
                    secondInput = "0";
                    stateControl = 2;
                }
                else
                {
                    secondInput = secondInput.Substring(0, secondInput.Length - 1);
                   

                }
                textBox1.Text = secondInput;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 0)
            {
                if (permString == "") 
                {
                    permString = textBox2.Text; 
                }
                if (notPermString == "")
                {
                    notPermString = firstInput;
                }
                firstInput = "" + Math.Sqrt(double.Parse(firstInput));
               
                textBox1.Text = firstInput;
                doingDumbShit = true;
                notPermString = "sqrt(" + notPermString + ")";
                textBox2.Text = permString + notPermString;

            }
            else if (stateControl == 1)

            {
                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = firstInput;
                }
                firstInput = "" + Math.Sqrt(double.Parse(firstInput));
                textBox1.Text = firstInput;
                doingDumbShit = true;
                notPermString = "sqrt(" + notPermString + ")";
                textBox2.Text = permString + notPermString;
                stateControl = 0;
            }
            else if (stateControl == 2)
            {
                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = firstInput;
                }
                secondInput = "" + Math.Sqrt(double.Parse(firstInput));
                textBox1.Text = secondInput;
                stateControl = 3;
                doingDumbShit = true;
                notPermString = "sqrt(" + notPermString + ")";
                textBox2.Text = permString + notPermString;
            }
            else if (stateControl == 3)
            {
                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = secondInput;
                }
                secondInput = "" + Math.Sqrt(double.Parse(secondInput));
                textBox1.Text = secondInput;
                doingDumbShit = true;
                notPermString = "sqrt(" + notPermString + ")";
                textBox2.Text = permString + notPermString;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 0)
            {
                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = firstInput;
                }
                firstInput = "" + 1 / double.Parse(firstInput);
                textBox1.Text = firstInput;
                
                doingDumbShit = true;
                notPermString = "recip(" + notPermString + ")";
                textBox2.Text = permString + notPermString;

            }
            else if (stateControl == 1)
            {

                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = firstInput;
                }
                firstInput = "" + 1 / double.Parse(firstInput);
                textBox1.Text = firstInput;
                doingDumbShit = true;
                notPermString = "recip(" + notPermString + ")";
                textBox2.Text = permString + notPermString;
                stateControl = 0;
            }
            else if (stateControl == 2)
            {

                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = firstInput;
                }
                secondInput = "" + 1 / (double.Parse(firstInput));
                textBox1.Text = secondInput;
                stateControl = 3;
                notPermString = "recip(" + notPermString + ")";
                textBox2.Text = permString + notPermString;
                doingDumbShit = true;
            }
            else if (stateControl == 3)
            {
                if (permString == "")
                {
                    permString = textBox2.Text;
                }
                if (notPermString == "")
                {
                    notPermString = secondInput;
                }
     
                secondInput = "" + 1 / (double.Parse(secondInput));

                textBox1.Text = secondInput;
                notPermString = "recip(" + notPermString + ")";
                textBox2.Text = permString + notPermString;
                doingDumbShit = true;

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button15.Focus();
            if (stateControl == 0)
            {

                firstInput = "0";
                textBox1.Text = firstInput;
                doingDumbShit = true;

            }
            else if (stateControl == 1)
            {

                firstInput = "0";
                textBox1.Text = firstInput;
                doingDumbShit = true;
                stateControl = 0;
            }
            else if (stateControl == 2)
            {

                secondInput = "" +(double.Parse(firstInput)*(double.Parse(firstInput)/100.0));
                textBox1.Text = secondInput;
                stateControl = 3;
                doingDumbShit = true;
            }
            else if (stateControl == 3)
            {

                  secondInput = "" +(double.Parse(firstInput)*(double.Parse(secondInput)/100));
                textBox1.Text = secondInput;
                doingDumbShit = true;

            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad9:
                    e.Handled = true;
                    button3.PerformClick();
                    break;
                case Keys.NumPad8:
                    e.Handled = true;
                    button11.PerformClick();
                    break;
                case Keys.NumPad7:
                    e.Handled = true;
                    button14.PerformClick();
                    break;
                case Keys.NumPad6:
                    e.Handled = true;
                    button6.PerformClick();
                    break;
                case Keys.NumPad5:
                    e.Handled = true;
                    button2.PerformClick();
                    break;
                case Keys.NumPad4:
                    e.Handled = true;
                    button10.PerformClick();
                    break;
                case Keys.NumPad3:
                    e.Handled = true;
                    button13.PerformClick();
                    break;
                case Keys.NumPad2:
                    e.Handled = true;
                    button5.PerformClick();
                    break;
                case Keys.NumPad1:
                    e.Handled = true;
                    button1.PerformClick();
                    break;
                case Keys.NumPad0:
                    e.Handled = true;
                    button9.PerformClick();
                    break;
                case Keys.Divide:
                    e.Handled = true;
                    button4.PerformClick();
                    break;
                case Keys.Decimal:
                    e.Handled = true;
                    button21.PerformClick();
                    break;
                case Keys.Multiply:
                    e.Handled = true;
                    button16.PerformClick();
                    break;
                case Keys.Subtract:
                    e.Handled = true;
                    button8.PerformClick();
                    break;
                case Keys.Add:
                    e.Handled = true;
                    button7.PerformClick();
                    break;
                
                case Keys.Back:
                    e.Handled = true;
                    button17.PerformClick();
                    break;
              

            }
        }

        private void button17_MouseClick(object sender, MouseEventArgs e)
        {
            button15.Focus();
        }
    }
}

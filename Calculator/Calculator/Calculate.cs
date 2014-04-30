/*
  Paul Hood
  4/17/2013
  L5 HomeWork
  New Class Form
*/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Calculator
{

    public class Calculate
    {
        // constructor - empty because it doesnt set any values
        public Calculate()
        {

        }
        
        // check for data in box
        public bool IsPresent(TextBox box)
        {
            if (box.Text == "")
            {
                MessageBox.Show("Please enter a calculation.", "No Data"); //error message
                return false;
            }
            return true;
        }

        // checks for error 
        public bool CheckError(TextBox box)
        {
            string test = box.Text.Trim();
            if (test.Length > 1)
            {
                // tests for an error, a operator cannot follow another operator
                if ((test[test.Length - 1] == '+' || test[test.Length - 1] == '-' || test[test.Length - 1] == '/' || test[test.Length - 1] == '*') &&
                            (test[test.Length - 2] == '+' || test[test.Length - 2] == '-' || test[test.Length - 2] == '/' || test[test.Length - 2] == '*'))
                {
                    MessageBox.Show(test[test.Length - 1] + " cannot be followed by " + test[test.Length - 2] + ".", "Entry Error");
                    box.Text = box.Text.Remove(test.Length - 1, 1);
                    return false;
                }
            }

            int opCounter = 0;
            // checks for more than one operator in an equation
            // I did this because creating a solution proved to be 
            // much more difficult than I expected
            foreach (char c in test)
            {
                
                if (c == '/' || c == '*' || c == '+' || c == '-')
                {
                    opCounter++;    
                }

                if (opCounter > 1)
                {
                    MessageBox.Show("Only one operator is allowed.", "Entry Error");
                    box.Text = box.Text.Remove(test.Length - 1, 1);
                    return false;
                }
            }
            return true;
        }

        public void DoCalc(TextBox box)
        {
     
            string op = ""; // operator
            string calculation = ""; // calculation 
            string result = ""; // result
            
            // sets operator
            foreach (char c in box.Text)
            {
                if (c == '/' || c == '*' || c == '+' || c == '-')
                {
                    op = c.ToString();
                }
            }

            // gets both numbers from equation
            string[] calc = box.Text.Trim().Split('/', '*', '+', '-');
            
            // try to do calculation
            try
            {
                double[] numbers = new double[2];
                // converstion
                numbers[0] = Convert.ToDouble(calc[0]);
                numbers[1] = Convert.ToDouble(calc[1]);

                // do the calculation
                foreach (char c in box.Text)
                {
                    if (c == '/')
                    {
                        op = c.ToString();
                        box.Clear(); // clear box
                        result = (numbers[0] / numbers[1]).ToString(); // do equation
                        box.Text = result; // update textbox
                    }
                    else if (c == '*')
                    {
                        op = c.ToString();
                        box.Clear();
                        result = (numbers[0] * numbers[1]).ToString();
                        box.Text = result;
                    }
                    else if (c == '+')
                    {
                        op = c.ToString();
                        box.Clear();
                        result = (numbers[0] + numbers[1]).ToString();
                        box.Text = result;
                    }
                    else if (c == '-')
                    {
                        op = c.ToString();
                        box.Clear();
                        result = (numbers[0] - numbers[1]).ToString();
                        box.Text = result;
                    }
                }
                calculation = numbers[0].ToString() + " "  + op + " " +  numbers[1].ToString() + " = " + result; // set calculation
                HistoryDB.Save(calculation); // save to text file
            }
            // error
            catch
            {
                box.Clear();
                MessageBox.Show("Error: Please enter a valid equation", "Entry Error");
            }
        }
    }
}

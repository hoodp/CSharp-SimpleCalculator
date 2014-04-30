/*
  Paul Hood
  4/17/2013
  L5 HomeWork
  Main Form
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        Calculate check = new Calculate(); // new check for testing

        #region Methods
        
        // method to get string value of button text
        private String ButtonClick(Button button)
        {
            return button.Text;
        }

        // method to add number to textbox
        private void DisplayUpdate(Button button)
        {
            txtCalculation.Text += ButtonClick(button);
        } 

        // checks for valid data
        public bool ValidData()
        {
            return check.IsPresent(txtCalculation);
        }
        #endregion

        #region Events
        #region Value Button Clicks
        // shows number of button that is clicked, or sign of equation
        private void btn7_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn7);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn9);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn6);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn3);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn0);
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btnDecimal);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btnAdd);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btnSubtract);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btnMultiply);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btnDivide);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            DisplayUpdate(btn8);
        }
        #endregion
        #region Exit, Equals, Clear & History Button Events, Text Change Events

        // clear data in textbox
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtCalculation.Clear();
        }

        // checks for error in equation
        private void txtCalculation_TextChanged(object sender, EventArgs e)
        {
            check.CheckError(txtCalculation);
        }
        
        // equals button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            // if data is valid do equation
            if (ValidData())
            {
                check.DoCalc(txtCalculation);
            }
        }

        // exit application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // remove last character entered
        private void btnClear_Click(object sender, EventArgs e)
        {
            // if textlength is greater than 0 remove last char
            if (txtCalculation.TextLength > 0)
            {
                txtCalculation.Text = 
                    txtCalculation.Text.Remove(txtCalculation.Text.Length - 1, 1);    
            }
            
        } 
        #endregion      
        #endregion      

        #region New Form
        // show new form with calculation history
        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmHistory viewHistory = new frmHistory(); // create new form
            viewHistory.ShowDialog(); // show new form
        } 
        #endregion 
      
    }
}

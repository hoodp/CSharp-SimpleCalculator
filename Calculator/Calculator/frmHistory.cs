/*
  Paul Hood
  4/17/2013
  L5 HomeWork
  Second Form
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
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }

        private List<string> equations; // new list of equations

        // exit applications
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // on load update listbox with past equations from text file
        private void frmHistory_Load(object sender, EventArgs e)
        {
            equations = new List<string>(HistoryDB.Read());
            foreach (string s in equations)
            {
                lstLoad.Items.Add(s);     
            }
        }

        // clear last equation in history and update text file
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lstLoad.Items.Count > 0)
	        {
		        lstLoad.Items.RemoveAt(lstLoad.Items.Count - 1);
	        }

            List<string> update = new List<string>();
            foreach (string s in lstLoad.Items)
            {
                update.Add(s);    
            }
            HistoryDB.Update(update);
        }
    }
}

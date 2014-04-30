/*
  Paul Hood
  4/17/2013
  L5 HomeWork
  Text File Form
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Calculator
{
    public static class HistoryDB
    {
        // name of file -- stored in bin/debug
        private const string path = @"calculations.txt";

        // save equation after equals button is clicked
        public static void Save(string calc)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(path, FileMode.Append, FileAccess.Write)))
            {
                textOut.WriteLine(calc);
            }
    
        }

        // update text file after button is cleared in frmHistory
        public static void Update(List<string> list)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(path, FileMode.Truncate, FileAccess.Write)))
            {
                foreach (string s in list)
                {
                    textOut.WriteLine(s);  
                }
                
            }
        }

        // read text file to show history in frmHistory
        public static List<string>  Read()
        {
            List<string> equations = new List<string>();
            using (StreamReader textIn = new StreamReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                while (textIn.Peek() != -1)
                {
                    string eq = textIn.ReadLine();
                    equations.Add(eq);
                }
                textIn.Close();
            }
            return equations;
        }
    }
}

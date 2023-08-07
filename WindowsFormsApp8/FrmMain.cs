using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public enum Operators { Add, Sub, Multi, Div, Result }

    public partial class FrmMain : Form
    {
        public int Result = 0;
        public bool isNewNum = true;
        public bool isStartNum = true;
        public Operators Opt = Operators.Add;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            SetNum(numButton.Text);
        }

        public void SetNum(String number)
        {
            if (isNewNum)
            {
                NumberScreen.Text = number;
                isNewNum = false;
            }
            else
            {
                NumberScreen.Text += number;
            }
        }

        private void Opt_Click(object sender, EventArgs e)
        {
            if (!isNewNum)
            {
                int num = int.Parse(NumberScreen.Text);

                // Perform calculation with the current operator and the previous number
                if (Opt == Operators.Add)
                    Result += num;
                else if (Opt == Operators.Sub)
                    Result -= num;
                else if (Opt == Operators.Multi)
                    Result *= num;
                else if (Opt == Operators.Div)
                    Result /= num;
            }

            Button optButton = (Button)sender;
            if (optButton.Text == "+")
            {
                Opt = Operators.Add;
            }
            else if (optButton.Text == "-")
            {
                Opt = Operators.Sub;
            }
            else if (optButton.Text == "*")
            {
                Opt = Operators.Multi;
            }
            else if (optButton.Text == "/")
            {
                Opt = Operators.Div;
            }
            else if (optButton.Text == "=")
            {
                // Display the final result
                NumberScreen.Text = Result.ToString();

                // Reset for a new calculation
                Result = 0;
                isNewNum = true;
                isStartNum = true;
                Opt = Operators.Add;
                return; // Exit the method as there is no need to continue
            }

            // Display the current operator
            NumberScreen.Text += optButton.Text;

            // Prepare for the next number input
            isNewNum = true;
        }

        private void Clear_click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            Result = 0;
            isNewNum = true;
            isStartNum = true;
            Opt = Operators.Add;

            NumberScreen.Text = "0";
        }

    }
}


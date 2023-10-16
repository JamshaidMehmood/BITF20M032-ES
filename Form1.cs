namespace the_Calculator
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // for writting 0
        private void n0_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "0";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "0";
            }
        }
        // for writting . symbol
        private void nDot_Click(object sender, EventArgs e)
        {
            EquationWritter.Text = EquationWritter.Text + ".";
        }
        // for plus click operation
        private void Plus_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text != "")
            {
                EquationWritter.Text = EquationWritter.Text + "+";
            }

        }
        // for equal operation
        private void equal_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text != "")
            {
                string equation= EquationWritter.Text;
                string result = CalculationLogic.stringSolver(equation);


                History.Text +=EquationWritter.Text + " = " + result + "   ";
                EquationWritter.Text = result.ToString();
                LastEquation.Text= equation;
            }

        }
        // for writting 1
        private void n1_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "1";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "1";
            }
        }
        // for writting 2
        private void n2_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "2";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "2";
            }
        }
        // for writting 3
        private void n3_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "3";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "3";
            }
        }

        private void The_Calculator_Load(object sender, EventArgs e)
        {
            EquationWritter.Text = "0";
        }
        // for minus click operation
        private void multiply_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text != "")
            {
                EquationWritter.Text = EquationWritter.Text + "x";
            }

        }
        // for writting 9
        private void n9_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "9";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "9";
            }
        }
        // for writting 8
        private void n8_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "8";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "8";
            }
        }
        // for writting 7
        private void n7_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "7";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "7";
            }
        }

        // for writting 5
        private void n5_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "5";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "5";
            }
        }

        // for writting 6
        private void n6_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text == "0" && EquationWritter.Text != null)
            {
                EquationWritter.Text = "6";
            }
            else
            {
                EquationWritter.Text = EquationWritter.Text + "6";
            }
        }
        // for clearing the screen
        private void CE_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text.Length > 0)
            {
                EquationWritter.Text = EquationWritter.Text.Substring(0, EquationWritter.Text.Length - 1);
            }

            if (EquationWritter.Text.Length == 0)
            {
                EquationWritter.Text = "0";
              
            }
        }
        // for division click operation
        private void division_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text != "")
            {
                EquationWritter.Text = EquationWritter.Text + "/";
            }
        }

        // for minus click operation
        private void minus_Click(object sender, EventArgs e)
        {
            if (EquationWritter.Text != "")
            {
                EquationWritter.Text = EquationWritter.Text + "-";
             
            }
        }

        // for removing the last character of he current equation
        private void clear_Click(object sender, EventArgs e)
        {
            EquationWritter.Clear();
            LastEquation.Clear();
            EquationWritter.Text= "0";
        }

        // for  for the current equation that is being procssed like 8/9 e.t.c
        private void EquationWritter_TextChanged(object sender, EventArgs e)
        {
            EquationWritter.Text=EquationWritter.Text;
            
        }

        // for the equation that latest equation that has processed
        private void LastEquation_TextChanged(object sender, EventArgs e)
        {
            LastEquation.Text= LastEquation.Text;
        }

        //for maintaing the history of the equation
        private void History_TextChanged(object sender, EventArgs e)
        {
            History.Text = History.Text;

        }



    }
}
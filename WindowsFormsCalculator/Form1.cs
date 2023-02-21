namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        string displayedNum = "0";
        string fullCommand = "";
        bool isCalcResult = false;
        bool isFullReset = false;

        bool isAllClear = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        void addCommand(string command)
        {
            if (isFullReset)
            {
                fullCommand = $"{displayedNum} {command}";
                fullCommandLabel.Text = fullCommand;
                isFullReset = false;
            }
            else
            {
                fullCommand += $" {displayedNum} {command}";
                fullCommandLabel.Text = fullCommand;
            }
            isCalcResult = true;

            isAllClear = false;
            clear.Text = "C";
        }

        void addNumToDisplay(string num)
        {
            if (displayedNum == "0" || isCalcResult || isFullReset)
                displayedNum = num;
            else
                displayedNum += num;

            if (isFullReset)
                fullCommand = "";

            if (fullCommand.Contains("/") || fullCommand.Contains("*") || fullCommand.Contains("-") || fullCommand.Contains("+")) { 
                isAllClear = false;
            clear.Text = "C"; }

            isCalcResult = false;
            isFullReset = false;
            if (displayedNum.Length > 9)
                calculatorResult.Text = displayedNum.Substring(displayedNum.Length - 9);
            else
                calculatorResult.Text = displayedNum;
            fullCommandLabel.Text = fullCommand;
        }

        private void num0_Click(object sender, EventArgs e)
        {
            addNumToDisplay("0");
        }

        private void num1_Click(object sender, EventArgs e)
        {
            addNumToDisplay("1");
        }

        private void num2_Click(object sender, EventArgs e)
        {
            addNumToDisplay("2");
        }

        private void num3_Click(object sender, EventArgs e)
        {
            addNumToDisplay("3");
        }

        private void num4_Click(object sender, EventArgs e)
        {
            addNumToDisplay("4");
        }

        private void num5_Click(object sender, EventArgs e)
        {
            addNumToDisplay("5");
        }

        private void num6_Click(object sender, EventArgs e)
        {
            addNumToDisplay("6");
        }

        private void num7_Click(object sender, EventArgs e)
        {
            addNumToDisplay("7");
        }

        private void num8_Click(object sender, EventArgs e)
        {
            addNumToDisplay("8");
        }

        private void num9_Click(object sender, EventArgs e)
        {
            addNumToDisplay("9");
        }

        void allClear()
        {
            displayedNum = "0";
            fullCommand = "";
            fullCommandLabel.Text = "";
            calculatorResult.Text = displayedNum;
        }

        void smallClear()
        {
            displayedNum = "0";
            calculatorResult.Text = displayedNum;

            isAllClear = true;
            clear.Text = "AC";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if(isAllClear)
                allClear();
            else
                smallClear();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            addCommand("/");
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            addCommand("*");
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            addCommand("-");
        }

        private void add_Click(object sender, EventArgs e)
        {
            addCommand("+");
        }

        private void equals_Click(object sender, EventArgs e)
        {
            if (isFullReset)
                return;

            fullCommand += $" {displayedNum}";

            displayedNum = Evaluate(fullCommand).ToString();

            if (displayedNum.Length > 9)
                displayedNum = displayedNum.Substring(0, 9);

            fullCommand += $" = {displayedNum}";

            fullCommandLabel.Text = fullCommand;

            calculatorResult.Text = displayedNum;

            isFullReset = true;

            isAllClear = true;
            clear.Text = "AC";
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (!displayedNum.Contains('.'))
            {
                if (displayedNum == "0")
                    displayedNum = "0.";
                else
                    displayedNum += '.';

                if (displayedNum.Length > 9)
                    calculatorResult.Text = displayedNum.Substring(displayedNum.Length - 9);
                else
                    calculatorResult.Text = displayedNum;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(Control.ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode == Keys.D8)
                    multiply.PerformClick();
                else if(e.KeyCode == Keys.Oemplus)
                    add.PerformClick();
                return;
            }

            if (e.KeyCode == Keys.OemQuestion)
                divide.PerformClick();
            else if (e.KeyCode == Keys.OemPeriod)
                dot.PerformClick();
            else if (e.KeyCode == Keys.Delete)
                clear.PerformClick();
            else if (e.KeyCode == Keys.Enter)
                equals.PerformClick();
            else if (e.KeyCode == Keys.OemMinus)
                subtract.PerformClick();
            else if(e.KeyCode == Keys.D0)
                num0.PerformClick();
            else if (e.KeyCode == Keys.D1)
                num1.PerformClick();
            else if (e.KeyCode == Keys.D2)
                num2.PerformClick();
            else if (e.KeyCode == Keys.D3)
                num3.PerformClick();
            else if (e.KeyCode == Keys.D4)
                num4.PerformClick();
            else if (e.KeyCode == Keys.D5)
                num5.PerformClick();
            else if (e.KeyCode == Keys.D6)
                num6.PerformClick();
            else if (e.KeyCode == Keys.D7)
                num7.PerformClick();
            else if (e.KeyCode == Keys.D8)
                num8.PerformClick();
            else if (e.KeyCode == Keys.D9)
                num9.PerformClick();
        }
    }
}
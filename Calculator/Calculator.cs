using Microsoft.VisualBasic.ApplicationServices;

namespace Calculator
{
    public partial class Calculator : Form
    {
        int newWidth;
        int newHeight;
        int fontSize;
        int fontSize2;
        int spaceBetween;
        int positionX;
        int positionY;

        string? input;
        double? result;

        static int length = 1;
        int index = 0;
        string[]? number = new string[length];
        string[]? operation = new string[length];

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Resize(object sender, EventArgs e)
        {
            Sizing();
        }

        public void Sizing()
        {
            newWidth = ActiveForm.Width;
            newHeight = ActiveForm.Height;

            if (WindowState != FormWindowState.Minimized)
            {
                if (ActiveForm.Height - Output.Height > ActiveForm.Width)
                {
                    spaceBetween = (int)Math.Round(0.027 * newWidth);

                    fontSize = (int)Math.Round(0.06 * newWidth);
                    Font font = new("Titillium Web", fontSize, FontStyle.Bold);
                    Output.Font = font;
                    font.Dispose();

                    fontSize2 = (int)Math.Round(0.064 * newWidth);
                    Font font2 = new("Titillium Web", fontSize2, FontStyle.Bold);
                    foreach (Button button in ActiveForm.Controls.OfType<Button>())
                    {
                        Positioning(button);
                        button.Width = (int)Math.Round(0.186 * newWidth);
                        button.Height = (int)Math.Round(0.186 * newWidth);
                        button.Font = font2;
                        button.Left = positionX;
                        button.Top = positionY;
                    }
                    font2.Dispose();
                }
                else
                {
                    spaceBetween = (int)Math.Round(0.022 * newHeight);

                    fontSize = (int)Math.Round(0.05 * newHeight);
                    Font font = new("Titillium Web", fontSize, FontStyle.Bold);
                    Output.Font = font;
                    font.Dispose();

                    fontSize2 = (int)Math.Round(0.053 * newHeight);
                    Font font2 = new("Titillium Web", fontSize2, FontStyle.Bold);
                    foreach (Button button in ActiveForm.Controls.OfType<Button>())
                    {
                        Positioning(button);
                        button.Width = (int)Math.Round(0.155 * newHeight);
                        button.Height = (int)Math.Round(0.155 * newHeight);
                        button.Font = font2;
                        button.Left = positionX;
                        button.Top = positionY;
                    }
                    font2.Dispose();
                }
            }
        }

        public void Positioning(Button button)
        {
            int centerX = newWidth / 2;
            int centerY = newHeight / 2 - button.Height / 2 - spaceBetween;

            int calcX1 = centerX - 2 * button.Width - 2 * spaceBetween;
            int calcX2 = centerX - button.Width - spaceBetween;
            int calcX3 = centerX;
            int calcX4 = centerX + button.Width + spaceBetween * 2;

            int calcY1 = centerY - 2 * button.Height - 2 * spaceBetween;
            int calcY2 = centerY - button.Height - spaceBetween;
            int calcY3 = centerY;
            int calcY4 = centerY + button.Height + spaceBetween;
            int calcY5 = centerY + 2 * button.Height + 2 * spaceBetween;

            switch (button.Name)
            {
                case "Comma":
                    positionX = calcX1;
                    positionY = calcY5;
                    break;
                case "Zero":
                    positionX = calcX2;
                    positionY = calcY5;
                    break;
                case "Equals":
                    positionX = calcX3;
                    positionY = calcY5;
                    break;
                case "Subtract":
                    positionX = calcX4;
                    positionY = calcY5;
                    break;
                case "One":
                    positionX = calcX1;
                    positionY = calcY4;
                    break;
                case "Two":
                    positionX = calcX2;
                    positionY = calcY4;
                    break;
                case "Three":
                    positionX = calcX3;
                    positionY = calcY4;
                    break;
                case "Add":
                    positionX = calcX4;
                    positionY = calcY4;
                    break;
                case "Four":
                    positionX = calcX1;
                    positionY = calcY3;
                    break;
                case "Five":
                    positionX = calcX2;
                    positionY = calcY3;
                    break;
                case "Six":
                    positionX = calcX3;
                    positionY = calcY3;
                    break;
                case "Multiply":
                    positionX = calcX4;
                    positionY = calcY3;
                    break;
                case "Seven":
                    positionX = calcX1;
                    positionY = calcY2;
                    break;
                case "Eight":
                    positionX = calcX2;
                    positionY = calcY2;
                    break;
                case "Nine":
                    positionX = calcX3;
                    positionY = calcY2;
                    break;
                case "Divide":
                    positionX = calcX4;
                    positionY = calcY2;
                    break;
                case "Reset":
                    positionX = calcX4;
                    positionY = calcY1;
                    break;
            }

            Output.Left = calcX1;
            Output.Top = (newHeight + Output.Height) / 2 - 3 * button.Width - 2 * spaceBetween;
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            number![index] += "0";
            input += "0";
            Output.Text = input;
        }

        private void One_Click(object sender, EventArgs e)
        {
            number![index] += "1";
            input += "1";
            Output.Text = input;
        }

        private void Two_Click(object sender, EventArgs e)
        {
            number![index] += "2";
            input += "2";
            Output.Text = input;
        }

        private void Three_Click(object sender, EventArgs e)
        {
            number![index] += "3";
            input += "3";
            Output.Text = input;
        }

        private void Four_Click(object sender, EventArgs e)
        {
            number![index] += "4";
            input += "4";
            Output.Text = input;
        }

        private void Five_Click(object sender, EventArgs e)
        {
            number![index] += "5";
            input += "5";
            Output.Text = input;
        }

        private void Six_Click(object sender, EventArgs e)
        {
            number![index] += "6";
            input += "6";
            Output.Text = input;
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            number![index] += "7";
            input += "7";
            Output.Text = input;
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            number![index] += "8";
            input += "8";
            Output.Text = input;
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            number![index] += "9";
            input += "9";
            Output.Text = input;
        }

        private void Subtract_Click(object sender, EventArgs e)
        {
            operation![index] = "-";
            index += 1;
            length += 1;
            Array.Resize(ref number, length);
            Array.Resize(ref operation, length);
            input += " - ";
            Output.Text = input;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            operation![index] = "+";
            index += 1;
            length += 1;
            Array.Resize(ref number, length);
            Array.Resize(ref operation, length);
            input += " + ";
            Output.Text = input;
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            operation![index] = "*";
            index += 1;
            length += 1;
            Array.Resize(ref number, length);
            Array.Resize(ref operation, length);
            input += " * ";
            Output.Text = input;
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            operation![index] = "/";
            index += 1;
            length += 1;
            Array.Resize(ref number, length);
            Array.Resize(ref operation, length);
            input += " / ";
            Output.Text = input;
        }

        private void Comma_Click(object sender, EventArgs e)
        {
            number![index] += ",";
            input += ",";
            Output.Text = input;
        }
        
        private void Equals_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < number!.Length; i++)
            {
                double term = double.Parse(number[i]);

                if (i == 0)
                {
                    result = term;
                }
                else if (operation![i - 1] == "-")
                {
                    result -= term;
                }
                else if (operation![i - 1] == "+")
                {
                    result += term;
                }
                else if (operation![i - 1] == "*")
                {
                    result *= term;
                }
                else if (operation![i - 1] == "/")
                {
                    result /= term;
                }
            }
            input += " = " + result;
            Output.Text = input;
            length = 1;
            index = 0;
            Array.Resize(ref number, 1);
            Array.Resize(ref operation, 1);
            Array.Clear(number, 0, 1);
            Array.Clear(operation, 0, 1);
            number[0] = result.ToString()!;
            input = number[0].ToString();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            input = "";
            Output.Text = input;
            length = 1;
            index = 0;
            Array.Resize(ref number, 1);
            Array.Resize(ref operation, 1);
            Array.Clear(number, 0, 1);
            Array.Clear(operation, 0, 1);
        }
    }
}
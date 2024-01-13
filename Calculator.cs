// Jag har gjort en miniräknare utifrån instruktionerna, därefter har jag implementerat och förbättrat ett flertal funktioner samt designat om den.

namespace Calculator
{
    public partial class Calculator : Form
    {
        int newWidth;
        int newHeight;
        int fontSize = 45;
        int fontSize2;
        int spaceBetween;
        int positionX;
        int positionY;

        bool commaExists = false;

        string? input;
        double? result;
        double adjustedSize;
        double previousSize;
        double fontFactor;

        static int length = 1;
        int index = 0;
        string[]? number = new string[length];
        string[]? operation = new string[length];

        public Calculator()
        {
            InitializeComponent();
        }

        /* En av funktionerna jag implementerat är att den del som visar input och output anpassar sin storlek
           automatiskt beroende på storleken av beräkningen. */

        public void TextAdjust()
        {
            /* Det räckte ej att ta längden stringen då det resulterade i ojämn anpassning.
               Detta berodde på att bredden av ett mellanslag är mindre än den av en siffra, så att när man använder de matematiska 
               operatörerna som inkluderar mellanslag är inte stringens längd en korrekt representation av hur mycket plats den tar.
               Istället räknar jag antal tecken som är samt inte är blanksteg. Då kan jag multiplicera antal blanksteg med ett lägre värde. */

            int nonWhiteSpaces = Output.Text.Count(c => !Char.IsWhiteSpace(c));
            int whiteSpaces = Output.Text.Count(c => Char.IsWhiteSpace(c));
            int textSpace = (int)Math.Round(nonWhiteSpaces + whiteSpaces * 0.3);

            // Max tillåtna längd är 9. För varje steg längre minskas storleken procentuellt.

            if (textSpace > 9)
            {
                adjustedSize = fontSize;
                previousSize = fontSize;
                for (float i = 10; i < textSpace; i++)
                {
                    /* Här var jag tvungen att använda switch case först när fontFactor = 1 / (i - 1) inte fungerade. 
                       Jag fann senare att man måste använda float. */
                    fontFactor = 1 / (i - 1f);
                    adjustedSize -= fontFactor * previousSize;
                    previousSize = adjustedSize;
                }
                Font font = new("Titillium Web", (int)Math.Round(adjustedSize), FontStyle.Bold);
                Output.Font = font;
                font.Dispose();
            }
            else
            {
                Font font = new("Titillium Web", fontSize, FontStyle.Bold);
                Output.Font = font;
                font.Dispose();
            }
            Output.Top = Reset.Top + Reset.Height / 2 - Output.Height / 2;
        }

        /* Jag har gjort miniräknaren extremt anpassningsbar. Den anpassar sig optimalt efter upplösning och fönstrets storlek.
           Vid resize eventen sätts nya värden för bredd och höjd och sedan kollas vilken som är störst. Miniräknaren skalas baserat på
           den med minst värde, eftersom denna blir flaskhalsen för möjlig maxstorlek. Sedan sätts så att storlekar alltid är samma andel
           av det nya värdet som de var av ursprungsvärdet. */

        private void Calculator_Resize(object sender, EventArgs e)
        {
            Sizing();
        }

        public void Sizing()
        {
            // Här uppstår error vid ändrad upplösning/skalning. Lösning: ta bort event handler från designern och lägg till den igen.

            newWidth = ActiveForm.Width;
            newHeight = ActiveForm.Height;

            if (WindowState != FormWindowState.Minimized)
            {
                if (ActiveForm.Height - Output.Height > ActiveForm.Width)
                {
                    spaceBetween = (int)Math.Round(0.027 * newWidth);
                    Output.Width = (int)Math.Round(0.612 * newWidth);

                    fontSize = (int)Math.Round(0.06 * newWidth);
                    Font font = new("Titillium Web", fontSize, FontStyle.Bold);
                    Output.Font = font;
                    font.Dispose();

                    TextAdjust();

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
                    Output.Width = (int)Math.Round(0.51 * newHeight);

                    fontSize = (int)Math.Round(0.05 * newHeight);
                    Font font = new("Titillium Web", fontSize, FontStyle.Bold);
                    Output.Font = font;
                    font.Dispose();

                    TextAdjust();

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

        /* När elementen ändrar storlek krävs också en metod som ser till att de positionerar sig korrekt. Här skapar jag som en egen grid
           för placering av alla knappar och text. Gridden utgår från center av fönstret och på så sätt läggs contenten ut snyggt, prydligt och centrerat. */

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

            Output.Left = calcX1 + spaceBetween;
            Output.Top = Reset.Top + Reset.Height / 2 - Output.Height / 2;
        }

        /* Från insturktionerna får man en halvbra miniräknare som endast kan räkna två termer.
           Jag bestämmde mig för att min miniräknare ska kunna:
            - Räkna hur många termer man vill.
            - Fortsätta räkna på resultatet.
            - Räkna med de fyra vanliga räknesätten.
            - Räkna med decimaler.
            - Vara anpassningsbar och användarvänlig.

           I framtiden skulle jag även vilja:
            - Fixa problemet med nuvarande versionen som ej gör det möjligt att använda prioriteringsregler. T.ex. 5 + 2 * 10 ger 70 istället för 25.
            - Lägga till en knapp som göra att användaren kan toggla mellan basic och advanced mode, i advanced mode ska det finnas fler funktioner som t.ex. cos, sin och tan.
           
           För att uppnå mina mål gjorde jag om miniräknarens grundläggande struktur.
           Jag har två arrays av strings, en som lagrar tal och en som lagrar matematiska operationer. Jag har även två ints - length och index.
           För varje ny operation blir length och index större, vilket i sin tur expanderar arrayen och skapar nya strings som representerar nästa nummer och ev. operation använder tycker in. */

        private void Zero_Click(object sender, EventArgs e)
        {
            if (length > 1 && operation![index - 1] == "/")
            {
                MessageBox.Show("Cannot divide by zero!");
            }
            else
            {
                number![index] += "0";
                input += "0";
                Output.Text = input;
                TextAdjust();
            }
        }

        private void One_Click(object sender, EventArgs e)
        {
            number![index] += "1";
            input += "1";
            Output.Text = input;
            TextAdjust();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            number![index] += "2";
            input += "2";
            Output.Text = input;
            TextAdjust();
        }

        private void Three_Click(object sender, EventArgs e)
        {
            number![index] += "3";
            input += "3";
            Output.Text = input;
            TextAdjust();
        }

        private void Four_Click(object sender, EventArgs e)
        {
            number![index] += "4";
            input += "4";
            Output.Text = input;
            TextAdjust();
        }

        private void Five_Click(object sender, EventArgs e)
        {
            number![index] += "5";
            input += "5";
            Output.Text = input;
            TextAdjust();
        }

        private void Six_Click(object sender, EventArgs e)
        {
            number![index] += "6";
            input += "6";
            Output.Text = input;
            TextAdjust();
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            number![index] += "7";
            input += "7";
            Output.Text = input;
            TextAdjust();
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            number![index] += "8";
            input += "8";
            Output.Text = input;
            TextAdjust();
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            number![index] += "9";
            input += "9";
            Output.Text = input;
            TextAdjust();
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
            TextAdjust();
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
            TextAdjust();
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
            TextAdjust();
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
            TextAdjust();
        }

        private void Comma_Click(object sender, EventArgs e)
        {
            commaExists = false;

            for (int i = 0; i < number![index].Length; i++)
            {
                if (number[index][i] == ',')
                {
                    commaExists = true;
                }
            }

            if (!commaExists)
            {
                number![index] += ",";
                input += ",";
                Output.Text = input;
                TextAdjust();
            }
            else
            {
                MessageBox.Show("Cannot write multiple commas in one number!");
            }
        }
        
        /* När användaren trycker på equals knappen beräknas resultatet. Längden på number arrayen ger antal termer som ska räknas i for loopen.
           For loopen använder villkorsatser och kollar vad den aktuella matematiska operationen är och beräknar därefter. 
           Sedan återställs också arraysen och första termen sätts till resultatet. */

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
            TextAdjust();
            length = 1;
            index = 0;
            Array.Resize(ref number, 1);
            Array.Resize(ref operation, 1);
            Array.Clear(number, 0, 1);
            Array.Clear(operation, 0, 1);
            number[0] = result.ToString()!;
            input = number[0].ToString();
        }

        // Denna event är ganska simpel, den återställer miniräknaren.

        private void Reset_Click(object sender, EventArgs e)
        {
            input = "";
            Output.Text = input;
            Font font = new("Titillium Web", fontSize, FontStyle.Bold);
            Output.Font = font;
            font.Dispose();
            length = 1;
            index = 0;
            Array.Resize(ref number, 1);
            Array.Resize(ref operation, 1);
            Array.Clear(number, 0, 1);
            Array.Clear(operation, 0, 1);
            TextAdjust();
        }
    }
}
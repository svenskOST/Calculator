// Jag har gjort en minir�knare utifr�n instruktionerna, d�refter har jag implementerat och f�rb�ttrat ett flertal funktioner samt designat om den.

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

        /* En av funktionerna jag implementerat �r att den del som visar input och output anpassar sin storlek
           automatiskt beroende p� storleken av ber�kningen. */

        public void TextAdjust()
        {
            /* Det r�ckte ej att ta l�ngden stringen d� det resulterade i oj�mn anpassning.
               Detta berodde p� att bredden av ett mellanslag �r mindre �n den av en siffra, s� att n�r man anv�nder de matematiska 
               operat�rerna som inkluderar mellanslag �r inte stringens l�ngd en korrekt representation av hur mycket plats den tar.
               Ist�llet r�knar jag antal tecken som �r samt inte �r blanksteg. D� kan jag multiplicera antal blanksteg med ett l�gre v�rde. */

            int nonWhiteSpaces = Output.Text.Count(c => !Char.IsWhiteSpace(c));
            int whiteSpaces = Output.Text.Count(c => Char.IsWhiteSpace(c));
            int textSpace = (int)Math.Round(nonWhiteSpaces + whiteSpaces * 0.3);

            // Max till�tna l�ngd �r 9. F�r varje steg l�ngre minskas storleken procentuellt.

            if (textSpace > 9)
            {
                adjustedSize = fontSize;
                previousSize = fontSize;
                for (float i = 10; i < textSpace; i++)
                {
                    /* H�r var jag tvungen att anv�nda switch case f�rst n�r fontFactor = 1 / (i - 1) inte fungerade. 
                       Jag fann senare att man m�ste anv�nda float. */
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

        /* Jag har gjort minir�knaren extremt anpassningsbar. Den anpassar sig optimalt efter uppl�sning och f�nstrets storlek.
           Vid resize eventen s�tts nya v�rden f�r bredd och h�jd och sedan kollas vilken som �r st�rst. Minir�knaren skalas baserat p�
           den med minst v�rde, eftersom denna blir flaskhalsen f�r m�jlig maxstorlek. Sedan s�tts s� att storlekar alltid �r samma andel
           av det nya v�rdet som de var av ursprungsv�rdet. */

        private void Calculator_Resize(object sender, EventArgs e)
        {
            Sizing();
        }

        public void Sizing()
        {
            // H�r uppst�r error vid �ndrad uppl�sning/skalning. L�sning: ta bort event handler fr�n designern och l�gg till den igen.

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

        /* N�r elementen �ndrar storlek kr�vs ocks� en metod som ser till att de positionerar sig korrekt. H�r skapar jag som en egen grid
           f�r placering av alla knappar och text. Gridden utg�r fr�n center av f�nstret och p� s� s�tt l�ggs contenten ut snyggt, prydligt och centrerat. */

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

        /* Fr�n insturktionerna f�r man en halvbra minir�knare som endast kan r�kna tv� termer.
           Jag best�mmde mig f�r att min minir�knare ska kunna:
            - R�kna hur m�nga termer man vill.
            - Forts�tta r�kna p� resultatet.
            - R�kna med de fyra vanliga r�knes�tten.
            - R�kna med decimaler.
            - Vara anpassningsbar och anv�ndarv�nlig.

           I framtiden skulle jag �ven vilja:
            - Fixa problemet med nuvarande versionen som ej g�r det m�jligt att anv�nda prioriteringsregler. T.ex. 5 + 2 * 10 ger 70 ist�llet f�r 25.
            - L�gga till en knapp som g�ra att anv�ndaren kan toggla mellan basic och advanced mode, i advanced mode ska det finnas fler funktioner som t.ex. cos, sin och tan.
           
           F�r att uppn� mina m�l gjorde jag om minir�knarens grundl�ggande struktur.
           Jag har tv� arrays av strings, en som lagrar tal och en som lagrar matematiska operationer. Jag har �ven tv� ints - length och index.
           F�r varje ny operation blir length och index st�rre, vilket i sin tur expanderar arrayen och skapar nya strings som representerar n�sta nummer och ev. operation anv�nder tycker in. */

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
        
        /* N�r anv�ndaren trycker p� equals knappen ber�knas resultatet. L�ngden p� number arrayen ger antal termer som ska r�knas i for loopen.
           For loopen anv�nder villkorsatser och kollar vad den aktuella matematiska operationen �r och ber�knar d�refter. 
           Sedan �terst�lls ocks� arraysen och f�rsta termen s�tts till resultatet. */

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

        // Denna event �r ganska simpel, den �terst�ller minir�knaren.

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
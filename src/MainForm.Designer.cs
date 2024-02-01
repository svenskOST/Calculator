namespace Calculator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Seven = new Button();
            Eight = new Button();
            Nine = new Button();
            Divide = new Button();
            Multiply = new Button();
            Six = new Button();
            Five = new Button();
            Four = new Button();
            Subtract = new Button();
            Equals = new Button();
            Reset = new Button();
            Add = new Button();
            Three = new Button();
            Two = new Button();
            One = new Button();
            Zero = new Button();
            Comma = new Button();
            Output = new Label();
            SuspendLayout();
            // 
            // Seven
            // 
            Seven.Anchor = AnchorStyles.None;
            Seven.BackColor = Color.FromArgb(64, 64, 64);
            Seven.FlatStyle = FlatStyle.Popup;
            Seven.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Seven.ForeColor = Color.White;
            Seven.Location = new Point(55, 200);
            Seven.Name = "Seven";
            Seven.Size = new Size(139, 140);
            Seven.TabIndex = 1;
            Seven.Text = "7";
            Seven.UseVisualStyleBackColor = false;
            Seven.Click += Seven_Click;
            // 
            // Eight
            // 
            Eight.Anchor = AnchorStyles.None;
            Eight.BackColor = Color.FromArgb(64, 64, 64);
            Eight.FlatStyle = FlatStyle.Popup;
            Eight.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Eight.ForeColor = Color.White;
            Eight.Location = new Point(215, 200);
            Eight.Name = "Eight";
            Eight.Size = new Size(139, 140);
            Eight.TabIndex = 2;
            Eight.Text = "8";
            Eight.UseVisualStyleBackColor = false;
            Eight.Click += Eight_Click;
            // 
            // Nine
            // 
            Nine.Anchor = AnchorStyles.None;
            Nine.BackColor = Color.FromArgb(64, 64, 64);
            Nine.FlatStyle = FlatStyle.Popup;
            Nine.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Nine.ForeColor = Color.White;
            Nine.Location = new Point(375, 200);
            Nine.Name = "Nine";
            Nine.Size = new Size(139, 140);
            Nine.TabIndex = 3;
            Nine.Text = "9";
            Nine.UseVisualStyleBackColor = false;
            Nine.Click += Nine_Click;
            // 
            // Divide
            // 
            Divide.Anchor = AnchorStyles.None;
            Divide.BackColor = Color.FromArgb(255, 128, 0);
            Divide.FlatStyle = FlatStyle.Popup;
            Divide.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Divide.ForeColor = Color.White;
            Divide.Location = new Point(555, 200);
            Divide.Name = "Divide";
            Divide.Size = new Size(139, 140);
            Divide.TabIndex = 4;
            Divide.Text = "/";
            Divide.UseVisualStyleBackColor = false;
            Divide.Click += Divide_Click;
            // 
            // Multiply
            // 
            Multiply.Anchor = AnchorStyles.None;
            Multiply.BackColor = Color.FromArgb(255, 128, 0);
            Multiply.FlatStyle = FlatStyle.Popup;
            Multiply.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Multiply.ForeColor = Color.White;
            Multiply.ImageAlign = ContentAlignment.TopLeft;
            Multiply.Location = new Point(555, 360);
            Multiply.Name = "Multiply";
            Multiply.Size = new Size(139, 140);
            Multiply.TabIndex = 8;
            Multiply.Text = "*";
            Multiply.TextAlign = ContentAlignment.BottomCenter;
            Multiply.UseVisualStyleBackColor = false;
            Multiply.Click += Multiply_Click;
            // 
            // Six
            // 
            Six.Anchor = AnchorStyles.None;
            Six.BackColor = Color.FromArgb(64, 64, 64);
            Six.FlatStyle = FlatStyle.Popup;
            Six.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Six.ForeColor = Color.White;
            Six.Location = new Point(375, 360);
            Six.Name = "Six";
            Six.Size = new Size(139, 140);
            Six.TabIndex = 7;
            Six.Text = "6";
            Six.UseVisualStyleBackColor = false;
            Six.Click += Six_Click;
            // 
            // Five
            // 
            Five.Anchor = AnchorStyles.None;
            Five.BackColor = Color.FromArgb(64, 64, 64);
            Five.FlatStyle = FlatStyle.Popup;
            Five.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Five.ForeColor = Color.White;
            Five.Location = new Point(215, 360);
            Five.Name = "Five";
            Five.Size = new Size(139, 140);
            Five.TabIndex = 6;
            Five.Text = "5";
            Five.UseVisualStyleBackColor = false;
            Five.Click += Five_Click;
            // 
            // Four
            // 
            Four.Anchor = AnchorStyles.None;
            Four.BackColor = Color.FromArgb(64, 64, 64);
            Four.FlatStyle = FlatStyle.Popup;
            Four.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Four.ForeColor = Color.White;
            Four.Location = new Point(55, 360);
            Four.Name = "Four";
            Four.Size = new Size(139, 140);
            Four.TabIndex = 5;
            Four.Text = "4";
            Four.UseVisualStyleBackColor = false;
            Four.Click += Four_Click;
            // 
            // Subtract
            // 
            Subtract.Anchor = AnchorStyles.None;
            Subtract.BackColor = Color.FromArgb(255, 128, 0);
            Subtract.FlatStyle = FlatStyle.Popup;
            Subtract.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Subtract.ForeColor = Color.White;
            Subtract.Location = new Point(555, 680);
            Subtract.Name = "Subtract";
            Subtract.Size = new Size(139, 140);
            Subtract.TabIndex = 16;
            Subtract.Text = "-";
            Subtract.UseVisualStyleBackColor = false;
            Subtract.Click += Subtract_Click;
            // 
            // Equals
            // 
            Equals.Anchor = AnchorStyles.None;
            Equals.BackColor = Color.FromArgb(32, 32, 32);
            Equals.FlatStyle = FlatStyle.Popup;
            Equals.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Equals.ForeColor = Color.White;
            Equals.Location = new Point(375, 680);
            Equals.Name = "Equals";
            Equals.Size = new Size(139, 140);
            Equals.TabIndex = 15;
            Equals.Text = "=";
            Equals.TextAlign = ContentAlignment.TopCenter;
            Equals.UseVisualStyleBackColor = false;
            Equals.Click += Equals_Click;
            // 
            // Reset
            // 
            Reset.Anchor = AnchorStyles.None;
            Reset.BackColor = Color.FromArgb(32, 32, 32);
            Reset.FlatStyle = FlatStyle.Popup;
            Reset.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Reset.ForeColor = Color.White;
            Reset.Location = new Point(555, 40);
            Reset.Name = "Reset";
            Reset.Size = new Size(139, 140);
            Reset.TabIndex = 13;
            Reset.Text = "C";
            Reset.UseVisualStyleBackColor = false;
            Reset.Click += Reset_Click;
            // 
            // Add
            // 
            Add.Anchor = AnchorStyles.None;
            Add.BackColor = Color.FromArgb(255, 128, 0);
            Add.FlatStyle = FlatStyle.Popup;
            Add.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Add.ForeColor = Color.White;
            Add.Location = new Point(555, 520);
            Add.Name = "Add";
            Add.Size = new Size(139, 140);
            Add.TabIndex = 12;
            Add.Text = "+";
            Add.UseVisualStyleBackColor = false;
            Add.Click += Add_Click;
            // 
            // Three
            // 
            Three.Anchor = AnchorStyles.None;
            Three.BackColor = Color.FromArgb(64, 64, 64);
            Three.FlatStyle = FlatStyle.Popup;
            Three.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Three.ForeColor = Color.White;
            Three.Location = new Point(375, 520);
            Three.Name = "Three";
            Three.Size = new Size(139, 140);
            Three.TabIndex = 11;
            Three.Text = "3";
            Three.UseVisualStyleBackColor = false;
            Three.Click += Three_Click;
            // 
            // Two
            // 
            Two.Anchor = AnchorStyles.None;
            Two.BackColor = Color.FromArgb(64, 64, 64);
            Two.FlatStyle = FlatStyle.Popup;
            Two.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Two.ForeColor = Color.White;
            Two.Location = new Point(215, 520);
            Two.Name = "Two";
            Two.Size = new Size(139, 140);
            Two.TabIndex = 10;
            Two.Text = "2";
            Two.UseVisualStyleBackColor = false;
            Two.Click += Two_Click;
            // 
            // One
            // 
            One.Anchor = AnchorStyles.None;
            One.BackColor = Color.FromArgb(64, 64, 64);
            One.FlatStyle = FlatStyle.Popup;
            One.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            One.ForeColor = Color.White;
            One.Location = new Point(55, 520);
            One.Name = "One";
            One.Size = new Size(139, 140);
            One.TabIndex = 9;
            One.Text = "1";
            One.UseVisualStyleBackColor = false;
            One.Click += One_Click;
            // 
            // Zero
            // 
            Zero.Anchor = AnchorStyles.None;
            Zero.BackColor = Color.FromArgb(64, 64, 64);
            Zero.FlatStyle = FlatStyle.Popup;
            Zero.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Zero.ForeColor = Color.White;
            Zero.Location = new Point(215, 680);
            Zero.Name = "Zero";
            Zero.Size = new Size(139, 140);
            Zero.TabIndex = 17;
            Zero.Text = "0";
            Zero.UseVisualStyleBackColor = false;
            Zero.Click += Zero_Click;
            // 
            // Comma
            // 
            Comma.Anchor = AnchorStyles.None;
            Comma.BackColor = Color.FromArgb(32, 32, 32);
            Comma.FlatStyle = FlatStyle.Popup;
            Comma.Font = new Font("Titillium Web", 48F, FontStyle.Bold);
            Comma.ForeColor = Color.White;
            Comma.Location = new Point(55, 680);
            Comma.Name = "Comma";
            Comma.Size = new Size(139, 140);
            Comma.TabIndex = 19;
            Comma.Text = " ,";
            Comma.TextAlign = ContentAlignment.TopCenter;
            Comma.UseVisualStyleBackColor = false;
            Comma.Click += Comma_Click;
            // 
            // Output
            // 
            Output.AutoSize = true;
            Output.Font = new Font("Titillium Web", 45F, FontStyle.Bold);
            Output.ForeColor = Color.White;
            Output.Location = new Point(74, 51);
            Output.Name = "Output";
            Output.Size = new Size(0, 114);
            Output.TabIndex = 21;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(731, 853);
            Controls.Add(Output);
            Controls.Add(Comma);
            Controls.Add(Zero);
            Controls.Add(Subtract);
            Controls.Add(Equals);
            Controls.Add(Reset);
            Controls.Add(Add);
            Controls.Add(Three);
            Controls.Add(Two);
            Controls.Add(One);
            Controls.Add(Multiply);
            Controls.Add(Six);
            Controls.Add(Five);
            Controls.Add(Four);
            Controls.Add(Divide);
            Controls.Add(Nine);
            Controls.Add(Eight);
            Controls.Add(Seven);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Calculator";
            Resize += Calculator_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Seven;
        private Button Eight;
        private Button Nine;
        private Button Divide;
        private Button Multiply;
        private Button Six;
        private Button Five;
        private Button Four;
        private Button Subtract;
        private new Button Equals;
        private Button Reset;
        private Button Add;
        private Button Three;
        private Button Two;
        private Button One;
        private Button Zero;
        private Button Comma;
        private Label Output;
    }
}
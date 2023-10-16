namespace the_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LastEquation = new System.Windows.Forms.TextBox();
            this.EquationWritter = new System.Windows.Forms.TextBox();
            this.History = new System.Windows.Forms.TextBox();
            this.n4 = new System.Windows.Forms.Button();
            this.n7 = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.n8 = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.n5 = new System.Windows.Forms.Button();
            this.n6 = new System.Windows.Forms.Button();
            this.division = new System.Windows.Forms.Button();
            this.CE = new System.Windows.Forms.Button();
            this.n9 = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.n1 = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.n3 = new System.Windows.Forms.Button();
            this.n2 = new System.Windows.Forms.Button();
            this.nDot = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
            this.n0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LastEquation
            // 
            this.LastEquation.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.LastEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LastEquation.Location = new System.Drawing.Point(201, 42);
            this.LastEquation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LastEquation.Multiline = true;
            this.LastEquation.Name = "LastEquation";
            this.LastEquation.Size = new System.Drawing.Size(531, 26);
            this.LastEquation.TabIndex = 45;
            this.LastEquation.Text = "< Last Equation > =     ";
            this.LastEquation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LastEquation.UseWaitCursor = true;
            this.LastEquation.TextChanged += new System.EventHandler(this.LastEquation_TextChanged);
            // 
            // EquationWritter
            // 
            this.EquationWritter.BackColor = System.Drawing.SystemColors.Window;
            this.EquationWritter.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EquationWritter.Location = new System.Drawing.Point(201, 70);
            this.EquationWritter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EquationWritter.Multiline = true;
            this.EquationWritter.Name = "EquationWritter";
            this.EquationWritter.Size = new System.Drawing.Size(531, 78);
            this.EquationWritter.TabIndex = 44;
            this.EquationWritter.Text = "0";
            this.EquationWritter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EquationWritter.TextChanged += new System.EventHandler(this.EquationWritter_TextChanged);
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.History.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.History.Location = new System.Drawing.Point(201, 156);
            this.History.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.History.Multiline = true;
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(157, 322);
            this.History.TabIndex = 43;
            this.History.Text = "History                                                                          " +
    "      ";
            this.History.TextChanged += new System.EventHandler(this.History_TextChanged);
            // 
            // n4
            // 
            this.n4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n4.Location = new System.Drawing.Point(365, 295);
            this.n4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n4.Name = "n4";
            this.n4.Size = new System.Drawing.Size(85, 57);
            this.n4.TabIndex = 41;
            this.n4.Text = "4";
            this.n4.UseVisualStyleBackColor = false;
            // 
            // n7
            // 
            this.n7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n7.Location = new System.Drawing.Point(365, 232);
            this.n7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n7.Name = "n7";
            this.n7.Size = new System.Drawing.Size(85, 57);
            this.n7.TabIndex = 40;
            this.n7.Text = "7";
            this.n7.UseVisualStyleBackColor = false;
            this.n7.Click += new System.EventHandler(this.n7_Click);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clear.Location = new System.Drawing.Point(365, 156);
            this.clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(85, 57);
            this.clear.TabIndex = 39;
            this.clear.Text = "C";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // n8
            // 
            this.n8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n8.Location = new System.Drawing.Point(463, 232);
            this.n8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n8.Name = "n8";
            this.n8.Size = new System.Drawing.Size(85, 57);
            this.n8.TabIndex = 38;
            this.n8.Text = "8";
            this.n8.UseVisualStyleBackColor = false;
            this.n8.Click += new System.EventHandler(this.n8_Click);
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.minus.Location = new System.Drawing.Point(463, 156);
            this.minus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(85, 57);
            this.minus.TabIndex = 37;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = false;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // n5
            // 
            this.n5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n5.Location = new System.Drawing.Point(463, 295);
            this.n5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n5.Name = "n5";
            this.n5.Size = new System.Drawing.Size(85, 57);
            this.n5.TabIndex = 36;
            this.n5.Text = "5";
            this.n5.UseVisualStyleBackColor = false;
            this.n5.Click += new System.EventHandler(this.n5_Click);
            // 
            // n6
            // 
            this.n6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n6.Location = new System.Drawing.Point(555, 295);
            this.n6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n6.Name = "n6";
            this.n6.Size = new System.Drawing.Size(85, 57);
            this.n6.TabIndex = 42;
            this.n6.Text = "6";
            this.n6.UseVisualStyleBackColor = false;
            this.n6.Click += new System.EventHandler(this.n6_Click);
            // 
            // division
            // 
            this.division.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.division.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.division.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.division.Location = new System.Drawing.Point(555, 156);
            this.division.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(85, 57);
            this.division.TabIndex = 25;
            this.division.Text = "/";
            this.division.UseVisualStyleBackColor = false;
            this.division.Click += new System.EventHandler(this.division_Click);
            // 
            // CE
            // 
            this.CE.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CE.Location = new System.Drawing.Point(648, 156);
            this.CE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CE.Name = "CE";
            this.CE.Size = new System.Drawing.Size(85, 57);
            this.CE.TabIndex = 33;
            this.CE.Text = "CE";
            this.CE.UseVisualStyleBackColor = false;
            this.CE.Click += new System.EventHandler(this.CE_Click);
            // 
            // n9
            // 
            this.n9.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n9.Location = new System.Drawing.Point(555, 232);
            this.n9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n9.Name = "n9";
            this.n9.Size = new System.Drawing.Size(85, 57);
            this.n9.TabIndex = 32;
            this.n9.Text = "9";
            this.n9.UseVisualStyleBackColor = false;
            this.n9.Click += new System.EventHandler(this.n9_Click);
            // 
            // multiply
            // 
            this.multiply.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.multiply.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.multiply.Location = new System.Drawing.Point(648, 232);
            this.multiply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(85, 57);
            this.multiply.TabIndex = 31;
            this.multiply.Text = "X";
            this.multiply.UseVisualStyleBackColor = false;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // n1
            // 
            this.n1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n1.Location = new System.Drawing.Point(365, 359);
            this.n1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(85, 57);
            this.n1.TabIndex = 30;
            this.n1.Text = "1";
            this.n1.UseVisualStyleBackColor = false;
            this.n1.Click += new System.EventHandler(this.n1_Click);
            // 
            // Plus
            // 
            this.Plus.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Plus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Plus.Location = new System.Drawing.Point(648, 295);
            this.Plus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(85, 120);
            this.Plus.TabIndex = 29;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = false;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // n3
            // 
            this.n3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n3.Location = new System.Drawing.Point(555, 359);
            this.n3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n3.Name = "n3";
            this.n3.Size = new System.Drawing.Size(85, 57);
            this.n3.TabIndex = 28;
            this.n3.Text = "3";
            this.n3.UseVisualStyleBackColor = false;
            this.n3.Click += new System.EventHandler(this.n3_Click);
            // 
            // n2
            // 
            this.n2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n2.Location = new System.Drawing.Point(463, 359);
            this.n2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(85, 57);
            this.n2.TabIndex = 27;
            this.n2.Text = "2";
            this.n2.UseVisualStyleBackColor = false;
            this.n2.Click += new System.EventHandler(this.n2_Click);
            // 
            // nDot
            // 
            this.nDot.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.nDot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nDot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nDot.Location = new System.Drawing.Point(555, 422);
            this.nDot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nDot.Name = "nDot";
            this.nDot.Size = new System.Drawing.Size(85, 57);
            this.nDot.TabIndex = 26;
            this.nDot.Text = ".";
            this.nDot.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.nDot.UseVisualStyleBackColor = false;
            this.nDot.Click += new System.EventHandler(this.nDot_Click);
            // 
            // equal
            // 
            this.equal.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.equal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.equal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.equal.Location = new System.Drawing.Point(648, 422);
            this.equal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(85, 57);
            this.equal.TabIndex = 34;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = false;
            this.equal.Click += new System.EventHandler(this.equal_Click);
            // 
            // n0
            // 
            this.n0.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.n0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.n0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.n0.Location = new System.Drawing.Point(365, 422);
            this.n0.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.n0.Name = "n0";
            this.n0.Size = new System.Drawing.Size(183, 57);
            this.n0.TabIndex = 35;
            this.n0.Text = "0";
            this.n0.UseVisualStyleBackColor = false;
            this.n0.Click += new System.EventHandler(this.n0_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.LastEquation);
            this.Controls.Add(this.EquationWritter);
            this.Controls.Add(this.History);
            this.Controls.Add(this.n4);
            this.Controls.Add(this.n7);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.n8);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.n5);
            this.Controls.Add(this.n6);
            this.Controls.Add(this.division);
            this.Controls.Add(this.CE);
            this.Controls.Add(this.n9);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.n3);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.nDot);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.n0);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "The_Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LastEquation;
        private System.Windows.Forms.TextBox EquationWritter;
        private System.Windows.Forms.TextBox History;
        private System.Windows.Forms.Button n4;
        private System.Windows.Forms.Button n7;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button n8;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button n5;
        private System.Windows.Forms.Button n6;
        private System.Windows.Forms.Button division;
        private System.Windows.Forms.Button CE;
        private System.Windows.Forms.Button n9;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button n1;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button n3;
        private System.Windows.Forms.Button n2;
        private System.Windows.Forms.Button nDot;
        private System.Windows.Forms.Button equal;
        private System.Windows.Forms.Button n0;
    }
}
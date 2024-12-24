namespace compiler_proj
{
    partial class IDE
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
            this.button = new System.Windows.Forms.Button();
            this.inputCode = new System.Windows.Forms.TextBox();
            this.outputAnalyze = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.parserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button.Location = new System.Drawing.Point(187, 553);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(154, 115);
            this.button.TabIndex = 2;
            this.button.Text = "Scanner";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.analyze);
            // 
            // inputCode
            // 
            this.inputCode.AccessibleDescription = "";
            this.inputCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCode.Location = new System.Drawing.Point(5, 1);
            this.inputCode.Multiline = true;
            this.inputCode.Name = "inputCode";
            this.inputCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputCode.Size = new System.Drawing.Size(587, 535);
            this.inputCode.TabIndex = 3;
            this.inputCode.Tag = "";
            this.inputCode.TextChanged += new System.EventHandler(this.input_code);
            // 
            // outputAnalyze
            // 
            this.outputAnalyze.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.outputAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputAnalyze.Location = new System.Drawing.Point(598, 1);
            this.outputAnalyze.Multiline = true;
            this.outputAnalyze.Name = "outputAnalyze";
            this.outputAnalyze.ReadOnly = true;
            this.outputAnalyze.Size = new System.Drawing.Size(585, 673);
            this.outputAnalyze.TabIndex = 4;
            this.outputAnalyze.Tag = "";
            this.outputAnalyze.Text = "Your Output";
            this.outputAnalyze.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.outputAnalyze.TextChanged += new System.EventHandler(this.output_analyze);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.clearButton.Location = new System.Drawing.Point(12, 553);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(154, 115);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click_1);
            // 
            // parserButton
            // 
            this.parserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.parserButton.Location = new System.Drawing.Point(375, 553);
            this.parserButton.Name = "parserButton";
            this.parserButton.Size = new System.Drawing.Size(154, 115);
            this.parserButton.TabIndex = 6;
            this.parserButton.Text = "Parser";
            this.parserButton.UseVisualStyleBackColor = false;
            this.parserButton.Click += new System.EventHandler(this.parserButton_Click);
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1195, 680);
            this.Controls.Add(this.parserButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.outputAnalyze);
            this.Controls.Add(this.inputCode);
            this.Controls.Add(this.button);
            this.Name = "IDE";
            this.Text = "IDE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox inputCode;
        private System.Windows.Forms.TextBox outputAnalyze;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button parserButton;
    }
}


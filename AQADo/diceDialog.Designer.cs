namespace AQADo
{
    partial class diceDialog
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
            this.rollButton = new System.Windows.Forms.Button();
            this.diceOutput = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.youMay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rollButton
            // 
            this.rollButton.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollButton.Location = new System.Drawing.Point(13, 13);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(150, 150);
            this.rollButton.TabIndex = 0;
            this.rollButton.Text = "ROLL!";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // diceOutput
            // 
            this.diceOutput.AutoSize = true;
            this.diceOutput.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diceOutput.Location = new System.Drawing.Point(204, 73);
            this.diceOutput.Name = "diceOutput";
            this.diceOutput.Size = new System.Drawing.Size(93, 38);
            this.diceOutput.TabIndex = 1;
            this.diceOutput.Text = "label1";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(325, 92);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(35, 13);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.Text = "label1";
            // 
            // youMay
            // 
            this.youMay.AutoSize = true;
            this.youMay.Location = new System.Drawing.Point(328, -1);
            this.youMay.Name = "youMay";
            this.youMay.Size = new System.Drawing.Size(35, 13);
            this.youMay.TabIndex = 3;
            this.youMay.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "If you have rolled a four and it is your first turn, please click one of your cou" +
    "nters to allow you to roll again. \r\nIf a four is rolled again, carry on until yo" +
    "u can move.";
            // 
            // diceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 202);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.youMay);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.diceOutput);
            this.Controls.Add(this.rollButton);
            this.Location = new System.Drawing.Point(620, 30);
            this.Name = "diceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Label diceOutput;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label youMay;
        private System.Windows.Forms.Label label1;
    }
}
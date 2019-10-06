namespace Game_Form
{
    partial class formGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGameForm));
            this.lblMap = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tbUnitInfo = new System.Windows.Forms.RichTextBox();
            this.tbNumUnits = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.BackColor = System.Drawing.SystemColors.MenuText;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMap.Location = new System.Drawing.Point(10, 10);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(371, 270);
            this.lblMap.TabIndex = 0;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(415, 255);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(51, 13);
            this.lblRound.TabIndex = 1;
            this.lblRound.Text = "Round: 0";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnStart.Location = new System.Drawing.Point(411, 104);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPause.Location = new System.Drawing.Point(411, 134);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tbUnitInfo
            // 
            this.tbUnitInfo.Location = new System.Drawing.Point(9, 295);
            this.tbUnitInfo.Name = "tbUnitInfo";
            this.tbUnitInfo.Size = new System.Drawing.Size(488, 75);
            this.tbUnitInfo.TabIndex = 4;
            this.tbUnitInfo.Text = "";
            // 
            // tbNumUnits
            // 
            this.tbNumUnits.Location = new System.Drawing.Point(397, 61);
            this.tbNumUnits.Name = "tbNumUnits";
            this.tbNumUnits.Size = new System.Drawing.Size(100, 20);
            this.tbNumUnits.TabIndex = 5;
            this.tbNumUnits.Text = "<number of units>";
            // 
            // formGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(505, 382);
            this.Controls.Add(this.tbNumUnits);
            this.Controls.Add(this.tbUnitInfo);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblMap);
            this.Name = "formGameForm";
            this.Text = "Game Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox tbUnitInfo;
        private System.Windows.Forms.TextBox tbNumUnits;
    }
}


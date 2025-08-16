namespace Minesweeper.GUI
{
    partial class MinesweeperGUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flpGameField = new System.Windows.Forms.FlowLayoutPanel();
            this.cBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnShowAllFields = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMinesCount = new System.Windows.Forms.Label();
            this.tbxPlayerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // flpGameField
            // 
            this.flpGameField.Location = new System.Drawing.Point(35, 94);
            this.flpGameField.Name = "flpGameField";
            this.flpGameField.Size = new System.Drawing.Size(1400, 577);
            this.flpGameField.TabIndex = 0;
            // 
            // cBoxDifficulty
            // 
            this.cBoxDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxDifficulty.FormattingEnabled = true;
            this.cBoxDifficulty.Items.AddRange(new object[] {
            "Beginner",
            "Advanced",
            "Expert",
            "Godmode"});
            this.cBoxDifficulty.Location = new System.Drawing.Point(212, 31);
            this.cBoxDifficulty.Name = "cBoxDifficulty";
            this.cBoxDifficulty.Size = new System.Drawing.Size(121, 32);
            this.cBoxDifficulty.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(524, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 34);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnShowAllFields
            // 
            this.btnShowAllFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllFields.Location = new System.Drawing.Point(369, 29);
            this.btnShowAllFields.Name = "btnShowAllFields";
            this.btnShowAllFields.Size = new System.Drawing.Size(149, 34);
            this.btnShowAllFields.TabIndex = 3;
            this.btnShowAllFields.Text = "Show Fields";
            this.btnShowAllFields.UseVisualStyleBackColor = true;
            this.btnShowAllFields.Click += new System.EventHandler(this.btnShowAllFields_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(630, 34);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(55, 24);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "00:00";
            // 
            // lblMinesCount
            // 
            this.lblMinesCount.AutoSize = true;
            this.lblMinesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinesCount.Location = new System.Drawing.Point(51, 34);
            this.lblMinesCount.Name = "lblMinesCount";
            this.lblMinesCount.Size = new System.Drawing.Size(126, 24);
            this.lblMinesCount.TabIndex = 5;
            this.lblMinesCount.Text = "[Mines Count]";
            // 
            // tbxPlayerName
            // 
            this.tbxPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPlayerName.Location = new System.Drawing.Point(784, 37);
            this.tbxPlayerName.Name = "tbxPlayerName";
            this.tbxPlayerName.Size = new System.Drawing.Size(145, 29);
            this.tbxPlayerName.TabIndex = 6;
            // 
            // MinesweeperGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 1061);
            this.Controls.Add(this.tbxPlayerName);
            this.Controls.Add(this.lblMinesCount);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnShowAllFields);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cBoxDifficulty);
            this.Controls.Add(this.flpGameField);
            this.Name = "MinesweeperGUI";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpGameField;
        private System.Windows.Forms.ComboBox cBoxDifficulty;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnShowAllFields;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMinesCount;
        private System.Windows.Forms.TextBox tbxPlayerName;
    }
}


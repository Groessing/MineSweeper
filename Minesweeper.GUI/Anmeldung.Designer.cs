namespace Minesweeper.GUI
{
    partial class Anmeldung
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lvwPlayers = new System.Windows.Forms.ListView();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnStartWithoutRegistration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(312, 112);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(140, 29);
            this.tbxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your name";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(349, 153);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(103, 38);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lvwPlayers
            // 
            this.lvwPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPlayers.HideSelection = false;
            this.lvwPlayers.Location = new System.Drawing.Point(60, 208);
            this.lvwPlayers.Name = "lvwPlayers";
            this.lvwPlayers.Size = new System.Drawing.Size(392, 149);
            this.lvwPlayers.TabIndex = 3;
            this.lvwPlayers.UseCompatibleStateImageBehavior = false;
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(206, 363);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(103, 38);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStartWithoutRegistration
            // 
            this.btnStartWithoutRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartWithoutRegistration.Location = new System.Drawing.Point(60, 12);
            this.btnStartWithoutRegistration.Name = "btnStartWithoutRegistration";
            this.btnStartWithoutRegistration.Size = new System.Drawing.Size(196, 57);
            this.btnStartWithoutRegistration.TabIndex = 5;
            this.btnStartWithoutRegistration.Text = "Start without Registration";
            this.btnStartWithoutRegistration.UseVisualStyleBackColor = true;
            this.btnStartWithoutRegistration.Click += new System.EventHandler(this.btnStartWithoutRegistration_Click);
            // 
            // Anmeldung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStartWithoutRegistration);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lvwPlayers);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxName);
            this.Name = "Anmeldung";
            this.Text = "Anmeldung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.ListView lvwPlayers;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnStartWithoutRegistration;
    }
}
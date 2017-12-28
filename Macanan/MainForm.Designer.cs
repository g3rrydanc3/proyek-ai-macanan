namespace Macanan
{
    partial class MainForm
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
            this.help1 = new Macanan.View.Help();
            this.menu1 = new Macanan.Menu();
            this.game1 = new Macanan.Game();
            this.SuspendLayout();
            // 
            // help1
            // 
            this.help1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.help1.Location = new System.Drawing.Point(1, -1);
            this.help1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(389, 481);
            this.help1.TabIndex = 1;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menu1.Location = new System.Drawing.Point(1, -1);
            this.menu1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(520, 481);
            this.menu1.TabIndex = 0;
            // 
            // game1
            // 
            this.game1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.game1.Location = new System.Drawing.Point(1, -1);
            this.game1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(1197, 576);
            this.game1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1244, 741);
            this.Controls.Add(this.game1);
            this.Controls.Add(this.help1);
            this.Controls.Add(this.menu1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Menu menu1;
        private View.Help help1;
        private Game game1;
    }
}


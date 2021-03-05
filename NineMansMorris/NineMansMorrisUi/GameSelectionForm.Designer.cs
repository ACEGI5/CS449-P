using System.ComponentModel;

namespace NineMansMorrisUi
{
    partial class GameSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlayerVsPlayer = new System.Windows.Forms.Button();
            this.btnPlayerVsComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(265, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(619, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "Umkc Nine Man\'s Morris";
            // 
            // btnPlayerVsPlayer
            // 
            this.btnPlayerVsPlayer.Location = new System.Drawing.Point(60, 182);
            this.btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            this.btnPlayerVsPlayer.Size = new System.Drawing.Size(362, 96);
            this.btnPlayerVsPlayer.TabIndex = 1;
            this.btnPlayerVsPlayer.Text = "Player Vs. Player";
            this.btnPlayerVsPlayer.UseVisualStyleBackColor = true;
            this.btnPlayerVsPlayer.Click += new System.EventHandler(this.btnPlayerVsPlayer_Click_1);
            // 
            // btnPlayerVsComputer
            // 
            this.btnPlayerVsComputer.Location = new System.Drawing.Point(607, 182);
            this.btnPlayerVsComputer.Name = "btnPlayerVsComputer";
            this.btnPlayerVsComputer.Size = new System.Drawing.Size(362, 96);
            this.btnPlayerVsComputer.TabIndex = 2;
            this.btnPlayerVsComputer.Text = "Player Vs. Computer";
            this.btnPlayerVsComputer.UseVisualStyleBackColor = true;
            this.btnPlayerVsComputer.Click += new System.EventHandler(this.btnPlayerVsComputer_Click);
            // 
            // GameSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 343);
            this.Controls.Add(this.btnPlayerVsComputer);
            this.Controls.Add(this.btnPlayerVsPlayer);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "GameSelectionForm";
            this.Text = "GameSelectionForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnPlayerVsComputer;

        private System.Windows.Forms.Button btnPlayerVsPlayer;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}
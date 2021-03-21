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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(102, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nine Man\'s Morris";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPlayerVsPlayer
            // 
            this.btnPlayerVsPlayer.Location = new System.Drawing.Point(10, 94);
            this.btnPlayerVsPlayer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            this.btnPlayerVsPlayer.Size = new System.Drawing.Size(136, 40);
            this.btnPlayerVsPlayer.TabIndex = 1;
            this.btnPlayerVsPlayer.Text = "Player VS Player";
            this.btnPlayerVsPlayer.UseVisualStyleBackColor = true;
            this.btnPlayerVsPlayer.Click += new System.EventHandler(this.btnPlayerVsPlayer_Click_1);
            // 
            // btnPlayerVsComputer
            // 
            this.btnPlayerVsComputer.Location = new System.Drawing.Point(273, 94);
            this.btnPlayerVsComputer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnPlayerVsComputer.Name = "btnPlayerVsComputer";
            this.btnPlayerVsComputer.Size = new System.Drawing.Size(136, 40);
            this.btnPlayerVsComputer.TabIndex = 2;
            this.btnPlayerVsComputer.Text = "Player VS Computer";
            this.btnPlayerVsComputer.UseVisualStyleBackColor = true;
            this.btnPlayerVsComputer.Click += new System.EventHandler(this.btnPlayerVsComputer_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(166, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "UMKC Themed";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GameSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 144);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnPlayerVsComputer);
            this.Controls.Add(this.btnPlayerVsPlayer);
            this.Controls.Add(this.label1);
            this.Name = "GameSelectionForm";
            this.Text = "GameSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button btnPlayerVsComputer;

        private System.Windows.Forms.Button btnPlayerVsPlayer;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}
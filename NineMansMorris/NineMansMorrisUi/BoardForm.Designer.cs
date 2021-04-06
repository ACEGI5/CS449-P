namespace NineMansMorrisUi
{
    partial class BoardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.btnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxWhitePlayerPiecesToPlace = new System.Windows.Forms.TextBox();
            this.textBoxWhitePlayerPiecesLeft = new System.Windows.Forms.TextBox();
            this.textBoxBlackPlayerPiecesToPlace = new System.Windows.Forms.TextBox();
            this.textBoxBlackPlayerPiecesLeft = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTurnIndicator = new System.Windows.Forms.Label();
            this.btnUnoccupiedKey = new System.Windows.Forms.Button();
            this.btnBlackKey = new System.Windows.Forms.Button();
            this.btnWhiteKey = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.btnBlackMilledKey = new System.Windows.Forms.Button();
            this.btnWhiteMilledKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(26, 560);
            this.btnReset.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(232, 55);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(1720, 29);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(232, 55);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExitClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BackgroundImage = global::NineMansMorrisUi.Properties.Resources.NineMansMorrisBoard;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(319, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 701);
            this.panel1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::NineMansMorrisUi.Properties.Resources.NineMansMorrisBoard;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = global::NineMansMorrisUi.Properties.Resources.NineMansMorrisBoard;
            this.pictureBox1.Location = new System.Drawing.Point(-67, -57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(860, 774);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label14.Location = new System.Drawing.Point(1179, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(208, 55);
            this.label14.TabIndex = 18;
            this.label14.Text = "White";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label15.Location = new System.Drawing.Point(1179, 520);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(208, 55);
            this.label15.TabIndex = 19;
            this.label15.Text = "Black";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxWhitePlayerPiecesToPlace
            // 
            this.textBoxWhitePlayerPiecesToPlace.Location = new System.Drawing.Point(1155, 341);
            this.textBoxWhitePlayerPiecesToPlace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxWhitePlayerPiecesToPlace.Name = "textBoxWhitePlayerPiecesToPlace";
            this.textBoxWhitePlayerPiecesToPlace.ReadOnly = true;
            this.textBoxWhitePlayerPiecesToPlace.Size = new System.Drawing.Size(81, 38);
            this.textBoxWhitePlayerPiecesToPlace.TabIndex = 20;
            // 
            // textBoxWhitePlayerPiecesLeft
            // 
            this.textBoxWhitePlayerPiecesLeft.Location = new System.Drawing.Point(1155, 413);
            this.textBoxWhitePlayerPiecesLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxWhitePlayerPiecesLeft.Name = "textBoxWhitePlayerPiecesLeft";
            this.textBoxWhitePlayerPiecesLeft.ReadOnly = true;
            this.textBoxWhitePlayerPiecesLeft.Size = new System.Drawing.Size(81, 38);
            this.textBoxWhitePlayerPiecesLeft.TabIndex = 21;
            // 
            // textBoxBlackPlayerPiecesToPlace
            // 
            this.textBoxBlackPlayerPiecesToPlace.Location = new System.Drawing.Point(1155, 577);
            this.textBoxBlackPlayerPiecesToPlace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBlackPlayerPiecesToPlace.Name = "textBoxBlackPlayerPiecesToPlace";
            this.textBoxBlackPlayerPiecesToPlace.ReadOnly = true;
            this.textBoxBlackPlayerPiecesToPlace.Size = new System.Drawing.Size(81, 38);
            this.textBoxBlackPlayerPiecesToPlace.TabIndex = 22;
            // 
            // textBoxBlackPlayerPiecesLeft
            // 
            this.textBoxBlackPlayerPiecesLeft.Location = new System.Drawing.Point(1155, 649);
            this.textBoxBlackPlayerPiecesLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBlackPlayerPiecesLeft.Name = "textBoxBlackPlayerPiecesLeft";
            this.textBoxBlackPlayerPiecesLeft.ReadOnly = true;
            this.textBoxBlackPlayerPiecesLeft.Size = new System.Drawing.Size(81, 38);
            this.textBoxBlackPlayerPiecesLeft.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label16.Location = new System.Drawing.Point(1248, 348);
            this.label16.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(320, 52);
            this.label16.TabIndex = 24;
            this.label16.Text = "Pieces To Place";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label17.Location = new System.Drawing.Point(1248, 584);
            this.label17.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(320, 52);
            this.label17.TabIndex = 25;
            this.label17.Text = "Pieces To Place";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label18.Location = new System.Drawing.Point(1248, 420);
            this.label18.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(320, 52);
            this.label18.TabIndex = 26;
            this.label18.Text = "Pieces Left";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label19.Location = new System.Drawing.Point(1248, 656);
            this.label19.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(320, 52);
            this.label19.TabIndex = 27;
            this.label19.Text = "Pieces Left";
            // 
            // lblTurnIndicator
            // 
            this.lblTurnIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblTurnIndicator.Location = new System.Drawing.Point(1149, 207);
            this.lblTurnIndicator.Name = "lblTurnIndicator";
            this.lblTurnIndicator.Size = new System.Drawing.Size(248, 55);
            this.lblTurnIndicator.TabIndex = 28;
            this.lblTurnIndicator.Text = "Turn\r\n";
            this.lblTurnIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnoccupiedKey
            // 
            this.btnUnoccupiedKey.Enabled = false;
            this.btnUnoccupiedKey.Location = new System.Drawing.Point(197, 143);
            this.btnUnoccupiedKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnoccupiedKey.Name = "btnUnoccupiedKey";
            this.btnUnoccupiedKey.Size = new System.Drawing.Size(40, 36);
            this.btnUnoccupiedKey.TabIndex = 29;
            this.btnUnoccupiedKey.UseVisualStyleBackColor = true;
            // 
            // btnBlackKey
            // 
            this.btnBlackKey.Enabled = false;
            this.btnBlackKey.Location = new System.Drawing.Point(197, 215);
            this.btnBlackKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBlackKey.Name = "btnBlackKey";
            this.btnBlackKey.Size = new System.Drawing.Size(40, 38);
            this.btnBlackKey.TabIndex = 30;
            this.btnBlackKey.UseVisualStyleBackColor = true;
            // 
            // btnWhiteKey
            // 
            this.btnWhiteKey.Enabled = false;
            this.btnWhiteKey.Location = new System.Drawing.Point(197, 286);
            this.btnWhiteKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWhiteKey.Name = "btnWhiteKey";
            this.btnWhiteKey.Size = new System.Drawing.Size(40, 41);
            this.btnWhiteKey.TabIndex = 31;
            this.btnWhiteKey.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(11, 143);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(181, 29);
            this.label20.TabIndex = 32;
            this.label20.Text = "Unoccupied";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(11, 215);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(181, 29);
            this.label21.TabIndex = 33;
            this.label21.Text = "Black";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(11, 286);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(181, 29);
            this.label22.TabIndex = 34;
            this.label22.Text = "White";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(26, 644);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(232, 55);
            this.buttonExit.TabIndex = 35;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // btnBlackMilledKey
            // 
            this.btnBlackMilledKey.Enabled = false;
            this.btnBlackMilledKey.Location = new System.Drawing.Point(197, 359);
            this.btnBlackMilledKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBlackMilledKey.Name = "btnBlackMilledKey";
            this.btnBlackMilledKey.Size = new System.Drawing.Size(40, 41);
            this.btnBlackMilledKey.TabIndex = 36;
            this.btnBlackMilledKey.UseVisualStyleBackColor = true;
            // 
            // btnWhiteMilledKey
            // 
            this.btnWhiteMilledKey.Enabled = false;
            this.btnWhiteMilledKey.Location = new System.Drawing.Point(197, 431);
            this.btnWhiteMilledKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWhiteMilledKey.Name = "btnWhiteMilledKey";
            this.btnWhiteMilledKey.Size = new System.Drawing.Size(40, 41);
            this.btnWhiteMilledKey.TabIndex = 37;
            this.btnWhiteMilledKey.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Black Milled";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 29);
            this.label2.TabIndex = 39;
            this.label2.Text = "White Milled";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 1168);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWhiteMilledKey);
            this.Controls.Add(this.btnBlackMilledKey);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnWhiteKey);
            this.Controls.Add(this.btnBlackKey);
            this.Controls.Add(this.btnUnoccupiedKey);
            this.Controls.Add(this.lblTurnIndicator);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxBlackPlayerPiecesLeft);
            this.Controls.Add(this.textBoxBlackPlayerPiecesToPlace);
            this.Controls.Add(this.textBoxWhitePlayerPiecesLeft);
            this.Controls.Add(this.textBoxWhitePlayerPiecesToPlace);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "BoardForm";
            this.Text = "9 Mans Morris";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnBlackMilledKey;
        private System.Windows.Forms.Button btnWhiteMilledKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button buttonExit;


        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;

        private System.Windows.Forms.Button btnBlackKey;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnWhiteKey;
        private System.Windows.Forms.Label label20;

        private System.Windows.Forms.Button btnUnoccupiedKey;

        private System.Windows.Forms.Label lblTurnIndicator;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;

        private System.Windows.Forms.Label label16;

        private System.Windows.Forms.TextBox textBoxBlackPlayerPiecesLeft;
        private System.Windows.Forms.TextBox textBoxWhitePlayerPiecesLeft;
        private System.Windows.Forms.TextBox textBoxWhitePlayerPiecesToPlace;
        private System.Windows.Forms.TextBox textBoxBlackPlayerPiecesToPlace;

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button BtnExit;

        #endregion
    }
}
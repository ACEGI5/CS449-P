using System;
using System.Windows.Forms;

namespace NineMansMorrisUi
{
    public partial class BoardForm : Form
    {
        public BoardForm()
        {
            InitializeComponent();
        }


        private void BtnResetClick(object sender, EventArgs e)
        {
            var gameSelectionForm = new GameSelectionForm();
            //need reset method for pieces and player objects
            gameSelectionForm.Show();
            this.Hide();
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
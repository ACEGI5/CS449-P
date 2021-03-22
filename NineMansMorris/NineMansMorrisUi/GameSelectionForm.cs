using System;
using System.Windows.Forms;

namespace NineMansMorrisUi
{
    public partial class GameSelectionForm : Form
    {
        BoardForm boardForm = new BoardForm();

        public GameSelectionForm()
        {
            InitializeComponent();
        }

        private void btnPlayerVsComputer_Click(object sender, EventArgs e)
        {
            boardForm.Show();
            this.Hide();
        }

        private void btnPlayerVsPlayer_Click_1(object sender, EventArgs e)
        {
            boardForm.Show();
            this.Hide();
        }
    }
}
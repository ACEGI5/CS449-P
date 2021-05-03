using System;
using System.Windows.Forms;

namespace NineMansMorrisUi
{
    public partial class GameSelectionForm : Form
    {
        public GameSelectionForm()
        {
            InitializeComponent();
        }

        private void btnPlayerVsComputer_Click(object sender, EventArgs e)
        {
            BoardForm.ComputerOpponent = true;
            BoardForm boardForm = new BoardForm();
            boardForm.Show();
            Hide();
        }

        private void btnPlayerVsPlayer_Click_1(object sender, EventArgs e)
        {
            BoardForm.ComputerOpponent = true;
            BoardForm boardForm = new BoardForm();
            boardForm.Show();
            Hide();
        }
    }
}
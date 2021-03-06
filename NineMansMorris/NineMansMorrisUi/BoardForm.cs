using System;
using System.Drawing;
using System.Windows.Forms;
using NineMansMorrisLib;
using static NineMansMorrisLib.Board;

namespace NineMansMorrisUi
{
    public partial class BoardForm : Form
    {
        private NineMansMorrisLogic _nineMansMorrisGame = new NineMansMorrisLogic();
        private Button[,] _btnGrid = new Button[BoardSize,BoardSize];
        public BoardForm()
        {
            InitializeComponent();
            PopulateButtonGrid();
        }

        private void PopulateButtonGrid()
        {
            var buttonSize = 20;
            for (var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
                {
                    if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
                    {
                        _btnGrid[row, col] = new Button {Height = buttonSize, Width = buttonSize, Text = "U"};
                        _btnGrid[row, col].Click += Grid_Button_click;
                        panel1.Controls.Add(_btnGrid[row,col]);
                        _btnGrid[row, col].BringToFront();
                        _btnGrid[row,col].Location = new Point( (row*50) , (col*50));
                        _btnGrid[row, col].Tag = new Point(row, col);
                    }
                    else
                    {
                        _btnGrid[row, col] = null;
                    }

                    
                }
            }

        }

        private void Grid_Button_click(object sender, EventArgs e)
        {
            var clickedButton =(Button) sender;
            var location = (Point) clickedButton.Tag;
            var row = location.X;
            var col = location.Y;
            clickedButton.Text = "O";

        }

        public void PopulateGameBoard()
        {
            
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
            Application.Exit();
            
        }
    }
}
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
        private Button[,] _btnGrid = new Button[BoardSize, BoardSize];

        public BoardForm()
        {
            InitializeComponent();
            PopulateButtonGrid();
            SetUpForm();
        }

        private void SetUpForm()
        {
            lblTurnIndicator.Text = _nineMansMorrisGame.Turn == 0 ? "White's Turn" : "Black's Turn";
            textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
            textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
            textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
            textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
            btnUnoccupiedKey.BackColor = Color.LightGoldenrodYellow;
            btnWhiteKey.BackColor = Color.White;
            btnBlackKey.BackColor = Color.Black;
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
                        _btnGrid[row, col] = new Button
                            {Height = buttonSize, Width = buttonSize, BackColor = Color.LightGoldenrodYellow};
                        _btnGrid[row, col].Click += Grid_Button_click;
                        panel1.Controls.Add(_btnGrid[row, col]);
                        _btnGrid[row, col].BringToFront();
                        _btnGrid[row, col].Location = new Point((row * 50), (col * 50));
                        _btnGrid[row, col].Tag = new Point(row, col);
                    }
                    else
                    {
                        _btnGrid[row, col] = null;
                    }
                }
            }
        }

//default pass in or member variable
//anchor board
        private void Grid_Button_click(object sender, EventArgs e)
        {
            var clickedButton = (Button) sender;
            Point location = (Point) clickedButton.Tag;
            int row = location.X;
            int col = location.Y;
            if (_nineMansMorrisGame.Turn == 0 && _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced == false &&
                _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {
                clickedButton.BackColor = Color.White;
                _nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.WhitePlayer, row, col);
                textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
                lblTurnIndicator.Text = "Black's Turn";
            }
            else if (_nineMansMorrisGame.Turn == 1 && _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced == false&&
                     _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {
                clickedButton.BackColor = Color.Black;
                _nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col);
                textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
                lblTurnIndicator.Text = "Whites's Turn";
            }

            if (_nineMansMorrisGame.Turn == 1 && _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced == true)
            {
                //  _nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.BlackPlayer);
            }
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
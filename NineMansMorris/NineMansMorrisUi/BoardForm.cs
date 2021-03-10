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
        private Button _selectButton = null;
        private string _turnIndicatorWhite = "White's turn";
        private string _turnIndicatorBlack = "Black's turn";
        private Color _unoccupiedColor= Color.Red;
        private Color _whiteColor= Color.GhostWhite;
        private Color _blackColor= Color.Black;
        public BoardForm()
        {
            InitializeComponent();
            PopulateButtonGrid();
            SetUpForm();
        }

        private void SetUpForm()
        {
            lblTurnIndicator.Text = _nineMansMorrisGame.Turn == 0 ? _turnIndicatorWhite : _turnIndicatorBlack;
            textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
            textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
            textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
            textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
            btnUnoccupiedKey.BackColor = _unoccupiedColor;
            btnWhiteKey.BackColor = _whiteColor;
            btnBlackKey.BackColor = _blackColor;
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
                            {Height = buttonSize, Width = buttonSize, BackColor = _unoccupiedColor};
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
            PiecePlacement(row, col, clickedButton);
            PieceMovement(row, col, clickedButton);
            _selectButton = clickedButton;
        }

        private void PieceMovement(int row, int col, Button clickedButton)
        {
            var allPiecesPlaced = _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced &&
                                  _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced;
            if (allPiecesPlaced)
            {
                Point oldLocation = (Point) _selectButton.Tag;
                int oldRow = oldLocation.X;
                int oldCol = oldLocation.Y;
                var oldPieceState = _nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState;


                bool correctTurn = (lblTurnIndicator.Text == _turnIndicatorWhite && _nineMansMorrisGame.Turn == 0 &&
                                    oldPieceState == PieceState.White) ||
                                   (lblTurnIndicator.Text == _turnIndicatorBlack && _nineMansMorrisGame.Turn == 1 &&
                                    oldPieceState == PieceState.Black);

                if ( _selectButton != clickedButton && _selectButton != null &&
                    _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open && correctTurn)
                {
                    switch (_nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState)
                    {
                        case PieceState.White:
                            _nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.WhitePlayer, row, col, oldRow, oldCol);
                            _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                            _btnGrid[row, col].BackColor = _whiteColor;
                            lblTurnIndicator.Text = _turnIndicatorBlack;
                            _selectButton = null;
                            break;
                        case PieceState.Black:
                            _nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.BlackPlayer, row, col, oldRow, oldCol);
                            _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                            _btnGrid[row, col].BackColor = _blackColor;
                            lblTurnIndicator.Text = _turnIndicatorWhite;
                            _selectButton = null;
                            break;
                        default:
                            _selectButton = clickedButton;
                            break;
                    }
                }
            }
        }

        private void PiecePlacement(int row, int col, Button clickedButton)
        {
            if (_nineMansMorrisGame.Turn == 0 && _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced == false &&
                _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {
                clickedButton.BackColor = _whiteColor;
                _nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.WhitePlayer, row, col);
                textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
                lblTurnIndicator.Text = _turnIndicatorBlack;
            }
            else if (_nineMansMorrisGame.Turn == 1 && _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced == false &&
                     _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {
                clickedButton.BackColor = _blackColor;
                _nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col);
                textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
                lblTurnIndicator.Text = _turnIndicatorWhite;
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
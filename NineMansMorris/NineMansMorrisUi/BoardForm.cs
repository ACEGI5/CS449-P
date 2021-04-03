using System;
using System.Drawing;
using System.Windows.Forms;
using NineMansMorrisLib;
using static NineMansMorrisLib.Board;

namespace NineMansMorrisUi
{
    public partial class BoardForm : Form
    {
        private readonly NineMansMorrisLogic _nineMansMorrisGame = new NineMansMorrisLogic();
        private readonly Button[,] _btnGrid = new Button[BoardSize, BoardSize];
        private Button _selectButton;
        private readonly string _turnIndicatorWhite = "White's Turn";
        private readonly string _turnIndicatorBlack = "Black's Turn";
        private readonly Color _unoccupiedColor = Color.Red;
        private readonly Color _whiteColor = Color.GhostWhite;
        private readonly Color _blackColor = Color.Black;

        private enum Turn
        {
            Black,
            White,
        }

        private Turn gameTurn;

        public BoardForm()
        {
            Random r = new Random();
            gameTurn = (Turn) r.Next(2);
            InitializeComponent();
            PopulateButtonGrid();
            SetUpForm();
        }

        private void SetUpForm()
        {
            lblTurnIndicator.Text = gameTurn == Turn.White ? _turnIndicatorWhite : _turnIndicatorBlack;
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
            const int buttonSize = 20;
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

        private void Grid_Button_click(object sender, EventArgs e)
        {
            var clickedButton = (Button) sender;
            var location = (Point) clickedButton.Tag;
            var row = location.X;
            var col = location.Y;
            PiecePlacement(row, col, clickedButton);
            PieceMovement(row, col, clickedButton);
            if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid &&
                _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState != PieceState.Open)
            {
             RemovePiece(row,col,clickedButton);   
            }
            _selectButton = clickedButton;
        }

        private void PieceMovement(int row, int col, Button clickedButton)
        {
            var allPiecesPlaced = _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced &&
                                  _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced;
            if (allPiecesPlaced)
            {
                var oldLocation = (Point) _selectButton.Tag;
                var oldRow = oldLocation.X;
                var oldCol = oldLocation.Y;
                var oldPieceState = _nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState;


                var correctTurn = (lblTurnIndicator.Text == _turnIndicatorWhite && gameTurn == Turn.White &&
                                   oldPieceState == PieceState.White) ||
                                  (lblTurnIndicator.Text == _turnIndicatorBlack && gameTurn == Turn.Black &&
                                   oldPieceState == PieceState.Black);

                if (_selectButton != clickedButton && _selectButton != null &&
                    _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open && correctTurn)
                {
                    switch (_nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState)
                    {
                        case PieceState.White:
                            if (_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.WhitePlayer, row, col, oldRow,
                                oldCol))
                            {
                                _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                                _btnGrid[row, col].BackColor = _whiteColor;
                                lblTurnIndicator.Text = _turnIndicatorBlack;
                                gameTurn = Turn.Black;
                                _selectButton = null;
                            }

                            break;
                        case PieceState.Black:
                            if (_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.BlackPlayer, row, col, oldRow,
                                oldCol))
                            {
                                _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                                _btnGrid[row, col].BackColor = _blackColor;
                                lblTurnIndicator.Text = _turnIndicatorWhite;
                                gameTurn = Turn.White;
                                _selectButton = null;
                            }

                            break;
                        case PieceState.Open:
                            break;
                        case PieceState.Invalid:
                            break;
                        default:
                            _selectButton = clickedButton;
                            break;
                    }
                }
            }
        }

        private void PiecePlacement(int row, int col, Control clickedButton)
        {
            if (gameTurn == Turn.White && _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced == false &&
                _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {
                if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.WhitePlayer, row, col))
                {
                    clickedButton.BackColor = _whiteColor;
                    textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
                    lblTurnIndicator.Text = _turnIndicatorBlack;
                    gameTurn = Turn.Black;
                }
            }

            else if (gameTurn == Turn.Black && _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced == false &&
                     _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {
                if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col))
                {
                    clickedButton.BackColor = _blackColor;
                    _nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col);
                    textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
                    lblTurnIndicator.Text = _turnIndicatorWhite;
                    gameTurn = Turn.White;
                }
            }
        }

        private void RemovePiece(int row, int col, Control clickedButton)
        {
            //if(_nineMansMorrisGame.RemovePiece())
            
            
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


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
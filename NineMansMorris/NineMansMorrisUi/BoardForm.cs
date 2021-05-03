using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using NineMansMorrisLib;
using static NineMansMorrisLib.Board;

namespace NineMansMorrisUi
{
    public partial class BoardForm : Form
    {
        //aa

        private AutoNineMansMorrisLogic _nineMansMorrisGame = new AutoNineMansMorrisLogic();
        private readonly Button[,] _btnGrid = new Button[BoardSize, BoardSize];
        private Button _selectButton;
        private readonly string _turnIndicatorWhite = "White's Turn";
        private readonly string _turnIndicatorBlack = "Black's Turn";
        private readonly Color _unoccupiedColor = Color.Purple;
        private readonly Color _whiteColor = Color.GhostWhite;
        private readonly Color _blackColor = Color.Black;
        private BoardFormHelper _boardFormHelper;
        public static bool ComputerOpponent = false;

        public BoardForm()
        {
            InitializeComponent();
            PopulateButtonGrid();
            InitComputerPlayer();
            SetUpForm();
        }

        private void InitComputerPlayer()
        {
            if (ComputerOpponent)
            {
                _boardFormHelper.autoPlacePiece();
                updateGameBoard();
            }
        }

//aaa
        private void updateGameBoard()
        {
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                    {
                        _btnGrid[row, col].BackColor = _blackColor;
                    }
                    else if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                    {
                        _btnGrid[row, col].BackColor = _whiteColor;
                    }
                    else if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
                    {
                        _btnGrid[row, col].BackColor = _unoccupiedColor;
                    }
                }
            }
        }

        private void SetUpForm()
        {
            if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.White)
            {
                lblTurnIndicator.Text = _turnIndicatorWhite;
            }
            else
            {
                lblTurnIndicator.Text = _turnIndicatorBlack;
            }

            textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
            textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesInPlay.ToString();
            textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
            textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesInPlay.ToString();
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
                    if (_nineMansMorrisGame.GameBoard.GameBoard[col, row].PieceState == PieceState.Open)
                    {
                        _btnGrid[col, row] = new Button
                            {Height = buttonSize, Width = buttonSize, BackColor = _unoccupiedColor};
                        _btnGrid[col, row].Click += Grid_Button_click;
                        panel1.Controls.Add(_btnGrid[col, row]);
                        _btnGrid[col, row].BringToFront();
                        _btnGrid[col, row].Location = new Point((row * 50), (col * 50));
                        _btnGrid[col, row].Tag = new Point(row, col);
                    }
                    else
                    {
                        _btnGrid[col, row] = null;
                    }


                    _boardFormHelper = new BoardFormHelper(_btnGrid, _nineMansMorrisGame);
                }
            }
        }

        private void Grid_Button_click(object sender, EventArgs e)
        {
            var clickedButton = (Button) sender;
            var location = (Point) clickedButton.Tag;
            var row = location.Y;
            var col = location.X;
            var allPiecesPlaced = _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced &&
                                  _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced;

            //MessageBox.Show("You have clicked row " + row + " & col " + col);

            if (_boardFormHelper._newMillFormed)
            {
                if (_boardFormHelper.RemovePiece(row, col))
                {
                    RemovePieceBoardUpdate(row, col, clickedButton);
                }
            }
            else
            {
                if (_boardFormHelper.PiecePlacement(row, col, clickedButton))
                {
                    PlacementBoardUpdate(row, col, clickedButton);
                }

                if (allPiecesPlaced && _selectButton != null)
                {
                    if (_boardFormHelper.PieceMovement(row, col, clickedButton, ref _selectButton))
                    {
                        BoardMovementUpdate(row, col, clickedButton);
                    }
                    else if (_boardFormHelper.FlyPiece(row, col, clickedButton, ref _selectButton))
                    {
                        BoardMovementUpdate(row, col, clickedButton);
                    }
                }
            }

            _selectButton = clickedButton;
            if (ComputerOpponent)
            {
                if (_boardFormHelper.PiecePlacement())
                {
                    PlacementBoardUpdate(row,col,clickedButton);
                }
            }
        }


        private void BoardMovementUpdate(int row, int col, Button clickedButton)
        {
            var oldLocation = (Point) _selectButton.Tag;
            var oldRow = oldLocation.Y;
            var oldCol = oldLocation.X;

            if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.White)
            {
                if (_boardFormHelper._newMillFormed)
                {
                    MessageBox.Show("Black Mill Formed");
                }
                else
                {
                    lblTurnIndicator.Text = _turnIndicatorWhite;
                }

                _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                _btnGrid[row, col].BackColor = _blackColor;
                EndGame();

                _selectButton = null;
            }
            else
            {
                if (_boardFormHelper._newMillFormed)
                {
                    MessageBox.Show("White Mill Formed");
                }
                else
                {
                    lblTurnIndicator.Text = _turnIndicatorBlack;
                }

                _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                _btnGrid[row, col].BackColor = _whiteColor;

                EndGame();
                _selectButton = null;
            }
        }


        private void PlacementBoardUpdate(int row, int col, Control clickedButton)
        {
            switch (_nineMansMorrisGame.gameTurn)
            {
                case NineMansMorrisLogic.Turn.Black:
                {
                    clickedButton.BackColor = _whiteColor;
                    textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
                    textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesInPlay.ToString();
                    if (_boardFormHelper._newMillFormed)
                    {
                        MessageBox.Show("White Mill Formed");
                        return;
                    }

                    lblTurnIndicator.Text = _turnIndicatorBlack;

                    break;
                }
                case NineMansMorrisLogic.Turn.White:
                {
                    if (!ComputerOpponent)
                    {
                        clickedButton.BackColor = _blackColor;
                    }
                    else
                    {
                        updateGameBoard();
                    }


                    if (_boardFormHelper._newMillFormed)
                    {
                        MessageBox.Show("Black Mill Formed");
                        return;
                    }
                    textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
                    textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesInPlay.ToString();
                    lblTurnIndicator.Text = _turnIndicatorWhite;
                    break;
                }
            }
        }

        private void RemovePieceBoardUpdate(int row, int col, Control clickedButton)
        {
            switch (_nineMansMorrisGame.gameTurn)
            {
                case NineMansMorrisLogic.Turn.Black:


                    _btnGrid[row, col].BackColor = _unoccupiedColor;
                    textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesInPlay.ToString();
                    if (!EndGame())
                    {
                        lblTurnIndicator.Text = _turnIndicatorBlack;
                    }


                    break;
                case NineMansMorrisLogic.Turn.White:

                    _btnGrid[row, col].BackColor = _unoccupiedColor;
                    textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesInPlay.ToString();
                    if (!EndGame())
                    {
                        lblTurnIndicator.Text = _turnIndicatorWhite;
                    }

                    break;
            }
        }

        private bool EndGame()
        {
            if (!_nineMansMorrisGame.GameOver) return false;
            for (var row = 0; row < 7; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid)
                        _btnGrid[row, col].Enabled = false;
                }
            }

            if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.Black)
            {
                MessageBox.Show("Black Player Wins");
            }
            else
            {
                MessageBox.Show("White Player Wins");
            }

            return true;
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            var gameSelectionForm = new GameSelectionForm();
            //need reset method for pieces and player objects
            gameSelectionForm.Show();
            Hide();
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
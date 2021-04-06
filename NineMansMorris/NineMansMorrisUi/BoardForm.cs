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
        private readonly Color _unoccupiedColor = Color.Purple;
        private readonly Color _whiteColor = Color.GhostWhite;
        private readonly Color _blackColor = Color.Black;
        private readonly Color _blackMilledColor = Color.DarkGray;
        private readonly Color _WhiteMilledColor = Color.LightCyan;
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
            textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesInPlay.ToString();
            textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
            textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesInPlay.ToString();
            btnUnoccupiedKey.BackColor = _unoccupiedColor;
            btnWhiteKey.BackColor = _whiteColor;
            btnBlackKey.BackColor = _blackColor;
            btnBlackMilledKey.BackColor = _blackMilledColor;
            btnWhiteMilledKey.BackColor = _WhiteMilledColor;
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
            var allPiecesPlaced = _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced &&
                                  _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced;
            PiecePlacement(row, col, clickedButton);
            if (allPiecesPlaced&&_selectButton!=null)
            {
                if (PieceMovement(row, col, clickedButton))
                {
                    
                }else FlyPiece(row, col, clickedButton);
            }

            _selectButton = clickedButton;
        }

        private bool FlyPiece(int row, int col, Button clickedButton)
        {
            var oldLocation = (Point) _selectButton.Tag;
            var oldRow = oldLocation.X;
            var oldCol = oldLocation.Y;
            if (_selectButton == clickedButton || _selectButton == null ||
                _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState != PieceState.Open) return false;
            if (_nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState != PieceState.White)
            {
                if (_nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState == PieceState.Black)
                {
                    if (!_nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.BlackPlayer, row, col, oldRow,
                        oldCol)) return false;
                    _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                    _btnGrid[row, col].BackColor = _blackColor;
                    lblTurnIndicator.Text = _turnIndicatorWhite;
                    gameTurn = Turn.White;
                    _selectButton = null;
                }
                else
                {
                    _selectButton = clickedButton;
                }
            }
            else
            {
                if (!_nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.WhitePlayer, row, col, oldRow,
                    oldCol)) return false;
                _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                _btnGrid[row, col].BackColor = _whiteColor;
                lblTurnIndicator.Text = _turnIndicatorBlack;
                gameTurn = Turn.Black;
                _selectButton = null;
            }
            return true;
        }

        private void UpdateMills()
        {
            for (var row = 0; row < 7; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    
                }
            }
            
            
        }

        private bool PieceMovement(int row, int col, Button clickedButton)
        {
            var oldLocation = (Point) _selectButton.Tag;
            var oldRow = oldLocation.X;
            var oldCol = oldLocation.Y;
            if (_selectButton == clickedButton || _selectButton == null ||
                _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState != PieceState.Open) return false;
            if (_nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState != PieceState.White)
            {
                if (_nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState == PieceState.Black)
                {
                    if (!_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.BlackPlayer, row, col, oldRow,
                        oldCol)) return false;
                    _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                    _btnGrid[row, col].BackColor = _blackColor;
                    lblTurnIndicator.Text = _turnIndicatorWhite;
                    gameTurn = Turn.White;
                    _selectButton = null;
                }
                else
                {
                    _selectButton = clickedButton;
                }
            }
            else
            {
                if (!_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.WhitePlayer, row, col, oldRow,
                    oldCol)) return false;
                _btnGrid[oldRow, oldCol].BackColor = _unoccupiedColor;
                _btnGrid[row, col].BackColor = _whiteColor;
                lblTurnIndicator.Text = _turnIndicatorBlack;
                gameTurn = Turn.Black;
                _selectButton = null;
            }

            return true;
        }

        private void PiecePlacement(int row, int col, Control clickedButton)
        {
            switch (gameTurn)
            {
                case Turn.White when _nineMansMorrisGame.WhitePlayer.AllPiecesPlaced == false &&
                                     _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open:
                {
                    if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.WhitePlayer, row, col))
                    {
                        clickedButton.BackColor = _whiteColor;
                        textBoxWhitePlayerPiecesToPlace.Text = _nineMansMorrisGame.WhitePlayer.PiecesToPlace.ToString();
                        textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesInPlay.ToString();
                        lblTurnIndicator.Text = _turnIndicatorBlack;
                        gameTurn = Turn.Black;
                    }

                    break;
                }
                case Turn.Black when _nineMansMorrisGame.BlackPlayer.AllPiecesPlaced == false &&
                                     _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open:
                {
                    if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col))
                    {
                        clickedButton.BackColor = _blackColor;
                        _nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col);
                        textBoxBlackPlayerPiecesToPlace.Text = _nineMansMorrisGame.BlackPlayer.PiecesToPlace.ToString();
                        textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesInPlay.ToString();
                        lblTurnIndicator.Text = _turnIndicatorWhite;
                        gameTurn = Turn.White;
                    }

                    break;
                }
            }
        }

        private void RemovePiece(int row, int col, Control clickedButton)
        {
            switch (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState)
            {
                case PieceState.White:
                    if (_nineMansMorrisGame.RemovePiece(_nineMansMorrisGame.BlackPlayer, row, col))
                    {
                        _btnGrid[row, col].BackColor = _unoccupiedColor;
                        lblTurnIndicator.Text = _turnIndicatorBlack;
                        textBoxBlackPlayerPiecesLeft.Text = _nineMansMorrisGame.BlackPlayer.PiecesInPlay.ToString();
                        gameTurn = Turn.Black;
                        _selectButton = null;
                    }

                    break;
                case PieceState.Black:
                    if (_nineMansMorrisGame.RemovePiece(_nineMansMorrisGame.WhitePlayer, row, col))
                    {
                        _btnGrid[row, col].BackColor = _unoccupiedColor;
                        lblTurnIndicator.Text = _turnIndicatorWhite;
                        textBoxWhitePlayerPiecesLeft.Text = _nineMansMorrisGame.WhitePlayer.PiecesInPlay.ToString();
                        gameTurn = Turn.White;
                        _selectButton = null;
                    }

                    break;
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


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
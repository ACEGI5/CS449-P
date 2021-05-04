using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using NineMansMorrisLib;
using static NineMansMorrisLib.Board;

namespace NineMansMorrisUi
{
    public class BoardFormHelper
    {
        private readonly Button[,] _btnGrid;
        private readonly AutoNineMansMorrisLogic _nineMansMorrisGame;
        public bool _newMillFormed { get; private set; }

        public BoardFormHelper(Button[,] btnGrid, AutoNineMansMorrisLogic nineMansMorrisGame)
        {
            _btnGrid = btnGrid;
            _nineMansMorrisGame = nineMansMorrisGame;
        }

        public bool autoPlacePiece()
        {
            if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer) &&
                _nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.White)
            {
                _newMillFormed = _nineMansMorrisGame.ComputerFormedNewMill;
                return true;
            }

            return false;
        }

        public bool autoMovePiece()
        {
            if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.Black && BoardForm.ComputerOpponent)
            {
                if (_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.BlackPlayer)
                )
                {
                    return true;
                }
            }


            return false;
        }

        public bool PiecePlacement(int row = -1, int col = -1, Control clickedButton = null)
        {
            switch (_nineMansMorrisGame.gameTurn)
            {
                case NineMansMorrisLogic.Turn.White when CanPlacePiece(row, col, _nineMansMorrisGame.WhitePlayer):
                {
                    if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.WhitePlayer, row, col))
                    {
                        CheckMillFormed(row, col, _nineMansMorrisGame.WhitePlayer);
                        return true;
                    }

                    break;
                }
                case NineMansMorrisLogic.Turn.Black when CanPlacePiece(row, col, _nineMansMorrisGame.BlackPlayer):
                {
                    if (BoardForm.ComputerOpponent)
                    {
                        var goodPlacement = autoPlacePiece();
                        if (_nineMansMorrisGame.ComputerFormedNewMill)
                            _newMillFormed = true;
                        return goodPlacement;
                    }

                    if (_nineMansMorrisGame.PlacePiece(_nineMansMorrisGame.BlackPlayer, row, col))
                    {
                        CheckMillFormed(row, col, _nineMansMorrisGame.BlackPlayer);
                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        private bool CanPlacePiece(int row, int col, Player player)
        {
            if (BoardForm.ComputerOpponent)
            {
                return player.AllPiecesPlaced == false;
            }

            return player.AllPiecesPlaced == false &&
                   _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState ==
                   PieceState.Open;
        }

        public bool FlyPiece(int row, int col, Button clickedButton, ref Button _selectButton)
        {
            var oldLocation = (Point) _selectButton.Tag;
            var oldRow = oldLocation.Y;
            var oldCol = oldLocation.X;
            if (!ValidPieceMovement(row, col, clickedButton, _selectButton)) return false;
            if (autoMovePiece()) return true;
            if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.Black &&
                _nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState == PieceState.Black)
            {
                if (!_nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.BlackPlayer, row, col, oldRow,
                    oldCol))
                {
                    return false;
                }

                if (!CheckMillFormed(row, col, _nineMansMorrisGame.BlackPlayer))
                {
                    _selectButton = null;
                }
            }
            else if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.White &&
                     _nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState == PieceState.White)
            {
                if (!_nineMansMorrisGame.FlyPiece(_nineMansMorrisGame.WhitePlayer, row, col, oldRow,
                    oldCol))
                {
                    return false;
                }

                if (!CheckMillFormed(row, col, _nineMansMorrisGame.WhitePlayer))
                {
                    _selectButton = null;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool PieceMovement(int row, int col, Button clickedButton, ref Button _selectButton)
        {
            var oldLocation = (Point) _selectButton.Tag;
            var oldRow = oldLocation.Y;
            var oldCol = oldLocation.X;
            if (autoMovePiece()) return true;
            if (!ValidPieceMovement(row, col, clickedButton, _selectButton)) return false;
            if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.Black &&
                _nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState == PieceState.Black)
            {
                if (!_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.BlackPlayer, row, col, oldRow,
                    oldCol))
                {
                    return false;
                }

                CheckMillFormed(row, col, _nineMansMorrisGame.BlackPlayer);
            }
            else if (_nineMansMorrisGame.gameTurn == NineMansMorrisLogic.Turn.White &&
                     _nineMansMorrisGame.GameBoard.GameBoard[oldRow, oldCol].PieceState == PieceState.White)
            {
                if (!_nineMansMorrisGame.MovePiece(_nineMansMorrisGame.WhitePlayer, row, col, oldRow,
                    oldCol))
                {
                    return false;
                }

                CheckMillFormed(row, col, _nineMansMorrisGame.WhitePlayer);
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool RemovePiece(int row, int col)
        {
            switch (_nineMansMorrisGame.gameTurn)
            {
                case NineMansMorrisLogic.Turn.Black:
                    if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                    {
                        if (_nineMansMorrisGame.RemovePiece(_nineMansMorrisGame.WhitePlayer, row, col))
                        {
                            _newMillFormed = false;
                            return true;
                        }
                    }

                    break;
                case NineMansMorrisLogic.Turn.White:
                    if (_nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                    {
                        if (_nineMansMorrisGame.RemovePiece(_nineMansMorrisGame.BlackPlayer, row, col))
                        {
                            _newMillFormed = false;
                            return true;
                        }
                    }

                    break;
            }

            return false;
        }

        private bool CheckMillFormed(int row, int col, Player player)
        {
            _newMillFormed = _nineMansMorrisGame.CheckMill(row, col, player);
            return _newMillFormed;
        }

        private bool ValidPieceMovement(int row, int col, Button clickedButton, Button _selectButton)
        {
            return _selectButton != clickedButton && _selectButton != null &&
                   _nineMansMorrisGame.GameBoard.GameBoard[row, col].PieceState == PieceState.Open;
        }
    }
}
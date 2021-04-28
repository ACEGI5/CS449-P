using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        public Board GameBoard { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }
        public bool GameOver { get; private set; }

        public enum Turn
        {
            Black,
            White,
        }

        public Turn gameTurn { get; private set; }

        private Dictionary<string, int[]> _directions = new Dictionary<string, int[]>
        {
            {"up", new[] {-1, 0}}, {"down", new[] {1, 0}},
            {"left", new[] {0, -1}}, {"right", new[] {0, 1}}
        };

        public NineMansMorrisLogic()
        {
            var r = new Random();
            GameBoard = new Board();
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            gameTurn = (Turn) r.Next(2);
            GameOver = false;
        }

        // pre : 
        public bool PlacePiece(Player player, int row, int col)
        {
            if (GameOver) return false;
            // if player has all pieces placed or where they are placing is not valid return false
            if (player.AllPiecesPlaced || GameBoard.GameBoard[row, col].PieceState != PieceState.Open) return false;
            // if white
            if (player == WhitePlayer)
            {
                // update
                WhitePlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.White;
                gameTurn = Turn.Black;
            }

            // if black
            else
            {
                // update
                BlackPlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.Black;
                gameTurn = Turn.White;
            }

            // events have taken place
            return true;

            // events have not taken place
        }
        // post : 

        // pre : 
        public bool MovePiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            if (GameOver) return false;
            // if invalid placement and not all pieces placed return
            if (!isValid(rowTo, colTo, rowFrom, colFrom) || !player.AllPiecesPlaced) return false;
            //if mill broken
            RemoveMill(rowFrom, colFrom, player);

            // if white
            if (player == WhitePlayer)
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.White;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
                gameTurn = Turn.Black;
            }

            // if black
            else
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.Black;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
                gameTurn = Turn.White;
            }

            // events have taken place
            return true;

            // events have not taken place
        }
        // post : 

        private bool isValid(int rowTo, int colTo, int rowFrom, int colFrom)
        {
            // traverse each direction
            foreach (var direction in _directions)
            {
                // while move is not possible
                var row = rowFrom;
                var col = colFrom;
                while (true)
                {
                    // update position
                    row += direction.Value[0];
                    col += direction.Value[1];

                    // if out of bounds
                    if ((row > 6 || col > 6) || (col <= -1) || (row <= -1))
                    {
                        break;
                    }

                    // if middle, do not cross
                    if (row == 3 && col == 3)
                    {
                        break;
                    }

                    // if black, white, open
                    if (GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid)
                    {
                        // if spot is open
                        if (GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
                        {
                            // if spot is where user wants to go
                            if (rowTo == row && colTo == col)
                            {
                                // spot is valid
                                return true;
                            }
                        }

                        // spot is invalid
                        break;
                    }
                }
            }

            // not a valid placement
            return false;
        }
        // post : 

        // pre : 
        public bool RemovePiece(Player player, int row, int col)
        {
            if (GameOver) return false;
            // if invalid return false
            if (GameBoard.GameBoard[row, col].PieceState == PieceState.Invalid) return false;
            // fix this opposite player check if pieces remaining equals pieces left
            Player oppositePlayer;
            if (player == BlackPlayer)
            {
                oppositePlayer = WhitePlayer;
            }
            else
            {
                oppositePlayer = BlackPlayer;
            }

            if (GameBoard.GameBoard[row, col].MillState != MillState.Milled ||
                oppositePlayer.PiecesInPlay == oppositePlayer.MilledPieces && oppositePlayer.AllPiecesPlaced)
            {
                RemoveMill(row, col, player);
                // if white and removing opponent piece
                if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                {
                    // update
                    BlackPlayer.RemovePiece();
                    GameOver = BlackPlayer.PlayerHasLost();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;
                    gameTurn = Turn.Black;
                    // events have taken place
                    return true;
                }

                // if black and removing opponent piece
                if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                {
                    // update
                    WhitePlayer.RemovePiece();
                    GameOver = WhitePlayer.PlayerHasLost();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;
                    gameTurn = Turn.White;
                    // events have taken place
                    return true;
                }
            }

            return false;
        }

        // pre : 
        public bool FlyPiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            if (GameOver) return false;
            // if player can't fly return
            if (!player.CanFly()) return false;
            // if invalid fly return false
            if (GameBoard.GameBoard[rowTo, colTo].PieceState != PieceState.Open ||
                GameBoard.GameBoard[rowTo, colTo].PieceState == PieceState.Invalid) return false;
            //if mill is broken
            RemoveMill(rowFrom, colFrom, player);
            //white player
            if (player == WhitePlayer)
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.White;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
                gameTurn = Turn.Black;
            }

            // if black
            else
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.Black;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
                gameTurn = Turn.White;
            }


            // events have taken place
            return true;
        }

        // post : 

        // pre :
        public Dictionary<string, List<GamePiece>> GetMills(int row, int col)
        {
            var currPieceState = GameBoard.GameBoard[row, col].PieceState;
            List<GamePiece> rowList = new List<GamePiece>();
            List<GamePiece> colList = new List<GamePiece>();
            var lists = new Dictionary<string, List<GamePiece>>()
            {
                {"row", rowList},
                {"col", colList}
            };
            PieceState validPieceState;
            //If PieceState is not Black or White, return false.
            switch (currPieceState)
            {
                case PieceState.Black:
                    validPieceState = PieceState.Black;
                    break;
                case PieceState.White:
                    validPieceState = PieceState.White;
                    break;
                default:
                    return lists;
            }

            if (row == 3 || col == 3)
            {
                for (var i = 0; i <= 6; i++)
                {
                    //If position MIDDLE (3,3) is hit, reset the matching list.
                    switch (i)
                    {
                        case 3 when row == 3 && col > 3:
                            lists["row"].Clear();
                            break;
                        case 3 when col == 3 && row > 3:
                            lists["col"].Clear();
                            break;
                    }

                    if (GameBoard.GameBoard[row, i].PieceState == validPieceState)
                    {
                        if (!(col < 3 && i > 3))
                            lists["row"].Add(GameBoard.GameBoard[row, i]);
                    }

                    if (GameBoard.GameBoard[i, col].PieceState == validPieceState)
                    {
                        if (!(row < 3 && i > 3))
                            lists["col"].Add(GameBoard.GameBoard[i, col]);
                    }
                }
            }
            else
            {
                //Search for Mills.
                for (var i = 0; i <= 6; i++)
                {
                    if (GameBoard.GameBoard[row, i].PieceState == validPieceState)
                    {
                        lists["row"].Add(GameBoard.GameBoard[row, i]);
                    }

                    if (GameBoard.GameBoard[i, col].PieceState == validPieceState)
                    {
                        lists["col"].Add(GameBoard.GameBoard[i, col]);
                    }
                }
            }

            return lists;
        }

        // post :

        // pre :
        public bool CheckMill(int row, int col, Player player)
        {
            var lists = GetMills(row, col);

            //Sets mills if any.
            if (lists["row"].Count == 3 || lists["col"].Count == 3)
            {
                if (lists["row"].Count == 3)
                {
                    foreach (GamePiece piece in lists["row"])
                    {
                        if (piece.MillState == MillState.NotMilled)
                            player.MillPiece();
                        piece.MillState = MillState.Milled;
                    }
                }

                if (lists["col"].Count == 3)
                {
                    foreach (GamePiece piece in lists["col"])
                    {
                        if (piece.MillState == MillState.NotMilled)
                            player.MillPiece();
                        piece.MillState = MillState.Milled;
                    }
                }

                return true;
            }

            //No mills found, return false.
            return false;
        }

        // post :

        // pre :
        public void RemoveMill(int row, int col, Player player)
        {
            var lists = GetMills(row, col);

            //Remove mills if any.
            if (lists["row"].Count == 3 || lists["col"].Count == 3)
            {
                if (lists["row"].Count == 3)
                {
                    foreach (GamePiece piece in lists["row"])
                    {
                        piece.MillState = MillState.NotMilled;
                        player.UnmillPiece();
                    }
                }

                if (lists["col"].Count == 3)
                {
                    foreach (GamePiece piece in lists["col"])
                    {
                        piece.MillState = MillState.NotMilled;
                        player.UnmillPiece();
                    }
                }
            }
        }


        public bool CheckIfMovementNotPossible(Player player)
        {
            foreach (List<int> a in player.coordinateList)
            {
                foreach (var direction in _directions)
                {
                    // while move is not possible
                    int row = a[0];
                    int col = a[1];
                    while (true)
                    {
                        // update position
                        row += direction.Value[0];
                        a[1] += direction.Value[1];

                        // if out of bounds
                        if ((row > 6 || col > 6) || (col <= -1) || (row <= -1))
                        {
                            break;
                        }

                        // if middle, do not cross
                        if (row == 3 && col == 3)
                        {
                            break;
                        }

                        // if black, white, open
                        if (GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid)
                        {
                            // if spot is open
                            if (GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
                            {
                                return false;
                            }

                            // spot is invalid
                            break;
                        }
                    }
                }
            }

            return true;
        }

        // post :
    }
}
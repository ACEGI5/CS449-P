using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NineMansMorrisLib
{
    public class AutoNineMansMorrisLogic : NineMansMorrisLogic
    {
        public bool ComputerFormedNewMill = false;

        private List<int> EvalPlacePiece(Player player)
        {
            var rand = new Random();
            var openPieces = LogicHelper.GetPieces(PieceState.Open, GameBoard);

            foreach (var piece in openPieces)
            {
                var row = piece[0];
                var col = piece[1];
                if (base.IsInMill(row, col, player))
                    return new List<int> {row, col};
            }

            return openPieces[rand.Next(openPieces.Count)];
        }

        public bool PlacePiece(Player player)
        {
            var piece = EvalPlacePiece(player);
            var successfulPlace = base.PlacePiece(player, piece[0], piece[1]);
            ComputerFormedNewMill = CheckMill(piece[0], piece[1], player);
            return successfulPlace;
        }

        // Returns list of to and from coordinates
        private Dictionary<string, List<int>> EvalMovePiece(Player player, PieceState pieceState)
        {
            var rand = new Random();
            // List of pieces on the board with same color
            var sameColorPieces = LogicHelper.GetPieces(pieceState, GameBoard);

            // List of open Adjacent pieces
            var possibleMoves = new List<Dictionary<string, List<int>>>();

            foreach (var piece in sameColorPieces)
            {
                var adjacentPieces = base.GetValidAdjacentCoordinates(piece[0], piece[1]);
                foreach (var adjacentPiece in adjacentPieces)
                {
                    var adjacentPieceState = GameBoard.GameBoard[adjacentPiece[0], adjacentPiece[1]].PieceState;
                    if (adjacentPieceState == PieceState.Open)
                    {
                        // List of movements 
                        var toFrom = new Dictionary<string, List<int>>()
                        {
                            {"to", adjacentPiece},
                            {"from", piece}
                        };
                        possibleMoves.Add(toFrom);
                        if (base.IsInMill(adjacentPiece[0], adjacentPiece[1], player))
                            return toFrom;
                    }
                }
            }

            return possibleMoves[rand.Next(possibleMoves.Count)];
        }

        public bool MovePiece(Player player)
        {
            Dictionary<string, List<int>> toFrom = EvalMovePiece(player, PieceState.Black);
            List<int> pieceTo = toFrom["to"];
            List<int> pieceFrom = toFrom["from"];
            return base.MovePiece(player, pieceTo[0], pieceTo[1], pieceFrom[0], pieceFrom[1]);
        }

        private List<int> EvalRemovePiece(Player player)
        {
            var rand = new Random();
            var opponentPieceState = player == BlackPlayer ? PieceState.White : PieceState.Black;
            var removablePieces = new List<List<int>>();
            var opponentPieces = LogicHelper.GetPieces(opponentPieceState, GameBoard);

            foreach (var piece in opponentPieces)
            {
                var row = piece[0];
                var col = piece[1];

                if (GameBoard.GameBoard[row, col].MillState == MillState.NotMilled)
                {
                    var pieceToRemove = new List<int> {row, col};
                    removablePieces.Add(pieceToRemove);
                }
            }

            return removablePieces[rand.Next(removablePieces.Count)];
        }

        public bool RemovePiece(Player player)
        {
            var coordinate = EvalRemovePiece(player);
            var row = coordinate[0];
            var col = coordinate[1];
            return base.RemovePiece(player, row, col);
        }
    }
}
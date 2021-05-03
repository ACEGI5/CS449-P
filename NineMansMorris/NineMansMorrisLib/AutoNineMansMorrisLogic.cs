using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NineMansMorrisLib
{
    public class AutoNineMansMorrisLogic : NineMansMorrisLogic
    {
        public bool computerFormedNewMill = false;
        public List<int> EvalPlacePiece(Player player){
            var openPieces = LogicHelper.GetPieces(PieceState.Open, GameBoard);
            var rand = new Random();

            foreach(var piece in openPieces) 
            {
                
                var row = piece[0];
                var col = piece[1];
                if (base.IsInMill(row, col, player))
                {
                    var goodPiece = new List<int> {row, col};
                    return goodPiece;
                }
            }
            return openPieces[rand.Next(openPieces.Count)];
        }

        public bool PlacePiece(Player player)
        {
            var piece = EvalPlacePiece(player);
            var successfulPlace = base.PlacePiece(player, piece[0], piece[1]);
           computerFormedNewMill= CheckMill(piece[0], piece[1], player);
           return successfulPlace;

        }

        // Returns list of to and from coordinates
        public Dictionary<string, List<int>> EvalMovePiece(Player player, PieceState pieceState)
        {
            var rand = new Random();
            // List of pieces on the board with same color
            List<List<int>> sameColorPieces = LogicHelper.GetPieces(pieceState, GameBoard);
            
            // List of open Adjacent pieces
            List<Dictionary<string, List<int>>> possibleMoves = new List<Dictionary<string, List<int>>>();

            foreach (List<int> piece in sameColorPieces)
            {
                List<List<int>> adjacentPieces = base.GetValidAdjacentCoordinates(piece[0], piece[1]);
                foreach (List<int> adjacentPiece in adjacentPieces)
                {
                    GamePiece adjacentPiecePlace = GameBoard.GameBoard[adjacentPiece[0], adjacentPiece[1]];
                    if (adjacentPiecePlace.PieceState == PieceState.Open)
                    {
                        // List of movements 
                        Dictionary<string, List<int>> toFrom = new Dictionary<string, List<int>>()
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

        public List<int> EvalRemovePiece(PieceState pieceState)
        {
            var rand = new Random();

            var piecesToRemove = new List<List<int>>();

            var opponentPieces = LogicHelper.GetPieces(pieceState, GameBoard);
            foreach (var piece in opponentPieces)
            {
                var row = piece[0];
                var col = piece[1];
                
                if (GameBoard.GameBoard[row, col].MillState == MillState.NotMilled)
                {
                    var pieceToRemove = new List<int>();

                    pieceToRemove.Add(row);
                    pieceToRemove.Add(col);
                    piecesToRemove.Add(pieceToRemove);
                    
                }
            }
            return piecesToRemove[rand.Next(piecesToRemove.Count)];
        }
        
        public bool RemovePiece(Player player)
        {
            var coordinate = EvalRemovePiece(PieceState.White);
            var row = coordinate[0];
            var col = coordinate[1];
            return base.RemovePiece(player, row, col);
        }
        public bool MovePiece(Player player)
        {
            var toFrom = EvalMovePiece(player, PieceState.Black);
            var pieceTo = toFrom["to"];
            var pieceFrom = toFrom["from"];
            return base.MovePiece(player, pieceTo[0], pieceTo[1], pieceFrom[0], pieceFrom[1]);
        }
        
    }
}
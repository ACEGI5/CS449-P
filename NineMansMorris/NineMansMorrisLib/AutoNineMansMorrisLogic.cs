﻿using System;
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

        private Dictionary<string, List<int>> EvalMovePiece(Player player)
        {
            var rand = new Random();
            var samePieceState = player == BlackPlayer ? PieceState.Black : PieceState.White;
            var sameColorPieces = LogicHelper.GetPieces(samePieceState, GameBoard);
            var possibleMoves = new List<Dictionary<string, List<int>>>();

            foreach (var piece in sameColorPieces)
            {
                var openAdjacentPieces = base.GetOpenAdjacentCoordinates(piece[0], piece[1]);
                foreach (var openAdjacentPiece in openAdjacentPieces)
                {
                    var toFrom = new Dictionary<string, List<int>>()
                    {
                        {"to", openAdjacentPiece},
                        {"from", piece}
                    };
                    possibleMoves.Add(toFrom);
                    if (base.IsInMill(openAdjacentPiece[0], openAdjacentPiece[1], player))
                        return toFrom;
                }
            }

            return possibleMoves[rand.Next(possibleMoves.Count)];
        }

        public bool MovePiece(Player player)
        {
            Dictionary<string, List<int>> toFrom = EvalMovePiece(player);
            List<int> pieceTo = toFrom["to"];
            List<int> pieceFrom = toFrom["from"];
            ComputerFormedNewMill = CheckMill(pieceTo[0], pieceTo[1], player);
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

            // Return peiece from removeablePiece if not empty
            // Other return piece from opponentPiece
            return removablePieces.Count > 0 ? removablePieces[rand.Next(removablePieces.Count)] : opponentPieces[rand.Next(opponentPieces.Count)];
        }

        public bool RemovePiece(Player player)
        {
            var coordinate = EvalRemovePiece(player);
            var row = coordinate[0];
            var col = coordinate[1];
            return base.RemovePiece(player, row, col);
        }

        private Dictionary<String, List<int>> EvalFlyPiece(Player player)
        {
            var rand = new Random();
            var openPieces = LogicHelper.GetPieces(PieceState.Open, GameBoard);
            var sameColorPieces = LogicHelper.GetPieces(PieceState.Black, GameBoard);
            var possibleFlys = new List<Dictionary<string, List<int>>>();

            foreach (var sameColorPiece in sameColorPieces)
            {
                foreach (var openPiece in openPieces)
                {
                    var row = openPiece[0];
                    var col = openPiece[1];
                    var toFrom = new Dictionary<string, List<int>>()
                    {
                        {"to", openPiece},
                        {"from", sameColorPiece}
                    };
                    possibleFlys.Add(toFrom);
                    if (base.IsInMill(row, col, player))
                        return toFrom;
                }
            }

            return possibleFlys[rand.Next(possibleFlys.Count)];
        }

        private bool FlyPiece(Player player)
        {
            var toFrom = EvalFlyPiece(player);
            var pieceTo = toFrom["to"];
            var pieceFrom = toFrom["from"];
            return base.FlyPiece(player, pieceTo[0], pieceTo[1], pieceFrom[0], pieceFrom[1]);
        }
    }
}
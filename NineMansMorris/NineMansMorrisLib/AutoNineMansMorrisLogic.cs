using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NineMansMorrisLib
{
    public class AutoNineMansMorrisLogic : NineMansMorrisLogic
    {
        List<int> evalPlacePiece(Player player){
            var openPieces = LogicHelper.GetPieces(PieceState.Open);
            var goodPieces = LogicHelper.GetPieces(PieceState.Open);

            for (var pieces = 0; pieces <= openPieces.Count; pieces++)
            {
                var row = openPieces[pieces][0];
                var col = openPieces[pieces][1];
                if(base.IsInMill(row, col, player)) {
                    var goodPiece = new List<int> {row, col};
                    goodPieces.Add(goodPiece);
                }
            }

            return goodPieces[0];
        }

        public override bool PlacePiece(Player player, int row, int col)
        {
            return base.PlacePiece(player, row, col);
        }

        public override bool MovePiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            return base.MovePiece(player, rowTo, colTo, rowFrom, colFrom);
        }

        public override bool FlyPiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            return base.FlyPiece(player, rowTo, colTo, rowFrom, colFrom);
        }

        public override bool RemovePiece(Player player, int row, int col)
        {
            return base.RemovePiece(player, row, col);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NineMansMorrisLib
{
    public class AutoNineMansMorrisLogic : NineMansMorrisLogic
    {
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
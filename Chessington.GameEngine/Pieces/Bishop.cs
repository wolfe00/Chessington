using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var dxdy = new List<Tuple<int, int>>(){Tuple.Create(-1, -1), Tuple.Create(-1, 1), Tuple.Create(1, -1), Tuple.Create(1, 1)};
            return RangedMoves(board, dxdy, currentSquare);
        }
    }
}
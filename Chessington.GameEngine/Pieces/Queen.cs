using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var drowdcol = new List<Tuple<int, int>>()
            {
                Tuple.Create(-1, -1), 
                Tuple.Create(-1, 1), 
                Tuple.Create(1, -1), 
                Tuple.Create(1, 1), 
                Tuple.Create(-1, 0), 
                Tuple.Create(1, 0), 
                Tuple.Create(0, -1), 
                Tuple.Create(0, 1)
            };
            return RangedMoves(board, drowdcol, currentSquare);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var drowdcol = new List<Tuple<int, int>>()
            {
                Tuple.Create(-2, -1), 
                Tuple.Create(-2, 1), 
                Tuple.Create(-1, -2), 
                Tuple.Create(-1, 2), 
                Tuple.Create(1, -2), 
                Tuple.Create(1, 2), 
                Tuple.Create(2, -1), 
                Tuple.Create(2, 1)
            };
            return StepMoves(board, drowdcol, currentSquare);
        }
    }
}
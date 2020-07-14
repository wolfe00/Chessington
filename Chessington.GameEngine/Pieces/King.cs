using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var dxdy = new List<Tuple<int, int>>(){Tuple.Create(-1, -1), Tuple.Create(-1, 1), Tuple.Create(1, -1), Tuple.Create(1, 1), Tuple.Create(-1, 0), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(0, 1)};
            var moves = new List<Square>();

            foreach (var dir in dxdy)
            {
                var dx = dir.Item1;
                var dy = dir.Item2;
                var x = currentSquare.Row + dx;
                var y = currentSquare.Col + dy;
                if (board.InBounds(Square.At(x,y)))
                {
                    moves.Add(Square.At(x, y));
                }
            }

            return moves;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private Player Player;

        public Pawn(Player player)
            : base(player)
        {
            Player = player;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var shift = (Player == Player.White) ? -1 : 1;
            var currentSquare = board.FindPiece(this);
            var ahead = Square.At(currentSquare.Row + shift, currentSquare.Col);
            var twoAhead = Square.At(currentSquare.Row + 2 * shift, currentSquare.Col);
            var moves = new List<Square>();
            
            if (!board.HasPiece(ahead))
            {
                moves.Add(ahead);
                if (!HasMoved && !board.HasPiece(twoAhead))
                {
                    moves.Add(twoAhead);
                }
            }
            
            var takedrowdcol = new List<Tuple<int, int>>()
            {
                Tuple.Create(shift, -1), 
                Tuple.Create(shift, 1),
            };

            foreach (var direction in takedrowdcol)
            {
                var drow = direction.Item1;
                var dcol = direction.Item2;
                var row = currentSquare.Row + drow;
                var col = currentSquare.Col + dcol;
                if (board.HasEnemy(Square.At(row, col), this.Player))
                {
                    moves.Add(Square.At(row, col));
                }
            }
            
            return moves.Where(board.InBounds);
        }
    }
}
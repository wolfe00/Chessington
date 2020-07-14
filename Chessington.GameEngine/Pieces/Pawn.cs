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
            moves.Add(ahead);
            if (!HasMoved)
            {
                moves.Add(twoAhead);
            }
            return moves;
        }
    }
}
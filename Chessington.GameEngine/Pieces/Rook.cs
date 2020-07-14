using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var moves = new List<Square>();
            for (var x = 0; x < GameSettings.BoardSize; x++)
            {
                if (currentSquare.Row != x)
                {
                    moves.Add(Square.At(currentSquare.Row, x));
                }
                if (x != currentSquare.Col)
                {
                    moves.Add(Square.At(x, currentSquare.Col));
                }
            }

            return moves;
        }
    }
}
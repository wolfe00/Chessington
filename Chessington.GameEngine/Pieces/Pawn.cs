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
            return new List<Square>() {Square.At(Row + shift, Col)};
        }
    }
}
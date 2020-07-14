using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }
        public bool HasMoved { get; set; } = false;
        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasMoved = true;
        }

        // For a given piece which can travel multiple squares in the same direction in one move, this function checks whether
        // the piece can reach square (x,y) in a single move given that it can reach square (x - dx, y - dy)
        // from its current position in one move. It requires that the piece can normally move in the (dx, dy) direction
        protected bool CanGoOneStepFurther(int x, int y, int dx, int dy, Board board)
        {
            return board.InBounds(Square.At(x, y)) && !board.HasEnemy(Square.At(x - dx, y - dy), this.Player) &&
                !board.HasAlly(Square.At(x, y), this.Player);
        }
    }
}
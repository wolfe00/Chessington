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

        // Checks whether a piece can reach square (row, col) in a single move given that it can reach square
        // (row - drow, col - dcol)from its current position in at most one move.
        // It requires that the piece can move in the (dx, dy) direction if unimpeded
        protected bool CanGoOneStepFurther(int row, int col, int drow, int dcol, Board board)
        {
            return board.InBounds(Square.At(row, col)) && !board.HasEnemy(Square.At(row - drow, col - dcol), this.Player) &&
                !board.HasAlly(Square.At(row, col), this.Player);
        }
        protected List<Square> RangedMoves(Board board, List<Tuple<int, int>> drowdcol, Square currentSquare)
        {
            var moves = new List<Square>();

            foreach (var direction in drowdcol)
            {
                var drow = direction.Item1;
                var dcol = direction.Item2;
                var row = currentSquare.Row + drow;
                var col = currentSquare.Col + dcol;
                while ((CanGoOneStepFurther(row, col, drow, dcol, board)))
                {
                    moves.Add(Square.At(row, col));
                    row += drow;
                    col += dcol;
                }
            }

            return moves;
        }
        
        protected List<Square> StepMoves(Board board, List<Tuple<int, int>> drowdcol, Square currentSquare)
        {
            var moves = new List<Square>();

            foreach (var direction in drowdcol)
            {
                var drow = direction.Item1;
                var dcol = direction.Item2;
                var row = currentSquare.Row + drow;
                var col = currentSquare.Col + dcol;
                if ((CanGoOneStepFurther(row, col, drow, dcol, board)))
                {
                    moves.Add(Square.At(row, col));
                }
            }

            return moves;
        }
        
    }
}
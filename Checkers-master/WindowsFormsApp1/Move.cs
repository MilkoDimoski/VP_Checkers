using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Move
    {
        public int StartRow { get; set; }
        public int StartCol { get; set; }
        public int EndRow { get; set; }
        public int EndCol { get; set; }
        public int CaptureRow { get; set; } 
        public int CaptureCol { get; set; } 
        public int Score { get; set; }
        Form1 form;

        public Move(int startRow, int startCol, int endRow, int endCol, Form1 form)
        {
            StartRow = startRow;
            StartCol = startCol;
            EndRow = endRow;
            EndCol = endCol;
            CaptureRow = -1; // Default to -1 for non-capturing moves
            CaptureCol = -1; // Default to -1 for non-capturing moves
            Score = 0;
            
        }

        public Move(int startRow, int startCol, int endRow, int endCol, int captureRow, int captureCol, Form1 form)
        {
            StartRow = startRow;
            StartCol = startCol;
            EndRow = endRow;
            EndCol = endCol;
            CaptureRow = captureRow;
            CaptureCol = captureCol;
            this.form = form;
            Score = 0;
            
        }
        
        public Move Minimax(int[,] board, int currentPlayer, int depth, int alpha, int beta, Form1 formInstance)
        {
            if (depth == 0)
            {
                // Evaluate the current board state
                int score = formInstance.EvaluatePosition();
                return new Move(-1, -1, -1, -1, formInstance) { Score = score };
            }

            List<Move> legalMoves = formInstance.GenerateLegalMoves(currentPlayer);
            Move bestMove = null;

            if (currentPlayer == 1) // Maximizing player
            {
                int bestScore = int.MinValue;

                foreach (Move move in legalMoves)
                {
                    int[,] newBoard = formInstance.ApplyMove(board, move);
                    Move currentMove = Minimax(newBoard, 3 - currentPlayer, depth - 1, alpha, beta, formInstance);

                    int score = currentMove.Score;

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = move;
                    }

                    alpha = Math.Max(alpha, bestScore);

                    if (beta <= alpha)
                    {
                        break; 
                    }
                }
            }
            else // Minimizing player 
            {
                int bestScore = int.MaxValue;

                foreach (Move move in legalMoves)
                {
                    int[,] newBoard = formInstance.ApplyMove(board, move);
                    Move currentMove = Minimax(newBoard, 3 - currentPlayer, depth - 1, alpha, beta, formInstance);
                    int score = 0;
                    if(currentMove!=null)
                      score = currentMove.Score;

                    if (score < bestScore)
                    {
                        bestScore = score;
                        bestMove = move;
                    }

                    beta = Math.Min(beta, bestScore);

                    if (beta <= alpha)
                    {
                        break; 
                    }
                }
            }

            return bestMove;
        }

        
    }


}

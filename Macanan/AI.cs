using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Macanan
{
    class AI
    {
        //https://www.geeksforgeeks.org/minima  x-algorithm-in-game-theory-set-3-tic-tac-toe-ai-finding-optimal-move/
        public Point getBestMove(char[,] peta, int eaten)
        {
            Point bestMove = new Point();
            int bestVal = -1000;
            bestMove.X = -1;
            bestMove.Y = -1;

            // Traverse all cells, evalutae minimax function for
            // all empty cells. And return the cell with optimal
            // value.
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Check if celll is empty
                    if (peta[i, j] == 'E')
                    {
                        // Make the move
                        peta[i, j] = 'M';

                        // compute evaluation function for this
                        // move.
                        int moveVal = minimax(peta, 0, false);

                        // Undo the move
                        peta[i, j] = '_';

                        // If the value of the current move is
                        // more than the best value, then update
                        // best/
                        if (moveVal > bestVal)
                        {
                            bestMove.X = i;
                            bestMove.Y = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }

            System.Windows.Forms.MessageBox.Show(bestVal.ToString());
            return bestMove;
        }
        public int evaluate(char[,] peta)
        {
            //kiri,kanan,atas,bawah,kiriatas,kiribawah,kananatas,kananbawah
            string arah;
            int score = 0;
            int tempScore;

            Point posMacan = new Point();
            //CARI POSISI MACAN
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (peta[i,j] == 'M')
                    {
                        posMacan.X = j;
                        posMacan.Y = i;
                        break;
                    }
                }
            }

            //CARI SEMUA KEMUNGKINAN
            //KEKANAN
            tempScore = 1;
            for (int i = (int)posMacan.X; i < 5; i++)
            {
                int jumlahGerak = i - (int)posMacan.X;
                if (jumlahGerak % 2 == 1)
                {
                    if (peta[i, (int)posMacan.Y] == 'Y')
                    {
                        tempScore *= 10;
                    }
                }
            }
            //score = Math.Max(score, tempScore);

            return score;
        }

        public int minimax(char[,] peta, int depth, bool isMax, int eaten = 0)
        {
            int score = evaluate(peta);
 
            // If Maximizer has won the game return his/her
            // evaluated score
            if (eaten == 6)
                return score;
 
            // If Minimizer has won the game return his/her
            // evaluated score
            if (score == -6)
                return score;
 
            // If there are no more moves and no winner then
            // it is a tie
            //if (isMovesLeft(board)==false)
                //return 0;
 
            // If this maximizer's move
            if (isMax)
            {
                int best = -1000;
 
                // Traverse all cells
                for (int i = 0; i<5; i++)
                {
                    for (int j = 0; j<9; j++)
                    {
                        // Check if cell is empty
                        if (peta[i, j]=='E')
                        {
                            // Make the move
                            peta[i, j] = 'M';
 
                            // Call minimax recursively and choose
                            // the maximum value
                            best = Math.Max(best, minimax(peta, depth+1, !isMax));
 
                            // Undo the move
                            peta[i, j] = 'E';
                        }
        }
                }
                return best;
            }
 
            // If this minimizer's move
            else
            {
                int best = 1000;
 
                // Traverse all cells
                for (int i = 0; i<3; i++)
                {
                    for (int j = 0; j<3; j++)
                    {
                        // Check if cell is empty
                        if (peta[i, j]=='E')
                        {
                            // Make the move
                            peta[i, j] = 'Y';
 
                            // Call minimax recursively and choose
                            // the minimum value
                            best = Math.Min(best, minimax(peta, depth+1, !isMax));
 
                            // Undo the move
                            peta[i, j] = 'E';
                        }
                    }
                }
                return best;
            }
        }

    }
}

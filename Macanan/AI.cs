using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Macanan
{
    class AI
    {
        //https://www.geeksforgeeks.org/minimax-algorithm-in-game-theory-set-3-tic-tac-toe-ai-finding-optimal-move/
        public Point getBestMove(char[,] peta, int eaten)
        {
            Point bestMove = new Point();
            return bestMove;
        }
        public int evaluate(char[,] peta, int reward = 100)
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
            for (int i = (int)posMacan.X; i < 9; i++)
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

            return 0;
        }

        public int minimax(char[,] peta, int depth, bool isMax, int eaten)
        {
            int score = evaluate(peta);

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macanan
{
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            pos1 = rand.Next(1, 10);
            random();
            random2();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    peta[i, j] = "";
                }
            }
            peta[1, 3] = "1";
            peta[1, 4] = "2";
            peta[1, 5] = "3";
            peta[2, 3] = "4";
            peta[2, 4] = "5";
            peta[2, 5] = "6";
            peta[3, 3] = "7";
            peta[3, 4] = "8";
            peta[3, 5] = "9";
            x1y3.Image = Properties.Resources.a1;
            x2y3.Image = Properties.Resources.a2;
            x3y3.Image = Properties.Resources.a3;
            x1y4.Image = Properties.Resources.a4;
            x2y4.Image = Properties.Resources.a5;
            x3y4.Image = Properties.Resources.a6;
            x1y5.Image = Properties.Resources.a7;
            x2y5.Image = Properties.Resources.a8;
            x3y5.Image = Properties.Resources.a9;

            x2y2.Image = Properties.Resources.m1;
            peta[2, 2] = "M";

            for (int i = 1; i < 4; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (peta[i, j] == pos1.ToString() || peta[i, j] == pos2.ToString() || peta[i, j] == pos3.ToString())
                    {
                        peta[i, j] = "";
                        String nama = "x" + i + "y" + j;
                        Control[] controls = Controls.Find(nama, false);
                        if (controls.Length == 1) // 0 means not found, more - there are several controls with the same name
                        {
                            PictureBox control = controls[0] as PictureBox;
                            if (control != null)
                            {
                                if (peta[i, j] == "" && klik == 0)
                                {
                                    control.Image = Properties.Resources.yellow_circle;
                                }
                            } 
                        }
                    }
                    else
                    {
                        peta[i, j] = "Y";
                    }
                }
            }

            peta[0, 1] = "X";
            peta[0, 7] = "X";
            peta[1, 0] = "X";
            peta[1, 8] = "X";
            peta[3, 0] = "X";
            peta[3, 8] = "X";
            peta[4, 1] = "X";
            peta[4, 7] = "X";
            
            arahgerak[0, 0] = "1,1;2,0";
            arahgerak[2, 0] = "0,0;4,0;2,1";
            arahgerak[4, 0] = "2,0;3,1";
            arahgerak[1, 1] = "0,0;2,1;2,2";
            arahgerak[2, 1] = "2,0;1,1;3,1;2,2";
            arahgerak[3, 1] = "4,0;2,1;2,2";
            arahgerak[0, 2] = "1,2;0,3;1,3";
            arahgerak[1, 2] = "0,2;2,2;1,3";
            arahgerak[2, 2] = "1,1;1,2;1,3;2,1;2,3;3,1;3,3;3,2";
            arahgerak[3, 2] = "2,2;4,2;3,3";
            arahgerak[4, 2] = "3,2;3,3;4,3";
            arahgerak[0, 3] = "0,2;0,4;1,3";
            arahgerak[1, 3] = "0,2;0,3;0,4;1,2;1,4;2,2;2,3;2,4";
            arahgerak[2, 3] = "1,3;3,3;2,2;2,4";
            arahgerak[3, 3] = "2,2;2,3;2,4;3,2;3,4;4,2;4,3;4,4";
            arahgerak[4, 3] = "4,2;4,4;3,3";
            arahgerak[0, 4] = "0,3;0,5;1,3;1,4;1,5";
            arahgerak[1, 4] = "0,4;2,4;1,3;1,5";
            arahgerak[2, 4] = "1,3;1,4;1,5;2,3;2,5;3,3;3,4;3,5";
            arahgerak[3, 4] = "2,4;4,4;3,3;3,5";
            arahgerak[4, 4] = "3,3;3,4;3,5;4,3;4,5";
            arahgerak[0, 5] = "0,4;0,6;1,5";
            arahgerak[1, 5] = "0,4;0,5;0,6;1,4;1,6;2,4;2,5;2,6";
            arahgerak[2, 5] = "1,5;3,5;2,4;2,6";
            arahgerak[3, 5] = "2,4;2,5;2,6;3,4;3,6;4,4;4,5;4,6";
            arahgerak[4, 5] = "3,5;4,4;4,6";
            arahgerak[0, 6] = "0,5;1,5;1,6";
            arahgerak[1, 6] = "0,6;2,6;1,5";
            arahgerak[2, 6] = "1,5;1,6;1,7;2,5;2,7;3,5;3,6;3,7";
            arahgerak[3, 6] = "2,6;4,6;3,5";
            arahgerak[4, 6] = "3,6;3,5;4,5";
            arahgerak[1, 7] = "2,6;0,8;2,7";
            arahgerak[2, 7] = "1,7;3,7;2,6;2,8";
            arahgerak[3, 7] = "2,7;2,6;4,8";
            arahgerak[0, 8] = "1,7;2,8";
            arahgerak[2, 8] = "2,7;0,8;4,8";
            arahgerak[4, 8] = "3,7;2,8";
        }

        private void Pertama_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Kedua_Clicked(object sender, EventArgs e)
        {
            if (peta[2, 0] == "" && klik == 0)
            {
                //pictureBox2.Image = Properties.Resources.a1;
                peta[2, 0] = "Y";
            }
            else if (peta[2, 0] == "" && klik == 1)
            {
                klik = 0;
                x2y0.Image = Properties.Resources.a1;
                peta[2, 0] = "Y";
                pindah();
            }
            else if (peta[2, 0] == "Y" && klik == 0)
            {
                klik = 1;
                //posAwal = 2;
            }
            else if (peta[2, 0] == "Y" && klik == 1)
            {

            }
        }

        private void Bidak_Clicked(object sender, EventArgs e)
        {
            string nama = ((PictureBox)sender).Name;
            //PROSES POTONG STRING DISINI
            String[] split = nama.Split('y');
            int x = Convert.ToInt32(split[0].Substring(1, split[0].Length-1));
            int y = Convert.ToInt32(split[1]);
            
            bidak(x, y);
        }
        


        #region Logic Game

        String[,] peta = new String[5, 9];
        String[,] arahgerak = new String[5, 9];
        int klik = 0;
        String posAwal = "";
        //baris 5 kolom 9

        Random rand = new Random();
        int pos1 = 0, pos2 = 0, pos3 = 0;
        int jumAnak = 12;

        private void random()
        {
            pos2 = rand.Next(1, 10);
            if (pos2 == pos1)
            {
                random();
            }
        }

        private void random2()
        {
            pos3 = rand.Next(1, 10);
            if (pos1 == pos3 || pos2 == pos3)
            {
                random2();
            }
        }

        public void pindah()
        {
            if (posAwal == "x0y0")
            {
                peta[0, 0] = "";
                x0y0.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y0")
            {
                peta[2, 0] = "";
                x2y0.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y0")
            {
                peta[4, 0] = "";
                x4y0.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y1")
            {
                peta[1, 1] = "";
                x1y1.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y1")
            {
                peta[2, 1] = "";
                x2y1.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y1")
            {
                peta[3, 1] = "";
                x3y1.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x0y2")
            {
                peta[0, 2] = "";
                x0y2.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y2")
            {
                peta[1, 2] = "";
                x1y2.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y2")
            {
                peta[2, 2] = "";
                x2y2.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y2")
            {
                peta[3, 2] = "";
                x3y2.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y2")
            {
                peta[4, 2] = "";
                x4y2.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x0y3")
            {
                peta[0, 3] = "";
                x0y3.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y3")
            {
                peta[1, 3] = "";
                x1y3.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y3")
            {
                peta[2, 3] = "";
                x2y3.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y3")
            {
                peta[3, 3] = "";
                x3y3.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y3")
            {
                peta[4, 3] = "";
                x4y3.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x0y4")
            {
                peta[0, 4] = "";
                x0y4.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y4")
            {
                peta[1, 4] = "";
                x1y4.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y4")
            {
                peta[2, 4] = "";
                x2y4.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y4")
            {
                peta[3, 4] = "";
                x3y4.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y4")
            {
                peta[4, 4] = "";
                x4y4.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x0y5")
            {
                peta[0, 5] = "";
                x0y5.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y5")
            {
                peta[1, 5] = "";
                x1y5.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y5")
            {
                peta[2, 5] = "";
                x2y5.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y5")
            {
                peta[3, 5] = "";
                x3y5.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y5")
            {
                peta[4, 5] = "";
                x4y5.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x0y6")
            {
                peta[0, 6] = "";
                x0y6.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y6")
            {
                peta[1, 6] = "";
                x1y6.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y6")
            {
                peta[2, 6] = "";
                x2y6.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y6")
            {
                peta[3, 6] = "";
                x3y6.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y6")
            {
                peta[4, 6] = "";
                x4y6.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x1y7")
            {
                peta[1, 7] = "";
                x1y7.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y7")
            {
                peta[2, 7] = "";
                x2y7.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x3y7")
            {
                peta[3, 7] = "";
                x3y7.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x0y8")
            {
                peta[0, 8] = "";
                x0y8.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x2y8")
            {
                peta[2, 8] = "";
                x2y8.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == "x4y8")
            {
                peta[4, 8] = "";
                x4y8.Image = Properties.Resources.yellow_circle;
            }
        }

        private void bidak(int x, int y)
        {
            String nama = "x" + x + "y" + y;
            Control[] controls = Controls.Find(nama, false);
            if (controls.Length == 1) // 0 means not found, more - there are several controls with the same name
            {
                PictureBox control = controls[0] as PictureBox;
                if (control != null)
                {
                    if (jumAnak > 0)
                    {
                        if (peta[x, y] == "" && klik == 0)
                        {
                            control.Image = Properties.Resources.a1;
                            peta[x, y] = "Y";
                            jumAnak--;
                        }
                    }
                    else
                    {
                        if (peta[x, y] == "" && klik == 1)
                        {
                            control.Image = Properties.Resources.a1;
                            klik = 0;
                            peta[x, y] = "Y";
                            pindah();
                        }
                        else if (peta[x, y] == "Y" && klik == 0)
                        {
                            klik = 1;
                            posAwal = "x" + x + "y" + y;
                        }
                    }
                }
            }
        }

        #endregion
    }
}

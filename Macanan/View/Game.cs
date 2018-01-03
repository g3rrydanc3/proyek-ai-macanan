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

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
            init();
        }

        private void Bidak_Clicked(object sender, EventArgs e)
        {
            string nama = ((PictureBox)sender).Name;
            String[] split = nama.Split('y');
            int x = Convert.ToInt32(split[0].Substring(1, split[0].Length-1));
            int y = Convert.ToInt32(split[1]);

            bidak(x, y);
        }

        #region #########################################General Function#########################################
        private void changeImage(string namaPictureBox, Image img)
        {
            Control[] controls = Controls.Find(namaPictureBox, false);
            if (controls.Length == 1) // 0 means not found, more - there are several controls with the same name
            {
                PictureBox control = controls[0] as PictureBox;
                if (control != null)
                {
                    control.Image.Dispose();
                    control.Image = img;
                }
            }
        }

        #endregion


        #region #########################################Logic Game#########################################

        //TIP OF THE DAY = CTRL + M , CTRL + O

        //Y = anak
        //X = invalid
        //M = macan
        //E = kosong

        Char[,] peta = new Char[5, 9];
        String[,] arahgerak = new String[5, 9];
        Boolean pindah_Mode = false;
        Point pindah_PosisiAwal;
        Point cursor_Sekarang;
        AI ai;
        //baris 5 kolom 9

        Random rand = new Random();
        int pos1 = 0, pos2 = 0, pos3 = 0;
        int sisaAnak;

        private void init()
        {
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


            reset();
        }

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

        private void reset()
        {
            sisaAnak = 12;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    peta[i, j] = 'E';
                }
            }

            pos1 = rand.Next(1, 10);
            random();
            random2();

            peta[1, 3] = '1';
            peta[1, 4] = '2';
            peta[1, 5] = '3';
            peta[2, 3] = '4';
            peta[2, 4] = '5';
            peta[2, 5] = '6';
            peta[3, 3] = '7';
            peta[3, 4] = '8';
            peta[3, 5] = '9';

            for (int i = 1; i < 4; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (peta[i, j] == pos1.ToString().ToCharArray()[0] || peta[i, j] == pos2.ToString().ToCharArray()[0] || peta[i, j] == pos3.ToString().ToCharArray()[0])
                    {
                        peta[i, j] = 'E';
                    }
                    else
                    {
                        peta[i, j] = 'Y';
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (peta[i, j] != 'Y')
                    {
                        peta[i, j] = 'E';
                    }
                }
            }

            //MAP INVALID
            peta[0, 1] = 'X';
            peta[0, 7] = 'X';
            peta[1, 0] = 'X';
            peta[1, 8] = 'X';
            peta[3, 0] = 'X';
            peta[3, 8] = 'X';
            peta[4, 1] = 'X';
            peta[4, 7] = 'X';

            //POSISI START MACAN
            peta[2, 2] = 'M';



            refresh();
        }

        private void refresh()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    String nama = "x" + i + "y" + j;
                    if (peta[i, j] == 'M')
                    {
                        changeImage(nama, Properties.Resources.m1);
                    }
                    else if (peta[i, j] == 'Y')
                    {
                        changeImage(nama, Properties.Resources.a1);
                    }
                    else if (peta[i,j] != 'X')
                    {
                        changeImage(nama, Properties.Resources.yellow_circle);
                    }
                }
            }

            labelSisaAnak.Text = sisaAnak.ToString();
        }

        private bool moveValid()
        {
            int pindah = 0;
            if (pindah_Mode)
            {
                String[] split = arahgerak[pindah_PosisiAwal.X, pindah_PosisiAwal.Y].Split(';');
                for (int i = 0; i < split.Length; i++)
                {
                    String[] potong = split[i].Split(',');
                    if (cursor_Sekarang.X == Convert.ToInt32(potong[0]) && cursor_Sekarang.Y == Convert.ToInt32(potong[1]))
                    {
                        pindah = 1;
                    }
                }
            }
            if (pindah == 1 || (pindah == 0 && sisaAnak > 0))
            {
                return true;
            }else
            {
                return false;
            }
        }
               


        private void bidak(int x, int y)
        {
            cursor_Sekarang.X = x;
            cursor_Sekarang.Y = y;

            
                if (peta[x, y] == 'E')
                {
                    if (pindah_Mode)
                    {
                        if (moveValid())
                        {
                            pindah_Mode = false;

                            peta[x, y] = 'Y';

                            peta[pindah_PosisiAwal.X, pindah_PosisiAwal.Y] = 'E';
                            pindah_PosisiAwal.X = 0;
                            pindah_PosisiAwal.Y = 0;
                        }
                        else
                        {
                            MessageBox.Show("Invalid move.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (sisaAnak > 0)
                        {
                            if (peta[x, y] == 'E')
                            {
                                peta[x, y] = 'Y';
                                sisaAnak--;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Anak sudah habis.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (peta[x, y] == 'Y' && sisaAnak <= 0)
                {
                    pindah_Mode = true;

                    pindah_PosisiAwal.X = x;
                    pindah_PosisiAwal.Y = y;
                }
                refresh();
            
        }
        #endregion
    }
}

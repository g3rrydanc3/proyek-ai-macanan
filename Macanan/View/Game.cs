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
            pictureBox13.Image = Properties.Resources.a1;
            pictureBox14.Image = Properties.Resources.a2;
            pictureBox15.Image = Properties.Resources.a3;
            pictureBox18.Image = Properties.Resources.a4;
            pictureBox19.Image = Properties.Resources.a5;
            pictureBox20.Image = Properties.Resources.a6;
            pictureBox23.Image = Properties.Resources.a7;
            pictureBox24.Image = Properties.Resources.a8;
            pictureBox25.Image = Properties.Resources.a9;

            for (int i = 1; i < 4; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (peta[i, j] == pos1.ToString() || peta[i, j] == pos2.ToString() || peta[i, j] == pos3.ToString())
                    {
                        peta[i, j] = "";
                        //kosong
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
                pictureBox2.Image = Properties.Resources.a1;
                peta[2, 0] = "Y";
                pindah();
            }
            else if (peta[2, 0] == "Y" && klik == 0)
            {
                klik = 1;
                posAwal = 2;
            }
            else if (peta[2, 0] == "Y" && klik == 1)
            {

            }
        }

        private void Bidak_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show(((PictureBox)sender).Name);
            bidak();
        }





        #region Logic Game

        String[,] peta = new String[5, 9];
        int klik = 0;
        int posAwal = -1;
        String path = "";
        //baris 5 kolom 9

        Random rand = new Random();
        int pos1 = 0, pos2 = 0, pos3 = 0;
        int jumAnak = 21;

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
            if (posAwal == 1)
            {
                peta[0, 0] = "";
                pictureBox1.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 2)
            {
                peta[2, 0] = "";
                pictureBox2.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 3)
            {
                peta[4, 0] = "";
                pictureBox3.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 4)
            {
                peta[1, 1] = "";
                pictureBox4.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 5)
            {
                peta[2, 1] = "";
                pictureBox5.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 6)
            {
                peta[3, 1] = "";
                pictureBox6.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 7)
            {
                peta[0, 2] = "";
                pictureBox7.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 8)
            {
                peta[1, 2] = "";
                pictureBox8.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 9)
            {
                peta[2, 2] = "";
                pictureBox9.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 10)
            {
                peta[3, 2] = "";
                pictureBox10.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 11)
            {
                peta[4, 2] = "";
                pictureBox11.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 12)
            {
                peta[0, 3] = "";
                pictureBox12.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 13)
            {
                peta[1, 3] = "";
                pictureBox13.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 14)
            {
                peta[2, 3] = "";
                pictureBox14.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 15)
            {
                peta[3, 3] = "";
                pictureBox15.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 16)
            {
                peta[4, 3] = "";
                pictureBox16.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 17)
            {
                peta[0, 4] = "";
                pictureBox17.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 18)
            {
                peta[1, 4] = "";
                pictureBox18.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 19)
            {
                peta[2, 4] = "";
                pictureBox19.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 20)
            {
                peta[3, 4] = "";
                pictureBox20.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 21)
            {
                peta[4, 4] = "";
                pictureBox21.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 22)
            {
                peta[0, 5] = "";
                pictureBox22.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 23)
            {
                peta[1, 5] = "";
                pictureBox23.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 24)
            {
                peta[2, 5] = "";
                pictureBox24.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 25)
            {
                peta[3, 5] = "";
                pictureBox25.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 26)
            {
                peta[4, 5] = "";
                pictureBox26.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 27)
            {
                peta[0, 6] = "";
                pictureBox27.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 28)
            {
                peta[1, 6] = "";
                pictureBox28.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 29)
            {
                peta[2, 6] = "";
                pictureBox29.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 30)
            {
                peta[3, 6] = "";
                pictureBox30.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 31)
            {
                peta[4, 6] = "";
                pictureBox31.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 32)
            {
                peta[1, 7] = "";
                pictureBox32.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 33)
            {
                peta[2, 7] = "";
                pictureBox33.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 34)
            {
                peta[3, 7] = "";
                pictureBox34.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 35)
            {
                peta[0, 8] = "";
                pictureBox35.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 36)
            {
                peta[2, 8] = "";
                pictureBox36.Image = Properties.Resources.yellow_circle;
            }
            else if (posAwal == 37)
            {
                peta[4, 8] = "";
                pictureBox37.Image = Properties.Resources.yellow_circle;
            }
        }

        private void bidak()
        {
            //string imagePath = (string)pictureBox1.ImageLocation;
            //string path = Path.GetFileName(pictureBox1.ToString());
            string imagePath = (string)pictureBox1.ToString();
            //MessageBox.Show(imagePath);
            //String a = new FileInfo(pictureBox1.InitialImag).Directory.FullName();
            //String a = pictureBox1.
            if (peta[0, 0] == "" && klik == 0)
            {
                pictureBox1.Image = Properties.Resources.a1;
                peta[0, 0] = "Y";
            }
            else if (peta[0, 0] == "" && klik == 1)
            {
                klik = 0;
                pictureBox1.Image = Properties.Resources.a1;
                peta[0, 0] = "Y";
                pindah();
            }
            else if (peta[0, 0] == "Y" && klik == 0)
            {
                klik = 1;
                posAwal = 1;
            }
            else if (peta[0, 0] == "Y" && klik == 1)
            {

            }
        }

        #endregion
    }
}

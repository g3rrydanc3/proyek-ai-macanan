﻿using System;
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
        String[,] arahAnak = new String[5, 9];
        String[,] arahMacan = new String[5, 9];
        Boolean pindah_Mode = false;
        Point pindah_PosisiAwal;
        AI ai = new AI();
        //baris 5 kolom 9

        int giliran;
        int eaten;
        bool menang;

        //MODE 0 = P V AI
        //MODE 1 = P V P
        internal int mode;

        Random rand = new Random();
        int pos1 = 0, pos2 = 0, pos3 = 0;
        int sisaAnak;

        private void init()
        {
            arahAnak[0, 0] = "1,1;2,0";
            arahMacan[0, 0] = "kanan bawah;bawah";

            arahAnak[2, 0] = "0,0;4,0;2,1";
            arahMacan[2, 0] = "atas;bawah;kanan";

            arahAnak[4, 0] = "2,0;3,1";
            arahMacan[4, 0] = "atas;kanan atas";

            arahAnak[1, 1] = "0,0;2,1;2,2";
            arahMacan[1, 1] = "kiri atas;bawah;kanan bawah";

            arahAnak[2, 1] = "2,0;1,1;3,1;2,2";
            arahMacan[2, 1] = "kiri;atas;bawah;kanan";

            arahAnak[3, 1] = "4,0;2,1;2,2";
            arahMacan[3, 1] = "kiri bawah;atas;kanan atas";

            arahAnak[0, 2] = "1,2;0,3;1,3";
            arahMacan[0, 2] = "bawah;kanan;kanan bawah";

            arahAnak[1, 2] = "0,2;2,2;1,3";
            arahMacan[1, 2] = "atas;bawah;kanan";

            arahAnak[2, 2] = "1,1;1,2;1,3;2,1;2,3;3,1;3,3;3,2";
            arahMacan[2, 2] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;kanan bawah; bawah";

            arahAnak[3, 2] = "2,2;4,2;3,3";
            arahMacan[3, 2] = "atas;bawah;kanan";

            arahAnak[4, 2] = "3,2;3,3;4,3";
            arahMacan[4, 2] = "atas;kanan atas;kanan";

            arahAnak[0, 3] = "0,2;0,4;1,3";
            arahMacan[0, 3] = "kiri;kanan;bawah";

            arahAnak[1, 3] = "0,2;0,3;0,4;1,2;1,4;2,2;2,3;2,4";
            arahMacan[1, 3] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[2, 3] = "1,3;3,3;2,2;2,4";
            arahMacan[2, 3] = "atas;bawah;kiri;kanan";

            arahAnak[3, 3] = "2,2;2,3;2,4;3,2;3,4;4,2;4,3;4,4";
            arahMacan[3, 3] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[4, 3] = "4,2;4,4;3,3";
            arahMacan[4, 3] = "kiri;kanan;atas";

            arahAnak[0, 4] = "0,3;0,5;1,3;1,4;1,5";
            arahMacan[0, 4] = "kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[1, 4] = "0,4;2,4;1,3;1,5";
            arahMacan[1, 4] = "atas;bawah;kiri;kanan";

            arahAnak[2, 4] = "1,3;1,4;1,5;2,3;2,5;3,3;3,4;3,5";
            arahMacan[2, 4] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[3, 4] = "2,4;4,4;3,3;3,5";
            arahMacan[3, 4] = "atas;bawah;kiri;kanan";

            arahAnak[4, 4] = "3,3;3,4;3,5;4,3;4,5";
            arahMacan[4, 4] = "kiri atas;atas;kanan atas;kiri;kanan";

            arahAnak[0, 5] = "0,4;0,6;1,5";
            arahMacan[0, 5] = "kiri;kanan;bawah";

            arahAnak[1, 5] = "0,4;0,5;0,6;1,4;1,6;2,4;2,5;2,6";
            arahMacan[1, 5] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[2, 5] = "1,5;3,5;2,4;2,6";
            arahMacan[2, 5] = "atas;bawah;kiri;kanan";

            arahAnak[3, 5] = "2,4;2,5;2,6;3,4;3,6;4,4;4,5;4,6";
            arahMacan[3, 5] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[4, 5] = "3,5;4,4;4,6";
            arahMacan[4, 5] = "atas;kiri;kanan";

            arahAnak[0, 6] = "0,5;1,5;1,6";
            arahMacan[0, 6] = "kiri;kiri bawah;bawah";

            arahAnak[1, 6] = "0,6;2,6;1,5";
            arahMacan[1, 6] = "atas;bawah;kiri";

            arahAnak[2, 6] = "1,5;1,6;1,7;2,5;2,7;3,5;3,6;3,7";
            arahMacan[2, 6] = "kiri atas;atas;kanan atas;kiri;kanan;kiri bawah;bawah;kanan bawah";

            arahAnak[3, 6] = "2,6;4,6;3,5";
            arahMacan[3, 6] = "atas;bawah;kiri";

            arahAnak[4, 6] = "3,6;3,5;4,5";
            arahMacan[4, 6] = "atas;kiri atas;kiri";

            arahAnak[1, 7] = "2,6;0,8;2,7";
            arahMacan[1, 7] = "kiri bawah;kanan atas;bawah";

            arahAnak[2, 7] = "1,7;3,7;2,6;2,8";
            arahMacan[2, 7] = "atas;bawah;kiri;kanan";

            arahAnak[3, 7] = "2,7;2,6;4,8";
            arahMacan[3, 7] = "atas;kiri atas;kanan bawah";

            arahAnak[0, 8] = "1,7;2,8";
            arahMacan[0, 8] = "kiri bawah;bawah";

            arahAnak[2, 8] = "2,7;0,8;4,8";
            arahMacan[2, 8] = "kiri;atas;bawah";

            arahAnak[4, 8] = "3,7;2,8";
            arahMacan[4, 8] = "kiri atas;atas";


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
            menang = false;
            giliran = 0;
            eaten = 0;
            sisaAnak = 12;

            labelSisaAnak.Text = sisaAnak.ToString();
            labelAnakDImakan.Text = eaten.ToString();

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

        private void cekMenang()
        {
            if (eaten >= 6)
            {
                menang = true;
                MessageBox.Show("Menang");
            }
        }

        private bool moveValid(int x, int y)
        {
            int pindah = 0;
            if (pindah_Mode)
            {
                String[] split = arahAnak[pindah_PosisiAwal.X, pindah_PosisiAwal.Y].Split(';');
                for (int i = 0; i < split.Length; i++)
                {
                    String[] potong = split[i].Split(',');
                    if (x == Convert.ToInt32(potong[0]) && y == Convert.ToInt32(potong[1]))
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

        private void pindahMacanAI()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (peta[i, j] == 'M')
                    {
                        pindah_PosisiAwal.X = i;
                        pindah_PosisiAwal.Y = j;
                        break;
                    }
                }
            }
            String[] split = arahAnak[pindah_PosisiAwal.X, pindah_PosisiAwal.Y].Split(';');
            String[] splitArah = arahMacan[pindah_PosisiAwal.X, pindah_PosisiAwal.Y].Split(';');
            int[] anak = new int[split.Length];
            int ret = 0; //ret 1 => tidak ada yg dimakan
            int posX = 0, posY = 0, xx = 0, yy = 0;

            for (int i = 0; i < split.Length; i++)
            {
                String[] potong = split[i].Split(',');
                if (peta[Convert.ToInt32(potong[0]), Convert.ToInt32(potong[1])] == 'Y')
                {
                    posX = Convert.ToInt32(potong[0]);
                    posY = Convert.ToInt32(potong[1]);
                    if (splitArah[i] == "atas")
                    {
                        while (posX > -1 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posX--;
                        }
                        if (posX > -1)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (xx > -1 && peta[xx, yy] != 'E')
                                    {
                                        if (xx > -1)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        xx--;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }

                    }
                    else if (splitArah[i] == "kiri atas")
                    {
                        while (posY > -1 && posX > -1 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posX--;
                            posY--;
                        }
                        if (posX > -1 && posY > -1)
                        {
                            if (peta[posX + 1, posY + 1] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (yy > -1 && xx > -1 && peta[xx, yy] != 'E')
                                    {
                                        if (xx > -1 && yy > -1)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        xx--;
                                        yy--;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                    else if (splitArah[i] == "kanan atas")
                    {
                        while (posY < 9 && posX > -1 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posX--;
                            posY++;
                        }
                        if (posX > -1 && posY < 9)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (yy < 9 && xx > -1 && peta[xx, yy] != 'E')
                                    {
                                        if (xx > -1 && yy < 9)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        xx--;
                                        yy++;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                    else if (splitArah[i] == "kiri")
                    {
                        while (posY > -1 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posY--;
                        }
                        if (posY > -1)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (yy > -1 && peta[xx, yy] != 'E')
                                    {
                                        if (yy > -1)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        yy--;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                    else if (splitArah[i] == "kanan")
                    {
                        while (posY < 9 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posY++;
                        }
                        if (posY < 9)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (yy < 9 && peta[xx, yy] != 'E')
                                    {
                                        if (yy < 9)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        yy++;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                    else if (splitArah[i] == "bawah")
                    {
                        while (posX < 5 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posX++;
                        }
                        if (posX < 5)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (xx < 5 && peta[xx, yy] != 'E')
                                    {
                                        if (xx < 5)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        xx++;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                    else if (splitArah[i] == "kiri bawah")
                    {
                        while (posY > -1 && posX < 5 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posX++;
                            posY--;
                        }
                        if (posX < 5 && posY > -1)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (yy > -1 && xx < 5 && peta[xx, yy] != 'E')
                                    {
                                        if (xx < 5 && yy > -1)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        xx++;
                                        yy--;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                    else if (splitArah[i] == "kanan bawah")
                    {
                        while (posY < 9 && posX < 5 && peta[posX, posY] != 'E')
                        {
                            if (peta[posX, posY] != 'X')
                            {
                                anak[i] = anak[i] + 1;
                            }
                            posX++;
                            posY++;
                        }
                        if (posX < 5 && posY < 9)
                        {
                            if (peta[posX, posY] == 'E')
                            {
                                if (anak[i] % 2 == 1)
                                {
                                    eaten = eaten + anak[i];
                                    ret = 0;
                                    xx = Convert.ToInt32(potong[0]);
                                    yy = Convert.ToInt32(potong[1]);
                                    while (yy < 9 && xx < 5 && peta[xx, yy] != 'E')
                                    {
                                        if (xx < 5 && yy < 9)
                                        {
                                            peta[xx, yy] = 'E';
                                        }
                                        xx++;
                                        yy++;
                                    }
                                    peta[posX, posY] = 'M';
                                    break;
                                }
                                else
                                {
                                    ret = 1;
                                }
                            }
                            else
                            {
                                ret = 1;
                            }
                        }
                        else
                        {
                            ret = 1;
                        }
                    }
                }
                else
                {
                    anak[i] = 0;
                    ret = 1;
                }
            }

            if (ret == 1)
            {
                Random rand = new Random();
                int random = rand.Next(0, split.Length);
                String[] bagi = split[random].Split(',');
                while (peta[Convert.ToInt32(bagi[0]), Convert.ToInt32(bagi[1])] != 'E')
                {
                    random = rand.Next(0, split.Length);
                    bagi = split[random].Split(',');
                }
                peta[Convert.ToInt32(bagi[0]), Convert.ToInt32(bagi[1])] = 'M';
            }

            peta[pindah_PosisiAwal.X, pindah_PosisiAwal.Y] = 'E';
            pindah_PosisiAwal.X = 0;
            pindah_PosisiAwal.Y = 0;

            labelAnakDImakan.Text = eaten.ToString();
        }

        private bool pindahMacan(int x, int y)
        {
            if (peta[x, y] != 'M')
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (peta[i, j] == 'M')
                        {
                            pindah_PosisiAwal.X = i;
                            pindah_PosisiAwal.Y = j;
                            break;
                        }
                    }
                }


                if (pindah_PosisiAwal.Y == y)
                {
                    if (pindah_PosisiAwal.X <= x)
                    {
                        for (int i = pindah_PosisiAwal.X; i < x; i++)   //ATAS
                        {
                            if (peta[i, y] == 'Y')
                            {
                                eaten += 1;
                                peta[i, y] = 'E';
                            }
                        }
                    }
                    else
                    {
                        for (int i = x; i < pindah_PosisiAwal.X; i++)   //BAWAH
                        {
                            if (peta[i, y] == 'Y')
                            {
                                eaten += 1;
                                peta[i, y] = 'E';
                            }
                        }
                    }
                }

                if (pindah_PosisiAwal.X == x)
                {
                    if (pindah_PosisiAwal.Y <= y)
                    {
                        for (int i = pindah_PosisiAwal.Y; i < y; i++)   //KIRI
                        {
                            if (peta[x, i] == 'Y')
                            {
                                eaten += 1;
                                peta[x, i] = 'E';
                            }
                        }
                    }
                    else
                    {
                        for (int i = y; i < pindah_PosisiAwal.Y; i++)   //KANAN
                        {
                            if (peta[x, i] == 'Y')
                            {
                                eaten += 1;
                                peta[x, i] = 'E';
                            }
                        }
                    }
                }




                if (peta[x, y] != 'E')
                {
                    eaten += 1;
                }

                peta[x, y] = 'M';

                peta[pindah_PosisiAwal.X, pindah_PosisiAwal.Y] = 'E';
                pindah_PosisiAwal.X = 0;
                pindah_PosisiAwal.Y = 0;

                labelAnakDImakan.Text = eaten.ToString();
                return true;
            }
            return false;
        }

        private bool pindahAnak(int x, int y)
        {
            if (peta[x, y] == 'E')
            {
                if (pindah_Mode)
                {
                    if (moveValid(x ,y))
                    {
                        pindah_Mode = false;

                        peta[x, y] = 'Y';

                        peta[pindah_PosisiAwal.X, pindah_PosisiAwal.Y] = 'E';
                        pindah_PosisiAwal.X = 0;
                        pindah_PosisiAwal.Y = 0;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid move.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
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
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anak sudah habis.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            else if (peta[x, y] == 'Y' && sisaAnak <= 0)
            {
                pindah_Mode = true;

                pindah_PosisiAwal.X = x;
                pindah_PosisiAwal.Y = y;

                return false;
            }
            return false;
        }

        private void bidak(int x, int y)
        {
            if (menang)
            {
                return;
            }

            if (mode == 0) // P V AI
            {
                if (pindahAnak(x, y))
                {
                    pindahMacanAI();
                }
            }
            else if (mode == 1) // P V P
            {
                if (giliran == 0)
                {
                    if (pindahAnak(x, y))
                    {
                        giliran = 1;
                    }
                    
                }
                else
                {
                    if (pindahMacan(x ,y))
                    {
                        giliran = 0;
                    }
                }
            }

            refresh();
            cekMenang();
        }
        #endregion
    }
}

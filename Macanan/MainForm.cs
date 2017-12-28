using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macanan
{
    public partial class MainForm : Form
    {
        String[,] peta = new String[5, 9];
        int klik = 0;
        int posAwal = -1;
        String path = "";
        //baris 5 kolom 9

        Random rand = new Random();
        int pos1 = 0, pos2 = 0, pos3 = 0;
        int jumAnak = 21;
        public MainForm()
        {
            InitializeComponent();
            menu1.pictureBox1.Click += new EventHandler(PictureBox1_Clicked);
            menu1.pictureBox4.Click += new EventHandler(PictureBox4_Clicked);

            help1.pictureBox1.Click += new EventHandler(Back_Clicked);

            game1.pictureBox1.Click += new EventHandler(Pertama_Clicked);
            game1.pictureBox2.Click += new EventHandler(Kedua_Clicked);
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            pos1 = rand.Next(1, 10);
            random();
            random2();

            changeView("menu");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    peta[i,j] = "";
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
            game1.pictureBox13.Image = Image.FromFile("../Debug/assets/1.jpg");
            game1.pictureBox14.Image = Image.FromFile("../Debug/assets/2.jpg");
            game1.pictureBox15.Image = Image.FromFile("../Debug/assets/3.jpg");
            game1.pictureBox18.Image = Image.FromFile("../Debug/assets/4.jpg");
            game1.pictureBox19.Image = Image.FromFile("../Debug/assets/5.jpg");
            game1.pictureBox20.Image = Image.FromFile("../Debug/assets/6.jpg");
            game1.pictureBox23.Image = Image.FromFile("../Debug/assets/7.jpg");
            game1.pictureBox24.Image = Image.FromFile("../Debug/assets/8.jpg");
            game1.pictureBox25.Image = Image.FromFile("../Debug/assets/9.jpg");

            for (int i = 1; i < 4; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (peta[i,j] == pos1.ToString() || peta[i, j] == pos2.ToString() || peta[i, j] == pos3.ToString())
                    {
                        peta[i, j] = "";
                        //kosong
                    }else
                    {
                        peta[i, j] = "Y";
                    }
                }
            }

            peta[0,1] = "X";
            peta[0,7] = "X";
            peta[1,0] = "X";
            peta[1,8] = "X";
            peta[3,0] = "X";
            peta[3,8] = "X";
            peta[4,1] = "X";
            peta[4,7] = "X";
        }

        #region GENERAL FUNCTION

        private void changeView(string view)
        {
            menu1.Visible = false;
            help1.Visible = false;
            game1.Visible = false;
            if (view == "menu")
            {
                menu1.Visible = true;
            }
            else if (view == "game")
            {
                game1.Visible = true;
            }
            else if (view == "help")
            {
                help1.Visible = true;
            }
        }

        #endregion
        #region Event Handler Menu Form

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            changeView("game");
        }

        #endregion

        private void menu1_Load(object sender, EventArgs e)
        {
            
        }

        private void PictureBox1_Clicked(object sender, EventArgs e)
        {
            changeView("game");
        }

        private void PictureBox4_Clicked(object sender, EventArgs e)
        {
            changeView("help");
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            changeView("menu");
        }

        public void pindah()
        {
            if (posAwal == 1)
            {
                peta[0, 0] = "";
                game1.pictureBox1.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 2)
            {
                peta[2, 0] = "";
                game1.pictureBox2.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 3)
            {
                peta[4, 0] = "";
                game1.pictureBox3.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 4)
            {
                peta[1, 1] = "";
                game1.pictureBox4.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 5)
            {
                peta[2, 1] = "";
                game1.pictureBox5.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 6)
            {
                peta[3, 1] = "";
                game1.pictureBox6.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 7)
            {
                peta[0, 2] = "";
                game1.pictureBox7.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 8)
            {
                peta[1, 2] = "";
                game1.pictureBox8.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 9)
            {
                peta[2, 2] = "";
                game1.pictureBox9.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 10)
            {
                peta[3, 2] = "";
                game1.pictureBox10.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 11)
            {
                peta[4, 2] = "";
                game1.pictureBox11.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 12)
            {
                peta[0, 3] = "";
                game1.pictureBox12.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 13)
            {
                peta[1, 3] = "";
                game1.pictureBox13.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 14)
            {
                peta[2, 3] = "";
                game1.pictureBox14.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 15)
            {
                peta[3, 3] = "";
                game1.pictureBox15.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 16)
            {
                peta[4, 3] = "";
                game1.pictureBox16.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 17)
            {
                peta[0, 4] = "";
                game1.pictureBox17.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 18)
            {
                peta[1, 4] = "";
                game1.pictureBox18.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 19)
            {
                peta[2, 4] = "";
                game1.pictureBox19.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 20)
            {
                peta[3, 4] = "";
                game1.pictureBox20.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            }
            else if (posAwal == 21)
            {
                peta[4, 4] = "";
                game1.pictureBox21.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 22)
            {
                peta[0, 5] = "";
                game1.pictureBox22.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 23)
            {
                peta[1, 5] = "";
                game1.pictureBox23.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 24)
            {
                peta[2, 5] = "";
                game1.pictureBox24.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 25)
            {
                peta[3, 5] = "";
                game1.pictureBox25.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 26)
            {
                peta[4, 5] = "";
                game1.pictureBox26.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 27)
            {
                peta[0, 6] = "";
                game1.pictureBox27.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 28)
            {
                peta[1, 6] = "";
                game1.pictureBox28.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 29)
            {
                peta[2, 6] = "";
                game1.pictureBox29.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 30)
            {
                peta[3, 6] = "";
                game1.pictureBox30.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 31)
            {
                peta[4, 6] = "";
                game1.pictureBox31.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 32)
            {
                peta[1, 7] = "";
                game1.pictureBox32.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 33)
            {
                peta[2, 7] = "";
                game1.pictureBox33.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 34)
            {
                peta[3, 7] = "";
                game1.pictureBox34.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 35)
            {
                peta[0, 8] = "";
                game1.pictureBox35.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            } else if (posAwal == 36)
            {
                peta[2, 8] = "";
                game1.pictureBox36.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            }else if (posAwal == 37)
            {
                peta[4, 8] = "";
                game1.pictureBox37.Image = Image.FromFile("../Debug/assets/Yellow_icon.svg.png");
            }
        }

        private void Pertama_Clicked(object sender, EventArgs e)
        {
            //string imagePath = (string)game1.pictureBox1.ImageLocation;
            //string path = Path.GetFileName(game1.pictureBox1.ToString());
            string imagePath = (string)game1.pictureBox1.ToString();
            //MessageBox.Show(imagePath);
            //String a = new FileInfo(game1.pictureBox1.InitialImag).Directory.FullName();
            //String a = game1.pictureBox1.
            if (peta[0,0] == "" && klik == 0)
            {
                game1.pictureBox1.Image = Image.FromFile("../Debug/assets/1.jpg");
                peta[0, 0] = "Y";
            }else if (peta[0,0] == "" && klik == 1)
            {
                klik = 0;
                game1.pictureBox1.Image = Image.FromFile("../Debug/assets/1.jpg");
                peta[0, 0] = "Y";
                pindah();
            }
            else if (peta[0, 0] == "Y" && klik == 0)
            {
                klik = 1;
                posAwal = 1;
            }else if (peta[0, 0] == "Y" && klik == 1)
            {

            }
        }

        private void Kedua_Clicked(object sender, EventArgs e)
        {
            if (peta[2, 0] == "" && klik == 0)
            {
                //game1.pictureBox2.Image = Image.FromFile("../Debug/assets/1.jpg");
                peta[2, 0] = "Y";
            }
            else if (peta[2, 0] == "" && klik == 1)
            {
                klik = 0;
                game1.pictureBox2.Image = Image.FromFile("../Debug/assets/1.jpg");
                peta[2, 0] = "Y";
                pindah();
            }
            else if (peta[2, 0] == "Y" && klik == 0)
            {
                klik = 1;
                posAwal = 2;
            } else if (peta[2, 0] == "Y" && klik == 1)
            {
                
            }
        }
    }
}

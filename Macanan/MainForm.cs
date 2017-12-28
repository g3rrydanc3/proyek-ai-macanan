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
        
        public MainForm()
        {
            InitializeComponent();
            menu1.pictureBoxPlay.Click += new EventHandler(ButtonStart_Clicked);
            menu1.pictureBoxHelp.Click += new EventHandler(ButtonHelp_Clicked);

            help1.pictureBox1.Click += new EventHandler(BackToMenu_Clicked);
            game1.pictureBoxBack.Click += new EventHandler(BackToMenu_Clicked);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            changeView("menu");
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

        private void BackToMenu_Clicked(object sender, EventArgs e)
        {
            changeView("menu");
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            changeView("game");
        }

        private void ButtonHelp_Clicked(object sender, EventArgs e)
        {
            changeView("help");
        }

        #endregion

        
    }
}

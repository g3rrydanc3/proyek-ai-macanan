using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            menu1.buttonStart.Click += ButtonStart_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            changeView("menu");
        }

        #region GENERAL FUNCTION

        private void changeView(string view)
        {
            menu1.Visible = false;
            game1.Visible = false;
            if (view == "menu")
            {
                menu1.Visible = true;
            }
            else if (view == "game")
            {
                game1.Visible = true;
            }
        }

        #endregion
        #region Event Handler Menu Form

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            changeView("game");
        }

        #endregion
    }
}

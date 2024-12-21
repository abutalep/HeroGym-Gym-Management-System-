using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroGym_Gym_Management_System_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void shutDownButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            if (userName.Text == "Ahmed" && password.Text == "2004")
            {
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password !");
            }

        }
    }
}

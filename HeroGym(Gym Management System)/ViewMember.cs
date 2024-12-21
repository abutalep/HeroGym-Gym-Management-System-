using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroGym_Gym_Management_System_
{
    public partial class ViewMember : Form
    {
        public ViewMember()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
        //You need to build local data base table to handeling data of member 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\Backend.net\project\HeroGym(Gym Management System)\DataBase\GymDataBase.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string quary = "select * from MemberTb1";
            SqlDataAdapter sda = new SqlDataAdapter(quary,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            viewMemberGrid.DataSource=ds.Tables[0];
            Con.Close();
        }
        private void ViewMember_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void filterByName()
        {
            Con.Open();
            string query = "SELECT * FROM MemberTb1 WHERE Name LIKE @searchText";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            sda.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchBox.Text + "%");
            var ds = new DataSet();
            sda.Fill(ds);
            viewMemberGrid.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            filterByName();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            populate();
            searchBox.Text = "";
        }
    }
}

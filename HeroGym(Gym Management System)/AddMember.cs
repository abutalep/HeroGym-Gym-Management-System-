using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HeroGym_Gym_Management_System_
{
    public partial class AddMember : Form
    {
        public AddMember()
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
        private void addButton_Click(object sender, EventArgs e)
        {
            if (memberName.Text==""||phoneNumber.Text==""||age.Value==0||gender.Text==""||monthlyAmount.Text=="")
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try 
                {
                    Con.Open();
                    String query = "insert into MemberTb1 values('"+memberName.Text+"','"+phoneNumber.Text+"','"+age.Value.ToString()+"','"+gender.Text+"','"+monthlyAmount.Text+"','"+startMembership.Value.Date.ToString("yyyy-MM-dd")+ "','"+endMembership.Value.Date.ToString("yyyy-MM-dd") + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added .");
                    Con.Close();
                    memberName.Text = "";
                    phoneNumber.Text = "";
                    age.Value=0;
                    gender.SelectedItem=null;
                    monthlyAmount.Text = "";
                    startMembership.ResetText();
                    endMembership.ResetText();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            memberName.Text = "";
            phoneNumber.Text = "";
            age.Value=0;
            gender.SelectedItem = null;
            monthlyAmount.Text = "";
            startMembership.ResetText();
            endMembership.ResetText();
        }
    }
}

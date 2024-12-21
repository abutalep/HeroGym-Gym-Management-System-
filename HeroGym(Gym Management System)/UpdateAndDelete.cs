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
    public partial class UpdateAndDelete : Form
    {
        public UpdateAndDelete()
        {
            InitializeComponent();
        }

        //You need to build local data base table to handeling data of member 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\Backend.net\project\HeroGym(Gym Management System)\DataBase\GymDataBase.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string quary = "select * from MemberTb1";
            SqlDataAdapter sda = new SqlDataAdapter(quary, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            viewMemberGrid.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void UpdateAndDelete_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key =0;

        private void viewMemberGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = (Int32)viewMemberGrid.SelectedRows[0].Cells[0].Value;
            memberName.Text = viewMemberGrid.SelectedRows[0].Cells[1].Value.ToString();
            phoneNumber.Text = viewMemberGrid.SelectedRows[0].Cells[2].Value.ToString();
            age.Text = viewMemberGrid.SelectedRows[0].Cells[3].Value.ToString();
            gender.Text = viewMemberGrid.SelectedRows[0].Cells[4].Value.ToString();
            monthlyAmount.Text = viewMemberGrid.SelectedRows[0].Cells[5].Value.ToString();
            startMembership.Value = (System.DateTime)viewMemberGrid.SelectedRows[0].Cells[6].Value;
            endMembership.Value = (System.DateTime)viewMemberGrid.SelectedRows[0].Cells[7].Value;

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (memberName.Text == "" || phoneNumber.Text == "" || age.Value == 0 || gender.Text == "" || monthlyAmount.Text == "")
            {
                if (key == 0)
                {
                    MessageBox.Show("Select The Member To Be Updated !");
                }
                else
                {
                    MessageBox.Show("Missing Information !");
                }
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update MemberTb1 set Name='"+memberName.Text+ "',Phone='"+phoneNumber.Text+"',Age='"+age.Value.ToString()+"',Gender='"+gender.Text+"',MonthlyAmount='"+monthlyAmount.Text+"',StartMembership='"+startMembership.Value.Date.ToString("yyyy-MM-dd")+ "',Endmembership='"+endMembership.Value.Date.ToString("yyyy-MM-dd") + "'where Id="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    memberName.Text = "";
                    phoneNumber.Text = "";
                    age.Value = 0;
                    gender.SelectedItem = null;
                    monthlyAmount.Text = "";
                    startMembership.ResetText();
                    endMembership.ResetText();
                    key = 0;
                    MessageBox.Show("Member Updated Successfully .");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select The Member To Be Deleted !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MemberTb1 Where Id="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    memberName.Text = "";
                    phoneNumber.Text = "";
                    age.Value = 0;
                    gender.SelectedItem = null;
                    monthlyAmount.Text = "";
                    startMembership.ResetText();
                    endMembership.ResetText();
                    key = 0;
                    MessageBox.Show("Member Deleted Successfully .");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            memberName.Text = "";
            phoneNumber.Text = "";
            age.Value = 0;
            gender.SelectedItem = null;
            monthlyAmount.Text = "";
            startMembership.ResetText();
            endMembership.ResetText();
            key = 0;


        }

        private void backButton_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
    }
}

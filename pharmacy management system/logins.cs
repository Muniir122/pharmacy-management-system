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

namespace pharmacy_management_system
{
    public partial class logins : Form
    {
        public logins()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

  
        }
       
        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("select * from Login where UserName='" + txtusername.Text + "'and Password='" + txtpassword.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbitemvalue = comboBox1.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["UserType"].ToString() == cmbitemvalue)
                    {
                        MessageBox.Show("Your login as" + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            dashboard f = new dashboard();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            User ff = new User();
                            ff.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        //private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedIndex == 0)
        //    {
        //        txtusername.Text = String.Empty;
        //        txtusername.Text = "Admin";
        //    }
        //   else if(comboBox1.SelectedIndex==1)
        //    {
        //        txtusername.Text = String.Empty;
        //        txtusername.Text = "User";
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                txtusername.Text = String.Empty;
                txtusername.Text = "Admin";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                txtusername.Text = String.Empty;
                txtusername.Text = "User";
            }
        }

        private void logins_Load(object sender, EventArgs e)
        {

        }
    }
}
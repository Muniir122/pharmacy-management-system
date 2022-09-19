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
namespace pharmacy_management_system
{
    public partial class manufacturer : Form
    {
        public manufacturer()
        {
            InitializeComponent();
            showman();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
      private void showman()
        {
            con.Open();
            string query = "select * from manufacturertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            manufacturerdgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if(manaddresstb.Text==""|| mannametb.Text==""||manphonetb.Text=="")
            {
                MessageBox.Show("missing information");

            }else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into manufacturertbl(manname,manadd,manphone,manjdate) values(@mn,@ma,@mp,@mjd)", con);
                    cmd.Parameters.AddWithValue("@mn", mannametb.Text);
                    cmd.Parameters.AddWithValue("@ma", manaddresstb.Text);
                    cmd.Parameters.AddWithValue("@mp", manphonetb.Text);
                    cmd.Parameters.AddWithValue("@mjd", manjdate.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("manufacturer added");
                    con.Close();
                    showman();
                    reset();


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message); 
                }
            }

        }
        int key = 0;
        private void manufacturerdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mannametb.Text = manufacturerdgv.SelectedRows[0].Cells[1].Value.ToString();
            manaddresstb.Text = manufacturerdgv.SelectedRows[0].Cells[2].Value.ToString();
            manphonetb.Text = manufacturerdgv.SelectedRows[0].Cells[3].Value.ToString();
            manjdate.Text = manufacturerdgv.SelectedRows[0].Cells[4].Value.ToString();
            if(mannametb.Text=="")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(manufacturerdgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("select the manufacturer");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from manufacturertbl where manid=@mkey", con);
                    cmd.Parameters.AddWithValue("@mkey", key);
                  
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("manufacturer deleted");
                    con.Close();
                    showman();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void reset()
        {
            mannametb.Text = "";
            manaddresstb.Text = "";
            manphonetb.Text = "";
            key = 0;
        }
        private void editbtn_Click(object sender, EventArgs e)
        {
            if (manaddresstb.Text == "" || mannametb.Text == "" || manphonetb.Text == "")
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update manufacturertbl set manname=@mn,manadd=@ma,manphone=@mp,manjdate=@mjd where manid=@mkey", con);
                    cmd.Parameters.AddWithValue("@mn", mannametb.Text);
                    cmd.Parameters.AddWithValue("@ma", manaddresstb.Text);
                    cmd.Parameters.AddWithValue("@mp", manphonetb.Text);
                    cmd.Parameters.AddWithValue("@mjd", manjdate.Value.Date);
                    cmd.Parameters.AddWithValue("@mkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("manufacturer updated");
                    con.Close();
                    showman();
                    reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void label17_Click(object sender, EventArgs e)
        {
            medicines med = new medicines();
            med.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            customers cust = new customers();
            cust.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            sellers sell = new sellers();
            sell.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            selling sill = new selling();
            sill.Show();
            this.Hide();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            manufacturer manu = new manufacturer();
            manu.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from manufacturertbl  where manname like'" + textBox_searching.Text + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            manufacturerdgv.DataSource = dt;
            con.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            dashboard dash = new dashboard();
            dash.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            logins dash = new logins();
            dash.Show();
            this.Hide();
        }
    }
}

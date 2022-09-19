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
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
            showcust();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showcust()
        {
            con.Open();
            string query = "select * from customertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            customerdgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void reset()
        {
            custnametb.Text = "";
            cusphonetb.Text = "";
            cusgencb.SelectedIndex = 0;
            custaddtb.Text = "";




        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (custnametb.Text == "" || cusphonetb.Text == "" || cusphonetb.Text == ""|| cusgencb.SelectedIndex==-1)
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into customertbl(custname,custphone,custadd,custdob,custgen) values(@cn,@cp,@ca,@cd,@cg)", con);
                    cmd.Parameters.AddWithValue("@cn", custnametb.Text);
                    cmd.Parameters.AddWithValue("@cp", cusphonetb.Text);
                    cmd.Parameters.AddWithValue("@ca", custaddtb.Text);
                    cmd.Parameters.AddWithValue("@cd", cusdob.Value.Date);
                    cmd.Parameters.AddWithValue("@cg", cusgencb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("patient added");
                    con.Close();
                    showcust();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void customerdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            custnametb.Text = customerdgv.SelectedRows[0].Cells[1].Value.ToString();
            cusphonetb.Text = customerdgv.SelectedRows[0].Cells[2].Value.ToString();
            custaddtb.Text = customerdgv.SelectedRows[0].Cells[3].Value.ToString();
            cusdob.Text = customerdgv.SelectedRows[0].Cells[4].Value.ToString();
            cusgencb.SelectedItem = customerdgv.SelectedRows[0].Cells[5].Value.ToString();
            if (custnametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(customerdgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            if (key == 0)
            {
                MessageBox.Show("select the patient");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from customertbl where custnum=@ckey", con);
                    cmd.Parameters.AddWithValue("@ckey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("patient deleted");
                    con.Close();
                    showcust();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (custnametb.Text == "" || cusphonetb.Text == "" || cusphonetb.Text == "" || cusgencb.SelectedIndex == -1)
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update  customertbl set custname=@cn,custphone=@cp,custadd=@ca,custdob=@cd,custgen=@cg where custnum=@ckey", con);
                    cmd.Parameters.AddWithValue("@cn", custnametb.Text);
                    cmd.Parameters.AddWithValue("@cp", cusphonetb.Text);
                    cmd.Parameters.AddWithValue("@ca", custaddtb.Text);
                    cmd.Parameters.AddWithValue("@cd", cusdob.Value.Date);
                    cmd.Parameters.AddWithValue("@cg", cusgencb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("patient updated");
                    con.Close();
                    showcust();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from customertbl where custname like'" + textBox1.Text + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            customerdgv. DataSource = dt;
            con.Close();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            manufacturer manu = new manufacturer();
            manu.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            medicines med = new medicines();
            med.Show();
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

        private void label11_Click_1(object sender, EventArgs e)
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

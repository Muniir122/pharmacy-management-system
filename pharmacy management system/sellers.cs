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
    public partial class sellers : Form
    {
        public sellers()
        {
            InitializeComponent();
            showseller();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showseller()
        {
            con.Open();
            string query = "select * from sellertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            sellerdgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void reset()
        {
            snametb.Text = "";
            sphonetb.Text = "";
            saddtb.Text = "";
            spasswordtb.Text = "";
            sgencb.SelectedIndex = 0;
            key = 0;

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (snametb.Text == "" || sphonetb.Text == "" || spasswordtb.Text == "" || sgencb.SelectedIndex == -1 || saddtb.Text == "")
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into sellertbl(sname,sdob,sphone,sadd,sgen,spassword) values(@sn,@sd,@sp,@sa,@sg,@spa)", con);
                    cmd.Parameters.AddWithValue("@sn", snametb.Text);
                    cmd.Parameters.AddWithValue("@sd", sdob.Value.Date);
                    cmd.Parameters.AddWithValue("@sp", sphonetb.Text);
                    cmd.Parameters.AddWithValue("@sa", saddtb.Text);
                    cmd.Parameters.AddWithValue("@sg", sgencb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@spa", spasswordtb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller added");
                    con.Close();
                    showseller();
                    reset();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void sellerdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            snametb.Text = sellerdgv.SelectedRows[0].Cells[1].Value.ToString();
            sdob.Text = sellerdgv.SelectedRows[0].Cells[2].Value.ToString();
            sphonetb.Text = sellerdgv.SelectedRows[0].Cells[3].Value.ToString();
            saddtb.Text = sellerdgv.SelectedRows[0].Cells[4].Value.ToString();
            sgencb.SelectedItem = sellerdgv.SelectedRows[0].Cells[5].Value.ToString();
            spasswordtb.Text = sellerdgv.SelectedRows[0].Cells[6].Value.ToString();

            if (snametb.Text=="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(sellerdgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select the seller");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from sellertbl where snum=@skey", con);
                    cmd.Parameters.AddWithValue("@skey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller deleted");
                    con.Close();
                    showseller();
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
            if (snametb.Text == "" || sphonetb.Text == "" || spasswordtb.Text == "" || sgencb.SelectedIndex == -1 || saddtb.Text == "")
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update sellertbl set sname=@sn,sdob=@sd,sphone=@sp,sadd=@sa,sgen=@sg,spassword=@spa where snum=@skey", con);
                    cmd.Parameters.AddWithValue("@sn", snametb.Text);
                    cmd.Parameters.AddWithValue("@sd", sdob.Value.Date);
                    cmd.Parameters.AddWithValue("@sp", sphonetb.Text);
                    cmd.Parameters.AddWithValue("@sa", saddtb.Text);
                    cmd.Parameters.AddWithValue("@sg", sgencb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@spa", spasswordtb.Text);
                    cmd.Parameters.AddWithValue("@skey",key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller updated");
                    con.Close();
                    showseller();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void textBox_searching_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from sellertbl  where sname like'" + textBox_searching.Text + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sellerdgv.DataSource = dt;
            con.Close();
        }

        private void label22_Click(object sender, EventArgs e)
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

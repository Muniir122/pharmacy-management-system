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
    public partial class medicines : Form
    {
        public medicines()
        {
            InitializeComponent();
            showmed();
            getmanufacturer();
        }

        private void medicines_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            manufacturer manu = new manufacturer();
            manu.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
            selling sill = new selling();
            sill.Show();
            this.Hide();

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            sellers sell = new sellers();
            sell.Show();
            this.Hide();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            customers cust = new customers();
            cust.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            medicines med = new medicines();
            med.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            if (key == 0)
            {
                MessageBox.Show("select the medicine");
  
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from medicinetbl where mednum=@mkey", con);
                    cmd.Parameters.AddWithValue("@mkey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("medicine deleted");
                    con.Close();
                    showmed();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            if (mednametb.Text == "" || medpricetb.Text == "" || medqtytb.Text == "" || medtypecb.SelectedIndex == -1 || medmantb.Text == "")
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update medicinetbl set medname=@mn,medtype=@mt,medqty=@mq,medprice=@mp,medmanid=@mmi,medmanufact=@mm where mednum=@mkey", con);
                    cmd.Parameters.AddWithValue("@mn", mednametb.Text);
                    cmd.Parameters.AddWithValue("@mt", medtypecb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mq", medqtytb.Text);
                    cmd.Parameters.AddWithValue("@mp", medpricetb.Text);
                    cmd.Parameters.AddWithValue("@mmi", medmancb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@mm", medmantb.Text);
                    cmd.Parameters.AddWithValue("@mkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("medicines updated");
                    con.Close();
                    showmed();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showmed()
        {
            con.Open();
            string query = "select * from medicinetbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            medicinesdgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void reset()
        {
            medmantb.Text = "";
            mednametb.Text = "";
            medpricetb.Text = "";
            medqtytb.Text = "";
            medtypecb.SelectedIndex = 0;
            key=0;


        }
        private void getmanufacturer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select manid from manufacturertbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("manid", typeof(int));
            dt.Load(rdr);
            medmancb.ValueMember = "manid";
            medmancb.DataSource = dt;
            con.Close();

        }
        private void getmanname()
        {
            con.Open();
            string query = "select* from manufacturertbl where manid='" + medmancb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach( DataRow dr in dt.Rows)
            {
                medmantb.Text = dr["manname"].ToString();
            }
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            /// save
                   if(mednametb.Text==""|| medpricetb.Text==""||medqtytb.Text==""|| medtypecb.SelectedIndex==-1||medmantb.Text=="")
            {
                MessageBox.Show("missing information");

            }else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into medicinetbl(medname,medtype,medqty,medprice,medmanid,medmanufact) values(@mn,@mt,@mq,@mp,@mmi,@mm)", con);
                    cmd.Parameters.AddWithValue("@mn", mednametb.Text);
                    cmd.Parameters.AddWithValue("@mt", medtypecb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mq", medqtytb.Text);
                    cmd.Parameters.AddWithValue("@mp", medpricetb.Text);
                    cmd.Parameters.AddWithValue("@mmi", medmancb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@mm", medmantb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("medicines added");
                    con.Close();
                    showmed();
                    reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void medmancb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getmanname();
        }
        int key = 0;
        private void medicinesdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mednametb.Text = medicinesdgv.SelectedRows[0].Cells[1].Value.ToString();
            medtypecb.SelectedItem = medicinesdgv.SelectedRows[0].Cells[2].Value.ToString();
           medqtytb .Text = medicinesdgv.SelectedRows[0].Cells[3].Value.ToString();
            medpricetb.Text = medicinesdgv.SelectedRows[0].Cells[4].Value.ToString();
            medmancb.SelectedValue= medicinesdgv.SelectedRows[0].Cells[5].Value.ToString();
            medmantb.Text = medicinesdgv.SelectedRows[0].Cells[6].Value.ToString();

            if (mednametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(medicinesdgv.SelectedRows[0].Cells[0].Value.ToString());
            }
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
            string query = "select * from medicinetbl  where medname like'" + textBox_searching.Text + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            medicinesdgv.DataSource = dt;
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

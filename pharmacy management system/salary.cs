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
    public partial class salary : Form
    {
        public salary()
        {
            InitializeComponent();
            showmed();
            getmanufacturer();
    
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showmed()
        {
            con.Open();
            string query = "select * from salary  ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Salarydgv.DataSource = ds.Tables[0];
            con.Close();
        }

        private void getmanufacturer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select snum from sellertbl ", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("snum", typeof(int));
            dt.Load(rdr);
            cmb.ValueMember = "snum";
            cmb.DataSource = dt;
            con.Close();

        }
        private void getmanname()
        {
            con.Open();
            string query = "select* from sellertbl where snum='" + cmb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtname.Text = dr["sname"].ToString();
            }
            con.Close();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            /// save
            if (cmb.SelectedIndex==-1  || txtname.Text == "" || txtamount.Text == "" )
            {
                MessageBox.Show("missing information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into salary(salaryname,Amount,regdate) values(@salaryname,@Amount,@regdate)", con);
               
                    cmd.Parameters.AddWithValue("@salaryname", txtname.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                    cmd.Parameters.AddWithValue("@regdate", dtb.Value.Date);
               
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("salary added");
                    con.Close();
                    showmed();
                    //reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getmanname();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (cmb.SelectedIndex == -1 || txtname.Text == "" || txtamount.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update salary  set Amount   ='" + txtamount.Text + "' where Amount  =" + txtamount.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("salary UPDATE");
                    con.Close();
                    showmed();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }



        }
        int key = 0;
        private void btndelete_Click(object sender, EventArgs e)
        {

            //delete
            if (key == 0)
            {
                MessageBox.Show("select the salary");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from salary where ID=@mkey", con);
                    cmd.Parameters.AddWithValue("@mkey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("salary deleted");
                    con.Close();
                    showmed();
                    //reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void Salarydgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = Salarydgv.SelectedRows[0].Cells[1].Value.ToString();
            txtamount.Text = Salarydgv.SelectedRows[0].Cells[2].Value.ToString();
            cmb.SelectedItem = Salarydgv.SelectedRows[0].Cells[3].Value.ToString();
     
          
    

            if (txtname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Salarydgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            logins log = new logins();
            log.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            manufacturer man = new manufacturer();
            man.Show();
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
            selling sell = new selling();
            sell.Show();
            this.Hide();
        }
    }
}

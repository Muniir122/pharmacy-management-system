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
    public partial class selling : Form
    {
        public selling()
        {
            InitializeComponent();
            showmed();
            getcustomer();
            getcustname();
            showbill();

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void getcustomer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select custnum from customertbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("custnum", typeof(int));
            dt.Load(rdr);
            custidcb.ValueMember = "custnum";
            custidcb.DataSource = dt;
            con.Close();

        }
        private void getcustname()
        {
            con.Open();
            string query = "select* from customertbl where custnum='" + custidcb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               cusnametb.Text = dr["custname"].ToString();
            }
            con.Close();

        }
        private void updateqty()
        {
            try
            {
                int newqty = stock - Convert.ToInt32(medqtytb.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("update medicinetbl set medqty=@mq where mednum=@mkey", con);
                cmd.Parameters.AddWithValue("@mq", newqty);
                
                cmd.Parameters.AddWithValue("@mkey", key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("medicines updated");
                con.Close();
                showmed();
               // reset();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void insertbill()
        {
            if (cusnametb.Text == "")
            {

            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into billtbl(sname,custnum,custname,bdate,bamount) values(@un,@cn,@cna,@bd,@baa)", con);
                    cmd.Parameters.AddWithValue("@un", snamelbl.Text);
                    cmd.Parameters.AddWithValue("@cn", custidcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@cna", cusnametb.Text);
                    cmd.Parameters.AddWithValue("@bd", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("@baa", txtdiscount.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("bill saved");
                    con.Close();
                    showbill();
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void showbill()
        {
            con.Open();
            string query = "select * from billtbl where sname='"+snamelbl.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            transactiondgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void showmed()
        {
            con.Open();
            string query = "select * from medicinetbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
          medicinesdgv.DataSource = ds.Tables[0];
            con.Close();
        }
        int n = 0,grdtotal=0;
        private void save_button_Click(object sender, EventArgs e)
        {
            if(medqtytb.Text==""|| Convert.ToInt32(medqtytb.Text)>stock)
            {
                MessageBox.Show("enter correct quanity");
            }
            else
            {
                int total = Convert.ToInt32(medqtytb.Text) * Convert.ToInt32(medpricetb.Text);
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(billdgv);
                newrow.Cells[0].Value = n + 1;
                newrow.Cells[1].Value = mednametb.Text;
                newrow.Cells[2].Value = medqtytb.Text;
                newrow.Cells[3].Value = medpricetb.Text;
                newrow.Cells[4].Value = txtdiscount.Text;
                billdgv.Rows.Add(newrow);
                grdtotal = grdtotal + total;
                totallbl.Text = "rs "+grdtotal ;
                n++;
                updateqty();
              

            }
        }
        int key = 0,stock;
        int medid, medprice, medmedqty, medtot;
        int pos = 60;

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void custidcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getcustname();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

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

        private void label21_Click(object sender, EventArgs e)
        {
            selling sill = new selling();
            sill.Show();
            this.Hide();

        }

        private void label19_Click(object sender, EventArgs e)
        {
            sellers sell = new sellers();
            sell.Show();
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
         
        }

        private void totallbl_Click(object sender, EventArgs e)
        {

        }
        int numone;
        int numtwo;
        int result;
        private void btnresult_Click(object sender, EventArgs e)
        {
            numone = Convert.ToInt32(medpricetb.Text);
            numtwo = Convert.ToInt32(medqtytb.Text);
            result = numone * numtwo;
            txtresult.Text = Convert.ToString(result);
        }

        string medname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("caalami pharmacy", new Font("century gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("id medicine price quantity total", new Font("century gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach(DataGridViewRow row in billdgv.Rows)
            {

                medid = Convert.ToInt32(row.Cells["column1"].Value);
                medname = "" + row.Cells["column2"].Value;
                medprice = Convert.ToInt32(row.Cells["column3"].Value);
                medmedqty = Convert.ToInt32(row.Cells["column4"].Value);
                medtot = Convert.ToInt32(row.Cells["column5"].Value);

                e.Graphics.DrawString("" + medid, new Font("century gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + medname, new Font("century gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + medprice, new Font("century gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + medmedqty, new Font("century gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + medtot, new Font("century gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;

            }
            e.Graphics.DrawString("grand total:rs" + grdtotal, new Font("century gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("********caalami*******", new Font("century gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            billdgv.Rows.Clear();
            pos = 100;
            grdtotal = 0;
            n = 0;
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            ;
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
            insertbill();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {

        }

        private void medicinesdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mednametb.Text = medicinesdgv.SelectedRows[0].Cells[1].Value.ToString();
           // medtypecb.SelectedItem = medicinesdgv.SelectedRows[0].Cells[2].Value.ToString();
            stock = Convert.ToInt32 (medicinesdgv.SelectedRows[0].Cells[3].Value.ToString());
            medpricetb.Text = medicinesdgv.SelectedRows[0].Cells[4].Value.ToString();
            //medmancb.SelectedValue = medicinesdgv.SelectedRows[0].Cells[5].Value.ToString();
            //medmantb.Text = medicinesdgv.SelectedRows[0].Cells[6].Value.ToString();

            if (mednametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(medicinesdgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}

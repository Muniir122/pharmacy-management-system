
using System.Data;
using System.Data.SqlClient;

namespace pharmacy_management_system
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            countmed();
            countsellers();
            countcust();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\pharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void countmed()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from medicinetbl",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            mednum.Text = dt.Rows[0][0].ToString();
            con.Close();

        }
        private void countsellers()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from sellertbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sellerlbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }
        private void countcust()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from customertbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            custlbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }
      
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            salary sill = new salary();
            sill.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            logins log = new logins();
            log.Show();
            this.Hide();
        }
    }
}
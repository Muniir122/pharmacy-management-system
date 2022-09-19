using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_management_system
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
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

        private void label18_Click(object sender, EventArgs e)
        {
            customers cus = new customers();
            cus.Show();
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

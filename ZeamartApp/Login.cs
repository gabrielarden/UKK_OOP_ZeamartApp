using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeamartApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "admin" && txt_password.Text == "admin")
            {
                new FormZeamartApp().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username atau Password Salah!");
                username.Clear();
                txt_password.Clear();
                username.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

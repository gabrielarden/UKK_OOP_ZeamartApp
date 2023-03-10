using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ubiety.Dns.Core.Records;

namespace ZeamartApp
{
    public partial class FormZeamart : Form
    {
        private readonly FormZeamartApp _parent;
        public string id, namabarang, jumlahbarang, hargabeli, hargajual;
        public FormZeamart(FormZeamartApp parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lblText.Text = "Update Stock";
            btn_save.Text = "Update";
            txtNamaBarang.Text = namabarang;
            txtJumlahBarang.Text = jumlahbarang;
            txtHargaBeli.Text = hargabeli;
            txtHargaJual.Text = hargajual;
        }

        public void SaveInfo()
        {
            lblText.Text = "Zeamart Stock";
            btn_save.Text = "Save";
        }

        private void txtNamaBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtJumlahBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtNamaBarang.Text = txtJumlahBarang.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNamaBarang.Text.Trim().Length < 3) 
            {
                MessageBox.Show("Nama barang is Empty ( > 3)");
                return;
            }
            if (txtJumlahBarang.Text.Trim().Length < 1)
            {
                MessageBox.Show("Jumlah barang is Empty ( > 1)");
                return;
            }
            if (txtHargaBeli.Text.Trim().Length < 1)
            {
                MessageBox.Show("Harga beli is Empty ( > 1)");
                return;
            }
            if (txtHargaJual.Text.Trim().Length < 1)
            {
                MessageBox.Show("Harga jual is Empty ( > 1)");
                return;
            }
            if (btn_save.Text == "Save")
            {
                Zeamart zmr = new Zeamart(txtNamaBarang.Text.Trim(), txtJumlahBarang.Text.Trim(), txtHargaBeli.Text.Trim(), txtHargaJual.Text.Trim());
                DbZeamart.AddZeamart(zmr);
                Clear();
            }
            if(btn_save.Text == "Update")
            {
                Zeamart zmr = new Zeamart(txtNamaBarang.Text.Trim(), txtJumlahBarang.Text.Trim(), txtHargaBeli.Text.Trim(), txtHargaJual.Text.Trim());
                DbZeamart.UpdateZeamart(zmr, id);
            }
            _parent.Display();
        }
    }
}

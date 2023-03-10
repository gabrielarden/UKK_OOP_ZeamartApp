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
    public partial class FormZeamartApp : Form
    {
        FormZeamart form;
            
        public FormZeamartApp()
        {
            InitializeComponent();
            form = new FormZeamart(this);

        }

        public void Display()
        {
            DbZeamart.DisplayAndSearch("SELECT ID, NamaBarang, JumlahBarang, HargaBeli, HargaJual FROM zeamart_table", dataGridView);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void FormZeamartApp_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbZeamart.DisplayAndSearch("SELECT ID, NamaBarang, JumlahBarang, HargaBeli, HargaJual FROM zeamart_table WHERE NamaBarang LIKE '%"+ txtSearch.Text +"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //edit
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.namabarang = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.jumlahbarang = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.hargabeli = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.hargajual = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Apa kamu ingin menghapus data ini?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbZeamart.DeleteZeamart(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}

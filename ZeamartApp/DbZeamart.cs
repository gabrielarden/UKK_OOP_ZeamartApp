using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeamartApp
{
    class DbZeamart
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=zeamart";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void AddZeamart(Zeamart zmr)
        {
            string sql = "INSERT INTO zeamart_table VALUES (NULL, @ZeamartNamaBarang, @ZeamartJumlahBarang, @ZeamartHargaBeli, @ZeamartHargaJual, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ZeamartNamaBarang", MySqlDbType.VarChar).Value = zmr.NamaBarang;
            cmd.Parameters.Add("@ZeamartJumlahBarang", MySqlDbType.VarChar).Value = zmr.JumlahBarang;
            cmd.Parameters.Add("@ZeamartHargaBeli", MySqlDbType.VarChar).Value = zmr.HargaBeli;
            cmd.Parameters.Add("@ZeamartHargaJual", MySqlDbType.VarChar).Value = zmr.HargaJual;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Ditambahkan!" ,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal Ditambahkan. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateZeamart(Zeamart zmr, string id)
        {
            string sql = "UPDATE zeamart_table SET NamaBarang = @ZeamartNamaBarang, JumlahBarang= @ZeamartJumlahBarang, HargaBeli = @ZeamartHargaBeli, HargaJual = @ZeamartHargaJual WHERE ID = @ZeamartID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ZeamartID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@ZeamartNamaBarang", MySqlDbType.VarChar).Value = zmr.NamaBarang;
            cmd.Parameters.Add("@ZeamartJumlahBarang", MySqlDbType.VarChar).Value = zmr.JumlahBarang;
            cmd.Parameters.Add("@ZeamartHargaBeli", MySqlDbType.VarChar).Value = zmr.HargaBeli;
            cmd.Parameters.Add("@ZeamartHargaJual", MySqlDbType.VarChar).Value = zmr.HargaJual;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Diupdate!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal Diupdate. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteZeamart(string id)
        {
            string sql = "DELETE FROM zeamart_table WHERE ID = @ZeamartID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ZeamartID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Dihapus!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal Dihapus. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}

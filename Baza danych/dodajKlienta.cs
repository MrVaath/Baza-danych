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

namespace Baza_danych
{
    public partial class dodajKlienta : Form
    {
        public dodajKlienta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("dodajKlienta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.AddWithValue("@hasło", SqlDbType.VarChar).Value = textBox2.Text;
                    cmd.Parameters.AddWithValue("@imie", SqlDbType.VarChar).Value = textBox3.Text;
                    cmd.Parameters.AddWithValue("@nazwisko", SqlDbType.VarChar).Value = textBox4.Text;
                    cmd.Parameters.AddWithValue("@adres", SqlDbType.VarChar).Value = textBox5.Text;
                    cmd.Parameters.AddWithValue("@stały_klient", SqlDbType.Bit).Value = comboBox1.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    dodajKlienta.ActiveForm.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

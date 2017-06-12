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
    public partial class dodajPracownika : Form
    {
        public dodajPracownika()
        {
            InitializeComponent();
            fillCombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("dodajPracownika", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@placówka", SqlDbType.Int).Value = comboBox1.Text;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = textBox2.Text;
                    cmd.Parameters.AddWithValue("@hasło", SqlDbType.VarChar).Value = textBox3.Text;
                    cmd.Parameters.AddWithValue("@imie", SqlDbType.VarChar).Value = textBox4.Text;
                    cmd.Parameters.AddWithValue("@nazwisko", SqlDbType.VarChar).Value = textBox5.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dodajPracownika.ActiveForm.Close();
                }
            }
        }

        void fillCombo()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Placówki", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(sqlReader["id"].ToString());
                }

                sqlReader.Close();
            }
        }
    }
}

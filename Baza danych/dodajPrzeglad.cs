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
    public partial class dodajPrzeglad : Form
    {
        public dodajPrzeglad()
        {
            InitializeComponent();
            fillCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("dodajPrzegląd", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pojazd", SqlDbType.Char).Value = comboBox1.Text;
                    cmd.Parameters.AddWithValue("@data_przeglądu", SqlDbType.Date).Value = textBox2.Text;
                    cmd.Parameters.AddWithValue("@ważność_przeglądu", SqlDbType.Date).Value = textBox3.Text;
                    cmd.Parameters.AddWithValue("@koszt", SqlDbType.Int).Value = textBox4.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dodajPrzeglad.ActiveForm.Close();
                }
            }
        }

        void fillCombo()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Pojazdy", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(sqlReader["tablica_rej"].ToString());
                }

                sqlReader.Close();
            }
        }
    }
}

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
    public partial class dodajWypozyczenie : Form
    {
        public dodajWypozyczenie()
        {
            InitializeComponent();
            fillCombo();
            fillCombo2();
            fillCombo3();
        }
        //SELECT ERROR_NUMBER() AS  'NUMER BLEDU',ERROR_MESSAGE() AS 'KOMUNIKAT'
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("dodajRezerwację", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@klient", SqlDbType.Int).Value = comboBox1.Text;
                    cmd.Parameters.AddWithValue("@pojazd", SqlDbType.Char).Value = comboBox2.Text;
                    cmd.Parameters.AddWithValue("@placówka", SqlDbType.Int).Value = comboBox3.Text;
                    cmd.Parameters.AddWithValue("@data_wypożyczenia", SqlDbType.Date).Value = textBox4.Text;
                    cmd.Parameters.AddWithValue("@data_odd_plan", SqlDbType.Date).Value = textBox5.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dodajWypozyczenie.ActiveForm.Close();
                }
            }
        }

        void fillCombo()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Klienci", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(sqlReader["id"].ToString());
                }

                sqlReader.Close();
            }
        }

        void fillCombo2()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Pojazdy", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox2.Items.Add(sqlReader["tablica_rej"].ToString());
                }

                sqlReader.Close();
            }
        }

        void fillCombo3()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Placówki", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox3.Items.Add(sqlReader["id"].ToString());
                }

                sqlReader.Close();
            }
        }
    }
}

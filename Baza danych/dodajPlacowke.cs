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
    public partial class dodajPlacowke : Form
    {
        public dodajPlacowke()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("dodajPlacówkę", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nazwa", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.AddWithValue("@adres", SqlDbType.VarChar).Value = textBox2.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    dodajPlacowke.ActiveForm.Close();
                }
            }

        }
    }
}

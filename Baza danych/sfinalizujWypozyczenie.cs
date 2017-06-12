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
    public partial class sfinalizujWypozyczenie : Form
    {
        public sfinalizujWypozyczenie()
        {
            InitializeComponent();
            fillCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("sfinalizujWypożyczenie", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = comboBox1.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    sfinalizujWypozyczenie.ActiveForm.Close();
                }
            }

        }

        void fillCombo()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True"))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Wypożyczenia", sqlConnection);
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

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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // utworz połączenie
            SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True");
            conn.Open();


            SqlDataAdapter wypozyczenia = new SqlDataAdapter("select * from Wypożyczenia", conn);

            DataSet dsPrac = new DataSet();

            wypozyczenia.Fill(dsPrac, "wypozyczenia");

            conn.Close();

            dataGridView1.DataSource = dsPrac;
            dataGridView1.DataMember = "wypozyczenia";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // utworz połączenie
            SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True");
            conn.Open();


            SqlDataAdapter placowki = new SqlDataAdapter("select * from Placówki", conn);

            DataSet dsPrac = new DataSet();

            placowki.Fill(dsPrac, "placowki");

            conn.Close();

            dataGridView1.DataSource = dsPrac;
            dataGridView1.DataMember = "placowki";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // utworz połączenie
            SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True");
            conn.Open();


            SqlDataAdapter pojazdy = new SqlDataAdapter("select * from Pojazdy", conn);

            DataSet dsPrac = new DataSet();

            pojazdy.Fill(dsPrac, "pojazdy");

            conn.Close();

            dataGridView1.DataSource = dsPrac;
            dataGridView1.DataMember = "pojazdy";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // utworz połączenie
            SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True");
            conn.Open();


            SqlDataAdapter przeglady = new SqlDataAdapter("select * from Przeglądy", conn);

            DataSet dsPrac = new DataSet();

            przeglady.Fill(dsPrac, "przeglady");

            conn.Close();

            dataGridView1.DataSource = dsPrac;
            dataGridView1.DataMember = "przeglady";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // utworz połączenie
            SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True");
            conn.Open();


            SqlDataAdapter klienci = new SqlDataAdapter("select * from Klienci", conn);

            DataSet dsPrac = new DataSet();

            klienci.Fill(dsPrac, "klienci");

            conn.Close();

            dataGridView1.DataSource = dsPrac;
            dataGridView1.DataMember = "klienci";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // utworz połączenie
            SqlConnection conn = new SqlConnection("Data Source=mssql.wmi.amu.edu.pl;Initial Catalog=dbad_s407333;Integrated Security=True");
            conn.Open();


            SqlDataAdapter pracownicy = new SqlDataAdapter("select * from Pracownicy", conn);

            DataSet dsPrac = new DataSet();

            pracownicy.Fill(dsPrac, "pracownicy");

            conn.Close();

            dataGridView1.DataSource = dsPrac;
            dataGridView1.DataMember = "pracownicy";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dodajPracownika settingsForm = new dodajPracownika();

            // Show the settings form
            settingsForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dodajKlienta settingsForm = new dodajKlienta();

            // Show the settings form
            settingsForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dodajPojazd settingsForm = new dodajPojazd();

            // Show the settings form
            settingsForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dodajPrzeglad settingsForm = new dodajPrzeglad();

            // Show the settings form
            settingsForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dodajWypozyczenie settingsForm = new dodajWypozyczenie();

            // Show the settings form
            settingsForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dodajPlacowke settingsForm = new dodajPlacowke();

            // Show the settings form
            settingsForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sfinalizujWypozyczenie settingsForm = new sfinalizujWypozyczenie();

            // Show the settings form
            settingsForm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            zmienKlienta settingsForm = new zmienKlienta();

            // Show the settings form
            settingsForm.Show();
        }
    }
}

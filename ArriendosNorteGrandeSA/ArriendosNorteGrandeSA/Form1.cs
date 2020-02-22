using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArriendosNorteGrandeSA
{
    public partial class Vista1 : Form
    {
        public Vista1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string r = "";
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            MySqlConnection conexionBD = new MySqlConnection(cadena);

            conexionBD.Open();
        
            MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", conexionBD);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                r += reader.GetString(0) + "\n";

            }

            MessageBox.Show(r);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { 
        }

        private void agregarReservaNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.agregarReserva agregarReserva = new Formularios.agregarReserva();
            agregarReserva.ShowDialog();
        }

        private void eliminarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.eliminarReserva eliminarReserva = new Formularios.eliminarReserva();
            eliminarReserva.ShowDialog();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.consultas consultas = new Formularios.consultas();
            consultas.ShowDialog();
        }

        private void estadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.estadisticas estadisticas = new Formularios.estadisticas();
            estadisticas.ShowDialog();
        }
    }
}

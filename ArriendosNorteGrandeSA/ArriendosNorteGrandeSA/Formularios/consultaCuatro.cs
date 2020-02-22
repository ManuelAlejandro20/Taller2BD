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

namespace ArriendosNorteGrandeSA.Formularios
{
    public partial class consultaCuatro : Form
    {
        private string rut;
        public consultaCuatro(string rut)
        {
            this.rut = rut;
            InitializeComponent();

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

            string consulta = "select r.Numero_reserva, r.Precio_final , r.Fecha_inicio, r.Fecha_final  " +
                               "from vehiculosnortegrandedb.reserva r join vehiculosnortegrandedb.cliente c on r.ClienteRut = c.Rut " +
                               "where c.Rut = '" + this.rut + "'";

            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();

            DateTime fechaInicio;
            DateTime fechaFinal;

            while (reader.Read())
            {
                fechaInicio = Convert.ToDateTime(reader.GetString(2));
                fechaFinal = Convert.ToDateTime(reader.GetString(3));
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), fechaInicio.ToString("dd-MM-yyyy"), fechaFinal.ToString("dd-MM-yyyy"));
            }
            conexionBD.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index == -1)
            {
                return;
            }
            listBox1.Items.Clear();

            DataGridViewRow sr = dataGridView1.Rows[index];
            string numRes = sr.Cells[0].Value.ToString();
            string str = "select * from vehiculosnortegrandedb.vehiculo where vehiculosnortegrandedb.vehiculo.reservanumero_reserva=" + numRes;
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();

            MySqlCommand cmd = new MySqlCommand(str, conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();
            string resVeh = "";
            while (reader.Read())
            {

                resVeh = reader.GetString(0) + "  " + reader.GetString(1) + "  " + reader.GetString(2) + "  " + reader.GetString(4);
                listBox1.Items.Insert(0, resVeh);

            }
            conexionBD.Close();
        }
    }
}

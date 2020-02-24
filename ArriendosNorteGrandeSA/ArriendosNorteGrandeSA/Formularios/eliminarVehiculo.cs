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
    public partial class eliminarVehiculo : Form
    {
        public eliminarVehiculo()
        {
            InitializeComponent();

            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = new MySqlCommand("select * " +
                                   "from vehiculosnortegrandedb.vehiculo " +
                                   "where vehiculosnortegrandedb.vehiculo.reservanumero_reserva is null", conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)
                    , reader.GetString(5), reader.GetString(6));

            }

            conexionBD.Close();

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void eliminarVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string patente = row.Cells[0].Value.ToString();
                string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
                string delete = "delete from vehiculosnortegrandedb.vehiculo where vehiculosnortegrandedb.vehiculo.patente= '" + patente + "'";

                MySqlConnection conexionBD = new MySqlConnection(cadena);
                conexionBD.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conexionBD);
                if (cmd.ExecuteNonQuery() == 1) {
                    conexionBD.Close();
                    MessageBox.Show("Vehículo eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }

            }
        }
    }
}

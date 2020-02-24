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
    public partial class eliminarReserva : Form
    {

        public eliminarReserva()
        {
            InitializeComponent();

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void eliminarReserva_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) {
                MessageBox.Show("Escoge una reserva para eliminar porfavor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string numRes = row.Cells[0].Value.ToString();

                string delete = "delete from vehiculosnortegrandedb.reserva where vehiculosnortegrandedb.reserva.numero_reserva= '" + numRes + "'";
                string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

                MySqlConnection conexionBD = new MySqlConnection(cadena);
                
                //begin
                conexionBD.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conexionBD);
                cmd.ExecuteNonQuery();
                conexionBD.Close();
                // end

                MessageBox.Show("Reserva eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 9)
            {
                int rut = Convert.ToInt32(textBox1.Text);
                string str = "select * from vehiculosnortegrandedb.reserva where vehiculosnortegrandedb.reserva.clienterut=" + rut;
                string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

                MySqlConnection conexionBD = new MySqlConnection(cadena);
                conexionBD.Open();

                MySqlCommand cmd = new MySqlCommand(str, conexionBD);
                MySqlDataReader reader = cmd.ExecuteReader();

                DateTime fechaInicio;
                DateTime fechaFinal;

                while (reader.Read())
                {
                    fechaInicio = Convert.ToDateTime(reader.GetString(1));
                    fechaFinal = Convert.ToDateTime(reader.GetString(2));
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(3), fechaInicio.ToString("dd-MM-yyyy"), fechaFinal.ToString("dd-MM-yyyy"));
                }
                conexionBD.Close();
            }
            else {
                listBox1.Items.Clear();
                dataGridView1.Rows.Clear();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                
                resVeh = reader.GetString(0) + "  " + reader.GetString(1)+ "  " + reader.GetString(2) + "  " + reader.GetString(4);
                listBox1.Items.Insert(0, resVeh);
                
            }
            conexionBD.Close();
        }
    }
}

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
    public partial class consultaSiete : Form
    {
        public consultaSiete(string rut)
        {
            InitializeComponent();
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

            string consulta = "select c.rut, c.nombre, c.direccion, c.telefono_domicilio, c.telefono_movil " +
                               "from vehiculosnortegrandedb.cliente c " +
                               "where c.clienterut ='" + rut + "'";

            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(rutFormal(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
            }
            conexionBD.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string rutFormal(string rut)
        {

            string rutStr = rut;
            string rutForm = "";

            for (int i = 0; i < 9; i++)
            {
                if (i == 2 || i == 5)
                {
                    rutForm += ".";
                }
                else if (i == 8)
                {
                    rutForm += "-";
                }
                rutForm += rutStr[i].ToString();

            }
            return rutForm;
        }
    }
}

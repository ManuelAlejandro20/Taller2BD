using MySql.Data.MySqlClient;
using System;
using System.Collections;
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



    public partial class eliminarCliente : Form
    {

        private ArrayList clientes;

        public eliminarCliente()
        {
            InitializeComponent();

            this.clientes = new ArrayList();
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = new MySqlCommand("select * " +
                                   "from vehiculosnortegrandedb.cliente ", conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(rutFormal(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                this.clientes.Add(reader.GetString(0) + "/" + reader.GetString(1));
            }

            conexionBD.Close();

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string rut = row.Cells[0].Value.ToString();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");

                ArrayList clientesAv = new ArrayList();

                string datos = "";
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
                    datos = reader.GetString(0) + "/" + reader.GetString(1) + "/" + reader.GetString(2) + "/" + reader.GetString(3) + "/" + reader.GetString(4);
                    clientesAv.Add(datos);
                }
                conexionBD.Close();
                if (clientesAv.Count == 0)
                {
                    string delete = "delete from vehiculosnortegrandedb.cliente where vehiculosnortegrandedb.cliente.rut= '" + rut + "'";
                    
                    conexionBD = new MySqlConnection(cadena);

                    //begin
                    conexionBD.Open();
                    cmd = new MySqlCommand(delete, conexionBD);
                    if (cmd.ExecuteNonQuery() == 1) {
                        //end
                        conexionBD.Close();
                        MessageBox.Show("Cliente eliminado", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                        return;
                    }

                }
                else {
                    MessageBox.Show("Este cliente está avalando a uno ó muchos clientes, se requiere actualizar la lista de clientes para continuar", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Formularios.actualizarCliente ac = new Formularios.actualizarCliente(clientesAv, this.clientes, rut);
                    ac.ShowDialog();
                    this.Close();
                }
                
            }
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

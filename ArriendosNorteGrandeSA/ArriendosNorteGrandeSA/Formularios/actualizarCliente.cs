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
    public partial class actualizarCliente : Form
    {
        private ArrayList clientesAvRut;
        private string rutDelete;

        public actualizarCliente(ArrayList clientesAv, ArrayList clientes, string rut)
        {
            this.clientesAvRut = new ArrayList();
            this.rutDelete = rut;

            string[] clienteAvSplit, clienteSplit;
          
            ArrayList b = new ArrayList();
            InitializeComponent();

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            DataGridViewRow dgvRow;
            int i = 0;

            //Se almacenan todos los nombres y rut disponibles para poner en los combobox (se almacenan en ArrayList)
            foreach (string clienteav in clientesAv) {

                ArrayList a = new ArrayList();
                clienteAvSplit = clienteav.Split('/');
                this.clientesAvRut.Add(clienteAvSplit[0]);

                foreach (string cliente in clientes)
                {
                    clienteSplit = cliente.Split('/');

                    //Para agregar a la lista de nombres disponbles debe ser diferente al rut propio y al rut de la persona que se desea eliminar
                    if (clienteSplit[0] != clienteAvSplit[0] && clienteSplit[0] != rut)
                    {
                        a.Add(rutFormal(clienteSplit[0]) + " " + clienteSplit[1]);
                    }
                }

                //La lista de nombres disponibles PARA ESTA PERSONA (que es un ArrayList) se almacena en otra ArrayList
                b.Add(a);
                
            }

            //Rellena las filas con los clientes que estoy avalando
            foreach (string clienteav in clientesAv)
            {
                clienteAvSplit = clienteav.Split('/');
                dgvRow = new DataGridViewRow();
                dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells.Add(new DataGridViewComboBoxCell());

                dgvRow.Cells[0].Value = rutFormal(clienteAvSplit[0]);
                dgvRow.Cells[1].Value = clienteAvSplit[1];
                dgvRow.Cells[2].Value = clienteAvSplit[2];
                dgvRow.Cells[3].Value = clienteAvSplit[3];
                dgvRow.Cells[4].Value = clienteAvSplit[4];

                //Se llena el combobox con los nombres disponibles para ESTA PERSONA
                ((DataGridViewComboBoxCell)dgvRow.Cells[5]).DataSource = b[i];

                dataGridView1.Rows.Add(dgvRow);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in dataGridView1.Rows) {
                if (d.Cells[5].Value == null) {
                    MessageBox.Show("Cada cliente tiene que ser avalado por un cliente, intenta nuevamente porfavor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MySqlConnection conexionBD;
            MySqlCommand cmd;

            string avEscogido, rutnuevoAv = "", accion, cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";

            for (int i = 0; i < this.clientesAvRut.Count; i++) {
                avEscogido = dataGridView1.Rows[i].Cells[5].Value.ToString();
                foreach (char ch in avEscogido)
                {
                    if (ch == ' ')
                    {
                        break;
                    }
                    rutnuevoAv += ch;
                }
                rutnuevoAv = rutnuevoAv.Replace(".", "");
                rutnuevoAv = rutnuevoAv.Replace("-", "");

                accion = "update vehiculosnortegrandedb.cliente " +
                        "set vehiculosnortegrandedb.cliente.clienterut = '" + rutnuevoAv + "' " +
                        "where vehiculosnortegrandedb.cliente.rut = '" + this.clientesAvRut[i] + "';";

                conexionBD = new MySqlConnection(cadena);
                //begin
                conexionBD.Open();
                cmd = new MySqlCommand(accion, conexionBD);
                cmd.ExecuteNonQuery();
                //close
                conexionBD.Close();

                rutnuevoAv = "";

            }

            accion = "delete from vehiculosnortegrandedb.cliente where vehiculosnortegrandedb.cliente.rut= '" + this.rutDelete + "'";

            conexionBD = new MySqlConnection(cadena);
            //begin
            conexionBD.Open();
            cmd = new MySqlCommand(accion, conexionBD);
            if (cmd.ExecuteNonQuery() == 1)
            {
                conexionBD.Close();
                MessageBox.Show("Cliente eliminado y filas actualizadas", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

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
    public partial class agregarReserva : Form
    {
        public agregarReserva()
        {
            InitializeComponent();
            string r = "";
            string rut = "";
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * " +
                                                "FROM vehiculosnortegrandedb.cliente", conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                r = reader.GetString(0);
                for (int i = 0; i < 9; i++)
                {
                    if (i == 2 || i == 5)
                    {
                        rut += ".";
                    }
                    else if (i == 8)
                    {
                        rut += "-";
                    }
                    rut += r[i].ToString();

                }
                checkedListBox2.Items.Add(rut);
                rut = "";

            }
            conexionBD.Close();
            conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            cmd = new MySqlCommand("select * " +
                                   "from vehiculosnortegrandedb.vehiculo ", conexionBD);
            reader = cmd.ExecuteReader();

            while (reader.Read()) {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)
                    , reader.GetString(5));
               
            }

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void agregarReserva_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un cliente porfavor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listBox1.Items.Count == 0) {
                MessageBox.Show("Selecciona un vehículo porfavor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value) {
                MessageBox.Show("Selecciona una fecha de inicio superior a la de término porfavor ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            string rutStr = "";
            string patente = "";
            TimeSpan days = dateTimePicker2.Value - dateTimePicker1.Value;
            int daysInt = days.Days + 1;

            List<string> patentes = new List<string>();
            
            int precioFinal = 0;

            foreach (string s in checkedListBox2.CheckedItems) {
                rutStr = s.Replace(".", "");
                rutStr = rutStr.Replace("-", "");
            }
            foreach (string s in listBox1.Items) {
                foreach (char ch in s) {
                    if (ch == ' ') {
                        break;
                    }
                    patente = patente + ch;
                }
                patentes.Add(patente);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Patente"].Value.ToString() == patente) {
                        precioFinal += Convert.ToInt32(row.Cells["PrecioAlquilerDiario"].Value.ToString()) * daysInt;
                    } 
                }
                patente = "";
            }

            int rut = Convert.ToInt32(rutStr);
            string fechaInicio = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string fechaFinal = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            string insertar = "insert into vehiculosnortegrandedb.reserva(clienteRut, precio_final, fecha_inicio, fecha_final)" +
                              "value" +
                              "(" + rut + "," + precioFinal + "," + "'" + fechaInicio + "'" + "," + "'" + fechaFinal + "'" + ")";

            //begin
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = new MySqlCommand(insertar, conexionBD);
            cmd.ExecuteNonQuery();
         
            int numRes = 0;

            string consulta = "select numero_reserva from vehiculosnortegrandedb.reserva where clienterut =" + rut;

            conexionBD.Close();
            //End

            //Begin
            conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            cmd = new MySqlCommand(consulta, conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                numRes = Convert.ToInt32(reader.GetString(0));
            }
            conexionBD.Close();
            //End


            string update = "";
            Random r = new Random();
            int rInt;

            for (int i = 0; i < patentes.Count; i++) {
                conexionBD = new MySqlConnection(cadena);
                conexionBD.Open();
                rInt = r.Next(0, 50);

                update = "insert into vehiculosnortegrandedb.reserva_vehiculo(numero_reserva, patente, litros_gasolina) " +
                         "value " +
                         "(" + numRes + ",'" + patentes[i] + "'," + rInt + ");";
                cmd = new MySqlCommand(update, conexionBD);
                cmd.ExecuteNonQuery();

                conexionBD.Close();
            }

            MessageBox.Show("Reserva realizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox2.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox2.Items.Count; iIndex++)
                checkedListBox2.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox2.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            if (index == -1) {
                return;
            }
       
            DataGridViewRow sr = dataGridView1.Rows[index];
            string str = sr.Cells[0].Value.ToString() + "  " + sr.Cells[2].Value.ToString() + "  " + sr.Cells[4].Value.ToString();
            if (!listBox1.Items.Contains(str))
            {
                listBox1.Items.Insert(0, str);
            }



        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) {
                listBox1.Items.Remove(listBox1.GetItemText(listBox1.SelectedItem));
            }
        }
    }
}

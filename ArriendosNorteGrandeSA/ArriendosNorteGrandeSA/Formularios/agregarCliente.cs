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
    public partial class agregarCliente : Form
    {
        public agregarCliente()
        {
            InitializeComponent();
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            string consulta = "select c.rut, c.nombre from vehiculosnortegrandedb.cliente c ";
            string datos = "";

            MySqlConnection conexionBD = new MySqlConnection(cadena);

            conexionBD.Open();

            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                datos = rutFormal(reader.GetString(0)) + "  " + reader.GetString(1);
                comboBox1.Items.Insert(0, datos);
            }
            conexionBD.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 ||
                textBox5.Text.Length == 0 || comboBox1.Text == "") {
                MessageBox.Show("¡Completa todos los campos para agregar al nuevo cliente porfavor!", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!textBox4.Text.All(char.IsDigit) || !textBox5.Text.All(char.IsDigit)) {
                MessageBox.Show("¡Ingresa sólo números en los campos de teléfonos porfavor!", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox1.Text.Length != 9) {
                MessageBox.Show("¡Ingresa un rut válido porfavor!", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rut = textBox1.Text;
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            string consulta = "select * from vehiculosnortegrandedb.cliente c where c.rut =" + rut;
            string datos = "";

            MySqlConnection conexionBD = new MySqlConnection(cadena);

            conexionBD.Open();

            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                datos = reader.GetString(0);
            }
            conexionBD.Close();
            if (datos != "") {
                
                MessageBox.Show("El rut de este cliente ya está registrado, ingresa otro porfavor", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaval = "";

            foreach (char ch in comboBox1.SelectedItem.ToString())
            {
                if (ch == ' ')
                {
                    break;
                }
                rutaval += ch;
            }
            rutaval = rutaval.Replace(".", "");
            rutaval = rutaval.Replace("-", "");
            
            string insertar = "insert into vehiculosnortegrandedb.cliente(rut, nombre, direccion, telefono_domicilio, telefono_movil, clienterut) " +
                              "values " +
                              "('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text+"','" + textBox4.Text + "','" + textBox5.Text+ "','" + rutaval + "');";

            conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            cmd = new MySqlCommand(insertar, conexionBD);
            if (cmd.ExecuteNonQuery() == 1) {
                conexionBD.Close();
                MessageBox.Show("Cliente registrado correctamente", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

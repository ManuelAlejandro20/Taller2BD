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
    public partial class agregarVehiculo : Form
    {
        public agregarVehiculo()
        {
            InitializeComponent();
        }

        private void agregarVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 ||
                textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("¡Completa todos los campos para agregar al nuevo vehículo porfavor!", "Agregar vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!textBox4.Text.All(char.IsDigit) || !textBox6.Text.All(char.IsDigit))
            {
                MessageBox.Show("¡Ingresa sólo números en los campos que lo requieran porfavor!", "Agregar vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string patente = textBox1.Text.ToUpper();
            string datos = "";

            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            string consulta = "select * from vehiculosnortegrandedb.vehiculo v where v.patente = '" + patente + "'";
            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                datos = reader.GetString(0);
            }
            conexionBD.Close();
            if (datos != "")
            {
                
                MessageBox.Show("La patente de este vehículo está registrada, ingresa otra porfavor", "Agregar vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insert = "insert into vehiculosnortegrandedb.vehiculo(patente, modelo, marca, numero_motor, color, precio_alquiler_diario) " +
                              "values " +
                              "('" + patente + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text +  "');";

            conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            cmd = new MySqlCommand(insert, conexionBD);
            if(cmd.ExecuteNonQuery() == 1){
                conexionBD.Close();
                MessageBox.Show("Vehículo registrado correctamente", "Agregar vehículo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return;
            }

        }
    }
}

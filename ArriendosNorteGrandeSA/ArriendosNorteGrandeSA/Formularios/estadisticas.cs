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
    public partial class estadisticas : Form
    {
        public estadisticas()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            label3.Visible = true;
            listBox1.Visible = true;
            listBox1.Items.Clear();
            switch (index) {
                case 0:
                case 1:
                    listBox1.Size = new Size(258, 17);
                    listBox1.Location = new Point(74, 119);
                    label3.Location = new Point(71, 103);
                    setOpcion(true,true);
                    break;
                case 2:
                    listBox1.Size = new Size(258, 95);
                    listBox1.Location = new Point(74, 119);
                    label3.Location = new Point(71, 103);
                    setOpcion(true,true);
                    break;
                case 3:
                case 4:
                case 5:
                default:
                    listBox1.Size = new Size(267, 134);
                    listBox1.Location = new Point(74,80) ;
                    label3.Location = new Point(71, 64);
                    setOpcion(false, false);
                    break;
            }
        }

        private void setOpcion(bool uno, bool tx)
        {
            label1.Visible = uno;
            textBox1.Visible = tx;       
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 9)
            {
                listBox1.Items.Clear();
                return;
            }

            int index = comboBox1.SelectedIndex;
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            string consulta = "";
            string rut = textBox1.Text;
            
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            
            switch (index) {
                case 0:
                    DateTime date;
                    int cont = 0;
                    consulta = "select fecha_inicio from vehiculosnortegrandedb.reserva where vehiculosnortegrandedb.reserva.clienterut =" + rut;
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        date = Convert.ToDateTime(reader.GetString(0));
                        if (DateTime.Now.Month == date.Month)
                        {
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        listBox1.Items.Add("El cliente no realizó reservas este mes");
                    }
                    else {
                        listBox1.Items.Add("El cliente realizó "+ cont +" reserva(s) este mes");
                    }
                    break;
                case 1:
                    cont = 0;
                    consulta = "select fecha_inicio from vehiculosnortegrandedb.reserva where vehiculosnortegrandedb.reserva.clienterut =" + rut;
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        date = Convert.ToDateTime(reader.GetString(0));
                        if (DateTime.Now.Year == date.Year)
                        {
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        listBox1.Items.Add("El cliente no realizó reservas este año");
                    }
                    else
                    {
                        listBox1.Items.Add("El cliente realizó " + cont + " reserva(s) este año");
                    }
                    break;
                default:
                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class consultas : Form
    {
        public consultas()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            button1.Visible = true;
            textBox1.Visible = true;
            textBox1.Clear();
            switch (index) {
                case 0:
                case 3:
                case 5:
                case 6:
                    setOpcion(true, false, false, 9);
                    break;
                case 1:
                case 4:
                    setOpcion(false, true, false, 10);
                    break;
                default:
                    setOpcion(false, false, true, 5);
                    break;
            }
        }

        private void setOpcion(bool uno, bool dos, bool tres, int largo) {
            label1.Visible = uno;
            label2.Visible = dos;
            label3.Visible = tres;
            textBox1.MaxLength = largo;
        }

        private void label1_Click(object sender, EventArgs e) { 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                return;
            }
            int index = comboBox1.SelectedIndex;
            string consulta = "";
            string datos = "";

            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            conexionBD.Open();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            switch (index) {
                case 0:
                    if (textBox1.Text.Length != 9)
                    {
                        return;
                    }
                    string rut = textBox1.Text;
                    string rut2 = "";

                    consulta = "select * from vehiculosnortegrandedb.cliente where vehiculosnortegrandedb.cliente.rut =" + rut;
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    while (reader.Read()) {

                        rut = rutFormal(rut);
                        rut2 = reader.GetString(5);
                        rut2 = rutFormal(rut2);

                        datos = "RUT CLIENTE : " + rut + "\n" +
                                "NOMBRE CLIENTE : " + reader.GetString(1) + "\n" +
                                "DIRECCIÓN : " + reader.GetString(2) + "\n" +
                                "TELÉFONO DOMICILIO : " + reader.GetString(3) + "\n" +
                                "TELÉFONO MÓVIL : " + reader.GetString(4) + "\n" +
                                "RUT CLIENTE QUE LO ESTA AVALANDO : " + rut2 + "\n"
                                ;
                    }
                    conexionBD.Close();
                    if (datos == "") {
                        MessageBox.Show("¡Cliente no registrado!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show(datos, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case 1:
                    string patente = textBox1.Text.ToUpper();

                    consulta = "select * from vehiculosnortegrandedb.vehiculo where vehiculosnortegrandedb.vehiculo.patente = '" + patente + "'";
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        datos = "PATENTE : " + reader.GetString(0) + "\n" +
                                "MODELO : " + reader.GetString(1) + "\n" +
                                "MARCA : " + reader.GetString(2) + "\n" +
                                "NÚMERO DE MOTOR : " + reader.GetString(3) + "\n" +
                                "NÚMERO DE MOTOR : " + reader.GetString(4) + "\n" +
                                "PRECIO ALQUILER DIARIO : " + reader.GetString(5) + "\n"
                                ;
                    }
                    if (datos == "") {
                        MessageBox.Show("¡Vehículo no registrado!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show(datos, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case 2:
                    int numRes = Convert.ToInt32(textBox1.Text);

                    consulta = "select * from vehiculosnortegrandedb.reserva where vehiculosnortegrandedb.reserva.numero_reserva = " + numRes;
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    DateTime fechaInicio;
                    DateTime fechaFinal;
                    string rutStr;

                    while (reader.Read()) {

                        fechaInicio = Convert.ToDateTime(reader.GetString(1));
                        fechaFinal = Convert.ToDateTime(reader.GetString(2));

                        rutStr = rutFormal(reader.GetString(4));

                        datos = "NÚMERO DE RESERVA : " + reader.GetString(0) + "\n" +
                                "FECHA DE INICIO RESERVA : " + fechaInicio.ToString("dd-MM-yyyy") + "\n" +
                                "FECHA DE TÉRMINO RESERVA : " + fechaFinal.ToString("dd-MM-yyyy") + "\n" +
                                "PRECIO FINAL DE RESERVA : $" + reader.GetString(3) + "\n" +
                                "RUT CLIENTE QUE RESERVÓ : " + rutStr + "\n"
                                ;
                    }
                    if (datos == "")
                    {
                        MessageBox.Show("¡Reserva no registrada!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show(datos, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case 3:
                    rut = textBox1.Text;

                    consulta = "select * from vehiculosnortegrandedb.cliente where vehiculosnortegrandedb.cliente.rut =" + rut;
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        datos = reader.GetString(0);
                    }
                    if (datos == "") {
                        MessageBox.Show("¡Cliente no registrado!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    datos = "";
                    conexionBD.Close();

                    consulta = "select r.numero_reserva " +
                                "from vehiculosnortegrandedb.reserva r join vehiculosnortegrandedb.cliente c on r.ClienteRut = c.Rut " +
                                "where c.Rut = '" + rut + "'";
                    conexionBD = new MySqlConnection(cadena);
                    conexionBD.Open();
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Esto solo sirve para asegurarme que la reserva exista 
                        datos = reader.GetString(0);
                    }
                    conexionBD.Close();
                    if (datos == "")
                    {
                        MessageBox.Show("¡Este cliente no tiene reservas!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Formularios.consultaCuatro c4 = new Formularios.consultaCuatro(textBox1.Text);
                    c4.ShowDialog();
                    break;
                case 4:
                    patente = textBox1.Text.ToUpper();

                    consulta = "select * from vehiculosnortegrandedb.vehiculo where vehiculosnortegrandedb.vehiculo.patente = '" + patente + "'";
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        //Me aseguro que la patente ingresada existe
                        datos = reader.GetString(0);
                    }
                    conexionBD.Close();
                    if (datos == "") {
                        MessageBox.Show("¡Vehículo no registrado!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ArrayList numResList = new ArrayList();
                    consulta = "select * from vehiculosnortegrandedb.reserva_vehiculo where patente = '" + patente + "'";
                    conexionBD.Open();
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != "") {
                            numResList.Add(reader.GetString(0));
                        }
                    }
                    conexionBD.Close();
                    if (numResList.Count == 0)
                    {
                        MessageBox.Show("¡Este vehículo no pertenece a ninguna reserva!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    foreach (string numReserva in numResList)
                    {
                        conexionBD = new MySqlConnection(cadena);
                        conexionBD.Open();

                        consulta = "select c.* " +
                                   "from vehiculosnortegrandedb.reserva r join vehiculosnortegrandedb.cliente c on r.clienterut = c.rut " +
                                   "where r.numero_reserva=" + numReserva;

                        cmd = new MySqlCommand(consulta, conexionBD);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            rut = rutFormal(reader.GetString(0));
                            rut2 = rutFormal(reader.GetString(5));

                            datos = "RUT CLIENTE : " + rut + "\n" +
                                    "NOMBRE CLIENTE : " + reader.GetString(1) + "\n" +
                                    "DIRECCIÓN : " + reader.GetString(2) + "\n" +
                                    "TELÉFONO DOMICILIO : " + reader.GetString(3) + "\n" +
                                    "TELÉFONO MÓVIL : " + reader.GetString(4) + "\n" +
                                    "RUT CLIENTE QUE LO ESTA AVALANDO : " + rut2 + "\n"
                                    ;
                        }

                        MessageBox.Show(datos, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        conexionBD.Close();
                    }
                    break;
                case 5:
                    if (textBox1.Text.Length != 9)
                    {
                        return;
                    }
                    rut = textBox1.Text;
                    rut2 = "";

                    consulta = "select c2.* " +
                               "from vehiculosnortegrandedb.cliente c1 join vehiculosnortegrandedb.cliente c2 on c1.clienterut = c2.rut " +
                               "where c1.rut = '" + rut + "';";
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        rut = rutFormal(reader.GetString(0));
                        rut2 = reader.GetString(5);
                        rut2 = rutFormal(rut2);

                        datos = "RUT CLIENTE : " + rut + "\n" +
                                "NOMBRE CLIENTE : " + reader.GetString(1) + "\n" +
                                "DIRECCIÓN : " + reader.GetString(2) + "\n" +
                                "TELÉFONO DOMICILIO : " + reader.GetString(3) + "\n" +
                                "TELÉFONO MÓVIL : " + reader.GetString(4) + "\n" +
                                "RUT CLIENTE QUE LO ESTA AVALANDO : " + rut2 + "\n"
                                ;
                    }
                    conexionBD.Close();
                    if (datos == "")
                    {
                        MessageBox.Show("¡Cliente no registrado!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show(datos, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                default:
                    if (textBox1.Text.Length != 9)
                    {
                        return;
                    }
                    rut = textBox1.Text;
                    rut2 = "";

                    consulta = "select * from vehiculosnortegrandedb.cliente where vehiculosnortegrandedb.cliente.rut =" + rut;
                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        datos = reader.GetString(0);
                    }
                    conexionBD.Close();
                    if (datos == "")
                    {
                        MessageBox.Show("¡Cliente no registrado!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    datos = "";
                    consulta = "select c.rut " +
                               "from vehiculosnortegrandedb.cliente c " +
                               "where c.clienterut ='" + rut + "'";

                    conexionBD = new MySqlConnection(cadena);
                    conexionBD.Open();

                    cmd = new MySqlCommand(consulta, conexionBD);
                    reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        datos = reader.GetString(0);
                    }
                    conexionBD.Close();
                    if (datos == "") {
                        MessageBox.Show("¡Este cliente no ha avalado a ningún otro cliente!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Formularios.consultaSiete cs = new Formularios.consultaSiete(rut);
                    cs.ShowDialog();
                    break;
            }
        }

        private string rutFormal(string rut) {
            
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

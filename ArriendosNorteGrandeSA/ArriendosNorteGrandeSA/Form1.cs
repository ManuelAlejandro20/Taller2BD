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

namespace ArriendosNorteGrandeSA
{
    public partial class Vista1 : Form
    {
        public Vista1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string r = "";
            string cadena = "server=localhost;port=3306;userid=root;password=admin123;database=mysql";
            MySqlConnection conexionBD = new MySqlConnection(cadena);

            conexionBD.Open();
        
            MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", conexionBD);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                r += reader.GetString(0) + "\n";

            }

            MessageBox.Show(r);
        }

        public void showInsert() {

            ToolStripMenuItem cliente = new ToolStripMenuItem("Cliente");
            ToolStripMenuItem vehiculo = new ToolStripMenuItem("Vehículo");
            
            menuStrip1.Items.RemoveAt(3);
            menuStrip1.Items.Add(cliente);
            menuStrip1.Items.Add(vehiculo);
            menuStrip1.Items.Add("Salir", null, salirToolStripMenuItem_Click);

            cliente.DropDownItems.Add("Agregar nuevo cliente", null, agregarClienteToolStripMenuItem_Click);
            cliente.DropDownItems.Add("Eliminar cliente", null, eliminarClienteToolStripMenuItem_Click);
            vehiculo.DropDownItems.Add("Agregar nuevo vehículo", null, agregarVehiculoToolStripMenuItem_Click);
            vehiculo.DropDownItems.Add("Eliminar vehículo", null, eliminarVehiculoToolStripMenuItem_Click);
        }

        private void agregarReservaNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.agregarReserva agregarReserva = new Formularios.agregarReserva();
            agregarReserva.ShowDialog();
        }

        private void eliminarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.eliminarReserva eliminarReserva = new Formularios.eliminarReserva();
            eliminarReserva.ShowDialog();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.consultas consultas = new Formularios.consultas();
            consultas.ShowDialog();
        }

        private void estadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.estadisticas estadisticas = new Formularios.estadisticas();
            estadisticas.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.auth a = new Formularios.auth(this);
            a.ShowDialog();
            
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e) {
            Formularios.agregarCliente ac = new Formularios.agregarCliente();
            ac.ShowDialog();
        }
        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e) {
            Formularios.eliminarCliente ec = new Formularios.eliminarCliente();
            ec.ShowDialog();
        }
        private void agregarVehiculoToolStripMenuItem_Click(object sender, EventArgs e) {
            Formularios.agregarVehiculo av = new Formularios.agregarVehiculo();
            av.ShowDialog();
        }
        private void eliminarVehiculoToolStripMenuItem_Click(object sender, EventArgs e) {
            Formularios.eliminarVehiculo ev = new Formularios.eliminarVehiculo();
            ev.ShowDialog();
        
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Items.RemoveAt(3);
            menuStrip1.Items.RemoveAt(3);
            menuStrip1.Items.RemoveAt(3);
            menuStrip1.Items.Add("Modificar clientes / vehículos", null, insertarToolStripMenuItem_Click);
        }
    }
}

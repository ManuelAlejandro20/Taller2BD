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
    public partial class auth : Form
    {

        private Vista1 vista;

        public auth(Vista1 vista1)
        {
            this.vista = vista1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "localhost"){            
                MessageBox.Show("¡Nombre de server incorrecto!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text != "3306") {
                MessageBox.Show("¡Puerto incorrecto!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox3.Text != "root") {
                MessageBox.Show("¡ID de usuario incorrecto!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox4.Text != "admin123") {
                MessageBox.Show("¡Contraseña incorrecta!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.vista.showInsert();
            this.Close();
        }

        
        

    }
}

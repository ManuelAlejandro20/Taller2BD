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
    }
}

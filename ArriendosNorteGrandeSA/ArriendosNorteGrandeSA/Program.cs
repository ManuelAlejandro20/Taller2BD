using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArriendosNorteGrandeSA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;userid=root;password=admin123;database=mysql");

            connection.Open();
            connection.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Vista1());


            try

            {

                //


            }

            catch (Exception)

            {

                //MessageBox.Show("Error al conectar con la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }



        }
    }
}

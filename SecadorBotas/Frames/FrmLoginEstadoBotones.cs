using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    public partial class FrmLoginEstadoBotones : Form
    {
        public FrmLoginEstadoBotones()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int hora = Convert.ToInt32(DateTime.Now.Hour);//En la variable se almacena la hora actual.
            string Fish = "FishKen";
            string Contrasena = hora + Fish;

            if (txtPass.Text != "")
            {

                if (txtPass.Text == Contrasena)
                {

                    lblAdvertenciaPass.Text = "";
                    Properties.Settings.Default.Bandera1ONOFF = "off";
                    Properties.Settings.Default.Bandera2ONOFF = "off";
                    Properties.Settings.Default.Bandera3ONOFF = "off";
                    Properties.Settings.Default.Bandera4ONOFF = "off";
                    Properties.Settings.Default.Bandera5ONOFF = "off";
                    Properties.Settings.Default.Bandera6ONOFF = "off";
                    Properties.Settings.Default.Bandera7ONOFF = "off";

                    Properties.Settings.Default.Save();

                    MessageBox.Show("Estados de botones establecido en off, vuelve para continuar!");
                }

                else
                {
                    lblAdvertenciaPass.Text = "Contrasena incorrecta";
                }
            }
            else
            {

                lblAdvertenciaPass.Text = "Ingrese contrasena";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath);
        }
    }
}

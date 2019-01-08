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
    public partial class FrmLoginAyudaInstalacion : Form
    {
        public FrmLoginAyudaInstalacion()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    MessageBox.Show("PASOS PARA INSTALACION:\n\n\n 1) Configurar IP de tarjetas, deben estar en el mismo segmento que el pc\n\n 2) Configurar parámetros de tarjetas\n\n 3) Establecer botones en OFF\n\n 4) Solo habilite secadores conectados a la red\n\n\n  VUELVA PARA CONTINUAR!!");
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
    }
}

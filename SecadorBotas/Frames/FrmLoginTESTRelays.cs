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
    public partial class FrmLoginTESTRelays : Form
    {
        public FrmLoginTESTRelays()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 formtServicioSec = new Form1();
            formtServicioSec.Show();
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
                    Frames.FrmTESTRelays formtTESTRelays = new Frames.FrmTESTRelays();
                    formtTESTRelays.Show();
                    this.Close();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

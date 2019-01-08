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
    public partial class FrmPassAccesoGeneral : Form
    {
        public FrmPassAccesoGeneral()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {


            
        }

        private void btnVolver_Click(object sender, EventArgs e)
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
            Frames.FrmSecadores formt1 = new Frames.FrmSecadores();
            formt1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string Contrasena = txtPass.Text;

            if (Contrasena != "")
            {
                Properties.Settings.Default.PASSGENERAL = Contrasena.ToString();
                Properties.Settings.Default.Save();
                MessageBox.Show( "Contraseña creada, vuelva para continuar!");
            }

            else
            {
                lblAdvertenciaPass.Text = "Ingrese contrasena";
            }
        }
    }

}

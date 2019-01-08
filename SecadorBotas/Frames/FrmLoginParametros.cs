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
    public partial class FrmLoginParametros : Form
    {
        public FrmLoginParametros()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
         
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath); 
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 formtServicioTarj1 = new Form1();
            formtServicioTarj1.Show();
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
                    Frames.FrmConfigParametros formtConfigParametros = new Frames.FrmConfigParametros();
                    formtConfigParametros.Show();
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
    }
}

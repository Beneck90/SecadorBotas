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
    public partial class FrmLoginEstado5 : Form
    {
        public FrmLoginEstado5()
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
            //Llama teclado
            System.Diagnostics.Process.Start("C:\\Program Files\\HotVirtualKeyboard\\hvk.exe");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int hora = Convert.ToInt32(DateTime.Now.Hour);//En la variable se almacena la hora actual.
            string Fish = "FishKen";
            string Contrasena = hora + Fish;
            string ContrasenaGeneral = Properties.Settings.Default.PASSGENERAL;

            if (txtPass.Text != "")
            {

                if (txtPass.Text == Contrasena || txtPass.Text == ContrasenaGeneral)
                {
                    Frames.FrmMenuServicioTarj5 formtServTar5 = new Frames.FrmMenuServicioTarj5();
                    formtServTar5.Show();
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


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta5 formtServTar5 = new Frames.FrmTarjeta5();
            formtServTar5.Show();
            this.Close();
        }
    }
}

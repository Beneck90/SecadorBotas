using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SecadorBotas.Frames
{
    public partial class FrmLoginEstado1 : Form
    {

        //comienza en apagado.
        int estado = 0;

        /*Isntancia de la clase Relay*/
        Clases.Relay R = new Clases.Relay();

        public FrmLoginEstado1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
          
        }

        
        

        private void FrmLoginEstado1_Load(object sender, EventArgs e)
        {

            
        }

        private void txtPass_TextChanged(object sender, System.EventArgs e)
        {
            
           
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, System.EventArgs e)
        {
            Frames.FrmTarjeta1 formtServTar1 = new Frames.FrmTarjeta1();
            formtServTar1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            int hora = Convert.ToInt32(DateTime.Now.Hour);//En la variable se almacena la hora actual.
            string Fish = "FishKen";
            string Contrasena = hora + Fish;
            string ContrasenaGeneral = Properties.Settings.Default.PASSGENERAL;

            if (txtPass.Text != "")
            {

                if (txtPass.Text == Contrasena || txtPass.Text == ContrasenaGeneral)
                {
                    Frames.FrmMenuServicioTarj1 formtServTar1 = new Frames.FrmMenuServicioTarj1();
                    formtServTar1.Show();
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

        private void pictureBox2_Click(object sender, System.EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath); 
        }
    }
}

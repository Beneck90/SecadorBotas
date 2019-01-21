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
    public partial class FrmLoginPeriodoActiv2 : Form
    {
        public FrmLoginPeriodoActiv2()
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
            string ContrasenaGeneral = Properties.Settings.Default.PASSGENERAL;

            if (txtPass.Text != "")
            {

                if (txtPass.Text == Contrasena || txtPass.Text == ContrasenaGeneral)
                {
                    Frames.FrmConfPeriodoActividad2 formt1 = new FrmConfPeriodoActividad2();
                    formt1.Show();
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

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
    public partial class FrmConfServTar2 : Form
    {
        public FrmConfServTar2()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEstablecer_Click(object sender, EventArgs e)
        {
           
        }

        public bool isInt32(String num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }



        private void FrmConfServTar2_Load(object sender, EventArgs e)
        {
            txtHrsMaxUV2.Text = Properties.Settings.Default.HMUV2.ToString();
            txtHrsMaxMotor2.Text = Properties.Settings.Default.HMM2.ToString();
            txtHrsMaxCalefactor2.Text = Properties.Settings.Default.HMC2.ToString();
            txtTempMax2.Text = Properties.Settings.Default.TempMax2.ToString();
            txtTiempoUVon2.Text = Properties.Settings.Default.TUVON2.ToString();
            txtTiempoUVoff2.Text = Properties.Settings.Default.TUVOFF2.ToString();
            txtemailInicio2.Text = Properties.Settings.Default.EMAIL2Parte1;
            txtemailFinal2.Text = Properties.Settings.Default.EMAIL2Parte2;
        }

        private void btnResetUV_Click(object sender, EventArgs e)
        {
            //Confirmación para guardar cambios
            DialogResult oDlgRes;

            oDlgRes = MessageBox.Show("Está seguro que dese resetear UV", "ADVERTENCIA",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (oDlgRes == DialogResult.Yes)
            {

                int Ano = DateTime.Now.Year;
                int Mes = DateTime.Now.Month;
                int Dia = DateTime.Now.Day;
                int Hrs = DateTime.Now.Hour;
                int Min = DateTime.Now.Minute;
                int Seg = DateTime.Now.Second;

                //Guarda fecha actual
                Properties.Settings.Default.AnoUVDos = Ano;
                Properties.Settings.Default.MesUVDos = Mes;
                Properties.Settings.Default.DiaUVDos = Dia;
                Properties.Settings.Default.HoraUVDos = Hrs;
                Properties.Settings.Default.MinUVDos = Min;
                Properties.Settings.Default.SegUVDos = Seg;

                //Establece horas de funcionamiento UV en 0
                Properties.Settings.Default.HorasUV2 = 0;

                Properties.Settings.Default.Save();

                lblMsjUV.Text = "UV restablecido";
            }
            else
            {


            }
        }

        private void btnResetMotor_Click(object sender, EventArgs e)
        {
            //Confirmación para guardar cambios
            DialogResult oDlgRes;

            oDlgRes = MessageBox.Show("Está seguro que dese resetear ventilador", "ADVERTENCIA",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (oDlgRes == DialogResult.Yes)
            {

                int Ano = DateTime.Now.Year;
                int Mes = DateTime.Now.Month;
                int Dia = DateTime.Now.Day;
                int Hrs = DateTime.Now.Hour;
                int Min = DateTime.Now.Minute;
                int Seg = DateTime.Now.Second;

                //Guarda fecha actual
                Properties.Settings.Default.AnoVentDos = Ano;
                Properties.Settings.Default.MesVentDos = Mes;
                Properties.Settings.Default.DiaVentDos = Dia;
                Properties.Settings.Default.HoraVentDos = Hrs;
                Properties.Settings.Default.MinVentDos = Min;
                Properties.Settings.Default.SegVentDos = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent2 = 0;

                Properties.Settings.Default.Save();

                lblMsjVent.Text = "Ventilador restablecido";
            }
            else
            {


            }
        }

        private void btnResetCalefactor_Click(object sender, EventArgs e)
        {
            //Confirmación para guardar cambios
            DialogResult oDlgRes;

            oDlgRes = MessageBox.Show("Está seguro que dese resetear calefactor", "ADVERTENCIA",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (oDlgRes == DialogResult.Yes)
            {

                int Ano = DateTime.Now.Year;
                int Mes = DateTime.Now.Month;
                int Dia = DateTime.Now.Day;
                int Hrs = DateTime.Now.Hour;
                int Min = DateTime.Now.Minute;
                int Seg = DateTime.Now.Second;

                //Guarda fecha actual
                Properties.Settings.Default.AnoCalefactorDos = Ano;
                Properties.Settings.Default.MesCalefactorDos = Mes;
                Properties.Settings.Default.DiaCalefactorDos = Dia;
                Properties.Settings.Default.HoraCalefactorDos = Hrs;
                Properties.Settings.Default.MinCalefactorDos = Min;
                Properties.Settings.Default.SegCalefactorDos = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor2 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV2_TextChanged(object sender, EventArgs e)
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

            Frames.FrmConfigParametros formConfig = new Frames.FrmConfigParametros();
            formConfig.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtHrsMaxUV2.Text != "" && txtHrsMaxMotor2.Text != "" && txtHrsMaxCalefactor2.Text != "" && txtTiempoUVon2.Text != "" && txtTiempoUVoff2.Text != "" && txtTempMax2.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV2.Text);
                bool vfVent = isInt32(txtHrsMaxMotor2.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor2.Text);
                bool vfUVon = isInt32(txtTiempoUVon2.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff2.Text);
                bool vfTempMaxCalef = isInt32(txtTempMax2.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV2 = Convert.ToInt32(txtHrsMaxUV2.Text);
                    Properties.Settings.Default.HMM2 = Convert.ToInt32(txtHrsMaxMotor2.Text);
                    Properties.Settings.Default.HMC2 = Convert.ToInt32(txtHrsMaxCalefactor2.Text);
                    Properties.Settings.Default.TUVON2 = Convert.ToInt32(txtTiempoUVon2.Text);
                    Properties.Settings.Default.TUVOFF2 = Convert.ToInt32(txtTiempoUVoff2.Text);
                    Properties.Settings.Default.EMAIL2Parte1 = txtemailInicio2.Text;
                    Properties.Settings.Default.EMAIL2Parte2 = txtemailFinal2.Text;
                    Properties.Settings.Default.TempMax2 = Convert.ToInt32(txtTempMax2.Text);
                    Properties.Settings.Default.Save();

                    /*Mensaje...*/
                    lblValidator.Text = "Valores ingresados correctamente";
                }
                else
                {
                    lblValidator.Text = "Ingrese solo numeros enteros";

                }
            }
            else//Si no se ingresa valor...
            {
                /*Mensaje...*/
                lblValidator.Text = "Ingrese todos los campos por favor";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoUVDos;
            int mes = Properties.Settings.Default.MesUVDos;
            int dia = Properties.Settings.Default.DiaUVDos;

            int hrs = Properties.Settings.Default.HoraUVDos;
            int mins = Properties.Settings.Default.MinUVDos;
            int sgds = Properties.Settings.Default.SegUVDos;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVentDos;
            int mes = Properties.Settings.Default.MesVentDos;
            int dia = Properties.Settings.Default.DiaVentDos;

            int hrs = Properties.Settings.Default.HoraVentDos;
            int mins = Properties.Settings.Default.MinVentDos;
            int sgds = Properties.Settings.Default.SegVentDos;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactorDos;
            int mes = Properties.Settings.Default.MesCalefactorDos;
            int dia = Properties.Settings.Default.DiaCalefactorDos;

            int hrs = Properties.Settings.Default.HoraCalefactorDos;
            int mins = Properties.Settings.Default.MinCalefactorDos;
            int sgds = Properties.Settings.Default.SegCalefactorDos;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }
    }
}

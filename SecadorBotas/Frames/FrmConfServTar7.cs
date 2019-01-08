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
    public partial class FrmConfServTar7 : Form
    {
        public FrmConfServTar7()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
           
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
                Properties.Settings.Default.AnoUVSiete = Ano;
                Properties.Settings.Default.MesUVSiete = Mes;
                Properties.Settings.Default.DiaUVSiete = Dia;
                Properties.Settings.Default.HoraUVSiete = Hrs;
                Properties.Settings.Default.MinUVSiete = Min;
                Properties.Settings.Default.SegUVSiete = Seg;

                //Establece horas de funcionamiento UV en 0
                Properties.Settings.Default.HorasUV7 = 0;

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
                Properties.Settings.Default.AnoVentSiete = Ano;
                Properties.Settings.Default.MesVentSiete = Mes;
                Properties.Settings.Default.DiaVentSiete = Dia;
                Properties.Settings.Default.HoraVentSiete = Hrs;
                Properties.Settings.Default.MinVentSiete = Min;
                Properties.Settings.Default.SegVentSiete = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent7 = 0;

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
                Properties.Settings.Default.AnoCalefactorSiete = Ano;
                Properties.Settings.Default.MesCalefactorSiete = Mes;
                Properties.Settings.Default.DiaCalefactorSiete = Dia;
                Properties.Settings.Default.HoraCalefactorSiete = Hrs;
                Properties.Settings.Default.MinCalefactorSiete = Min;
                Properties.Settings.Default.SegCalefactorSiete = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor7 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV7_TextChanged(object sender, EventArgs e)
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

            Frames.FrmConfigParametros formConfig = new Frames.FrmConfigParametros();
            formConfig.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtHrsMaxUV7.Text != "" && txtHrsMaxMotor7.Text != "" && txtHrsMaxCalefactor7.Text != "" && txtTiempoUVon7.Text != "" && txtTiempoUVoff7.Text != "" && txtTempMax7.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV7.Text);
                bool vfVent = isInt32(txtHrsMaxMotor7.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor7.Text);
                bool vfUVon = isInt32(txtTiempoUVon7.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff7.Text);
                bool vfTempMaxCalef = isInt32(txtTempMax7.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV7 = Convert.ToInt32(txtHrsMaxUV7.Text);
                    Properties.Settings.Default.HMM7 = Convert.ToInt32(txtHrsMaxMotor7.Text);
                    Properties.Settings.Default.HMC7 = Convert.ToInt32(txtHrsMaxCalefactor7.Text);
                    Properties.Settings.Default.TUVON7 = Convert.ToInt32(txtTiempoUVon7.Text);
                    Properties.Settings.Default.TUVOFF7 = Convert.ToInt32(txtTiempoUVoff7.Text);
                    Properties.Settings.Default.EMAIL7Parte1 = txtemailInicio7.Text;
                    Properties.Settings.Default.EMAIL7Parte2 = txtemailFinal7.Text;
                    Properties.Settings.Default.TempMax7 = Convert.ToInt32(txtTempMax7.Text);
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

        private void FrmConfServTar7_Load(object sender, EventArgs e)
        {
            txtHrsMaxUV7.Text = Properties.Settings.Default.HMUV7.ToString();
            txtHrsMaxMotor7.Text = Properties.Settings.Default.HMM7.ToString();
            txtHrsMaxCalefactor7.Text = Properties.Settings.Default.HMC7.ToString();
            txtTempMax7.Text = Properties.Settings.Default.TempMax7.ToString();
            txtTiempoUVon7.Text = Properties.Settings.Default.TUVON7.ToString();
            txtTiempoUVoff7.Text = Properties.Settings.Default.TUVOFF7.ToString();
            txtemailInicio7.Text = Properties.Settings.Default.EMAIL7Parte1;
            txtemailFinal7.Text = Properties.Settings.Default.EMAIL7Parte2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoUVSiete;
            int mes = Properties.Settings.Default.MesUVSiete;
            int dia = Properties.Settings.Default.DiaUVSiete;

            int hrs = Properties.Settings.Default.HoraUVSiete;
            int mins = Properties.Settings.Default.MinUVSiete;
            int sgds = Properties.Settings.Default.SegUVSiete;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVentSiete;
            int mes = Properties.Settings.Default.MesVentSiete;
            int dia = Properties.Settings.Default.DiaVentSiete;

            int hrs = Properties.Settings.Default.HoraVentSiete;
            int mins = Properties.Settings.Default.MinVentSiete;
            int sgds = Properties.Settings.Default.SegVentSiete;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactorSiete;
            int mes = Properties.Settings.Default.MesCalefactorSiete;
            int dia = Properties.Settings.Default.DiaCalefactorSiete;

            int hrs = Properties.Settings.Default.HoraCalefactorSiete;
            int mins = Properties.Settings.Default.MinCalefactorSiete;
            int sgds = Properties.Settings.Default.SegCalefactorSiete;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }
    }
}

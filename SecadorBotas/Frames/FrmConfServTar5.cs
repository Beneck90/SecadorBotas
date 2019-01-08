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
    public partial class FrmConfServTar5 : Form
    {
        public FrmConfServTar5()
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

        private void btnEstablecer_Click(object sender, EventArgs e)
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
                Properties.Settings.Default.AnoUVCinco = Ano;
                Properties.Settings.Default.MesUVCinco = Mes;
                Properties.Settings.Default.DiaUVCinco = Dia;
                Properties.Settings.Default.HoraUVCinco = Hrs;
                Properties.Settings.Default.MinUVCinco = Min;
                Properties.Settings.Default.SegUVCinco = Seg;

                //Establece horas de funcionamiento UV en 0
                Properties.Settings.Default.HorasUV5 = 0;

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
                Properties.Settings.Default.AnoVentCinco = Ano;
                Properties.Settings.Default.MesVentCinco = Mes;
                Properties.Settings.Default.DiaVentCinco = Dia;
                Properties.Settings.Default.HoraVentCinco = Hrs;
                Properties.Settings.Default.MinVentCinco = Min;
                Properties.Settings.Default.SegVentCinco = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent5 = 0;

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
                Properties.Settings.Default.AnoCalefactorCinco = Ano;
                Properties.Settings.Default.MesCalefactorCinco = Mes;
                Properties.Settings.Default.DiaCalefactorCinco = Dia;
                Properties.Settings.Default.HoraCalefactorCinco = Hrs;
                Properties.Settings.Default.MinCalefactorCinco = Min;
                Properties.Settings.Default.SegCalefactorCinco = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor5 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV5_TextChanged(object sender, EventArgs e)
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
            if (txtHrsMaxUV5.Text != "" && txtHrsMaxMotor5.Text != "" && txtHrsMaxCalefactor5.Text != "" && txtTiempoUVon5.Text != "" && txtTiempoUVoff5.Text != "" && txtTempMax5.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV5.Text);
                bool vfVent = isInt32(txtHrsMaxMotor5.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor5.Text);
                bool vfUVon = isInt32(txtTiempoUVon5.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff5.Text);
                bool vfTempMaxCalef = isInt32(txtTempMax5.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV5 = Convert.ToInt32(txtHrsMaxUV5.Text);
                    Properties.Settings.Default.HMM5 = Convert.ToInt32(txtHrsMaxMotor5.Text);
                    Properties.Settings.Default.HMC5 = Convert.ToInt32(txtHrsMaxCalefactor5.Text);
                    Properties.Settings.Default.TUVON5 = Convert.ToInt32(txtTiempoUVon5.Text);
                    Properties.Settings.Default.TUVOFF5 = Convert.ToInt32(txtTiempoUVoff5.Text);
                    Properties.Settings.Default.EMAIL5Parte1 = txtemailInicio5.Text;
                    Properties.Settings.Default.EMAIL5Parte2 = txtemailFinal5.Text;
                    Properties.Settings.Default.TempMax5 = Convert.ToInt32(txtTempMax5.Text);
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

        private void FrmConfServTar5_Load(object sender, EventArgs e)
        {
            txtHrsMaxUV5.Text = Properties.Settings.Default.HMUV5.ToString();
            txtHrsMaxMotor5.Text = Properties.Settings.Default.HMM5.ToString();
            txtHrsMaxCalefactor5.Text = Properties.Settings.Default.HMC5.ToString();
            txtTempMax5.Text = Properties.Settings.Default.TempMax5.ToString();
            txtTiempoUVon5.Text = Properties.Settings.Default.TUVON5.ToString();
            txtTiempoUVoff5.Text = Properties.Settings.Default.TUVOFF5.ToString();
            txtemailInicio5.Text = Properties.Settings.Default.EMAIL5Parte1;
            txtemailFinal5.Text = Properties.Settings.Default.EMAIL5Parte2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoUVCinco;
            int mes = Properties.Settings.Default.MesUVCinco;
            int dia = Properties.Settings.Default.DiaUVCinco;

            int hrs = Properties.Settings.Default.HoraUVCinco;
            int mins = Properties.Settings.Default.MinUVCinco;
            int sgds = Properties.Settings.Default.SegUVCinco;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVentCinco;
            int mes = Properties.Settings.Default.MesVentCinco;
            int dia = Properties.Settings.Default.DiaVentCinco;

            int hrs = Properties.Settings.Default.HoraVentCinco;
            int mins = Properties.Settings.Default.MinVentCinco;
            int sgds = Properties.Settings.Default.SegVentCinco;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactorCinco;
            int mes = Properties.Settings.Default.MesCalefactorCinco;
            int dia = Properties.Settings.Default.DiaCalefactorCinco;

            int hrs = Properties.Settings.Default.HoraCalefactorCinco;
            int mins = Properties.Settings.Default.MinCalefactorCinco;
            int sgds = Properties.Settings.Default.SegCalefactorCinco;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }
    }
}

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
    public partial class FrmConfServTar3 : Form
    {
        public FrmConfServTar3()
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
                Properties.Settings.Default.AnoUVTres = Ano;
                Properties.Settings.Default.MesUVTres = Mes;
                Properties.Settings.Default.DiaUVTres = Dia;
                Properties.Settings.Default.HoraUVTres = Hrs;
                Properties.Settings.Default.MinUVTres = Min;
                Properties.Settings.Default.SegUVTres = Seg;

                //Establece horas de funcionamiento UV en 0
                Properties.Settings.Default.HorasUV3 = 0;

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
                Properties.Settings.Default.AnoVentTres = Ano;
                Properties.Settings.Default.MesVentTres = Mes;
                Properties.Settings.Default.DiaVentTres = Dia;
                Properties.Settings.Default.HoraVentTres = Hrs;
                Properties.Settings.Default.MinVentTres = Min;
                Properties.Settings.Default.SegVentTres = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent3 = 0;

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
                Properties.Settings.Default.AnoCalefactorTres = Ano;
                Properties.Settings.Default.MesCalefactorTres = Mes;
                Properties.Settings.Default.DiaCalefactorTres = Dia;
                Properties.Settings.Default.HoraCalefactorTres = Hrs;
                Properties.Settings.Default.MinCalefactorTres = Min;
                Properties.Settings.Default.SegCalefactorTres = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor3 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV3_TextChanged(object sender, EventArgs e)
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

            if (txtHrsMaxUV3.Text != "" && txtHrsMaxMotor3.Text != "" && txtHrsMaxCalefactor3.Text != "" && txtTiempoUVon3.Text != "" && txtTiempoUVoff3.Text != "" && txtTempMax3.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV3.Text);
                bool vfVent = isInt32(txtHrsMaxMotor3.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor3.Text);
                bool vfUVon = isInt32(txtTiempoUVon3.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff3.Text);
                bool vfTempMaxCalef = isInt32(txtTempMax3.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV3 = Convert.ToInt32(txtHrsMaxUV3.Text);
                    Properties.Settings.Default.HMM3 = Convert.ToInt32(txtHrsMaxMotor3.Text);
                    Properties.Settings.Default.HMC3 = Convert.ToInt32(txtHrsMaxCalefactor3.Text);
                    Properties.Settings.Default.TUVON3 = Convert.ToInt32(txtTiempoUVon3.Text);
                    Properties.Settings.Default.TUVOFF3 = Convert.ToInt32(txtTiempoUVoff3.Text);
                    Properties.Settings.Default.EMAIL3Parte1 = txtemailInicio3.Text;
                    Properties.Settings.Default.EMAIL3Parte2 = txtemailFinal3.Text;
                    Properties.Settings.Default.TempMax3 = Convert.ToInt32(txtTempMax3.Text);
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

        private void FrmConfServTar3_Load(object sender, EventArgs e)
        {
            txtHrsMaxUV3.Text = Properties.Settings.Default.HMUV3.ToString();
            txtHrsMaxMotor3.Text = Properties.Settings.Default.HMM3.ToString();
            txtHrsMaxCalefactor3.Text = Properties.Settings.Default.HMC3.ToString();
            txtTempMax3.Text = Properties.Settings.Default.TempMax3.ToString();
            txtTiempoUVon3.Text = Properties.Settings.Default.TUVON3.ToString();
            txtTiempoUVoff3.Text = Properties.Settings.Default.TUVOFF3.ToString();
            txtemailInicio3.Text = Properties.Settings.Default.EMAIL3Parte1;
            txtemailFinal3.Text = Properties.Settings.Default.EMAIL3Parte2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoUVTres;
            int mes = Properties.Settings.Default.MesUVTres;
            int dia = Properties.Settings.Default.DiaUVTres;

            int hrs = Properties.Settings.Default.HoraUVTres;
            int mins = Properties.Settings.Default.MinUVTres;
            int sgds = Properties.Settings.Default.SegUVTres;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVentTres;
            int mes = Properties.Settings.Default.MesVentTres;
            int dia = Properties.Settings.Default.DiaVentTres;

            int hrs = Properties.Settings.Default.HoraVentTres;
            int mins = Properties.Settings.Default.MinVentTres;
            int sgds = Properties.Settings.Default.SegVentTres;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactorTres;
            int mes = Properties.Settings.Default.MesCalefactorTres;
            int dia = Properties.Settings.Default.DiaCalefactorTres;

            int hrs = Properties.Settings.Default.HoraCalefactorTres;
            int mins = Properties.Settings.Default.MinCalefactorTres;
            int sgds = Properties.Settings.Default.SegCalefactorTres;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }
    }
}

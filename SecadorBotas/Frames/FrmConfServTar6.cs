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
    public partial class FrmConfServTar6 : Form
    {
        public FrmConfServTar6()
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
                Properties.Settings.Default.AnoUVSeis = Ano;
                Properties.Settings.Default.MesUVSeis = Mes;
                Properties.Settings.Default.DiaUVSeis = Dia;
                Properties.Settings.Default.HoraUVSeis = Hrs;
                Properties.Settings.Default.MinUVSeis = Min;
                Properties.Settings.Default.SegUVSeis = Seg;

                //Establece horas de funcionamiento UV en 0
                Properties.Settings.Default.HorasUV6 = 0;

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
                Properties.Settings.Default.AnoVentSeis = Ano;
                Properties.Settings.Default.MesVentSeis = Mes;
                Properties.Settings.Default.DiaVentSeis = Dia;
                Properties.Settings.Default.HoraVentSeis = Hrs;
                Properties.Settings.Default.MinVentSeis = Min;
                Properties.Settings.Default.SegVentSeis = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent6 = 0;

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
                Properties.Settings.Default.AnoCalefactorSeis = Ano;
                Properties.Settings.Default.MesCalefactorSeis = Mes;
                Properties.Settings.Default.DiaCalefactorSeis = Dia;
                Properties.Settings.Default.HoraCalefactorSeis = Hrs;
                Properties.Settings.Default.MinCalefactorSeis = Min;
                Properties.Settings.Default.SegCalefactorSeis = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor6 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Frames.FrmConfigParametros formConfig = new Frames.FrmConfigParametros();
            formConfig.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtHrsMaxUV6.Text != "" && txtHrsMaxMotor6.Text != "" && txtHrsMaxCalefactor6.Text != "" && txtTiempoUVon6.Text != "" && txtTiempoUVoff6.Text != "" && txtTempMax6.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV6.Text);
                bool vfVent = isInt32(txtHrsMaxMotor6.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor6.Text);
                bool vfUVon = isInt32(txtTiempoUVon6.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff6.Text);
                bool vfTempMaxCalef = isInt32(txtTempMax6.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV6 = Convert.ToInt32(txtHrsMaxUV6.Text);
                    Properties.Settings.Default.HMM6 = Convert.ToInt32(txtHrsMaxMotor6.Text);
                    Properties.Settings.Default.HMC6 = Convert.ToInt32(txtHrsMaxCalefactor6.Text);
                    Properties.Settings.Default.TUVON6 = Convert.ToInt32(txtTiempoUVon6.Text);
                    Properties.Settings.Default.TUVOFF6 = Convert.ToInt32(txtTiempoUVoff6.Text);
                    Properties.Settings.Default.EMAIL6Parte1 = txtemailInicio6.Text;
                    Properties.Settings.Default.EMAIL6Parte2 = txtemailFinal6.Text;
                    Properties.Settings.Default.TempMax6 = Convert.ToInt32(txtTempMax6.Text);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath); 
        }

        private void FrmConfServTar6_Load(object sender, EventArgs e)
        {
            txtHrsMaxUV6.Text = Properties.Settings.Default.HMUV6.ToString();
            txtHrsMaxMotor6.Text = Properties.Settings.Default.HMM6.ToString();
            txtHrsMaxCalefactor6.Text = Properties.Settings.Default.HMC6.ToString();
            txtTempMax6.Text = Properties.Settings.Default.TempMax6.ToString();
            txtTiempoUVon6.Text = Properties.Settings.Default.TUVON6.ToString();
            txtTiempoUVoff6.Text = Properties.Settings.Default.TUVOFF6.ToString();
            txtemailInicio6.Text = Properties.Settings.Default.EMAIL6Parte1;
            txtemailFinal6.Text = Properties.Settings.Default.EMAIL6Parte2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoUVSeis;
            int mes = Properties.Settings.Default.MesUVSeis;
            int dia = Properties.Settings.Default.DiaUVSeis;

            int hrs = Properties.Settings.Default.HoraUVSeis;
            int mins = Properties.Settings.Default.MinUVSeis;
            int sgds = Properties.Settings.Default.SegUVSeis;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVentSeis;
            int mes = Properties.Settings.Default.MesVentSeis;
            int dia = Properties.Settings.Default.DiaVentSeis;

            int hrs = Properties.Settings.Default.HoraVentSeis;
            int mins = Properties.Settings.Default.MinVentSeis;
            int sgds = Properties.Settings.Default.SegVentSeis;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactorSeis;
            int mes = Properties.Settings.Default.MesCalefactorSeis;
            int dia = Properties.Settings.Default.DiaCalefactorSeis;

            int hrs = Properties.Settings.Default.HoraCalefactorSeis;
            int mins = Properties.Settings.Default.MinCalefactorSeis;
            int sgds = Properties.Settings.Default.SegCalefactorSeis;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }
    }
}

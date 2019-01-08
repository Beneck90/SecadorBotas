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
    public partial class FrmConfServTar4 : Form
    {
        public FrmConfServTar4()
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
                Properties.Settings.Default.AnoUVCuatro = Ano;
                Properties.Settings.Default.MesUVCuatro = Mes;
                Properties.Settings.Default.DiaUVCuatro = Dia;
                Properties.Settings.Default.HoraUVCuatro = Hrs;
                Properties.Settings.Default.MinUVCuatro = Min;
                Properties.Settings.Default.SegUVCuatro = Seg;

                //Establece horas de funcionamiento UV en 0
                Properties.Settings.Default.HorasUV4 = 0;

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
                Properties.Settings.Default.AnoVentCuatro = Ano;
                Properties.Settings.Default.MesVentCuatro = Mes;
                Properties.Settings.Default.DiaVentCuatro = Dia;
                Properties.Settings.Default.HoraVentCuatro = Hrs;
                Properties.Settings.Default.MinVentCuatro = Min;
                Properties.Settings.Default.SegVentCuatro = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent4 = 0;

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
                Properties.Settings.Default.AnoCalefactorCuatro = Ano;
                Properties.Settings.Default.MesCalefactorCuatro = Mes;
                Properties.Settings.Default.DiaCalefactorCuatro = Dia;
                Properties.Settings.Default.HoraCalefactorCuatro = Hrs;
                Properties.Settings.Default.MinCalefactorCuatro = Min;
                Properties.Settings.Default.SegCalefactorCuatro = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor4 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV4_TextChanged(object sender, EventArgs e)
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
            if (txtHrsMaxUV4.Text != "" && txtHrsMaxMotor4.Text != "" && txtHrsMaxCalefactor4.Text != "" && txtTiempoUVon4.Text != "" && txtTiempoUVoff4.Text != "" && txtTempMax4.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV4.Text);
                bool vfVent = isInt32(txtHrsMaxMotor4.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor4.Text);
                bool vfUVon = isInt32(txtTiempoUVon4.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff4.Text);
                bool vfTempMaxCalef = isInt32(txtTempMax4.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV4 = Convert.ToInt32(txtHrsMaxUV4.Text);
                    Properties.Settings.Default.HMM4 = Convert.ToInt32(txtHrsMaxMotor4.Text);
                    Properties.Settings.Default.HMC4 = Convert.ToInt32(txtHrsMaxCalefactor4.Text);
                    Properties.Settings.Default.TUVON4 = Convert.ToInt32(txtTiempoUVon4.Text);
                    Properties.Settings.Default.TUVOFF4 = Convert.ToInt32(txtTiempoUVoff4.Text);
                    Properties.Settings.Default.EMAIL4Parte1 = txtemailInicio4.Text;
                    Properties.Settings.Default.EMAIL4Parte2 = txtemailFinal4.Text;
                    Properties.Settings.Default.TempMax4 = Convert.ToInt32(txtTempMax4.Text);
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

        private void FrmConfServTar4_Load(object sender, EventArgs e)
        {
            txtHrsMaxUV4.Text = Properties.Settings.Default.HMUV4.ToString();
            txtHrsMaxMotor4.Text = Properties.Settings.Default.HMM4.ToString();
            txtHrsMaxCalefactor4.Text = Properties.Settings.Default.HMC4.ToString();
            txtTempMax4.Text = Properties.Settings.Default.TempMax4.ToString();
            txtTiempoUVon4.Text = Properties.Settings.Default.TUVON4.ToString();
            txtTiempoUVoff4.Text = Properties.Settings.Default.TUVOFF4.ToString();
            txtemailInicio4.Text = Properties.Settings.Default.EMAIL4Parte1;
            txtemailFinal4.Text = Properties.Settings.Default.EMAIL4Parte2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoUVCuatro;
            int mes = Properties.Settings.Default.MesUVCuatro;
            int dia = Properties.Settings.Default.DiaUVCuatro;

            int hrs = Properties.Settings.Default.HoraUVCuatro;
            int mins = Properties.Settings.Default.MinUVCuatro;
            int sgds = Properties.Settings.Default.SegUVCuatro;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVentCuatro;
            int mes = Properties.Settings.Default.MesVentCuatro;
            int dia = Properties.Settings.Default.DiaVentCuatro;

            int hrs = Properties.Settings.Default.HoraVentCuatro;
            int mins = Properties.Settings.Default.MinVentCuatro;
            int sgds = Properties.Settings.Default.SegVentCuatro;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactorCuatro;
            int mes = Properties.Settings.Default.MesCalefactorCuatro;
            int dia = Properties.Settings.Default.DiaCalefactorCuatro;

            int hrs = Properties.Settings.Default.HoraCalefactorCuatro;
            int mins = Properties.Settings.Default.MinCalefactorCuatro;
            int sgds = Properties.Settings.Default.SegCalefactorCuatro;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }
    }
}

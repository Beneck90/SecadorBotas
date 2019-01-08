using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    public partial class FrmConfServTar1 : Form
    {
        public FrmConfServTar1()
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


        private void FrmConfServTar1_Load(object sender, EventArgs e)
        {

            txtHrsMaxUV.Text = Properties.Settings.Default.HMUV1.ToString();
            txtHrsMaxMotor.Text = Properties.Settings.Default.HMM1.ToString();
            txtHrsMaxCalefactor.Text = Properties.Settings.Default.HMC1.ToString();
            TempMaxCalef.Text = Properties.Settings.Default.TempMax1.ToString();
            txtTiempoUVon.Text = Properties.Settings.Default.TUVON1.ToString();
            txtTiempoUVoff.Text = Properties.Settings.Default.TUVOFF1.ToString();
            txtemailInicio.Text = Properties.Settings.Default.EMAIL1Parte1;
            txtemailFinal.Text = Properties.Settings.Default.EMAIL1Parte2;

        }

        private void btnResetUV_Click(object sender, EventArgs e)
        {  
            //Confirmación para guardar cambios
             DialogResult oDlgRes;

             oDlgRes= MessageBox.Show("Está seguro que dese resetear UV","ADVERTENCIA",
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
                 Properties.Settings.Default.AnoUV = Ano;
                 Properties.Settings.Default.MesUV = Mes;
                 Properties.Settings.Default.DiaUV = Dia;
                 Properties.Settings.Default.HoraUV = Hrs;
                 Properties.Settings.Default.MinUV = Min;
                 Properties.Settings.Default.SegUV = Seg;

                 //Establece horas de funcionamiento UV en 0
                 Properties.Settings.Default.HorasUV1 = 0;
                 Properties.Settings.Default.Save();

                 lblMsjUV.Text = "UV restablecido";
             }
             else
             {


             }
        }

        private void linkLabelNewPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frames.FrmPassAccesoGeneral formtPassAccesoGeneral = new Frames.FrmPassAccesoGeneral();
            formtPassAccesoGeneral.Show();
            this.Close();
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
                Properties.Settings.Default.AnoVent = Ano;
                Properties.Settings.Default.MesVent = Mes;
                Properties.Settings.Default.DiaVent = Dia;
                Properties.Settings.Default.HoraVent = Hrs;
                Properties.Settings.Default.MinVent = Min;
                Properties.Settings.Default.SegVent = Seg;

                //Establece horas de funcionamiento ventilador en 0
                Properties.Settings.Default.HorasMotorVent1 = 0;

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
                Properties.Settings.Default.AnoCalefactor = Ano;
                Properties.Settings.Default.MesCalefactor = Mes;
                Properties.Settings.Default.DiaCalefactor = Dia;
                Properties.Settings.Default.HoraCalefactor = Hrs;
                Properties.Settings.Default.MinCalefactor = Min;
                Properties.Settings.Default.SegCalefactor = Seg;

                //Establece horas de funcionamiento calefactor en 0
                Properties.Settings.Default.HorasCalefactor1 = 0;

                Properties.Settings.Default.Save();

                lblMsjCalef.Text = "Calefactor restablecido";
            }
            else
            {


            }
        }

        private void txtHrsMaxUV_TextChanged(object sender, EventArgs e)
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

            if (txtHrsMaxUV.Text != "" && txtHrsMaxMotor.Text != "" && txtHrsMaxCalefactor.Text != "" && txtTiempoUVon.Text != "" && txtTiempoUVoff.Text != "" && TempMaxCalef.Text != "")
            {

                bool vfUV = isInt32(txtHrsMaxUV.Text);
                bool vfVent = isInt32(txtHrsMaxMotor.Text);
                bool vfCalef = isInt32(txtHrsMaxCalefactor.Text);
                bool vfUVon = isInt32(txtTiempoUVon.Text);
                bool vfUVoff = isInt32(txtTiempoUVoff.Text);
                bool vfTempMaxCalef = isInt32(TempMaxCalef.Text);

                if (vfUV == true && vfVent == true && vfCalef == true && vfUVon == true && vfUVoff == true && vfTempMaxCalef == true)
                {
                    Properties.Settings.Default.HMUV1 = Convert.ToInt32(txtHrsMaxUV.Text);
                    Properties.Settings.Default.HMM1 = Convert.ToInt32(txtHrsMaxMotor.Text);
                    Properties.Settings.Default.HMC1 = Convert.ToInt32(txtHrsMaxCalefactor.Text);
                    Properties.Settings.Default.TUVON1 = Convert.ToInt32(txtTiempoUVon.Text);
                    Properties.Settings.Default.TUVOFF1 = Convert.ToInt32(txtTiempoUVoff.Text);
                    Properties.Settings.Default.EMAIL1Parte1 = txtemailInicio.Text;
                    Properties.Settings.Default.EMAIL1Parte2 = txtemailFinal.Text;
                    Properties.Settings.Default.TempMax1 = Convert.ToInt32(TempMaxCalef.Text);
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
            int ano = Properties.Settings.Default.AnoUV;
            int mes = Properties.Settings.Default.MesUV;
            int dia = Properties.Settings.Default.DiaUV;

            int hrs = Properties.Settings.Default.HoraUV;
            int mins = Properties.Settings.Default.MinUV;
            int sgds = Properties.Settings.Default.SegUV;


            MessageBox.Show("UV se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":"+ mins +":"+ sgds);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoVent;
            int mes = Properties.Settings.Default.MesVent;
            int dia = Properties.Settings.Default.DiaVent;

            int hrs  = Properties.Settings.Default.HoraVent;
            int mins = Properties.Settings.Default.MinVent;
            int sgds = Properties.Settings.Default.SegVent;

            MessageBox.Show("VENTILADOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int ano = Properties.Settings.Default.AnoCalefactor;
            int mes = Properties.Settings.Default.MesCalefactor;
            int dia = Properties.Settings.Default.DiaCalefactor;

            int hrs = Properties.Settings.Default.HoraCalefactor;
            int mins = Properties.Settings.Default.MinCalefactor;
            int sgds = Properties.Settings.Default.SegCalefactor;

            MessageBox.Show("CALEFACTOR se reseteo por última vez el : " + dia + "/" + mes + "/" + ano + " a las " + hrs + ":" + mins + ":" + sgds);

        }
    }
}

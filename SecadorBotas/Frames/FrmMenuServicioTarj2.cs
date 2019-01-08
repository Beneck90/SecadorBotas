using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    public partial class FrmMenuServicioTarj2 : Form
    {

        Clases.Relay R = new Clases.Relay();


        public FrmMenuServicioTarj2()
        {
            InitializeComponent();
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMenuServicioTarj2_Load(object sender, EventArgs e)
        {
            timerHrsFuncionamiento.Enabled = true;
            timerSesion.Enabled = true;
        }

        private void linkLabelNewPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frames.FrmPassAccesoGeneral formt1 = new Frames.FrmPassAccesoGeneral();
            formt1.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta2 formt2 = new Frames.FrmTarjeta2();
            formt2.Show();
            this.Close();
        }

  

        private void timerHrsFuncionamiento_Tick(object sender, EventArgs e)
        {
            int MaxMotor2 = Properties.Settings.Default.HMM2;
            int MaxUV2 = Properties.Settings.Default.HMUV2;
            int MaxCalefactor2 = Properties.Settings.Default.HMC2;


            ////Horas máximas establecidas
            lblHrsMaxMotor2.Text = MaxMotor2.ToString() + " Hrs.";
            lblHrsMaxUV2.Text = MaxUV2.ToString() + " Hrs.";
            lblHrsMaxCalefactor2.Text = MaxCalefactor2.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent2 = Properties.Settings.Default.HorasMotorVent2;
            int HorasFuncionamientoUV2 = Properties.Settings.Default.HorasUV2;
            int HorasFuncionamientoCalefactor2 = Properties.Settings.Default.HorasCalefactor2;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);

            ////Horas funcionamiento
            lblHrsSerMotor2.Text = HorasFuncionamientoVent2.ToString();
            lblHrsSerUV2.Text = HorasFuncionamientoUV2.ToString();
            lblHrsSerCalefactor3.Text = HorasFuncionamientoCalefactor2.ToString();
        }

        private void timerSesion_Tick(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
        }
    }
}

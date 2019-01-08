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
    public partial class FrmMenuServicioTarj3 : Form
    {

        Clases.Relay R = new Clases.Relay();

        public FrmMenuServicioTarj3()
        {
            InitializeComponent();
        }

        private void btnConfiguraciónServicios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMenuServicioTarj3_Load(object sender, EventArgs e)
        {
            timerHrsFuncionamiento.Enabled = true;
            timerSesion.Enabled = true;
        }

        private void linkLabelNewPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta3 formt3 = new Frames.FrmTarjeta3();
            formt3.Show();
            this.Close();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frames.FrmPassAccesoGeneral formt1 = new Frames.FrmPassAccesoGeneral();
            formt1.Show();
            this.Close();
        }

        private void timerHrsFuncionamiento_Tick(object sender, EventArgs e)
        {
            int MaxMotor3 = Properties.Settings.Default.HMM3;
            int MaxUV3 = Properties.Settings.Default.HMUV3;
            int MaxCalefactor3 = Properties.Settings.Default.HMC3;

            ////Horas máximas establecidas
            lblHrsMaxMotor3.Text = MaxMotor3.ToString() + " Hrs.";
            lblHrsMaxUV3.Text = MaxUV3.ToString() + " Hrs.";
            lblHrsMaxCalefactor3.Text = MaxCalefactor3.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent3 = Properties.Settings.Default.HorasMotorVent3;
            int HorasFuncionamientoUV3 = Properties.Settings.Default.HorasUV3;
            int HorasFuncionamientoCalefactor3 = Properties.Settings.Default.HorasCalefactor3;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);


            ////Horas funcionamiento
            lblHrsSerMotor3.Text = HorasFuncionamientoVent3.ToString();
            lblHrsSerUV3.Text = HorasFuncionamientoUV3.ToString();
            lblHrsSerCalefactor3.Text = HorasFuncionamientoCalefactor3.ToString();
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

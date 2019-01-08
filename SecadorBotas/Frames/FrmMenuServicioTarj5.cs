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
    public partial class FrmMenuServicioTarj5 : Form
    {

        Clases.Relay R = new Clases.Relay();

        public FrmMenuServicioTarj5()
        {
            InitializeComponent();
        }

        private void btnConfiguraciónServicios_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMenuServicioTarj5_Load(object sender, EventArgs e)
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
            Frames.FrmTarjeta5 formt5 = new Frames.FrmTarjeta5();
            formt5.Show();
            this.Close();
        }

        private void timerHrsFuncionamiento_Tick(object sender, EventArgs e)
        {
            int MaxMotor5 = Properties.Settings.Default.HMM5;
            int MaxUV5 = Properties.Settings.Default.HMUV5;
            int MaxCalefactor5 = Properties.Settings.Default.HMC5;

            ////Horas máximas establecidas
            lblHrsMaxMotor5.Text = MaxMotor5.ToString() + " Hrs.";
            lblHrsMaxUV5.Text = MaxUV5.ToString() + " Hrs.";
            lblHrsMaxCalefactor5.Text = MaxCalefactor5.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent5 = Properties.Settings.Default.HorasMotorVent5;
            int HorasFuncionamientoUV5 = Properties.Settings.Default.HorasUV5;
            int HorasFuncionamientoCalefactor5 = Properties.Settings.Default.HorasCalefactor5;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);

            ////Horas funcionamiento
            lblHrsSerMotor5.Text = HorasFuncionamientoVent5.ToString();
            lblHrsSerUV5.Text = HorasFuncionamientoUV5.ToString();
            lblHrsSerCalefactor5.Text = HorasFuncionamientoCalefactor5.ToString();
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

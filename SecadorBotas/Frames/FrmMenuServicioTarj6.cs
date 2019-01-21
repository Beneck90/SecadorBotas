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
    public partial class FrmMenuServicioTarj6 : Form
    {

        Clases.Relay R = new Clases.Relay();

        public FrmMenuServicioTarj6()
        {
            InitializeComponent();
        }

        private void btnConfiguraciónServicios_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMenuServicioTarj6_Load(object sender, EventArgs e)
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
            Frames.FrmTarjeta6 formt6 = new Frames.FrmTarjeta6();
            formt6.Show();
            this.Close();
        }

     

        private void timerHrsFuncionamiento_Tick(object sender, EventArgs e)
        {
            int MaxMotor6 = Properties.Settings.Default.HMM6;
            int MaxUV6 = Properties.Settings.Default.HMUV6;
            int MaxCalefactor6 = Properties.Settings.Default.HMC6;

            ////Horas máximas establecidas
            lblHrsMaxMotor6.Text = MaxMotor6.ToString() + " Hrs.";
            lblHrsMaxUV6.Text = MaxUV6.ToString() + " Hrs.";
            lblHrsMaxCalefactor6.Text = MaxCalefactor6.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent6 = Properties.Settings.Default.HorasMotorVent6;
            int HorasFuncionamientoUV6 = Properties.Settings.Default.HorasUV6;
            int HorasFuncionamientoCalefactor6 = Properties.Settings.Default.HorasCalefactor6;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);

            ////Horas funcionamiento
            lblHrsSerMotor6.Text = HorasFuncionamientoVent6.ToString();
            lblHrsSerUV6.Text = HorasFuncionamientoUV6.ToString();
            lblHrsSerCalefactor6.Text = HorasFuncionamientoCalefactor6.ToString();
        }

        private void timerSesion_Tick(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginPeriodoActiv6 formtP = new Frames.FrmLoginPeriodoActiv6();
            formtP.Show();
            this.Close();
        }
    }
}

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
    public partial class FrmMenuServicioTarj7 : Form
    {

        Clases.Relay R = new Clases.Relay();

        public FrmMenuServicioTarj7()
        {
            InitializeComponent();
        }

        private void btnConfiguraciónServicios_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
         
        }

        private void FrmMenuServicioTarj7_Load(object sender, EventArgs e)
        {
            timerHrsFuncionamiento.Enabled = true;
        }

        private void linkLabelNewPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta7 formt7 = new Frames.FrmTarjeta7();
            formt7.Show();
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
            int MaxMotor7 = Properties.Settings.Default.HMM7;
            int MaxUV7 = Properties.Settings.Default.HMUV7;
            int MaxCalefactor7 = Properties.Settings.Default.HMC7;

            ////Horas máximas establecidas
            lblHrsMaxMotor7.Text = MaxMotor7.ToString() + " Hrs.";
            lblHrsMaxUV7.Text = MaxUV7.ToString() + " Hrs.";
            lblHrsMaxCalefactor7.Text = MaxCalefactor7.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent7 = Properties.Settings.Default.HorasMotorVent7;
            int HorasFuncionamientoUV7 = Properties.Settings.Default.HorasUV7;
            int HorasFuncionamientoCalefactor7 = Properties.Settings.Default.HorasCalefactor7;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);

            ////Horas funcionamiento
            lblHrsSerMotor7.Text = HorasFuncionamientoVent7.ToString();
            lblHrsSerUV7.Text = HorasFuncionamientoUV7.ToString();
            lblHrsSerCalefactor7.Text = HorasFuncionamientoCalefactor7.ToString();
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

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
    public partial class FrmMenuServicioTarj4 : Form
    {

        Clases.Relay R = new Clases.Relay();


        public FrmMenuServicioTarj4()
        {
            InitializeComponent();
        }

        private void btnConfiguraciónServicios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmMenuServicioTarj4_Load(object sender, EventArgs e)
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
            Frames.FrmTarjeta4 formt4 = new Frames.FrmTarjeta4();
            formt4.Show();
            this.Close();
        }


        private void timerHrsFuncionamiento_Tick(object sender, EventArgs e)
        {
            int MaxMotor4 = Properties.Settings.Default.HMM4;
            int MaxUV4 = Properties.Settings.Default.HMUV4;
            int MaxCalefactor4 = Properties.Settings.Default.HMC4;

            ////Horas máximas establecidas
            lblHrsMaxMotor4.Text = MaxMotor4.ToString() + " Hrs.";
            lblHrsMaxUV4.Text = MaxUV4.ToString() + " Hrs.";
            lblHrsMaxCalefactor4.Text = MaxCalefactor4.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent4 = Properties.Settings.Default.HorasMotorVent4;
            int HorasFuncionamientoUV4 = Properties.Settings.Default.HorasUV4;
            int HorasFuncionamientoCalefactor4 = Properties.Settings.Default.HorasCalefactor4;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);

            ////Horas funcionamiento
            lblHrsSerMotor4.Text = HorasFuncionamientoVent4.ToString();
            lblHrsSerUV4.Text = HorasFuncionamientoUV4.ToString();
            lblHrsSerCalefactor4.Text = HorasFuncionamientoCalefactor4.ToString();
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
            Frames.FrmLoginPeriodoActiv4 formtP = new Frames.FrmLoginPeriodoActiv4();
            formtP.Show();
            this.Close();
        }
    }
}

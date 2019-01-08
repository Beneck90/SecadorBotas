using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{

    public partial class FrmMenuServicioTarj1 : Form
    {

        Clases.Relay R = new Clases.Relay();

        public FrmMenuServicioTarj1()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
         
            
        }

        private void btnConfiguraciónServicios_Click(object sender, EventArgs e)
        {
            
        }


        private void FrmMenuServicioTarj1_Load(object sender, EventArgs e)
        {
            timerHrsFuncionamiento.Enabled = true;
            timerSesion.Enabled = true;
                     
        }



        private void linkLabelNewPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta1 formt1 = new Frames.FrmTarjeta1();
            formt1.Show();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginParametros formtLoginTarj1 = new Frames.FrmLoginParametros();
            formtLoginTarj1.Show();
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
       

            int MaxMotor1 = Properties.Settings.Default.HMM1;
            int MaxUV1 = Properties.Settings.Default.HMUV1;
            int MaxCalefactor1 = Properties.Settings.Default.HMC1;


            ////Horas máximas establecidas
            lblHrsMaxMotor.Text = MaxMotor1.ToString() + " Hrs.";
            lblHrsMaxUV.Text = MaxUV1.ToString() + " Hrs.";
            lblHrsMaxCalefactor.Text = MaxCalefactor1.ToString() + " Hrs.";

            int milliseconds = 20;
            Thread.Sleep(milliseconds);

            int HorasFuncionamientoVent = Properties.Settings.Default.HorasMotorVent1;
            int HorasFuncionamientoUV = Properties.Settings.Default.HorasUV1;
            int HorasFuncionamientoCalefactor = Properties.Settings.Default.HorasCalefactor1;

            int milliseconds2 = 20;
            Thread.Sleep(milliseconds2);

            ////Horas funcionamiento
            lblHrsSerMotor.Text = HorasFuncionamientoVent.ToString();
            lblHrsSerUV.Text = HorasFuncionamientoUV.ToString();
            lblHrsSeCalefactor.Text = HorasFuncionamientoCalefactor.ToString();

           
           
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


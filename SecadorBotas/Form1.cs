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

namespace SecadorBotas
{

    public partial class Form1 : Form
    {

      
        
        public Form1()
        {
            InitializeComponent();



            //Texto sobre picturebox ENCENDER   
            var tEncender = new ToolTip();
            tEncender.SetToolTip(pictureBox2, "ENCENDER");

            //Texto sobre picturebox CONFIGURAR IPS TARJETAS
            var tConIP = new ToolTip();
            tConIP.SetToolTip(pictureBox3, "CONFIGURAR IP SECADORES");

            //Texto sobre picturebox TEST RELAYS
            var tTestRelays = new ToolTip();
            tTestRelays.SetToolTip(pictureBox4, "TEST TARJETAS");

            //Texto sobre picturebox CONFIG. PARAMETROS TARJETAS
            var tConfigTarjetas = new ToolTip();
            tConfigTarjetas.SetToolTip(pictureBox8, "CONFIGURAR PARAMETROS SECADORES");

            //Texto sobre label HELP
            var tHelp = new ToolTip();
            tHelp.SetToolTip(label7, "HELP");

            //Texto sobre label OFF
            var tOFF = new ToolTip();
            tOFF.SetToolTip(pictureBox1, "OFF");



        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timerInicio.Start();
           
           
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnNoIniciar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginEstadoBotones formLoginEstadoBotones = new Frames.FrmLoginEstadoBotones();
            formLoginEstadoBotones.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Frames.FrmSecadores formt1 = new Frames.FrmSecadores();
            formt1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginIPs formt2 = new Frames.FrmLoginIPs();
            formt2.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginTESTRelays formtR = new Frames.FrmLoginTESTRelays();
            formtR.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginParametros formtR = new Frames.FrmLoginParametros();
            formtR.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginAyudaInstalacion formAyudaInstalacion = new Frames.FrmLoginAyudaInstalacion();
            formAyudaInstalacion.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }


        //Este timer se creó para cuando se programe un encendido automático, después de 1 minuto abrirá el form de secadores
        private void timerInicio_Tick(object sender, EventArgs e)
        {

                //Revisa si exite algún formulario abierto, solo si todos están cerrados abre el form secadores
            
                if (Application.OpenForms["FrmSecadores"] == null & Application.OpenForms["FrmTarjeta1"] == null & Application.OpenForms["FrmTarjeta2"] == null & Application.OpenForms["FrmTarjeta3"] == null & Application.OpenForms["FrmTarjeta4"] == null & Application.OpenForms["FrmTarjeta5"] == null & Application.OpenForms["FrmTarjeta6"] == null & Application.OpenForms["FrmTarjeta7"] == null & Application.OpenForms["FrmTESTRelays"] == null & Application.OpenForms["FrmConfigIPSecadores"] == null & Application.OpenForms["FrmConfigParametros"] == null & Application.OpenForms["FrmConfigPeriodoActividad"] == null & Application.OpenForms["FrmConfServTar1"] == null & Application.OpenForms["FrmConfServTar2"] == null & Application.OpenForms["FrmConfServTar3"] == null & Application.OpenForms["FrmConfServTar4"] == null & Application.OpenForms["FrmConfServTar5"] == null & Application.OpenForms["FrmConfServTar6"] == null & Application.OpenForms["FrmConfServTar7"] == null & Application.OpenForms["FrmGuiaEncendidoAuto"] == null & Application.OpenForms["FrmLoginAyudaInstalacion"] == null & Application.OpenForms["FrmLoginEstado1"] == null & Application.OpenForms["FrmLoginEstado2"] == null & Application.OpenForms["FrmLoginEstado3"] == null & Application.OpenForms["FrmLoginEstado4"] == null & Application.OpenForms["FrmLoginEstado5"] == null & Application.OpenForms["FrmLoginEstado6"] == null & Application.OpenForms["FrmLoginEstado7"] == null & Application.OpenForms["FrmLoginEstadoBotones"] == null & Application.OpenForms["FrmLoginIPs"] == null & Application.OpenForms["FrmLoginParametros"] == null & Application.OpenForms["FrmLoginPeriodoActiv"] == null & Application.OpenForms["FrmLoginTESTRelays"] == null & Application.OpenForms["FrmMenuServicioTarj1"] == null & Application.OpenForms["FrmMenuServicioTarj2"] == null & Application.OpenForms["FrmMenuServicioTarj3"] == null & Application.OpenForms["FrmMenuServicioTarj4"] == null & Application.OpenForms["FrmMenuServicioTarj5"] == null & Application.OpenForms["FrmMenuServicioTarj6"] == null & Application.OpenForms["FrmMenuServicioTarj7"] == null & Application.OpenForms["FrmPassAccesoGeneral"] == null)
                {

                Frames.FrmSecadores formt1 = new Frames.FrmSecadores();
                formt1.Show();

                }


            }        
        }
    }


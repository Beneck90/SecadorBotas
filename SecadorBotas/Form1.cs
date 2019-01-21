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

             


            }        
        }
    }


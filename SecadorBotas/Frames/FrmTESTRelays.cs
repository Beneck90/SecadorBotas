using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    public partial class FrmTESTRelays : Form
    {

        Clases.Relay R = new Clases.Relay();


        public FrmTESTRelays()
        {
            InitializeComponent();
        }

        private void btnVent_Click(object sender, EventArgs e)
        {

            try { 

            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

            R.EnvioInstruccionRelay("relay on 0");
            R.Close();
            MessageBox.Show("RELAY ENCENDIDO!");

            
                }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 1!");
            }

            
        }

        private void btnUV_Click(object sender, EventArgs e)
        {

            try
            {
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 1!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

            try
            {

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("Relay encendido!");

            }

            catch (Exception)
            {
                MessageBox.Show("Relay no encendio, revisa conexión a tarjeta!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1
 
            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

            R.EnvioInstruccionRelay("relay off 0");
            R.EnvioInstruccionRelay("relay off 1");
            R.EnvioInstruccionRelay("relay off 2");
            R.EnvioInstruccionRelay("relay off 3");

            R.Close();

            MessageBox.Show("Relays apagados!");

            }

            catch (Exception)
            {

                MessageBox.Show("Relays apagados!");
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 0");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 2!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 2!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 2!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  

           

                R.EnvioInstruccionRelay("relay on 0");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 3!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  
            
                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 3!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 3!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            try
            {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 0");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 4!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            try
            {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 4!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            try
            {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 4!");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {

            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 0");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 5!");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            try
            {
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 5!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

            try
            {
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay  

            

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 5!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay 

            R.EnvioInstruccionRelay("relay off 0");
            R.EnvioInstruccionRelay("relay off 1");
            R.EnvioInstruccionRelay("relay off 2");
            R.EnvioInstruccionRelay("relay off 3");
            R.Close();
            MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 2!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

                R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("relay off 0");
                R.EnvioInstruccionRelay("relay off 1");
                R.EnvioInstruccionRelay("relay off 2");
                R.EnvioInstruccionRelay("relay off 3");
                R.Close();
                MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 3!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            try
            {
                string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

                R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("relay off 0");
                R.EnvioInstruccionRelay("relay off 1");
                R.EnvioInstruccionRelay("relay off 2");
                R.EnvioInstruccionRelay("relay off 3");
                R.Close();
                MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 4!");
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {

            try { 
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay

            R.EnvioInstruccionRelay("relay off 0");
            R.EnvioInstruccionRelay("relay off 1");
            R.EnvioInstruccionRelay("relay off 2");
            R.EnvioInstruccionRelay("relay off 3");
            R.Close();
            MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 5!");
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {

            try
            {
                string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

                R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("relay off 0");
                R.EnvioInstruccionRelay("relay off 1");
                R.EnvioInstruccionRelay("relay off 2");
                R.EnvioInstruccionRelay("relay off 3");
                R.Close();
                MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 6!");
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 0");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 6!");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 6!");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 6!");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  
            
                R.EnvioInstruccionRelay("relay on 0");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 7!");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 1");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 7!");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {

            try
            {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  
            
                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 7!");
            }
        }

        private void btnvVolver_Click(object sender, EventArgs e)
        {
            
        
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

                R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("relay off 0");
                R.EnvioInstruccionRelay("relay off 1");
                R.EnvioInstruccionRelay("relay off 2");
                R.EnvioInstruccionRelay("relay off 3");
                R.Close();
                MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 7!");
            }
        }

        private void FrmTESTRelays_Load(object sender, EventArgs e)
        {
            MessageBox.Show("APAGUE TODOS LOS RELAYS ANTES DE SALIR!");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

                R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

                R.EnvioInstruccionRelay("relay on 2");
                R.EnvioInstruccionRelay("relay on 3");
                R.Close();
                MessageBox.Show("RELAY ENCENDIDO!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 1!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try { 
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 

            R.EnvioInstruccionRelay("relay off 0");
            R.EnvioInstruccionRelay("relay off 1");
            R.EnvioInstruccionRelay("relay off 2");
            R.EnvioInstruccionRelay("relay off 3");
            R.Close();
            MessageBox.Show("RELAYS APAGADOS!");


            }
            catch (Exception)
            {

                MessageBox.Show("REVISE CONFIGURACION IP Y CONEXION DE RED 1!");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

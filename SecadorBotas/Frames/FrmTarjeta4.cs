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
    public partial class FrmTarjeta4 : Form
    {

        //comienza en apagado.
        int estado = 0;

        Clases.Relay R = new Clases.Relay();


        public FrmTarjeta4()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void btnMenuServicio_Click(object sender, EventArgs e)
        {
            Frames.FrmMenuServicioTarj4 formtMenu4 = new Frames.FrmMenuServicioTarj4();
            formtMenu4.Show();
            this.Close();
        }

        private void FrmTarjeta4_Load(object sender, EventArgs e)
        {

            #region EncendidoApagado

            int encendidoUV4 = Properties.Settings.Default.TUVON4;
            int apagadoUV4 = Properties.Settings.Default.TUVOFF4;

            int milisegundosON = encendidoUV4 * 60000;

            timerOnUV4.Interval = milisegundosON;

            int milisegundosOFF = apagadoUV4 * 60000;

            timerOffUV4.Interval = milisegundosOFF;

            #endregion EncendidoApagado


            timerSesion4.Enabled = true;

            timerBotonONOFF.Enabled = true;

            timer4.Enabled = true;

            timerTemp.Enabled = true;

            //Temp Máxima
            int TempMax4 = Properties.Settings.Default.TempMax4;
            lblTempMax4.Text = TempMax4.ToString() + "°C";

        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            /*Estado relay 1 ventilador*/
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");
            /*Estado relay 2 UV*/
            string rele2 = R.EnvioInstruccionRelay("relay read 1").Replace("\n", "").Replace("\r", "").Replace(">", "");
            /*Estado relay 3 calefactor*/
            string rele3 = R.EnvioInstruccionRelay("relay read 2").Replace("\n", "").Replace("\r", "").Replace(">", "");

            //Sentencias, consulta si los relays están encendidos...

            #region Relay_ventilador

            if (rele == "on")//Ventilador
            {
                //Actualiza estados
                lblEstadoVent4.Text = "ON";
                lblEstadoVent4.BackColor = Color.Lime;
                this.lblEstadoVent4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                //Rota ventilador
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Invalidate();

            }

            if (rele == "off")//Ventilador
            {
                //Actualiza estados
                lblEstadoVent4.Text = "OFF";
                lblEstadoVent4.BackColor = Color.Red;
                this.lblEstadoVent4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                //Inmoviliza 
                pictureBox1.Invalidate();

            }

            #endregion Relay_ventilador

            #region Relay_UV

            if (rele2 == "on")//UV
            {
                //Actualiza estados
                lblEstadoUV4.Text = "ON";
                lblEstadoUV4.BackColor = Color.Lime;
                this.lblEstadoUV4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;

            }

            if (rele2 == "off")//UV
            {
                //Actualiza estados
                lblEstadoUV4.Text = "OFF";
                lblEstadoUV4.BackColor = Color.Red;
                this.lblEstadoUV4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;

            }

            #endregion Relay_UV

            #region Relay_Calefactor

            if (rele3 == "on")//CALEFACTOR
            {
                //Actualiza estados
                lblEstadoCalefactor4.Text = "ON";
                lblEstadoCalefactor4.BackColor = Color.Lime;
                this.lblEstadoCalefactor4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                pictureBox5.Visible = true;
                pictureBox2.Visible = false;

            }

            if (rele3 == "off")//CALEFACTOR
            {
                //Actualiza estados
                lblEstadoCalefactor4.Text = "OFF";
                lblEstadoCalefactor4.BackColor = Color.Red;
                this.lblEstadoCalefactor4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                pictureBox5.Visible = false;
                pictureBox2.Visible = true;
            }

            #endregion Relay_Calefactor
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {

            try { 

            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 1

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            lblMensaje4.Text = "";

            string respuesta1 = R.EnvioInstruccionRelay("adc read 1").Substring(0, 3);//Entrega temperatura
            int Respuesta = Convert.ToInt32(respuesta1);//Convierte a entero

            //Obtención de temperatura fórmula
            string Respuesta2 = (Respuesta * 3.3).ToString();
            double Respuesta22 = (Convert.ToDouble(Respuesta2) / 1024);
            double Respuesta222 = (Convert.ToDouble(Respuesta22 - 0.5));
            double Respuesta2222 = (Respuesta222 * 100);
            //FIN Obtención de temperatura fórmula            

            //Llenado de barra de temperatura
            int Respuesta3 = Convert.ToInt32(Respuesta2222);
            progressBarTemp4.Value = Respuesta3;
            lblTemp4.Text = Respuesta3.ToString() + "°C";

            int temnpMax = Properties.Settings.Default.TempMax4;
            string EstadoCalefactor = Properties.Settings.Default.EstadoCalef4;

            if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
            {
                timerOFFCalefactor.Start();//Enciende timer apaga calefactor
                timerONCalefactor.Stop();//Apaga timer enciende calefactor
            }
            else//si no...
            {
                if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                {
                    timerONCalefactor.Start();//enciende timer de encendido calefactor
                    timerOFFCalefactor.Stop();////Apaga timer apaga calefactor
                }

                else//si no...
                {
                    timerOFFCalefactor.Start();//Enciende timer apaga calefactor
                    timerONCalefactor.Stop();//Apaga timer encendido calefactor
                }
            }
            }
            catch (Exception)

            {
                lblMensaje4.Text = "SIN RED";

            }
        }

        private void timerBotonONOFF_Tick(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            #region MuestrasTemperatura

            //GPIO 1
            string respuesta1 = R.EnvioInstruccionRelay("gpio read 2");// primera muestra botón
            int milliseconds = 10;
            Thread.Sleep(milliseconds);
            string respuesta2 = R.EnvioInstruccionRelay("gpio read 2");// segunda muestra botón
            int milliseconds1 = 10;
            Thread.Sleep(milliseconds1);
            string respuesta3 = R.EnvioInstruccionRelay("gpio read 2");//tercera muestra botón
            int milliseconds2 = 10;
            Thread.Sleep(milliseconds2);

            #endregion MuestrasTemperatura

            #region MenúEncenderApagar

            string Estado = Properties.Settings.Default.Bandera4ONOFF.ToString();//Estado encendido o no

            switch (Estado)
            {
                //Caso ON
                case "on":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef4 = "off";//Guarda estado para ocuparlo en timer Temp
                        Properties.Settings.Default.Save();

                        //Consulta estado high/off
                        if (estado != 0)//Si estado es distinto de 0...
                        {

                            estado = 0;//Guarda estado en 0


                            #region ApagaTermostato

                            string respuesta11 = R.EnvioInstruccionRelay("adc read 1").Substring(0, 3);//Entrega temperatura
                            int Respuesta = Convert.ToInt32(respuesta11);

                            //Obtención de temperatura fórmula
                            string Respuesta2 = (Respuesta * 3.3).ToString();
                            double Respuesta22 = (Convert.ToDouble(Respuesta2) / 1024);
                            double Respuesta222 = (Convert.ToDouble(Respuesta22 - 0.5));
                            double Respuesta2222 = (Respuesta222 * 100);
                            //FIN Obtención de temperatura fórmula            

                            int temnpMax = Properties.Settings.Default.TempMax4;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays


                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV4.Enabled = false;

                            timerOffUV4.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //  //Guardar estado
                            Properties.Settings.Default.Bandera4ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else
                    {

                        Properties.Settings.Default.EstadoCalef4 = "on";//Guarda estado para ocuparlo en timer Temp
                        Properties.Settings.Default.Save();

                        if (estado != 1)//Si estado es distinto de 1
                        {

                            estado = 1;//Guarda estado en 1


                            #region EncenderRelays

                            R.EnvioInstruccionRelay("relay on 0");
                            R.EnvioInstruccionRelay("relay on 1");
                            R.EnvioInstruccionRelay("relay on 2");
                            R.EnvioInstruccionRelay("relay on 3");

                            #endregion EncenderRelays

                            #region EnciendeTermostato

                            string respuesta11 = R.EnvioInstruccionRelay("adc read 1").Substring(0, 3);//Entrega temperatura
                            int Respuesta = Convert.ToInt32(respuesta11);

                            //Obtención de temperatura fórmula
                            string Respuesta2 = (Respuesta * 3.3).ToString();
                            double Respuesta22 = (Convert.ToDouble(Respuesta2) / 1024);
                            double Respuesta222 = (Convert.ToDouble(Respuesta22 - 0.5));
                            double Respuesta2222 = (Respuesta222 * 100);
                            //FIN Obtención de temperatura fórmula            


                            int temnpMax = Properties.Settings.Default.TempMax4;


                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor.Enabled = true;
                                timerONCalefactor.Enabled = false;
                            }

                            else
                            {
                                timerONCalefactor.Enabled = true;
                                timerOFFCalefactor.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region Encendido_y_apagado_de_UV

                            timerOffUV4.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //     //Guardar estado
                            Properties.Settings.Default.Bandera4ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef4 = "on";//Guarda estado para ocuparlo en timer Temp
                        Properties.Settings.Default.Save();

                        if (estado != 1)//Si estado es distinto de 1...
                        {
                            estado = 1;//Guarda estado en 1


                            #region EnciendeTermostato

                            string respuesta11 = R.EnvioInstruccionRelay("adc read 1").Substring(0, 3);//Entrega temperatura
                            int Respuesta = Convert.ToInt32(respuesta11);

                            //Obtención de temperatura fórmula
                            string Respuesta2 = (Respuesta * 3.3).ToString();
                            double Respuesta22 = (Convert.ToDouble(Respuesta2) / 1024);
                            double Respuesta222 = (Convert.ToDouble(Respuesta22 - 0.5));
                            double Respuesta2222 = (Respuesta222 * 100);
                            //FIN Obtención de temperatura fórmula            

                            int temnpMax = Properties.Settings.Default.TempMax4;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor.Enabled = true;
                                timerONCalefactor.Enabled = false;
                            }

                            else
                            {
                                timerONCalefactor.Enabled = true;
                                timerOFFCalefactor.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region EnciendeRelays

                            R.EnvioInstruccionRelay("relay on 0");
                            R.EnvioInstruccionRelay("relay on 1");
                            R.EnvioInstruccionRelay("relay on 2");
                            R.EnvioInstruccionRelay("relay on 3");

                            #endregion EnciendeRelays

                            #region Encendido_y_apagado_de_UV

                            timerOffUV4.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera4ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else//Si no...
                    {
                        Properties.Settings.Default.EstadoCalef4 = "off";//Guarda estado para ocuparlo en timer Temp
                        Properties.Settings.Default.Save();

                        if (estado != 0)//Si estado es distinto de 0...
                        {
                            estado = 0;//Guarda estado en 0


                            #region ApagaTermostato

                            string respuesta11 = R.EnvioInstruccionRelay("adc read 1").Substring(0, 3);//Entrega temperatura
                            int Respuesta = Convert.ToInt32(respuesta11);

                            //Obtención de temperatura fórmula
                            string Respuesta2 = (Respuesta * 3.3).ToString();
                            double Respuesta22 = (Convert.ToDouble(Respuesta2) / 1024);
                            double Respuesta222 = (Convert.ToDouble(Respuesta22 - 0.5));
                            double Respuesta2222 = (Respuesta222 * 100);
                            //FIN Obtención de temperatura fórmula            

                            int temnpMax = Properties.Settings.Default.TempMax4;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays

                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV4.Enabled = false;

                            timerOffUV4.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera4ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;

            }

            #endregion MenúEncenderApagar
        }

        private void timerONCalefactor_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerOFFCalefactor_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay off 3");//Enciende calefactor
        }

        private void timerOnUV4_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 1");//Enciende relay

            timerOnUV4.Stop();//Apago timer de encendido
            timerOffUV4.Start();//Enciendo timer de apagado


            /*Para no iniciar los dos timer juntos*/
        }

        private void timerOffUV4_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV4.Stop();//Apago timer de encendido
            timerOnUV4.Start();//Enciendo timer de apagado

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerSesion4_Tick(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
        }

        private void btnMenuServicio_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 3

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmLoginEstado4 formtMenu1 = new Frames.FrmLoginEstado4();
            formtMenu1.Show();
            this.Close();
        }

       
    }
}

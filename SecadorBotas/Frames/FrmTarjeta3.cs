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
    public partial class FrmTarjeta3 : Form
    {

        //comienza en apagado.
        int estado = 0;

        Clases.Relay R = new Clases.Relay();


        public FrmTarjeta3()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnMenuServicio_Click(object sender, EventArgs e)
        {
            Frames.FrmMenuServicioTarj3 formtMenu3 = new Frames.FrmMenuServicioTarj3();
            formtMenu3.Show();
            this.Close();
        }

        private void FrmTarjeta3_Load(object sender, EventArgs e)
        {

            #region EncendidoApagado

            int encendidoUV3 = Properties.Settings.Default.TUVON3;
            int apagadoUV3 = Properties.Settings.Default.TUVOFF3;

            int milisegundosON = encendidoUV3 * 60000;

            timerOnUV3.Interval = milisegundosON;

            int milisegundosOFF = apagadoUV3 * 60000;

            timerOffUV3.Interval = milisegundosOFF;

            #endregion EncendidoApagado

            timerSesion3.Enabled = true;

            timerBotonONOFF.Enabled = true;

            timer3.Enabled = true;

            timerTemp.Enabled = true;

            //Temp Máxima
            int TempMax3 = Properties.Settings.Default.TempMax3;
            lblTempMax3.Text = TempMax3.ToString() + "°C";

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  

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
                lblEstadoVent3.Text = "ON";
                lblEstadoVent3.BackColor = Color.Lime;
                this.lblEstadoVent3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                //Rota ventilador
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Invalidate();

            }

            if (rele == "off")//Ventilador
            {
                //Actualiza estados
                lblEstadoVent3.Text = "OFF";
                lblEstadoVent3.BackColor = Color.Red;
                this.lblEstadoVent3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                //Inmoviliza 
                pictureBox1.Invalidate();

            }

            #endregion Relay_ventilador

            #region Relay_UV

            if (rele2 == "on")//UV
            {
                //Actualiza estados
                lblEstadoUV3.Text = "ON";
                lblEstadoUV3.BackColor = Color.Lime;
                this.lblEstadoUV3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;

            }

            if (rele2 == "off")//UV
            {
                //Actualiza estados
                lblEstadoUV3.Text = "OFF";
                lblEstadoUV3.BackColor = Color.Red;
                this.lblEstadoUV3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;

            }

            #endregion Relay_UV

            #region Relay_Calefactor

            if (rele3 == "on")//CALEFACTOR
            {
                //Actualiza estados
                lblEstadoCalefactor3.Text = "ON";
                lblEstadoCalefactor3.BackColor = Color.Lime;
                this.lblEstadoCalefactor3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                pictureBox5.Visible = true;
                pictureBox2.Visible = false;

            }

            if (rele3 == "off")//CALEFACTOR
            {
                //Actualiza estados
                lblEstadoCalefactor3.Text = "OFF";
                lblEstadoCalefactor3.BackColor = Color.Red;
                this.lblEstadoCalefactor3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                pictureBox5.Visible = false;
                pictureBox2.Visible = true;
            }

            #endregion Relay_Calefactor
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {

            try {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 1

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay 

            lblMensaje3.Text = "";

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
            progressBarTemp3.Value = Respuesta3;
            lblTemp3.Text = Respuesta3.ToString() + "°C";

            int temnpMax = Properties.Settings.Default.TempMax3;
            string EstadoCalefactor = Properties.Settings.Default.EstadoCalef3;

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
                lblMensaje3.Text = "SIN RED";

            }
        }

        private void timerSesion3_Tick(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
        }

        private void timerBotonONOFF_Tick(object sender, EventArgs e)
        {

            #region todo

            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  

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

            string Estado = Properties.Settings.Default.Bandera2ONOFF.ToString();//Estado encendido o no

            switch (Estado)
            {
                //Caso ON
                case "on":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef3 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax2;

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

                            timerOnUV3.Enabled = false;

                            timerOffUV3.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //  //Guardar estado
                            Properties.Settings.Default.Bandera2ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else
                    {

                        Properties.Settings.Default.EstadoCalef3 = "on";//Guarda estado para ocuparlo en timer Temp
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


                            int temnpMax = Properties.Settings.Default.TempMax2;


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

                            timerOffUV3.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //     //Guardar estado
                            Properties.Settings.Default.Bandera2ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef3 = "on";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax2;

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

                            timerOffUV3.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera2ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else//Si no...
                    {
                        Properties.Settings.Default.EstadoCalef3 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax2;

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

                            timerOnUV3.Enabled = false;

                            timerOffUV3.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera2ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;

            }

            #endregion MenúEncenderApagar

            #endregion todo

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

        private void timerOnUV3_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 1");//Enciende relay

            timerOnUV3.Stop();//Apago timer de encendido
            timerOffUV3.Start();//Enciendo timer de apagado


            /*Para no iniciar los dos timer juntos*/
        }

        private void timerOffUV3_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV3.Stop();//Apago timer de encendido
            timerOnUV3.Start();//Enciendo timer de apagado

            /*Para no iniciar los dos timer juntos*/
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            
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
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  

            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmLoginEstado3 formtMenu1 = new Frames.FrmLoginEstado3();
            formtMenu1.Show();
            this.Close();
        }

        

        
    }
}

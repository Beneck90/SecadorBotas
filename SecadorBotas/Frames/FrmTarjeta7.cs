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
    public partial class FrmTarjeta7 : Form
    {

        //comienza en apagado.
        int estado = 0;

        Clases.Relay R = new Clases.Relay();


        public FrmTarjeta7()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuServicio_Click(object sender, EventArgs e)
        {
            Frames.FrmMenuServicioTarj7 formtMenu7 = new Frames.FrmMenuServicioTarj7();
            formtMenu7.Show();
            this.Close();
        }

        private void FrmTarjeta7_Load(object sender, EventArgs e)
        {


            #region EncendidoApagado

            int encendidoUV7 = Properties.Settings.Default.TUVON7;
            int apagadoUV7 = Properties.Settings.Default.TUVOFF7;


            int milisegundosON = encendidoUV7 * 60000;

            timerOnUV7.Interval = milisegundosON;

            int milisegundosOFF = apagadoUV7 * 60000;

            timerOffUV7.Interval = milisegundosOFF;

            #endregion EncendidoApagado

            timerON.Start();

            timerOFF.Start();

            timerSesion7.Enabled = true;

            timerBotonONOFF.Enabled = true;

            timer7.Enabled = true;

            timerTemp.Enabled = true;

            //Temp Máxima
            int TempMax7 = Properties.Settings.Default.TempMax7;
            lblTempMax7.Text = TempMax7.ToString() + "°C";
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  

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
                lblEstadoVent7.Text = "ON";
                lblEstadoVent7.BackColor = Color.Lime;
                this.lblEstadoVent7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                //Rota ventilador
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Invalidate();

            }

            if (rele == "off")//Ventilador
            {
                //Actualiza estados
                lblEstadoVent7.Text = "OFF";
                lblEstadoVent7.BackColor = Color.Red;
                this.lblEstadoVent7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                //Inmoviliza 
                pictureBox1.Invalidate();

            }

            #endregion Relay_ventilador

            #region Relay_UV

            if (rele2 == "on")//UV
            {
                //Actualiza estados
                lblEstadoUV7.Text = "ON";
                lblEstadoUV7.BackColor = Color.Lime;
                this.lblEstadoUV7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;

            }

            if (rele2 == "off")//UV
            {
                //Actualiza estados
                lblEstadoUV7.Text = "OFF";
                lblEstadoUV7.BackColor = Color.Red;
                this.lblEstadoUV7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;

            }

            #endregion Relay_UV

            #region Relay_Calefactor

            if (rele3 == "on")//CALEFACTOR
            {
                //Actualiza estados
                lblEstadoCalefactor7.Text = "ON";
                lblEstadoCalefactor7.BackColor = Color.Lime;
                this.lblEstadoCalefactor7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                pictureBox5.Visible = true;
                pictureBox2.Visible = false;

            }

            if (rele3 == "off")//CALEFACTOR
            {
                //Actualiza estados
                lblEstadoCalefactor7.Text = "OFF";
                lblEstadoCalefactor7.BackColor = Color.Red;
                this.lblEstadoCalefactor7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                pictureBox5.Visible = false;
                pictureBox2.Visible = true;
            }

            #endregion Relay_Calefactor
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {

            try { 
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  

            lblMensaje7.Text = "";

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
            progressBarTemp7.Value = Respuesta3;
            lblTemp7.Text = Respuesta3.ToString() + "°C";

            int temnpMax = Properties.Settings.Default.TempMax7;
            string EstadoCalefactor = Properties.Settings.Default.EstadoCalef7;

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
                lblMensaje7.Text = "SIN RED";

            }
        }

        private void timerBotonONOFF_Tick(object sender, EventArgs e)
        {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  

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

            string Estado = Properties.Settings.Default.Bandera7ONOFF.ToString();//Estado encendido o no

            switch (Estado)
            {
                //Caso ON
                case "on":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef7 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax7;

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

                            timerOnUV7.Enabled = false;
                            
                            timerOffUV7.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //  //Guardar estado
                            Properties.Settings.Default.Bandera7ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else
                    {

                        Properties.Settings.Default.EstadoCalef7 = "on";//Guarda estado para ocuparlo en timer Temp
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


                            int temnpMax = Properties.Settings.Default.TempMax7;


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

                           
                            timerOffUV7.Enabled = true;


                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //     //Guardar estado
                            Properties.Settings.Default.Bandera7ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef7 = "on";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax7;

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


                            timerOffUV7.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera7ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else//Si no...
                    {
                        Properties.Settings.Default.EstadoCalef7 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax7;

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
                          
                            timerOnUV7.Enabled = false;
                      
                            timerOffUV7.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera7ONOFF = "off";
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

        private void timerOnUV7_Tick(object sender, EventArgs e)
        {

            R.EnvioInstruccionRelay("relay on 1");//Enciende relay

            timerOnUV7.Stop();//Apago timer de encendido
            timerOffUV7.Start();//Enciendo timer de apagado


            /*Para no iniciar los dos timer juntos*/
        }

        private void timerOffUV7_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV7.Stop();//Apago timer de encendido
            timerOnUV7.Start();//Enciendo timer de apagado

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerSesion7_Tick(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
        }

        private void timerOFFCalefactor_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
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
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmLoginEstado7 formtMenu7 = new Frames.FrmLoginEstado7();
            formtMenu7.Show();
            this.Close();
        }

        private void timerON_Tick(object sender, EventArgs e)
        {
            string DiaEN = DateTime.Now.DayOfWeek.ToString();
            string DiaEs = "";
            int Hora = DateTime.Now.Hour;
            int Minuto = DateTime.Now.Minute;
            int Segundo = DateTime.Now.Second;


            //SWTICH QUE TRADUCE LOS DIAS A ESPAÑOL
            switch (DiaEN)
            {
                case "Monday":
                    DiaEs = "Lunes";
                    break;

                case "Tuesday":
                    DiaEs = "Martes";
                    break;

                case "Wednesday":
                    DiaEs = "Miercoles";
                    break;

                case "Thursday":
                    DiaEs = "Jueves";
                    break;

                case "Friday":
                    DiaEs = "Viernes";
                    break;

                case "Saturday":
                    DiaEs = "Sabado";
                    break;

                case "Sunday":
                    DiaEs = "Domingo";
                    break;

            }


            //LLAMADA AL METODO QUE VALIDA ENCENDIDO AUTOMATICO DEL SECADOR 7
            if (SecadorBotas.Clases.ConexBD.ValidaPeriodoONSecador7(DiaEs, Hora, Minuto))
            {

                #region ENCIENDE_SECADOR


                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

                try
                {

                    R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay


                    R.EnvioInstruccionRelay("relay on 0");
                    R.EnvioInstruccionRelay("relay on 1");
                    R.EnvioInstruccionRelay("relay on 2");
                    R.EnvioInstruccionRelay("relay on 3");

                    Properties.Settings.Default.Bandera7ONOFF = "on";
                    Properties.Settings.Default.EstadoCalef7 = "on";
                    Properties.Settings.Default.Estado7 = 1;
                    Properties.Settings.Default.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Programado para encender secador 7 el " + DiaEs + " a las " + Hora + ":" + Minuto + "\n No se puede realizar la acción ya que existe un error de red!");
                }

                #endregion ENCIENDE_SECADOR

            }
        }

        private void timerOFF_Tick(object sender, EventArgs e)
        {
            string DiaEN = DateTime.Now.DayOfWeek.ToString();
            string DiaEs = "";
            int Hora = DateTime.Now.Hour;
            int Minuto = DateTime.Now.Minute;


            //SWTICH QUE TRADUCE LOS DIAS A ESPAÑOL
            switch (DiaEN)
            {
                case "Monday":
                    DiaEs = "Lunes";
                    break;

                case "Tuesday":
                    DiaEs = "Martes";
                    break;

                case "Wednesday":
                    DiaEs = "Miercoles";
                    break;

                case "Thursday":
                    DiaEs = "Jueves";
                    break;

                case "Friday":
                    DiaEs = "Viernes";
                    break;

                case "Saturday":
                    DiaEs = "Sabado";
                    break;

                case "Sunday":
                    DiaEs = "Domingo";
                    break;

            }


            //LLAMADA AL METODO QUE VALIDA APAGADO AUTOMATICO DEL SECADOR 7
            if (SecadorBotas.Clases.ConexBD.ValidaPeriodoOFFSecador7(DiaEs, Hora, Minuto))
            {

                #region APAGA_SECADOR

                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

                try
                {
                    R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay

                    R.EnvioInstruccionRelay("reset");

                    Properties.Settings.Default.Bandera7ONOFF = "off";
                    Properties.Settings.Default.EstadoCalef7 = "off";
                    Properties.Settings.Default.Save();

                    R.Close();

                    Properties.Settings.Default.Estado7 = 0;
                    Properties.Settings.Default.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Programado para apagar secador 7 el " + DiaEs + " a las " + Hora + ":" + Minuto + "\n No se puede realizar la acción ya que existe un error de red!");

                }

                #endregion APAGA_SECADOR


            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    
    public partial class FrmTarjeta1 : Form
    {      
        //comienza en apagado.
        int estado = 0;

        Clases.Relay R = new Clases.Relay();


        public FrmTarjeta1()
        {
            InitializeComponent();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            
          
        }

        private void btnMenuServicio_Click(object sender, EventArgs e)
        {
           
        }
     
        private void FrmTarjeta1_Load(object sender, EventArgs e)
        {

            #region EncendidoApagado

            int encendidoUV1 = Properties.Settings.Default.TUVON1;
            int apagadoUV1 = Properties.Settings.Default.TUVOFF1;

            int milisegundosON = encendidoUV1 * 60000;

            timerOnUV1.Interval = milisegundosON;

            int milisegundosOFF = apagadoUV1 * 60000;

            timerOffUV1.Interval = milisegundosOFF;

            #endregion EncendidoApagado

            timerON.Start();

            timerOFF.Start();


            //Despues de 15 minutos vuelve la pantalla de los secadores
            timerSesion1.Enabled = true;    

            timerBotonONOFF.Enabled = true;         

            timer1.Enabled = true;
  
            timerTemp.Enabled = true;

            //Temp Máxima
            int TempMax1 = Properties.Settings.Default.TempMax1;
            lblTempMax1.Text = TempMax1.ToString() + "°C";
  
          }

        private void timerTemp_Tick(object sender, EventArgs e)
        {

            try
            {
                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

                R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay    

                lblMensaje1.Text = "";

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
                progressBarTemp1.Value = Respuesta3;
                lblTemp.Text = Respuesta3.ToString() + "°C";

                int temnpMax = Properties.Settings.Default.TempMax1;
                string EstadoCalefactor = Properties.Settings.Default.EstadoCalef1;

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
                lblMensaje1.Text = "SIN RED";

            }
}


    
        private void timerBotonONOFF_Tick(object sender, EventArgs e)
        {

            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

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

            string Estado = Properties.Settings.Default.Bandera1ONOFF.ToString();//Estado encendido o no

            switch (Estado)

            {
               
                //Caso ON
                case "on":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef1 = "off";//Guarda estado para ocuparlo en timer Temp
                        Properties.Settings.Default.Save();

                        //Consulta estado high/off
                        if(estado!=0)//Si estado es distinto de 0...
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

                           int temnpMax = Properties.Settings.Default.TempMax1;

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

                        timerOnUV1.Enabled = false;

                        timerOffUV1.Enabled = false;

                        #endregion Encendido_y_apagado_de_UV

                      #region ActualizaEstados

                        //  //Ventilador sin movimiento
                      //  pictureBox1.Invalidate();
                      //  //Fondo de calefactor transparente
                      //  pictureBox2.BackColor = Color.Transparent;
                      //  //Fondo de UV transparente
                      //  pictureBox3.BackColor = Color.Transparent;
                      //  //Estado 
                      //  lblEstadoVent1.Text = "OFF";
                      //  lblEstadoVent1.BackColor = Color.Red;
                      //  lblEstadoUV1.Text = "OFF";
                      //  lblEstadoUV1.BackColor = Color.Red;
                      //  lblEstadoCalefactor1.Text = "OFF";
                      //  lblEstadoCalefactor1.BackColor = Color.Red;

                      //  //Guardar estado
                        Properties.Settings.Default.Bandera1ONOFF = "off";
                        Properties.Settings.Default.Save();

                       #endregion ActualizaEstados

                   }
               }

                    else{

                        Properties.Settings.Default.EstadoCalef1 = "on";//Guarda estado para ocuparlo en timer Temp
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


                            int temnpMax = Properties.Settings.Default.TempMax1;



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

                       timerOffUV1.Enabled = true;

                      #endregion Encendido_y_apagado_de_UV

                       #region ActualizaEstados

                            //     //Actualiza estados
                       //     lblEstadoVent1.Text = "ON";
                       //     lblEstadoVent1.BackColor = Color.Lime;

                       //     //UV
                       //     lblEstadoUV1.Text = "ON";
                       //     lblEstadoUV1.BackColor = Color.Lime;
                       //     pictureBox3.BackColor = Color.DarkViolet;

                       //     //rotar imagen de ventilador
                       //     pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                       //     pictureBox1.Invalidate();

                       //     //Guardar estado
                            Properties.Settings.Default.Bandera1ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                   } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")

                     {
                         Properties.Settings.Default.EstadoCalef1 = "on";//Guarda estado para ocuparlo en timer Temp
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


                            int temnpMax = Properties.Settings.Default.TempMax1;


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

                        timerOffUV1.Enabled = true;

                       #endregion Encendido_y_apagado_de_UV

                       #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera1ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else//Si no...
                    {
                        Properties.Settings.Default.EstadoCalef1 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax1;

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

                        timerOnUV1.Enabled = false;

                        timerOffUV1.Enabled = false;

                       #endregion Encendido_y_apagado_de_UV

                       #region ActualizaEstados

                            ////Ventilador sin movimiento
                            //pictureBox1.Invalidate();
                            ////Fondo de calefactor transparente
                            //pictureBox2.BackColor = Color.Transparent;
                            ////Fondo de UV transparente
                            //pictureBox3.BackColor = Color.Transparent;
                            ////Estado 
                            //lblEstadoVent1.Text = "OFF";
                            //lblEstadoVent1.BackColor = Color.Red;
                            //lblEstadoUV1.Text = "OFF";
                            //lblEstadoUV1.BackColor = Color.Red;
                            //lblEstadoCalefactor1.Text = "OFF";
                            //lblEstadoCalefactor1.BackColor = Color.Red;


                            //Guardar estado
                            Properties.Settings.Default.Bandera1ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;

                }

            #endregion MenúEncenderApagar

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
                #region Relays

                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

                R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

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
                    lblEstadoVent1.Text = "ON";
                    lblEstadoVent1.BackColor = Color.Lime;
                    this.lblEstadoVent1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                    
                    //Rota ventilador
                    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox1.Invalidate();

                }

                if (rele == "off")//Ventilador
                {

                    //Actualiza estados
                    lblEstadoVent1.Text = "OFF";
                    lblEstadoVent1.BackColor = Color.Red;
                    this.lblEstadoVent1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                    //Inmoviliza 
                   
                    //Inmoviliza 
                    pictureBox1.Invalidate();

                }

                #endregion Relay_ventilador

                #region Relay_UV

                if (rele2 == "on")//UV
                {
                    //Actualiza estados

                    lblEstadoUV1.Text = "ON";
                    lblEstadoUV1.BackColor = Color.Lime;
                    this.lblEstadoUV1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = true;



                }

                if (rele2 == "off")//UV
                {
                    //Actualiza estados
                    lblEstadoUV1.Text = "OFF";
                    lblEstadoUV1.BackColor = Color.Red;
                    this.lblEstadoUV1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                    
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = false;

                }

                #endregion Relay_UV

                #region Relay_Calefactor

                if (rele3 == "on")//CALEFACTOR
                {
                    //Actualiza estados

                    lblEstadoCalefactor1.Text = "ON";
                    lblEstadoCalefactor1.BackColor = Color.Lime;
                    this.lblEstadoCalefactor1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");//Texto color negro

                    pictureBox5.Visible = true;
                    pictureBox2.Visible = false;

                }

                if (rele3 == "off")//CALEFACTOR
                {
                    //Actualiza estados
                    lblEstadoCalefactor1.Text = "OFF";
                    lblEstadoCalefactor1.BackColor = Color.Red;
                    this.lblEstadoCalefactor1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco
                    pictureBox5.Visible = false;

                    pictureBox5.Visible = false;
                    pictureBox2.Visible = true;
                }

                #endregion Relay_Calefactor

                #endregion Relays
         
        }

        private void timerCalefactor_Tick(object sender, EventArgs e)
        {
            int TempApagado = Properties.Settings.Default.TempMax1;

             string respuesta1 = R.EnvioInstruccionRelay("adc read 1").Substring(0, 3);//Entrega temperatura
            int Respuesta = Convert.ToInt32(respuesta1);

            //Obtención de temperatura fórmula
            string Respuesta2 = (Respuesta * 3.3).ToString();
            double Respuesta22 = (Convert.ToDouble(Respuesta2) / 1024);
            double Respuesta222 = (Convert.ToDouble(Respuesta22 - 0.5));
            double Respuesta2222 = (Respuesta222 * 100);
            //FIN Obtención de temperatura fórmula            


            //Llenado de barra de temperatura
            int Respuesta3 = Convert.ToInt32(Respuesta2222);

            if (Respuesta3 > TempApagado)
            {
                R.EnvioInstruccionRelay("relay off 2");
                R.EnvioInstruccionRelay("relay off 3");
                //Guardar estado

                lblEstadoCalefactor1.Text = "OFF";
                lblEstadoCalefactor1.BackColor = Color.Red;
                this.lblEstadoCalefactor1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");//Texto color blanco

                pictureBox2.BackColor = Color.Transparent;
                Properties.Settings.Default.Calefactoronoff = "off";//Guarada estado de calefactor
                Properties.Settings.Default.Save();

            }
           
          }

        private void timerONCalefactor_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
            
        }

        private void timerOFFCalefactor_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
            
        }

        private void timerOnUV1_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 1");//Enciende relay

            timerOnUV1.Stop();//Apago timer de encendido
            timerOffUV1.Start();//Enciendo timer de apagado
            

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerOffUV1_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV1.Stop();//Apago timer de encendido
            timerOnUV1.Start();//Enciendo timer de apagado
            
            

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerSesion1_Tick(object sender, EventArgs e)
        {
            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmSecadores formtMenu1 = new Frames.FrmSecadores();
            formtMenu1.Show();
            this.Close();
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
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

            R.Close();
            R.EnvioInstruccionRelay("reset");
            Frames.FrmLoginEstado1 formtMenu1 = new Frames.FrmLoginEstado1();
            formtMenu1.Show();
            this.Close();
        }

        private void timerTestConex_Tick(object sender, EventArgs e)
        {
          
            
        }

        private void timerON_Tick(object sender, EventArgs e)
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


            //LLAMADA AL METODO QUE VALIDA ENCENDIDO AUTOMATICO DEL SECADOR 1
            if (SecadorBotas.Clases.ConexBD.ValidaPeriodoONSecador1(DiaEs, Hora, Minuto))
            {

                #region ENCIENDE_SECADOR

                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

                try
                {

                    R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay

                    R.EnvioInstruccionRelay("relay on 0");
                    R.EnvioInstruccionRelay("relay on 1");
                    R.EnvioInstruccionRelay("relay on 2");
                    R.EnvioInstruccionRelay("relay on 3");

                    Properties.Settings.Default.Bandera1ONOFF = "on";
                    Properties.Settings.Default.EstadoCalef1 = "on";
                    Properties.Settings.Default.Estado1 = 1;
                    Properties.Settings.Default.Save();

                }
                catch (Exception)
                {
                    MessageBox.Show("Programado para encender secador 1 el " + DiaEs + " a las " + Hora + ":" + Minuto + "\n No se puede realizar la acción ya que existe un error de red!");
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


            //LLAMADA AL METODO QUE VALIDA APAGADO AUTOMATICO DEL SECADOR 1
            if (SecadorBotas.Clases.ConexBD.ValidaPeriodoOFFSecador1(DiaEs, Hora, Minuto))
            {

                #region APAGA_SECADOR

                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

                try
                {

                    R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay

                    R.EnvioInstruccionRelay("reset");

                    Properties.Settings.Default.Bandera1ONOFF = "off";
                    Properties.Settings.Default.EstadoCalef1 = "off";
                    Properties.Settings.Default.Save();

                    R.Close();

                    Properties.Settings.Default.Estado1 = 0;
                    Properties.Settings.Default.Save();

                }

                catch (Exception)
                {
                    MessageBox.Show("Programado para apagar secador 1 el " + DiaEs + " a las " + Hora + ":" + Minuto + "\n No se puede realizar la acción ya que existe un error de red!");

                }

                #endregion APAGA_SECADOR

            }
        }
    } 
 
}



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
using System.Threading;

namespace SecadorBotas.Frames
{
    public partial class FrmSecadores : Form
    {

        //comienza en apagado.
        int estado = 0;
        
        /*Isntancia de la clase Relay*/
        Clases.Relay R = new Clases.Relay();

        public FrmSecadores()
        {
            InitializeComponent();

        }


        private void FrmSecadores_Load(object sender, EventArgs e)
        {
           

            #region Secador1

            //Si estado de secador es igual a 1 activa timers
            if (Properties.Settings.Default.Estado1 == 1) { 
            
            //timer respuesta de botón
            timerBoton1.Start();
            //timer estado secador
            timer1.Start();
            //timer suma hrs de funcionamiento ventilador
            timerHrsVent1.Start();
            //timer suma hrs de funcionamiento calefactor
            timerHrsCalef1.Start();
            //timer suma hrs de funcionamiento UV
            timerHrsUV1.Start();
            //timer temperatura
            timerTemp1.Start();
            }
            //Si no desactiva timers
            if (Properties.Settings.Default.Estado1 == 0)
            {
                timerBoton1.Stop();
                timer1.Stop();
                timerHrsVent1.Stop();
                timerHrsCalef1.Stop();
                timerHrsUV1.Stop();
                timerTemp1.Stop();

                //Deshabilita picturebox de ON y OFF
                pictureBoxT1OFF.Visible = false;
                pictureBoxT1ON.Visible = false; 

                //Activa picturebox DESACTIVADO
                pictureBoxDisabled1.Visible = true;
            }

            #endregion Secador1

            #region EnvioCorreoSecador1

            #region Ventilador

            //Horas máximas dispositivo
            int MaxMotor1 = Properties.Settings.Default.HMM1;//Ventilador

            #region Hrs

            int AnoVent = Properties.Settings.Default.AnoVent;
            int MesVent = Properties.Settings.Default.MesVent;
            int DiaVent = Properties.Settings.Default.DiaVent;
            int HrsVent = Properties.Settings.Default.HoraVent;
            int MinVent = Properties.Settings.Default.MinVent;
            int SegVent = Properties.Settings.Default.SegVent;

            DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
            DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent = fechaNuevaVent - fechaAntiguaVent;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent.TotalHours)) >= Convert.ToInt32(MaxMotor1))
            {
                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL1Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL1Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 1", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 1 necesita ser reemplazado!" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "<p> Debe resetar VENTILADOR de máquina 1! </p> <a href=\"http://www.fishken.com/\">www.fishken.com</a>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }

            }

            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV1 = Properties.Settings.Default.HMUV1;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV = Properties.Settings.Default.AnoUV;
            int MesUV = Properties.Settings.Default.MesUV;
            int DiaUV = Properties.Settings.Default.DiaUV;
            int HrsUV = Properties.Settings.Default.HoraUV;
            int MinUV = Properties.Settings.Default.MinUV;
            int SegUV = Properties.Settings.Default.SegUV;

            DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
            DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV.TotalHours)) >= Convert.ToInt32(MaxUV1))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL1Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL1Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 1", System.Text.Encoding.UTF8);
                email.Subject = "UV 1 necesita ser reemplazado!" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "<p> Debe reemplazar UV de máquina 1! </p>  <a href=\"http://www.fishken.com/\">www.fishken.com</a>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef1 = Properties.Settings.Default.HMC1;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef = Properties.Settings.Default.AnoCalefactor;
            int MesCalef = Properties.Settings.Default.MesCalefactor;
            int DiaCalef = Properties.Settings.Default.DiaCalefactor;
            int HrsCalef = Properties.Settings.Default.HoraCalefactor;
            int MinCalef = Properties.Settings.Default.MinCalefactor;
            int SegCalef = Properties.Settings.Default.SegCalefactor;

            DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
            DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef = fechaNuevaCalef - fechaAntiguaCalef;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef.TotalHours)) >= Convert.ToInt32(MaxCalef1))
            {
                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL1Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL1Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 1", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 1 necesita ser reemplazado!" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "<p>Debe reemplazar CALEFACTOR de máquina 2!</p> <a href=\"http://www.fishken.com/\">www.fishken.com</a>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }

            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador1

            #region EncendidoApagado1

            int encendidoUV1 = Properties.Settings.Default.TUVON1;
            int apagadoUV1 = Properties.Settings.Default.TUVOFF1;

            int milisegundosON = encendidoUV1 * 60000;

            timerOnUV1.Interval = milisegundosON;

            int milisegundosOFF = apagadoUV1 * 60000;

            timerOffUV1.Interval = milisegundosOFF;

            #endregion EncendidoApagado1

            #region Secador2

            if (Properties.Settings.Default.Estado2 == 1)
            {
                timerBoton2.Start();
                timer2.Start();
                timerHrsVent2.Start();
                timerHrsCalef2.Start();
                timerHrsUV2.Start();
                timerTemp2.Start();
            }

            if (Properties.Settings.Default.Estado2 == 0)
            {
                timerBoton2.Stop();
                timer2.Stop();
                timerHrsVent2.Stop();
                timerHrsCalef2.Stop();
                timerHrsUV2.Stop();
                timerTemp2.Stop();

                pictureBoxT2OFF.Visible = false;
                pictureBoxT2ON.Visible = false;
                pictureBoxDisabled2.Visible = true;
            }


            #endregion Secador2

            #region EnvioCorreoSecador2

            #region Ventilador
            //Horas máximas dispositivos
            int MaxMotor2 = Properties.Settings.Default.HMM2;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoVent2 = Properties.Settings.Default.AnoVentDos;
            int MesVent2 = Properties.Settings.Default.MesVentDos;
            int DiaVent2 = Properties.Settings.Default.DiaVentDos;
            int HrsVent2 = Properties.Settings.Default.HoraVentDos;
            int MinVent2 = Properties.Settings.Default.MinVentDos;
            int SegVent2 = Properties.Settings.Default.SegVentDos;

            DateTime fechaAntiguaVent2 = new DateTime(AnoVent2, MesVent2, DiaVent2, HrsVent2, MinVent2, SegVent2);//Fecha establecida
            DateTime fechaNuevaVent2 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent2 = fechaNuevaVent2 - fechaAntiguaVent2;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent2.TotalHours)) >= Convert.ToInt32(MaxMotor2))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL2Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL2Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 2", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 2 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "<p>Debe reemplazar VENTILADOR de máquina 2!</p> <a href=\"http://www.fishken.com/\">www.fishken.com</a>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }
            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV2 = Properties.Settings.Default.HMUV2;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV2 = Properties.Settings.Default.AnoUVDos;
            int MesUV2 = Properties.Settings.Default.MesUVDos;
            int DiaUV2 = Properties.Settings.Default.DiaUVDos;
            int HrsUV2 = Properties.Settings.Default.HoraUVDos;
            int MinUV2 = Properties.Settings.Default.MinUVDos;
            int SegUV2 = Properties.Settings.Default.SegUVDos;

            DateTime fechaAntiguaUV2 = new DateTime(AnoUV2, MesUV2, DiaUV2, HrsUV2, MinUV2, SegUV2);//Fecha establecida
            DateTime fechaNuevaUV2 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV2 = fechaNuevaUV2 - fechaAntiguaUV2;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV2.TotalHours)) >= Convert.ToInt32(MaxUV2))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL2Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL2Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo



                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 2", System.Text.Encoding.UTF8);
                email.Subject = "UV 2 necesita ser reemplazado!" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "<p>Debe reemplazar UV de máquina 2!</p> <a href=\"http://www.fishken.com/\">www.fishken.com</a>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef2 = Properties.Settings.Default.HMC2;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef2 = Properties.Settings.Default.AnoCalefactorDos;
            int MesCalef2 = Properties.Settings.Default.MesCalefactorDos;
            int DiaCalef2 = Properties.Settings.Default.DiaCalefactorDos;
            int HrsCalef2 = Properties.Settings.Default.HoraCalefactorDos;
            int MinCalef2 = Properties.Settings.Default.MinCalefactorDos;
            int SegCalef2 = Properties.Settings.Default.SegCalefactorDos;

            DateTime fechaAntiguaCalef2 = new DateTime(AnoCalef2, MesCalef2, DiaCalef2, HrsCalef2, MinCalef2, SegCalef2);//Fecha establecida
            DateTime fechaNuevaCalef2 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef2 = fechaNuevaCalef2 - fechaAntiguaCalef2;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef2.TotalHours)) >= Convert.ToInt32(MaxCalef2))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL2Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL2Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 2", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 2 necesita ser reemplazado!" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "<p>Debe reemplazar CALEFACTOR de máquina 2!</p> <a href=\"http://www.fishken.com/\">www.fishken.com</a>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador2

            #region EncendidoApagado2

            int encendidoUV2 = Properties.Settings.Default.TUVON2;
            int apagadoUV2 = Properties.Settings.Default.TUVOFF2;

            int milisegundosON2 = encendidoUV2 * 60000;

            timerOnUV2.Interval = milisegundosON2;

            int milisegundosOFF2 = apagadoUV2 * 60000;

            timerOffUV2.Interval = milisegundosOFF2;

            #endregion EncendidoApagado2

            #region Secador3

            if (Properties.Settings.Default.Estado3 == 1) { 

                timerBoton3.Start();
                timer3.Start();
                timerHrsVent3.Start();
                timerHrsCalef3.Start();
                timerHrsUV3.Start();
                timerTemp3.Start();
            }
            if (Properties.Settings.Default.Estado3 == 0)
            {
                timerBoton3.Stop();
                timer3.Stop();
                timerHrsVent3.Stop();
                timerHrsCalef3.Stop();
                timerHrsUV3.Stop();
                timerTemp3.Stop();

                pictureBoxT3OFF.Visible = false;
                pictureBoxT3ON.Visible = false;
                pictureBoxDisabled3.Visible = true;
            }


            #endregion Secador3

            #region EnvioCorreoSecador3

            #region Ventilador

            //Horas máximas dispositivos
            int MaxMotor3 = Properties.Settings.Default.HMM3;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoVent3 = Properties.Settings.Default.AnoVentTres;
            int MesVent3 = Properties.Settings.Default.MesVentTres;
            int DiaVent3 = Properties.Settings.Default.DiaVentTres;
            int HrsVent3 = Properties.Settings.Default.HoraVentTres;
            int MinVent3 = Properties.Settings.Default.MinVentTres;
            int SegVent3 = Properties.Settings.Default.SegVentTres;

            DateTime fechaAntiguaVent3 = new DateTime(AnoVent3, MesVent3, DiaVent3, HrsVent3, MinVent3, SegVent3);//Fecha establecida
            DateTime fechaNuevaVent3 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent3 = fechaNuevaVent3 - fechaAntiguaVent3;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent3.TotalHours)) >= Convert.ToInt32(MaxMotor3))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL3Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL3Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 3", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 3 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar VENTILADOR de máquina 3!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV3 = Properties.Settings.Default.HMUV3;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV3 = Properties.Settings.Default.AnoUVTres;
            int MesUV3 = Properties.Settings.Default.MesUVTres;
            int DiaUV3 = Properties.Settings.Default.DiaUVTres;
            int HrsUV3 = Properties.Settings.Default.HoraUVTres;
            int MinUV3 = Properties.Settings.Default.MinUVTres;
            int SegUV3 = Properties.Settings.Default.SegUVTres;

            DateTime fechaAntiguaUV3 = new DateTime(AnoUV3, MesUV3, DiaUV3, HrsUV3, MinUV3, SegUV3);//Fecha establecida
            DateTime fechaNuevaUV3 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV3 = fechaNuevaUV3 - fechaAntiguaUV3;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV3.TotalHours)) >= Convert.ToInt32(MaxUV3))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL3Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL3Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 3", System.Text.Encoding.UTF8);
                email.Subject = "UV 3 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar UV de máquina 3!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef3 = Properties.Settings.Default.HMC3;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef3 = Properties.Settings.Default.AnoCalefactorTres;
            int MesCalef3 = Properties.Settings.Default.MesCalefactorTres;
            int DiaCalef3 = Properties.Settings.Default.DiaCalefactorTres;
            int HrsCalef3 = Properties.Settings.Default.HoraCalefactorTres;
            int MinCalef3 = Properties.Settings.Default.MinCalefactorTres;
            int SegCalef3 = Properties.Settings.Default.SegCalefactorTres;

            DateTime fechaAntiguaCalef3 = new DateTime(AnoCalef3, MesCalef3, DiaCalef3, HrsCalef3, MinCalef3, SegCalef3);//Fecha establecida
            DateTime fechaNuevaCalef3 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef3 = fechaNuevaCalef3 - fechaAntiguaCalef3;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef3.TotalHours)) >= Convert.ToInt32(MaxCalef3))
            {


                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL3Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL3Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 3", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 3 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar CALEFACTOR de máquina 3!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador3

            #region EncendidoApagado3

            int encendidoUV3 = Properties.Settings.Default.TUVON3;
            int apagadoUV3 = Properties.Settings.Default.TUVOFF3;

            int milisegundosON3 = encendidoUV3 * 60000;

            timerOnUV3.Interval = milisegundosON3;

            int milisegundosOFF3 = apagadoUV3 * 60000;

            timerOffUV3.Interval = milisegundosOFF3;

            #endregion EncendidoApagado3

            #region Secador4

            if (Properties.Settings.Default.Estado4 == 1)
            {

                timerBoton4.Start();
                timer4.Start();
                timerHrsVent4.Start();
                timerHrsCalef4.Start();
                timerHrsUV4.Start();
                timerTemp4.Start();
            }

            if (Properties.Settings.Default.Estado4 == 0)
            {

                timerBoton4.Stop();
                timer4.Stop();
                timerHrsVent4.Stop();
                timerHrsCalef4.Stop();
                timerHrsUV4.Stop();
                timerTemp4.Stop();

                pictureBoxT4OFF.Visible = false;
                pictureBoxT4ON.Visible = false;
                pictureBoxDisabled4.Visible = true;
            }


            #endregion Secador4

            #region EnvioCorreoSecador4

            #region Ventilador

            //Horas máximas dispositivos
            int MaxMotor4 = Properties.Settings.Default.HMM4;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoVent4 = Properties.Settings.Default.AnoVentCuatro;
            int MesVent4 = Properties.Settings.Default.MesVentCuatro;
            int DiaVent4 = Properties.Settings.Default.DiaVentCuatro;
            int HrsVent4 = Properties.Settings.Default.HoraVentCuatro;
            int MinVent4 = Properties.Settings.Default.MinVentCuatro;
            int SegVent4 = Properties.Settings.Default.SegVentCuatro;

            DateTime fechaAntiguaVent4 = new DateTime(AnoVent4, MesVent4, DiaVent4, HrsVent4, MinVent4, SegVent4);//Fecha establecida
            DateTime fechaNuevaVent4 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent4 = fechaNuevaVent4 - fechaAntiguaVent4;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent4.TotalHours)) >= Convert.ToInt32(MaxMotor4))
            {
                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL4Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL4Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 4", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 4 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar VENTILADOR de máquina 4!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV4 = Properties.Settings.Default.HMUV4;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV4 = Properties.Settings.Default.AnoUVCuatro;
            int MesUV4 = Properties.Settings.Default.MesUVCuatro;
            int DiaUV4 = Properties.Settings.Default.DiaUVCuatro;
            int HrsUV4 = Properties.Settings.Default.HoraUVCuatro;
            int MinUV4 = Properties.Settings.Default.MinUVCuatro;
            int SegUV4 = Properties.Settings.Default.SegUVCuatro;

            DateTime fechaAntiguaUV4 = new DateTime(AnoUV4, MesUV4, DiaUV4, HrsUV4, MinUV4, SegUV4);//Fecha establecida
            DateTime fechaNuevaUV4 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV4 = fechaNuevaUV4 - fechaAntiguaUV4;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV4.TotalHours)) >= Convert.ToInt32(MaxUV4))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL4Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL4Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 4", System.Text.Encoding.UTF8);
                email.Subject = "UV 4 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar UV de máquina 4!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }



            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef4 = Properties.Settings.Default.HMC4;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef4 = Properties.Settings.Default.AnoCalefactorCuatro;
            int MesCalef4 = Properties.Settings.Default.MesCalefactorCuatro;
            int DiaCalef4 = Properties.Settings.Default.DiaCalefactorCuatro;
            int HrsCalef4 = Properties.Settings.Default.HoraCalefactorCuatro;
            int MinCalef4 = Properties.Settings.Default.MinCalefactorCuatro;
            int SegCalef4 = Properties.Settings.Default.SegCalefactorCuatro;

            DateTime fechaAntiguaCalef4 = new DateTime(AnoCalef4, MesCalef4, DiaCalef4, HrsCalef4, MinCalef4, SegCalef4);//Fecha establecida
            DateTime fechaNuevaCalef4 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef4 = fechaNuevaCalef4 - fechaAntiguaCalef4;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef4.TotalHours)) >= Convert.ToInt32(MaxCalef4))
            {
                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL4Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL4Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 4", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 4 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar CALEFACTOR de máquina 4!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador4

            #region EncendidoApagado4

            int encendidoUV4 = Properties.Settings.Default.TUVON4;
            int apagadoUV4 = Properties.Settings.Default.TUVOFF4;

            int milisegundosON4 = encendidoUV4 * 60000;

            timerOnUV4.Interval = milisegundosON4;

            int milisegundosOFF4 = apagadoUV4 * 60000;

            timerOffUV4.Interval = milisegundosOFF4;

            #endregion EncendidoApagado4

            #region Secador5

            if (Properties.Settings.Default.Estado5 == 1)
            {

                timerBoton5.Start();
                timer5.Start();
                timerHrsVent5.Start();
                timerHrsCalef5.Start();
                timerHrsUV5.Start();
                timerTemp5.Start();
            }

            if (Properties.Settings.Default.Estado5 == 0)
            {

                timerBoton5.Stop();
                timer5.Stop();
                timerHrsVent5.Stop();
                timerHrsCalef5.Stop();
                timerHrsUV5.Stop();
                timerTemp5.Stop();

                pictureBoxT5OFF.Visible = false;
                pictureBoxT5ON.Visible = false;
                pictureBoxDisabled5.Visible = true;
            }


            #endregion Secador5

            #region EnvioCorreoSecador5

            #region Ventilador

            //Horas máximas dispositivos
            int MaxMotor5 = Properties.Settings.Default.HMM5;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoVent5 = Properties.Settings.Default.AnoVentCinco;
            int MesVent5 = Properties.Settings.Default.MesVentCinco;
            int DiaVent5 = Properties.Settings.Default.DiaVentCinco;
            int HrsVent5 = Properties.Settings.Default.HoraVentCinco;
            int MinVent5 = Properties.Settings.Default.MinVentCinco;
            int SegVent5 = Properties.Settings.Default.SegVentCinco;

            DateTime fechaAntiguaVent5 = new DateTime(AnoVent5, MesVent5, DiaVent5, HrsVent5, MinVent5, SegVent5);//Fecha establecida
            DateTime fechaNuevaVent5 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent5 = fechaNuevaVent5 - fechaAntiguaVent5;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent5.TotalHours)) >= Convert.ToInt32(MaxMotor5))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL5Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL5Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 5", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 5 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar VENTILADOR de máquina 5!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV5 = Properties.Settings.Default.HMUV5;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV5 = Properties.Settings.Default.AnoUVCinco;
            int MesUV5 = Properties.Settings.Default.MesUVCinco;
            int DiaUV5 = Properties.Settings.Default.DiaUVCinco;
            int HrsUV5 = Properties.Settings.Default.HoraUVCinco;
            int MinUV5 = Properties.Settings.Default.MinUVCinco;
            int SegUV5 = Properties.Settings.Default.SegUVCinco;

            DateTime fechaAntiguaUV5 = new DateTime(AnoUV5, MesUV5, DiaUV5, HrsUV5, MinUV5, SegUV5);//Fecha establecida
            DateTime fechaNuevaUV5 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV5 = fechaNuevaUV5 - fechaAntiguaUV5;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV5.TotalHours)) >= Convert.ToInt32(MaxUV5))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL5Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL5Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 5", System.Text.Encoding.UTF8);
                email.Subject = "UV 5 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar UV de máquina 5!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }


            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef5 = Properties.Settings.Default.HMC5;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef5 = Properties.Settings.Default.AnoCalefactorCinco;
            int MesCalef5 = Properties.Settings.Default.MesCalefactorCinco;
            int DiaCalef5 = Properties.Settings.Default.DiaCalefactorCinco;
            int HrsCalef5 = Properties.Settings.Default.HoraCalefactorCinco;
            int MinCalef5 = Properties.Settings.Default.MinCalefactorCinco;
            int SegCalef5 = Properties.Settings.Default.SegCalefactorCinco;

            DateTime fechaAntiguaCalef5 = new DateTime(AnoCalef5, MesCalef5, DiaCalef5, HrsCalef5, MinCalef5, SegCalef5);//Fecha establecida
            DateTime fechaNuevaCalef5 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef5 = fechaNuevaCalef5 - fechaAntiguaCalef5;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef5.TotalHours)) >= Convert.ToInt32(MaxCalef5))
            {
                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL5Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL5Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 5", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 5 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar CALEFACTOR de máquina 5!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador5

            #region EncendidoApagado5

            int encendidoUV5 = Properties.Settings.Default.TUVON5;
            int apagadoUV5 = Properties.Settings.Default.TUVOFF5;

            int milisegundosON5 = encendidoUV5 * 60000;

            timerOnUV5.Interval = milisegundosON5;

            int milisegundosOFF5 = apagadoUV5 * 60000;

            timerOffUV5.Interval = milisegundosOFF5;

            #endregion EncendidoApagado5

            #region Secador6

            if (Properties.Settings.Default.Estado6 == 1)
            {

                timerBoton6.Start();
                timer6.Start();
                timerHrsVent6.Start();
                timerHrsCalef6.Start();
                timerHrsUV6.Start();
                timerTemp6.Start();
            }

            if (Properties.Settings.Default.Estado6 == 0)
            {

                timerBoton6.Stop();
                timer6.Stop();
                timerHrsVent6.Stop();
                timerHrsCalef6.Stop();
                timerHrsUV6.Stop();
                timerTemp6.Stop();

                pictureBoxT6OFF.Visible = false;
                pictureBoxT6ON.Visible = false;
                pictureBoxDisabled6.Visible = true;
            }


            #endregion Secador6

            #region EnvioCorreoSecador6

            #region Ventilador

            //Horas máximas dispositivos
            int MaxMotor6 = Properties.Settings.Default.HMM6;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoVent6 = Properties.Settings.Default.AnoVentSeis;
            int MesVent6 = Properties.Settings.Default.MesVentSeis;
            int DiaVent6 = Properties.Settings.Default.DiaVentSeis;
            int HrsVent6 = Properties.Settings.Default.HoraVentSeis;
            int MinVent6 = Properties.Settings.Default.MinVentSeis;
            int SegVent6 = Properties.Settings.Default.SegVentSeis;

            DateTime fechaAntiguaVent6 = new DateTime(AnoVent6, MesVent6, DiaVent6, HrsVent6, MinVent6, SegVent6);//Fecha establecida
            DateTime fechaNuevaVent6 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent6 = fechaNuevaVent6 - fechaAntiguaVent6;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent6.TotalHours)) >= Convert.ToInt32(MaxMotor6))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL6Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL6Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 6", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 6 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar VENTILADOR de máquina 6!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV6 = Properties.Settings.Default.HMUV6;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV6 = Properties.Settings.Default.AnoUVSeis;
            int MesUV6 = Properties.Settings.Default.MesUVSeis;
            int DiaUV6 = Properties.Settings.Default.DiaUVSeis;
            int HrsUV6 = Properties.Settings.Default.HoraUVSeis;
            int MinUV6 = Properties.Settings.Default.MinUVSeis;
            int SegUV6 = Properties.Settings.Default.SegUVSeis;

            DateTime fechaAntiguaUV6 = new DateTime(AnoUV6, MesUV6, DiaUV6, HrsUV6, MinUV6, SegUV6);//Fecha establecida
            DateTime fechaNuevaUV6 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV6 = fechaNuevaUV6 - fechaAntiguaUV6;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV6.TotalHours)) >= Convert.ToInt32(MaxUV6))
            {
                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL6Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL6Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 6", System.Text.Encoding.UTF8);
                email.Subject = "UV 6 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar UV de máquina 6!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef6 = Properties.Settings.Default.HMC6;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef6 = Properties.Settings.Default.AnoCalefactorSeis;
            int MesCalef6 = Properties.Settings.Default.MesCalefactorSeis;
            int DiaCalef6 = Properties.Settings.Default.DiaCalefactorSeis;
            int HrsCalef6 = Properties.Settings.Default.HoraCalefactorSeis;
            int MinCalef6 = Properties.Settings.Default.MinCalefactorSeis;
            int SegCalef6 = Properties.Settings.Default.SegCalefactorSeis;

            DateTime fechaAntiguaCalef6 = new DateTime(AnoCalef6, MesCalef6, DiaCalef6, HrsCalef6, MinCalef6, SegCalef6);//Fecha establecida
            DateTime fechaNuevaCalef6 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef6 = fechaNuevaCalef6 - fechaAntiguaCalef6;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef6.TotalHours)) >= Convert.ToInt32(MaxCalef6))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL6Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL6Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 6", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 6 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar CALEFACTOR de máquina 6!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador6

            #region EncendidoApagado6

            int encendidoUV6 = Properties.Settings.Default.TUVON6;
            int apagadoUV6 = Properties.Settings.Default.TUVOFF6;


            int milisegundosON6 = encendidoUV6 * 60000;

            timerOnUV6.Interval = milisegundosON6;

            int milisegundosOFF6 = apagadoUV6 * 60000;

            timerOffUV6.Interval = milisegundosOFF6;

            #endregion EncendidoApagado6

            #region Secador7

            if (Properties.Settings.Default.Estado7 == 1)
            {

                timerBoton7.Start();
                timer7.Start();
                timerHrsVent7.Start();
                timerHrsCalef7.Start();
                timerHrsUV7.Start();
                timerTemp7.Start();
            }

            if (Properties.Settings.Default.Estado7 == 0)
            {

                timerBoton7.Stop();
                timer7.Stop();
                timerHrsVent7.Stop();
                timerHrsCalef7.Stop();
                timerHrsUV7.Stop();
                timerTemp7.Stop();

                pictureBoxT7OFF.Visible = false;
                pictureBoxT7ON.Visible = false;
                pictureBoxDisabled7.Visible = true;
            }


            #endregion Secador7

            #region EnvioCorreoSecador7

            #region Ventilador

            //Horas máximas dispositivos
            int MaxMotor7 = Properties.Settings.Default.HMM7;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoVent7 = Properties.Settings.Default.AnoVentSiete;
            int MesVent7 = Properties.Settings.Default.MesVentSiete;
            int DiaVent7 = Properties.Settings.Default.DiaVentSiete;
            int HrsVent7 = Properties.Settings.Default.HoraVentSiete;
            int MinVent7 = Properties.Settings.Default.MinVentSiete;
            int SegVent7 = Properties.Settings.Default.SegVentSiete;

            DateTime fechaAntiguaVent7 = new DateTime(AnoVent7, MesVent7, DiaVent7, HrsVent7, MinVent7, SegVent7);//Fecha establecida
            DateTime fechaNuevaVent7 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsVent7 = fechaNuevaVent7 - fechaAntiguaVent7;

            #endregion Hrs


            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsVent7.TotalHours)) >= Convert.ToInt32(MaxMotor7))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL7Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL7Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo


                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 7", System.Text.Encoding.UTF8);
                email.Subject = "VENTILADOR 7 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar VENTILADOR de máquina 7!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Ventilador

            #region UV

            //Horas máximas dispositivos
            int MaxUV7 = Properties.Settings.Default.HMUV7;//Ventilador

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
            int AnoUV7 = Properties.Settings.Default.AnoUVSiete;
            int MesUV7 = Properties.Settings.Default.MesUVSiete;
            int DiaUV7 = Properties.Settings.Default.DiaUVSiete;
            int HrsUV7 = Properties.Settings.Default.HoraUVSiete;
            int MinUV7 = Properties.Settings.Default.MinUVSiete;
            int SegUV7 = Properties.Settings.Default.SegUVSiete;

            DateTime fechaAntiguaUV7 = new DateTime(AnoUV7, MesUV7, DiaUV7, HrsUV7, MinUV7, SegUV7);//Fecha establecida
            DateTime fechaNuevaUV7 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsUV7 = fechaNuevaUV7 - fechaAntiguaUV7;

            #endregion Hrs
            
            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsUV7.TotalHours)) >= Convert.ToInt32(MaxUV7))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL7Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL7Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 7", System.Text.Encoding.UTF8);
                email.Subject = "UV 7 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar UV de máquina 7!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion UV

            #region Calefactor

            //Horas máximas dispositivos
            int MaxCalef7 = Properties.Settings.Default.HMC7;//Calefactor

            #region Hrs

            //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
            int AnoCalef7 = Properties.Settings.Default.AnoCalefactorSiete;
            int MesCalef7 = Properties.Settings.Default.MesCalefactorSiete;
            int DiaCalef7 = Properties.Settings.Default.DiaCalefactorSiete;
            int HrsCalef7 = Properties.Settings.Default.HoraCalefactorSiete;
            int MinCalef7 = Properties.Settings.Default.MinCalefactorSiete;
            int SegCalef7 = Properties.Settings.Default.SegCalefactorSiete;

            DateTime fechaAntiguaCalef7 = new DateTime(AnoCalef7, MesCalef7, DiaCalef7, HrsCalef7, MinCalef7, SegCalef7);//Fecha establecida
            DateTime fechaNuevaCalef7 = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan tsCalef7 = fechaNuevaCalef7 - fechaAntiguaCalef7;

            #endregion Hrs

            //Condición para enviar correo si las horas de funcionamiento superan las hrs máximas de funcionamiento
            if (Convert.ToInt32(Math.Truncate(tsCalef7.TotalHours)) >= Convert.ToInt32(MaxCalef7))
            {

                //Correo receptor email de advertencia
                string primeraParteEmail = Properties.Settings.Default.EMAIL7Parte1.ToString();
                string segundaParteEmail = Properties.Settings.Default.EMAIL7Parte2.ToString();
                string arroba = "@";
                string correo = primeraParteEmail + arroba + segundaParteEmail;//Correo

                MailMessage email = new MailMessage();
                email.To.Add(correo);
                email.From = new MailAddress("fishkenalarmas@gmail.com", "FishKen SECADOR DE BOTAS 7", System.Text.Encoding.UTF8);
                email.Subject = "CALEFACTOR 7 necesita ser reemplazado" + " ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.SubjectEncoding = System.Text.Encoding.UTF8;
                email.Body = "Debe reemplazar CALEFACTOR de máquina 7!";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                /*Especificación correo emisor*/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fishkenalarmas@gmail.com", "fishken2018");

                string output = null;

                try
                {
                    smtp.Send(email);
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error en el envío: " + ex.Message;
                }
            }

            #endregion Calefactor

            #endregion EnvioCorreoSecador7

            #region EncendidoApagado7

            int encendidoUV7 = Properties.Settings.Default.TUVON7;
            int apagadoUV7 = Properties.Settings.Default.TUVOFF7;


            int milisegundosON7 = encendidoUV7 * 60000;

            timerOnUV7.Interval = milisegundosON7;

            int milisegundosOFF7 = apagadoUV7 * 60000;

            timerOffUV7.Interval = milisegundosOFF7;

            #endregion EncendidoApagado7

        }

        private void btnEstadoT1_Click(object sender, EventArgs e)
        {
           



        }

        private void btnEstadoT2_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta2 formt2 = new Frames.FrmTarjeta2();
            formt2.Show();
            //this.Close();
        }

        private void btnEstadoT3_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta3 formt3 = new Frames.FrmTarjeta3();
            formt3.Show();
            //this.Close();
        }

        private void btnEstadoT4_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta4 formt4 = new Frames.FrmTarjeta4();
            formt4.Show();
            //this.Close();
        }

        private void btnEstadoT5_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta5 formt5 = new Frames.FrmTarjeta5();
            formt5.Show();
            //this.Close();
        }

        private void btnEstadoT6_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta6 formt6 = new Frames.FrmTarjeta6();
            formt6.Show();
            //this.Close();
        }

        private void btnEstadoT7_Click(object sender, EventArgs e)
        {
            Frames.FrmTarjeta7 formt7 = new Frames.FrmTarjeta7();
            formt7.Show();
            //this.Close();
        }

     


        private void timer1_Tick(object sender, EventArgs e)
        {

            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

           
            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay  

            //Lee estado Relay 0
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");
           
            
            //Consulta si la tarjeta está encendida...
            if (rele == "on")
            {
                pictureBoxT1ON.Visible = true;
                pictureBoxT1OFF.Visible = false;
            }

            else
            {
                pictureBoxT1ON.Visible = false;
                pictureBoxT1OFF.Visible = true;

            }


        }


        private void timerBoton_Tick(object sender, EventArgs e)
        {
            #region Todo

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
                                    timerOFFCalefactor1.Enabled = false;

                                }
                                else
                                {
                                    timerONCalefactor1.Enabled = false;

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

                                //Guardar estado
                                Properties.Settings.Default.Bandera1ONOFF = "off";
                                Properties.Settings.Default.Save();

                                #endregion ActualizaEstados

                            }
                        }

                        else
                        {

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
                                    timerOFFCalefactor1.Enabled = true;
                                    timerONCalefactor1.Enabled = false;


                            }
                                else
                                {
                                    timerONCalefactor1.Enabled = true;
                                    timerOFFCalefactor1.Enabled = false;

                            }

                                #endregion EnciendeTermostato

                                #region Encendido_y_apagado_de_UV

                                timerOffUV1.Enabled = true;

                                #endregion Encendido_y_apagado_de_UV

                                #region ActualizaEstados


                                //Guardar estado
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

                         
                            if (estado != 1)//Si estado es distinto de 1
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
                                    timerOFFCalefactor1.Enabled = true;
                                    timerONCalefactor1.Enabled = false;


                            }
                                else
                                {
                                    timerONCalefactor1.Enabled = true;
                                    timerOFFCalefactor1.Enabled = false;

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

                           

                            if (estado != 0)//Si estado es distinto de 1
                            {

                                estado = 0;//Guarda estado en 1


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
                                    timerOFFCalefactor1.Enabled = false;

                                }
                                else
                                {
                                    timerONCalefactor1.Enabled = false;

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

                                //Guardar estado
                                Properties.Settings.Default.Bandera1ONOFF = "off";
                                Properties.Settings.Default.Save();

                                #endregion ActualizaEstados

                            }

                        } break;

                }

                #endregion MenúEncenderApagar

            #endregion Todo


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


        private void timerHrsVent1_Tick(object sender, EventArgs e)
        {
           
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador

                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVent;
                int MesVent = Properties.Settings.Default.MesVent;
                int DiaVent = Properties.Settings.Default.DiaVent;
                int HrsVent = Properties.Settings.Default.HoraVent;
                int MinVent = Properties.Settings.Default.MinVent;
                int SegVent = Properties.Settings.Default.SegVent;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);
              
                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);

            
                Properties.Settings.Default.HorasMotorVent1 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                                                            //ts.Days;
                                                            //ts.Minutes;
                                                            //ts.Seconds;
                Properties.Settings.Default.Save();
          

            #endregion HrsVentilador

            }

 
        private void timerHrsUV1_Tick(object sender, EventArgs e)
        {

            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 
     
            #region HrsUV

                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUV;
                int MesUV = Properties.Settings.Default.MesUV;
                int DiaUV = Properties.Settings.Default.DiaUV;
                int HrsUV = Properties.Settings.Default.HoraUV;
                int MinUV = Properties.Settings.Default.MinUV;
                int SegUV = Properties.Settings.Default.SegUV;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);

            
                Properties.Settings.Default.HorasUV1 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();
        

            #endregion HrsUV


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

        private void timerTemp1_Tick(object sender, EventArgs e)
        {
            try { 

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

            int temnpMax = Properties.Settings.Default.TempMax1;
            string EstadoCalefactor = Properties.Settings.Default.EstadoCalef1;

            if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
            {
                timerOFFCalefactor1.Start();//Enciende timer apaga calefactor
                timerONCalefactor1.Stop();//Apaga timer enciende calefactor
            }
            else//si no...
            {
                if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                {
                    timerONCalefactor1.Start();//enciende timer de encendido calefactor
                    timerOFFCalefactor1.Stop();////Apaga timer apaga calefactor
                }

                else//si no...
                {
                    timerOFFCalefactor1.Start();//Enciende timer apaga calefactor
                    timerONCalefactor1.Stop();//Apaga timer encendido calefactor
                }
            }
            }

            catch (Exception)

            {              
                lblMensaje1.Text = "SIN RED";

            }

        }

        private void timerHrsCalef1_Tick(object sender, EventArgs e)
        {
            string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1

            R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 

            #region HrsCalefactor


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactor;
                int MesCalef = Properties.Settings.Default.MesCalefactor;
                int DiaCalef = Properties.Settings.Default.DiaCalefactor;
                int HrsCalef = Properties.Settings.Default.HoraCalefactor;
                int MinCalef = Properties.Settings.Default.MinCalefactor;
                int SegCalef = Properties.Settings.Default.SegCalefactor;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);

    
                Properties.Settings.Default.HorasCalefactor1 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsCalefactor

        }


        private void timer2_Tick(object sender, EventArgs e)
        {

            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

                R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay  

                //Lee estado Relay 0
                string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");


                //Consulta si la tarjeta está encendida...
                if (rele == "on")
                {
                    pictureBoxT2ON.Visible = true;
                    pictureBoxT2OFF.Visible = false;
                }

                else
                {
                    pictureBoxT2ON.Visible = false;
                    pictureBoxT2OFF.Visible = true;

                }

        }

        private void timerBoton2_Tick(object sender, EventArgs e)
        {

            #region Todo

          
            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay  

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
                        Properties.Settings.Default.EstadoCalef2 = "off";//Guarda estado para ocuparlo en timer Temp
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
                                timerOFFCalefactor2.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor2.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays


                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV2.Enabled = false;

                            timerOffUV2.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera2ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else
                    {

                        Properties.Settings.Default.EstadoCalef2 = "on";//Guarda estado para ocuparlo en timer Temp
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
                                timerOFFCalefactor2.Enabled = true;
                                timerONCalefactor2.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor2.Enabled = true;
                                timerOFFCalefactor2.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region Encendido_y_apagado_de_UV

                            timerOffUV2.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados


                            //Guardar estado
                            Properties.Settings.Default.Bandera2ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef2 = "on";//Guarda estado para ocuparlo en timer Temp
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
                                timerOFFCalefactor2.Enabled = true;
                                timerONCalefactor2.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor2.Enabled = true;
                                timerOFFCalefactor2.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region EnciendeRelays

                            R.EnvioInstruccionRelay("relay on 0");
                            R.EnvioInstruccionRelay("relay on 1");
                            R.EnvioInstruccionRelay("relay on 2");
                            R.EnvioInstruccionRelay("relay on 3");

                            #endregion EnciendeRelays

                            #region Encendido_y_apagado_de_UV

                            timerOffUV2.Enabled = true;

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
                        Properties.Settings.Default.EstadoCalef2 = "off";//Guarda estado para ocuparlo en timer Temp
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
                                timerOFFCalefactor2.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor2.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays

                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV2.Enabled = false;

                            timerOffUV2.Enabled = false;

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


            #endregion Todo

        }

        private void timerOnUV2_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 1");//Enciende relay
            timerOnUV2.Stop();//Apago timer de encendido
            timerOffUV2.Start();//Enciendo timer de apagado

            /*Para no iniciar los dos timer juntos*/

        }

        private void timerOffUV2_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV2.Stop();//Apago timer de encendido
            timerOnUV2.Start();//Enciendo timer de apagado           

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerHrsVent2_Tick(object sender, EventArgs e)
        {
          
            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 1

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVentDos;
                int MesVent = Properties.Settings.Default.MesVentDos;
                int DiaVent = Properties.Settings.Default.DiaVentDos;
                int HrsVent = Properties.Settings.Default.HoraVentDos;
                int MinVent = Properties.Settings.Default.MinVentDos;
                int SegVent = Properties.Settings.Default.SegVentDos;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);

            
                Properties.Settings.Default.HorasMotorVent2 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


                #endregion HrsVentilador
            
            
        }

        private void timerHrsUV2_Tick(object sender, EventArgs e)
        {
        
            
                string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 1

                R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay 

                #region HrsUV


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUVDos;
                int MesUV = Properties.Settings.Default.MesUVDos;
                int DiaUV = Properties.Settings.Default.DiaUVDos;
                int HrsUV = Properties.Settings.Default.HoraUVDos;
                int MinUV = Properties.Settings.Default.MinUVDos;
                int SegUV = Properties.Settings.Default.SegUVDos;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);


                Properties.Settings.Default.HorasUV2 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


                #endregion HrsUV
           

        }

        private void timerHrsCalef2_Tick(object sender, EventArgs e)
        {
     
                string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 1

                R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay 

                #region HrsCalefactor


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactorDos;
                int MesCalef = Properties.Settings.Default.MesCalefactorDos;
                int DiaCalef = Properties.Settings.Default.DiaCalefactorDos;
                int HrsCalef = Properties.Settings.Default.HoraCalefactorDos;
                int MinCalef = Properties.Settings.Default.MinCalefactorDos;
                int SegCalef = Properties.Settings.Default.SegCalefactorDos;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);


                Properties.Settings.Default.HorasCalefactor2 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


                #endregion HrsCalefactor
           

        }

        private void timerONCalefactor2_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerOFFCalefactor2_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
        }

        private void timerTemp2_Tick(object sender, EventArgs e)
        {

            try {
            string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 1

            R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay       

            lblMensaje2.Text = "";

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

            int temnpMax = Properties.Settings.Default.TempMax2;
            string EstadoCalefactor = Properties.Settings.Default.EstadoCalef2;

            if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
            {
                timerOFFCalefactor2.Start();//Enciende timer apaga calefactor
                timerONCalefactor2.Stop();//Apaga timer enciende calefactor
            }
            else//si no...
            {
                if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                {
                    timerONCalefactor2.Start();//enciende timer de encendido calefactor
                    timerOFFCalefactor2.Stop();////Apaga timer apaga calefactor
                }

                else//si no...
                {
                    timerOFFCalefactor2.Start();//Enciende timer apaga calefactor
                    timerONCalefactor2.Stop();//Apaga timer encendido calefactor
                }
            }
            }

            catch (Exception)

            {
                lblMensaje2.Text = "SIN RED";

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay  

            //Lee estado Relay 0
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");


            //Consulta si la tarjeta está encendida...

            
            if (rele == "on")
            {
                pictureBoxT3ON.Visible = true;
                pictureBoxT3OFF.Visible = false;
            }

            else
            {
                pictureBoxT3ON.Visible = false;
                pictureBoxT3OFF.Visible = true;

            }
            
           
        }

        private void timerBoton3_Tick(object sender, EventArgs e)
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
                                timerOFFCalefactor3.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor3.Enabled = false;

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
                                timerOFFCalefactor3.Enabled = true;
                                timerONCalefactor3.Enabled = false;
                            }

                            else
                            {
                                timerONCalefactor3.Enabled = true;
                                timerOFFCalefactor3.Enabled = false;
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

                    }
                    break;


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
                                timerOFFCalefactor3.Enabled = true;
                                timerONCalefactor3.Enabled = false;
                            }

                            else
                            {
                                timerONCalefactor3.Enabled = true;
                                timerOFFCalefactor3.Enabled = false;
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
                                timerOFFCalefactor3.Enabled = false;
                               
                            }
                            else
                            {
                                timerONCalefactor3.Enabled = false;

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

                    }
                    break;

            }

            #endregion MenúEncenderApagar

            #endregion todo
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

        private void timerHrsVent3_Tick(object sender, EventArgs e)
        {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador



                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVentTres;
                int MesVent = Properties.Settings.Default.MesVentTres;
                int DiaVent = Properties.Settings.Default.DiaVentTres;
                int HrsVent = Properties.Settings.Default.HoraVentTres;
                int MinVent = Properties.Settings.Default.MinVentTres;
                int SegVent = Properties.Settings.Default.SegVentTres;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

            #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);

                //Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.HorasMotorVent3 = Convert.ToInt32(Math.Truncate(ts.TotalHours));
                Properties.Settings.Default.Save();


            #endregion HrsVentilador


        }

        private void timerHrsUV3_Tick(object sender, EventArgs e)
        {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay 

            #region HrsUV


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUVTres;
                int MesUV = Properties.Settings.Default.MesUVTres;
                int DiaUV = Properties.Settings.Default.DiaUVTres;
                int HrsUV = Properties.Settings.Default.HoraUVTres;
                int MinUV = Properties.Settings.Default.MinUVTres;
                int SegUV = Properties.Settings.Default.SegUVTres;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);

            
                Properties.Settings.Default.HorasUV3 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsUV

        }

        private void timerHrsCalef3_Tick(object sender, EventArgs e)
        {
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

            R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay 

            #region HrsCalefactor

                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactorTres;
                int MesCalef = Properties.Settings.Default.MesCalefactorTres;
                int DiaCalef = Properties.Settings.Default.DiaCalefactorTres;
                int HrsCalef = Properties.Settings.Default.HoraCalefactorTres;
                int MinCalef = Properties.Settings.Default.MinCalefactorTres;
                int SegCalef = Properties.Settings.Default.SegCalefactorTres;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasCalefactor3 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsCalefactor

        }

        private void timerONCalefactor3_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerOFFCalefactor3_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
        }

        private void timerTemp3_Tick(object sender, EventArgs e)
        {
            try { 
            string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

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

            int temnpMax = Properties.Settings.Default.TempMax3;
            string EstadoCalefactor = Properties.Settings.Default.EstadoCalef3;

            if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
            {
                timerOFFCalefactor3.Start();//Enciende timer apaga calefactor
                timerONCalefactor3.Stop();//Apaga timer enciende calefactor
            }
            else//si no...
            {
                if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                {
                    timerONCalefactor3.Start();//enciende timer de encendido calefactor
                    timerOFFCalefactor3.Stop();////Apaga timer apaga calefactor
                }

                else//si no...
                {
                    timerOFFCalefactor3.Start();//Enciende timer apaga calefactor
                    timerONCalefactor3.Stop();//Apaga timer encendido calefactor
                }
            }
            }
            catch (Exception)

            {
                lblMensaje3.Text = "SIN RED";

            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay  

            //Lee estado Relay 0
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");


            //Consulta si la tarjeta está encendida...
            if (rele == "on")
            {
                pictureBoxT4ON.Visible = true;
                pictureBoxT4OFF.Visible = false;
            }

            else
            {
                pictureBoxT4ON.Visible = false;
                pictureBoxT4OFF.Visible = true;

            }
        }

        private void timerBoton4_Tick(object sender, EventArgs e)
        {
            #region Todo

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
                                timerOFFCalefactor4.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor4.Enabled = false;

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
                                timerOFFCalefactor4.Enabled = true;
                                timerONCalefactor4.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor4.Enabled = true;
                                timerOFFCalefactor4.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region Encendido_y_apagado_de_UV

                            timerOffUV4.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados


                            //Guardar estado
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
                                timerOFFCalefactor4.Enabled = true;
                                timerONCalefactor4.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor4.Enabled = true;
                                timerOFFCalefactor4.Enabled = false;
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
                                timerOFFCalefactor4.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor4.Enabled = false;

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

            #endregion Todo
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

        private void timerHrsVent4_Tick(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador

                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVentCuatro;
                int MesVent = Properties.Settings.Default.MesVentCuatro;
                int DiaVent = Properties.Settings.Default.DiaVentCuatro;
                int HrsVent = Properties.Settings.Default.HoraVentCuatro;
                int MinVent = Properties.Settings.Default.MinVentCuatro;
                int SegVent = Properties.Settings.Default.SegVentCuatro;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
           
                Properties.Settings.Default.HorasMotorVent4 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsVentilador

        }

        private void timerHrsUV4_Tick(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay             

            #region HrsUV


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUVCuatro;
                int MesUV = Properties.Settings.Default.MesUVCuatro;
                int DiaUV = Properties.Settings.Default.DiaUVCuatro;
                int HrsUV = Properties.Settings.Default.HoraUVCuatro;
                int MinUV = Properties.Settings.Default.MinUVCuatro;
                int SegUV = Properties.Settings.Default.SegUVCuatro;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasUV4 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsUV

        }

        private void timerOFFCalefactor4_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
        }

        private void timerHrsCalef4_Tick(object sender, EventArgs e)
        {
            string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

            R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay 

            #region HrsCalefactor

                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactorCuatro;
                int MesCalef = Properties.Settings.Default.MesCalefactorCuatro;
                int DiaCalef = Properties.Settings.Default.DiaCalefactorCuatro;
                int HrsCalef = Properties.Settings.Default.HoraCalefactorCuatro;
                int MinCalef = Properties.Settings.Default.MinCalefactorCuatro;
                int SegCalef = Properties.Settings.Default.SegCalefactorCuatro;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
           
                Properties.Settings.Default.HorasCalefactor4 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsCalefactor

        }

        private void timerONCalefactor4_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerTemp4_Tick(object sender, EventArgs e)
        {

            try
            {
                string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

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


                int temnpMax = Properties.Settings.Default.TempMax4;
                string EstadoCalefactor = Properties.Settings.Default.EstadoCalef4;

                if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
                {
                    timerOFFCalefactor4.Start();//Enciende timer apaga calefactor
                    timerONCalefactor4.Stop();//Apaga timer enciende calefactor
                }
                else//si no...
                {
                    if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                    {
                        timerONCalefactor4.Start();//enciende timer de encendido calefactor
                        timerOFFCalefactor4.Stop();////Apaga timer apaga calefactor
                    }

                    else//si no...
                    {
                        timerOFFCalefactor4.Start();//Enciende timer apaga calefactor
                        timerONCalefactor4.Stop();//Apaga timer encendido calefactor
                    }
                }
            }
            catch (Exception)

            {
                lblMensaje4.Text = "SIN RED";

            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay  

            //Lee estado Relay 0
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");


            //Consulta si la tarjeta está encendida...
            if (rele == "on")
            {
                pictureBoxT5ON.Visible = true;
                pictureBoxT5OFF.Visible = false;
            }

            else
            {
                pictureBoxT5ON.Visible = false;
                pictureBoxT5OFF.Visible = true;

            }
        }

        private void timerBoton5_Tick(object sender, EventArgs e)
        {
            #region Todo

            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay  

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

            string Estado = Properties.Settings.Default.Bandera5ONOFF.ToString();//Estado encendido o no

            switch (Estado)
            {

                //Caso ON
                case "on":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef5 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax5;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor5.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor5.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays


                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV5.Enabled = false;

                            timerOffUV5.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera5ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else
                    {

                        Properties.Settings.Default.EstadoCalef5 = "on";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax5;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor5.Enabled = true;
                                timerONCalefactor5.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor5.Enabled = true;
                                timerOFFCalefactor5.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region Encendido_y_apagado_de_UV

                            timerOffUV5.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados


                            //Guardar estado
                            Properties.Settings.Default.Bandera5ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef5 = "on";//Guarda estado para ocuparlo en timer Temp
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


                            int temnpMax = Properties.Settings.Default.TempMax5;



                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor5.Enabled = true;
                                timerONCalefactor5.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor5.Enabled = true;
                                timerOFFCalefactor5.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region EnciendeRelays

                            R.EnvioInstruccionRelay("relay on 0");
                            R.EnvioInstruccionRelay("relay on 1");
                            R.EnvioInstruccionRelay("relay on 2");
                            R.EnvioInstruccionRelay("relay on 3");

                            #endregion EnciendeRelays

                            #region Encendido_y_apagado_de_UV

                            timerOffUV5.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera5ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else//Si no...
                    {
                        Properties.Settings.Default.EstadoCalef5 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax5;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor5.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor5.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays

                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV5.Enabled = false;

                            timerOffUV5.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera5ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;

            }

            #endregion MenúEncenderApagar

            #endregion Todo
        }

        private void timerOnUV5_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 1");//Enciende relay
            timerOnUV5.Stop();//Apago timer de encendido
            timerOffUV5.Start();//Enciendo timer de apagado

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerOffUV5_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV5.Stop();//Apago timer de encendido
            timerOnUV5.Start();//Enciendo timer de apagado           

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerHrsVent5_Tick(object sender, EventArgs e)
        {
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador

                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVentCinco;
                int MesVent = Properties.Settings.Default.MesVentCinco;
                int DiaVent = Properties.Settings.Default.DiaVentCinco;
                int HrsVent = Properties.Settings.Default.HoraVentCinco;
                int MinVent = Properties.Settings.Default.MinVentCinco;
                int SegVent = Properties.Settings.Default.SegVentCinco;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasMotorVent5 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsVentilador

        }

        private void timerHrsUV5_Tick(object sender, EventArgs e)
        {
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay 

            #region HrsUV


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUVCinco;
                int MesUV = Properties.Settings.Default.MesUVCinco;
                int DiaUV = Properties.Settings.Default.DiaUVCinco;
                int HrsUV = Properties.Settings.Default.HoraUVCinco;
                int MinUV = Properties.Settings.Default.MinUVCinco;
                int SegUV = Properties.Settings.Default.SegUVCinco;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;
               
                #endregion Hrs


                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasUV5 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsUV

        }

        private void timerHrsCalef5_Tick(object sender, EventArgs e)
        {
            string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

            R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay 

            #region HrsCalefactor


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactorCinco;
                int MesCalef = Properties.Settings.Default.MesCalefactorCinco;
                int DiaCalef = Properties.Settings.Default.DiaCalefactorCinco;
                int HrsCalef = Properties.Settings.Default.HoraCalefactorCinco;
                int MinCalef = Properties.Settings.Default.MinCalefactorCinco;
                int SegCalef = Properties.Settings.Default.SegCalefactorCinco;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasCalefactor5 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsCalefactor

        }

        private void timerONCalefactor5_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerOFFCalefactor5_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
        }

        private void timerTemp5_Tick(object sender, EventArgs e)
        {

            try
            {
                string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

                R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay  
                
                lblMensaje5.Text = "";

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

                int temnpMax = Properties.Settings.Default.TempMax5;
                string EstadoCalefactor = Properties.Settings.Default.EstadoCalef5;

                if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
                {
                    timerOFFCalefactor5.Start();//Enciende timer apaga calefactor
                    timerONCalefactor5.Stop();//Apaga timer enciende calefactor
                }
                else//si no...
                {
                    if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                    {
                        timerONCalefactor5.Start();//enciende timer de encendido calefactor
                        timerOFFCalefactor5.Stop();////Apaga timer apaga calefactor
                    }

                    else//si no...
                    {
                        timerOFFCalefactor5.Start();//Enciende timer apaga calefactor
                        timerONCalefactor5.Stop();//Apaga timer encendido calefactor
                    }
                }
            }
            catch (Exception)

            {
                lblMensaje5.Text = "SIN RED";

            }

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay  

            //Lee estado Relay 0
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");


            //Consulta si la tarjeta está encendida...
            if (rele == "on")
            {
                pictureBoxT6ON.Visible = true;
                pictureBoxT6OFF.Visible = false;
            }

            else
            {
                pictureBoxT6ON.Visible = false;
                pictureBoxT6OFF.Visible = true;

            }
        }

        private void timerBoton6_Tick(object sender, EventArgs e)
        {
            #region Todo

            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay  

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

            string Estado = Properties.Settings.Default.Bandera6ONOFF.ToString();//Estado encendido o no

            switch (Estado)
            {

                //Caso ON
                case "on":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef6 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax6;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor6.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor6.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays


                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV6.Enabled = false;

                            timerOffUV6.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera6ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else
                    {

                        Properties.Settings.Default.EstadoCalef6 = "on";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax6;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor6.Enabled = true;
                                timerONCalefactor6.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor6.Enabled = true;
                                timerOFFCalefactor6.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region Encendido_y_apagado_de_UV

                            timerOffUV6.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados


                            //Guardar estado
                            Properties.Settings.Default.Bandera6ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;


                case "off":

                    //Toma las 3 muestras de botón
                    if (respuesta1 == respuesta2 && respuesta2 == respuesta3 && respuesta1 == respuesta3 && respuesta3 == "0\r\n>")
                    {
                        Properties.Settings.Default.EstadoCalef6 = "on";//Guarda estado para ocuparlo en timer Temp
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


                            int temnpMax = Properties.Settings.Default.TempMax6;



                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor6.Enabled = true;
                                timerONCalefactor6.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor6.Enabled = true;
                                timerOFFCalefactor6.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region EnciendeRelays

                            R.EnvioInstruccionRelay("relay on 0");
                            R.EnvioInstruccionRelay("relay on 1");
                            R.EnvioInstruccionRelay("relay on 2");
                            R.EnvioInstruccionRelay("relay on 3");

                            #endregion EnciendeRelays

                            #region Encendido_y_apagado_de_UV

                            timerOffUV6.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera6ONOFF = "on";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }
                    }

                    else//Si no...
                    {
                        Properties.Settings.Default.EstadoCalef6 = "off";//Guarda estado para ocuparlo en timer Temp
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

                            int temnpMax = Properties.Settings.Default.TempMax6;

                            // Llenado de barra de temperatura
                            int Respuesta3 = Convert.ToInt32(Respuesta2222);


                            if (Respuesta3 >= temnpMax)
                            {
                                timerOFFCalefactor6.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor6.Enabled = false;

                            }

                            #endregion ApagaTermostato

                            #region ApagaRelays

                            R.EnvioInstruccionRelay("relay off 0");
                            R.EnvioInstruccionRelay("relay off 1");
                            R.EnvioInstruccionRelay("relay off 2");
                            R.EnvioInstruccionRelay("relay off 3");

                            #endregion ApagaRelays

                            #region Encendido_y_apagado_de_UV

                            timerOnUV6.Enabled = false;

                            timerOffUV6.Enabled = false;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados

                            //Guardar estado
                            Properties.Settings.Default.Bandera6ONOFF = "off";
                            Properties.Settings.Default.Save();

                            #endregion ActualizaEstados

                        }

                    } break;

            }

            #endregion MenúEncenderApagar

            #endregion Todo
        }

        private void timerOnUV6_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 1");//Enciende relay
            timerOnUV6.Stop();//Apago timer de encendido
            timerOffUV6.Start();//Enciendo timer de apagado

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerOffUV6_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 1");//Apaga relay
            timerOffUV6.Stop();//Apago timer de encendido
            timerOnUV6.Start();//Enciendo timer de apagado           

            /*Para no iniciar los dos timer juntos*/
        }

        private void timerHrsVent6_Tick(object sender, EventArgs e)
        {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVentSeis;
                int MesVent = Properties.Settings.Default.MesVentSeis;
                int DiaVent = Properties.Settings.Default.DiaVentSeis;
                int HrsVent = Properties.Settings.Default.HoraVentSeis;
                int MinVent = Properties.Settings.Default.MinVentSeis;
                int SegVent = Properties.Settings.Default.SegVentSeis;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasMotorVent6 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsVentilador

        }

        private void timerHrsUV6_Tick(object sender, EventArgs e)
        {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay 

            #region HrsUV


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUVSeis;
                int MesUV = Properties.Settings.Default.MesUVSeis;
                int DiaUV = Properties.Settings.Default.DiaUVSeis;
                int HrsUV = Properties.Settings.Default.HoraUVSeis;
                int MinUV = Properties.Settings.Default.MinUVSeis;
                int SegUV = Properties.Settings.Default.SegUVSeis;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasUV6 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsUV


        }

        private void timerHrsCalef6_Tick(object sender, EventArgs e)
        {
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

            R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay 

            #region HrsCalefactor


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactorSeis;
                int MesCalef = Properties.Settings.Default.MesCalefactorSeis;
                int DiaCalef = Properties.Settings.Default.DiaCalefactorSeis;
                int HrsCalef = Properties.Settings.Default.HoraCalefactorSeis;
                int MinCalef = Properties.Settings.Default.MinCalefactorSeis;
                int SegCalef = Properties.Settings.Default.SegCalefactorSeis;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasCalefactor6 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsCalefactor

        }

        private void timerONCalefactor6_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerOFFCalefactor6_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
        }

        private void timerTemp6_Tick(object sender, EventArgs e)
        {

            try
            {
                string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

                R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay       
                lblMensaje6.Text = "";

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

                int temnpMax = Properties.Settings.Default.TempMax6;
                string EstadoCalefactor = Properties.Settings.Default.EstadoCalef6;

                if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
                {
                    timerOFFCalefactor6.Start();//Enciende timer apaga calefactor
                    timerONCalefactor6.Stop();//Apaga timer enciende calefactor
                }
                else//si no...
                {
                    if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                    {
                        timerONCalefactor6.Start();//enciende timer de encendido calefactor
                        timerOFFCalefactor6.Stop();////Apaga timer apaga calefactor
                    }

                    else//si no...
                    {
                        timerOFFCalefactor6.Start();//Enciende timer apaga calefactor
                        timerONCalefactor6.Stop();//Apaga timer encendido calefactor
                    }
                }
            }
            catch (Exception)

            {
                lblMensaje6.Text = "SIN RED";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frames.FrmLoginTESTRelays formLoginRelays = new Frames.FrmLoginTESTRelays();
            formLoginRelays.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay  

            //Lee estado Relay 0
            string rele = R.EnvioInstruccionRelay("relay read 0").Replace("\n", "").Replace("\r", "").Replace(">", "");


            //Consulta si la tarjeta está encendida...
            if (rele == "on")
            {
                pictureBoxT7ON.Visible = true;
                pictureBoxT7OFF.Visible = false;
            }

            else
            {
                pictureBoxT7ON.Visible = false;
                pictureBoxT7OFF.Visible = true;

            }
        }


        private void timerBoton7_Tick(object sender, EventArgs e)
        {
            #region Todo

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
                                timerOFFCalefactor7.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor7.Enabled = false;

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
                                timerOFFCalefactor7.Enabled = true;
                                timerONCalefactor7.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor7.Enabled = true;
                                timerOFFCalefactor7.Enabled = false;
                            }

                            #endregion EnciendeTermostato

                            #region Encendido_y_apagado_de_UV

                            timerOffUV7.Enabled = true;

                            #endregion Encendido_y_apagado_de_UV

                            #region ActualizaEstados


                            //Guardar estado
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
                                timerOFFCalefactor7.Enabled = true;
                                timerONCalefactor7.Enabled = false;
                            }
                            else
                            {
                                timerONCalefactor7.Enabled = true;
                                timerOFFCalefactor7.Enabled = false;
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
                                timerOFFCalefactor7.Enabled = false;

                            }
                            else
                            {
                                timerONCalefactor7.Enabled = false;

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

            #endregion Todo
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

        private void timerHrsVent7_Tick(object sender, EventArgs e)
        {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay 

            #region HrsVentilador

 
                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoVent = Properties.Settings.Default.AnoVentSiete;
                int MesVent = Properties.Settings.Default.MesVentSiete;
                int DiaVent = Properties.Settings.Default.DiaVentSiete;
                int HrsVent = Properties.Settings.Default.HoraVentSiete;
                int MinVent = Properties.Settings.Default.MinVentSiete;
                int SegVent = Properties.Settings.Default.SegVentSiete;

                DateTime fechaAntiguaVent = new DateTime(AnoVent, MesVent, DiaVent, HrsVent, MinVent, SegVent);//Fecha establecida
                DateTime fechaNuevaVent = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaVent - fechaAntiguaVent;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasMotorVent7 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsVentilador

        }

        private void timerHrsUV7_Tick(object sender, EventArgs e)
        {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay    

            #region HrsUV


                #region Hrs

                //TOMAR FECHA DE UN DATO EN EL CONFIG del UV
                int AnoUV = Properties.Settings.Default.AnoUVSiete;
                int MesUV = Properties.Settings.Default.MesUVSiete;
                int DiaUV = Properties.Settings.Default.DiaUVSiete;
                int HrsUV = Properties.Settings.Default.HoraUVSiete;
                int MinUV = Properties.Settings.Default.MinUVSiete;
                int SegUV = Properties.Settings.Default.SegUVSiete;

                DateTime fechaAntiguaUV = new DateTime(AnoUV, MesUV, DiaUV, HrsUV, MinUV, SegUV);//Fecha establecida
                DateTime fechaNuevaUV = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan tsUV = fechaNuevaUV - fechaAntiguaUV;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasUV7 = Convert.ToInt32(Math.Truncate(tsUV.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsUV

        }

        private void timerHrsCalef7_Tick(object sender, EventArgs e)
        {
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay 

            #region HrsCalefactor


                #region Hrs


                //TOMAR FECHA DE UN DATO EN EL CONFIG del ventilador
                int AnoCalef = Properties.Settings.Default.AnoCalefactorSiete;
                int MesCalef = Properties.Settings.Default.MesCalefactorSiete;
                int DiaCalef = Properties.Settings.Default.DiaCalefactorSiete;
                int HrsCalef = Properties.Settings.Default.HoraCalefactorSiete;
                int MinCalef = Properties.Settings.Default.MinCalefactorSiete;
                int SegCalef = Properties.Settings.Default.SegCalefactorSiete;

                DateTime fechaAntiguaCalef = new DateTime(AnoCalef, MesCalef, DiaCalef, HrsCalef, MinCalef, SegCalef);//Fecha establecida
                DateTime fechaNuevaCalef = DateTime.Now; // Toma la fecha y hora del sistema en el momento actual

                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = fechaNuevaCalef - fechaAntiguaCalef;

                #endregion Hrs

                int milliseconds = 20;
                Thread.Sleep(milliseconds);

                int milliseconds2 = 20;
                Thread.Sleep(milliseconds2);
            
                Properties.Settings.Default.HorasCalefactor7 = Convert.ToInt32(Math.Truncate(ts.TotalHours));//Se guardan las horas de funcionamiento actualizadas
                Properties.Settings.Default.Save();


            #endregion HrsCalefactor

        }

        private void timerONCalefactor7_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay on 2");//Enciende calefactor
            R.EnvioInstruccionRelay("relay on 3");//Enciende calefactor
        }

        private void timerOFFCalefactor7_Tick(object sender, EventArgs e)
        {
            R.EnvioInstruccionRelay("relay off 2");//Apaga calefactor
            R.EnvioInstruccionRelay("relay off 3");//Apaga calefactor
        }

        private void timerTemp7_Tick(object sender, EventArgs e)
        {

            try
            {
                
                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

                R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay       

                lblMensaje7.Text = "";//Vacía label advertencia SIN RED

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

                int temnpMax = Properties.Settings.Default.TempMax7;
                string EstadoCalefactor = Properties.Settings.Default.EstadoCalef7;

                if (Respuesta3 >= temnpMax)//Si respuesta es mayor o igual a temp.máxima...
                {
                    timerOFFCalefactor7.Start();//Enciende timer apaga calefactor
                    timerONCalefactor7.Stop();//Apaga timer enciende calefactor
                }
                else//si no...
                {
                    if (EstadoCalefactor == "on")//solo si el estado de calefactor se encuentra en on...
                    {
                        timerONCalefactor7.Start();//enciende timer de encendido calefactor
                        timerOFFCalefactor7.Stop();////Apaga timer apaga calefactor
                    }

                    else//si no...
                    {
                        timerOFFCalefactor7.Start();//Enciende timer apaga calefactor
                        timerONCalefactor7.Stop();//Apaga timer encendido calefactor
                    }
                }
            }
            catch (Exception)

            {
                lblMensaje7.Text = "SIN RED";

            }
        }

       
        

      

        private void timerCorreoVent1_Tick(object sender, EventArgs e)
        {

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxT7OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

                R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer7.Stop();
                Frames.FrmTarjeta7 formt7 = new Frames.FrmTarjeta7();
                formt7.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT7OFF.Visible = true;
                lblMensaje7.Text = "Secador 7 sin red!";

            }
        }

        private void pictureBoxT1OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 7

                R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer1.Stop();
                Frames.FrmTarjeta1 formt1 = new Frames.FrmTarjeta1();
                formt1.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT1OFF.Visible = true;
                lblMensaje1.Text = "Secador 1 sin red!";

            }
        }

        private void pictureBoxT1ON_Click(object sender, EventArgs e)
        {
            try
            {

                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 7

                R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer1.Stop();
                Frames.FrmTarjeta1 formt1 = new Frames.FrmTarjeta1();
                formt1.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT1OFF.Visible = true;
                lblMensaje1.Text = "Secador 1 sin red!";

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBoxT2ON_Click(object sender, EventArgs e)
        {
            try
            {

                string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

                R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer2.Stop();
                Frames.FrmTarjeta2 formt2 = new Frames.FrmTarjeta2();
                formt2.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT2OFF.Visible = true;
                lblMensaje2.Text = "SIN RED";

            }
        }

        private void pictureBoxT2OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2

                R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer2.Stop();
                Frames.FrmTarjeta2 formt1 = new Frames.FrmTarjeta2();
                formt1.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT2OFF.Visible = true;
                lblMensaje2.Text = "SIN RED";

            }
        }

        private void pictureBoxT3OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

                R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer3.Stop();
                Frames.FrmTarjeta3 formt3 = new Frames.FrmTarjeta3();
                formt3.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT3OFF.Visible = true;
                lblMensaje3.Text = "Secador 3 sin red!";

            }
        }

        private void pictureBoxT3ON_Click(object sender, EventArgs e)
        {
            try
            {

                string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3

                R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer3.Stop();
                Frames.FrmTarjeta3 formt3 = new Frames.FrmTarjeta3();
                formt3.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT3OFF.Visible = true;
                lblMensaje3.Text = "Secador 3 sin red!";

            }
        }

        private void pictureBoxT4OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

                R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer4.Stop();
                Frames.FrmTarjeta4 formt4 = new Frames.FrmTarjeta4();
                formt4.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT4OFF.Visible = true;
                lblMensaje4.Text = "Secador 4 sin red!";

            }
        }

        private void pictureBoxT4ON_Click(object sender, EventArgs e)
        {
            try
            {

                string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4

                R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer4.Stop();
                Frames.FrmTarjeta4 formt4 = new Frames.FrmTarjeta4();
                formt4.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT4OFF.Visible = true;
                lblMensaje4.Text = "Secador 4 sin red!";

            }
        }

        private void pictureBoxT5ON_Click(object sender, EventArgs e)
        {
            try
            {

                string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

                R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer5.Stop();
                Frames.FrmTarjeta5 formt5 = new Frames.FrmTarjeta5();
                formt5.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT5OFF.Visible = true;
                lblMensaje5.Text = "Secador 5 sin red!";

            }
        }

        private void pictureBoxT5OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5

                R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer5.Stop();
                Frames.FrmTarjeta5 formt5 = new Frames.FrmTarjeta5();
                formt5.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT5OFF.Visible = true;
                lblMensaje5.Text = "Secador 5 sin red!";

            }
        }

        private void pictureBoxT6OFF_Click(object sender, EventArgs e)
        {
            try
            {

                string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

                R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer6.Stop();
                Frames.FrmTarjeta6 formt6 = new Frames.FrmTarjeta6();
                formt6.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT6OFF.Visible = true;
                lblMensaje6.Text = "Secador 6 sin red!";

            }
        }

        private void pictureBoxT6ON_Click(object sender, EventArgs e)
        {
            try{
            string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6

                R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer6.Stop();
                Frames.FrmTarjeta6 formt6 = new Frames.FrmTarjeta6();
                formt6.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT6OFF.Visible = true;
                lblMensaje6.Text = "Secador 6 sin red!";

            }
        }

        private void pictureBoxT7ON_Click(object sender, EventArgs e)
        {
            try
            {

                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

                R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay 
                R.Close();
                R.EnvioInstruccionRelay("reset");
                timer7.Stop();
                Frames.FrmTarjeta7 formt7 = new Frames.FrmTarjeta7();
                formt7.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                pictureBoxT7OFF.Visible = true;
                lblMensaje7.Text = "Secador 7 sin red!";

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

            #region ApagadoTarjeta1

            //Si secador esta activado apaga tarjeta
            if (Properties.Settings.Default.Estado1 == 1)
            {


                string IP1 = Properties.Settings.Default.IP1.ToString();//IP secador 1
                R.ObtenerIP(IP1);//Obtiene IP de tarjeta Relay 

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera1ONOFF = "off";
                Properties.Settings.Default.EstadoCalef1 = "off";

                R.Close();
            }


            #endregion ApagadoTarjeta1

            #region ApagadoTarjeta2

            if (Properties.Settings.Default.Estado2 == 1)
            {
                string IP2 = Properties.Settings.Default.IP2.ToString();//IP secador 2
                R.ObtenerIP(IP2);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera2ONOFF = "off";
                Properties.Settings.Default.EstadoCalef2 = "off";

                R.Close();
            }

            #endregion ApagadoTarjeta2

            #region ApagadoTarjeta3

            if (Properties.Settings.Default.Estado3 == 1)
            {
                string IP3 = Properties.Settings.Default.IP3.ToString();//IP secador 3
                R.ObtenerIP(IP3);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera3ONOFF = "off";
                Properties.Settings.Default.EstadoCalef3 = "off";

                R.Close();
            }

            #endregion ApagadoTarjeta3

            #region ApagadoTarjeta4

            if (Properties.Settings.Default.Estado4 == 1)
            {
                string IP4 = Properties.Settings.Default.IP4.ToString();//IP secador 4
                R.ObtenerIP(IP4);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera4ONOFF = "off";
                Properties.Settings.Default.EstadoCalef4 = "off";

                R.Close();
            }

            #endregion ApagadoTarjeta4

            #region ApagadoTarjeta5

            if (Properties.Settings.Default.Estado5 == 1)
            {
                string IP5 = Properties.Settings.Default.IP5.ToString();//IP secador 5
                R.ObtenerIP(IP5);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera5ONOFF = "off";
                Properties.Settings.Default.EstadoCalef5 = "off";

                R.Close();
            }

            #endregion ApagadoTarjeta5

            #region ApagadoTarjeta6

            if (Properties.Settings.Default.Estado6 == 1)
            {
                string IP6 = Properties.Settings.Default.IP6.ToString();//IP secador 6
                R.ObtenerIP(IP6);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera6ONOFF = "off";
                Properties.Settings.Default.EstadoCalef6 = "off";

                R.Close();
            }

            #endregion ApagadoTarjeta6

            #region ApagadoTarjeta7

            if (Properties.Settings.Default.Estado7 == 1)
            {
                string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7
                R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay

                R.EnvioInstruccionRelay("reset");

                Properties.Settings.Default.Bandera7ONOFF = "off";
                Properties.Settings.Default.EstadoCalef7 = "off";

                R.Close();
            }

            #endregion ApagadoTarjeta7

            #region BotonesEnOFF

            Properties.Settings.Default.Bandera1ONOFF = "off";
            Properties.Settings.Default.Bandera2ONOFF = "off";
            Properties.Settings.Default.Bandera3ONOFF = "off";
            Properties.Settings.Default.Bandera4ONOFF = "off";
            Properties.Settings.Default.Bandera5ONOFF = "off";
            Properties.Settings.Default.Bandera6ONOFF = "off";
            Properties.Settings.Default.Bandera7ONOFF = "off";
            Properties.Settings.Default.Save();

            #endregion BotonesEnOFF

            Application.Exit();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try { 
            R.Close();
            this.Close();
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timerConex7_Tick(object sender, EventArgs e)
        {
            try { 
            string IP7 = Properties.Settings.Default.IP7.ToString();//IP secador 7

            R.ObtenerIP(IP7);//Obtiene IP de tarjeta Relay 
            }
            catch (Exception)
            {
                MessageBox.Show("Revise conexión de red o IP 7!! ");
            }
        }
    }

}

    


        


  
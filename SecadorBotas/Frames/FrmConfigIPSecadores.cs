using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    public partial class FrmConfigIPSecadores : Form
    {
        public FrmConfigIPSecadores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        
        }

        public bool IsIPv4(string ipString)//Método que valida formato IP
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }


        private void btnConfig_Click(object sender, EventArgs e)
        {

           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool ip1 = false;
            bool ip2 = false;
            bool ip3 = false;
            bool ip4 = false;
            bool ip5 = false;
            bool ip6 = false;
            bool ip7 = false;


            if (txtip1.Text != "")//Si campo Ip es distinto a vacío...
            {
                ip1 = IsIPv4(txtip1.Text);//Llama a método que valida formato IP
                switch (ip1)
                {
                    case true:

                        break;
                    case false://Si caso falso

                        /*Mensaje...*/
                        lblMsj.Text = txtip1.Text + "No valido";
                        /*Foco en campo ip*/
                        txtip1.Focus();
                        break;
                }
            }
            else //Si no...
            {
                /*Mensaje...*/
                lblMsj.Text = "Ingrese Ip 1";
                /*Foco en campo ip*/
                txtip1.Focus();

            }

            if (ip1 == true)//Si el valor de IP es verdadero...
            {
                if (txtip2.Text != "")//Verifica IP 2, pregunta si campo IP 'txtip2.Text' es distinto de vacío...
                {

                    ip2 = IsIPv4(txtip2.Text);//Llama a método que valida formato IP

                    switch (ip2)
                    {
                        case true:

                            break;
                        case false://Si caso falso
                            /*Mensaje...*/
                            lblMsj.Text = txtip2.Text + "No valido";
                            /*Foco en campo ip*/
                            txtip2.Focus();
                            break;

                    }
                }
                else//Si no...
                {
                    /*Mensaje...*/
                    lblMsj.Text = "Ingrese Ip 2";
                    /*Foco en campo ip*/
                    txtip2.Focus();

                }
            }


            if (ip2 == true)
            {
                if (txtip3.Text != "")
                {
                    ip3 = IsIPv4(txtip3.Text);
                    switch (ip3)
                    {
                        case true:

                            break;
                        case false:
                            lblMsj.Text = txtip3.Text + "No valido";
                            txtip3.Focus();
                            break;

                    }
                }
                else
                {
                    lblMsj.Text = "Ingrese Ip 3";
                    txtip3.Focus();

                }
            }

            if (ip3 == true)
            {
                if (txtip4.Text != "")
                {
                    ip4 = IsIPv4(txtip4.Text);
                    switch (ip4)
                    {
                        case true:

                            break;
                        case false:
                            lblMsj.Text = txtip4.Text + "No valido";
                            txtip4.Focus();
                            break;

                    }
                }
                else
                {
                    lblMsj.Text = "Ingrese Ip 4";
                    txtip4.Focus();

                }
            }


            if (ip4 == true)
            {
                if (txtip5.Text != "")
                {
                    ip5 = IsIPv4(txtip5.Text);
                    switch (ip5)
                    {
                        case true:

                            break;
                        case false:
                            lblMsj.Text = txtip5.Text + "No valido";
                            txtip5.Focus();
                            break;

                    }
                }
                else
                {
                    lblMsj.Text = "Ingrese Ip 5";
                    txtip5.Focus();

                }
            }

            if (ip5 == true)
            {
                if (txtip6.Text != "")
                {
                    ip6 = IsIPv4(txtip6.Text);
                    switch (ip6)
                    {
                        case true:

                            break;
                        case false:
                            lblMsj.Text = txtip6.Text + "No valido";
                            txtip6.Focus();
                            break;

                    }
                }
                else
                {
                    lblMsj.Text = "Ingrese Ip 6";
                    txtip6.Focus();

                }
            }

            if (ip6 == true)
            {
                if (txtip7.Text != "")
                {
                    ip7 = IsIPv4(txtip7.Text);
                    switch (ip6)
                    {
                        case true:

                            break;
                        case false:
                            lblMsj.Text = txtip7.Text + "No valido";
                            txtip7.Focus();
                            break;

                    }
                }
                else
                {
                    lblMsj.Text = "Ingrese Ip 7";
                    txtip7.Focus();

                }
            }


            if (ip1 == true && ip2 == true && ip3 == true && ip4 == true && ip5 == true && ip6 == true && ip7 == true)
            {


                Properties.Settings.Default.IP1 = txtip1.Text;
                Properties.Settings.Default.IP2 = txtip2.Text;
                Properties.Settings.Default.IP3 = txtip3.Text;
                Properties.Settings.Default.IP4 = txtip4.Text;
                Properties.Settings.Default.IP5 = txtip5.Text;
                Properties.Settings.Default.IP6 = txtip6.Text;
                Properties.Settings.Default.IP7 = txtip7.Text;

                Properties.Settings.Default.Save();



                lblMsj.Text = "IPs guardadas correctamente, vuelva para continuar";

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process.Start(keyboardPath); 
        }

        private void FrmConfigIPSecadores_Load(object sender, EventArgs e)
        {
            txtip1.Text = Properties.Settings.Default.IP1;
            txtip2.Text = Properties.Settings.Default.IP2;
            txtip3.Text = Properties.Settings.Default.IP3;
            txtip4.Text = Properties.Settings.Default.IP4;
            txtip5.Text = Properties.Settings.Default.IP5;
            txtip6.Text = Properties.Settings.Default.IP6;
            txtip7.Text = Properties.Settings.Default.IP7;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskScheduler;

namespace SecadorBotas.Frames
{
    public partial class FrmConfPeriodoActividad : Form
    {
        public FrmConfPeriodoActividad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {

           
            this.Close();
        }

        private void FrmConfPeriodoActividad_Load(object sender, EventArgs e)
        {
            //Texto sobre picturebox ENCENDER   
            var tEncender = new ToolTip();
            tEncender.SetToolTip(pictureBox1, "GUIA DE CONFIGURACION PARA ENCENDIDO AUTOMATICO");



        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       


        private void btnGuardarApagado_Click(object sender, EventArgs e)
        {

            if (comboBox3.Text == "-Seleccione dia-")
            {

                MessageBox.Show("Seleccione dia!!");

            }
            else
            {

                string dia = comboBox3.SelectedItem.ToString();
                int hora = Convert.ToInt32(numericUpDownHrs.Text);
                int min = Convert.ToInt32(numericUpDownMins.Text);


                Properties.Settings.Default.HoraPeriodoOFF = hora;
                Properties.Settings.Default.MinPeriodoOFF = min;
                Properties.Settings.Default.DiaOFF = dia;
                Properties.Settings.Default.Save();

                MessageBox.Show("Configuración guardada!!");          
            
        }
    }

        private void btnEliminarApagado_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HoraPeriodoOFF = 0;
            Properties.Settings.Default.MinPeriodoOFF = 0;
            Properties.Settings.Default.DiaOFF = "---";
            Properties.Settings.Default.Save();

            MessageBox.Show("Configuración removida!!");
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(numericUpDownHrs.Text);
            valor++;
            numericUpDownHrs.Text = valor.ToString();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(numericUpDownHrs.Text);
            if (valor == 0)
            {
                numericUpDownHrs.Text = 0.ToString();
            }
            else
            {
                valor--;
                numericUpDownHrs.Text = valor.ToString();
            }
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(numericUpDownMins.Text);
            valor++;
            numericUpDownMins.Text = valor.ToString();
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(numericUpDownMins.Text);
            if (valor == 0)
            {
                numericUpDownMins.Text = 0.ToString();
            }
            else
            {
                valor--;
                numericUpDownMins.Text = valor.ToString();
            }
        }



        private void btnQuitarEncendido_Click(object sender, EventArgs e)
        {
            using (ScheduledTasks Tareas = new ScheduledTasks())

            {

                Tareas.DeleteTask("Ejecutar secador de botas");
                MessageBox.Show("Configuración removida!!");
            }
        }

        private void btnConfON_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();

            info.UseShellExecute = true;
            info.FileName = "taskschd.msc";
            info.WorkingDirectory = @"C:\WINDOWS\system32";

            Process.Start(info);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frames.FrmGuiaEncendidoAuto formtGuia = new Frames.FrmGuiaEncendidoAuto();
            formtGuia.Show();
            
        }
    }
}

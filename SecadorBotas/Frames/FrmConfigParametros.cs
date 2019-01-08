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
    public partial class FrmConfigParametros : Form
    {
        public FrmConfigParametros()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar1 formt1 = new Frames.FrmConfServTar1();
            formt1.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar2 formt1 = new Frames.FrmConfServTar2();
            formt1.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar3 formt1 = new Frames.FrmConfServTar3();
            formt1.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar4 formt1 = new Frames.FrmConfServTar4();
            formt1.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar5 formt1 = new Frames.FrmConfServTar5();
            formt1.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar6 formt1 = new Frames.FrmConfServTar6();
            formt1.Show();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Frames.FrmConfServTar7 formt1 = new Frames.FrmConfServTar7();
            formt1.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHabilitar1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado1 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 1 habilitado!");
        }

        private void btnDeshabilitar1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado1 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 1 deshabilitado!");
        }

        private void btnHabilitar2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado2 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 2 habilitado!");
        }

        private void btnDeshabilitar2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado2 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 2 deshabilitado!");
        }

        private void btnHabilitar3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado3 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 3 habilitado!");
        }

        private void btnDeshabilitar3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado3 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 3 deshabilitado!");
        }

        private void btnHabilitar4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado4 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 4 habilitado!");
        }

        private void btnDeshabilitar4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado4 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 4 deshabilitado!");
        }

        private void btnHabilitar5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado5 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 5 habilitado!");
        }

        private void btnDeshabilitar5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado5 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 5 deshabilitado!");
        }

        private void btnHabilitar6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado6 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 6 habilitado!");
        }

        private void btnDeshabilitar6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado6 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 6 deshabilitado!");
        }

        private void btnHabilitar7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado7 = 1;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 7 habilitado!");
        }

        private void btnDeshabilitar7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Estado7 = 0;
            Properties.Settings.Default.Save();

            MessageBox.Show("Secador 7 deshabilitado!");
        }
    }
}

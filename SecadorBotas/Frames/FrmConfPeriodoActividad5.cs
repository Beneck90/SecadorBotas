using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecadorBotas.Frames
{
    public partial class FrmConfPeriodoActividad5 : Form
    {

        #region Variables_de_conexion

        static string sqlConexionWebConfig = ConfigurationManager.ConnectionStrings["BDConnectionString"].ToString();

        SqlConnection cn = new SqlConnection(sqlConexionWebConfig);

        #endregion Variables_de_conexion


        public FrmConfPeriodoActividad5()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Frames.FrmSecadores formSsecadores = new Frames.FrmSecadores();
            formSsecadores.Show();
            this.Close();
        }

        private void btnGuardarON_Click(object sender, EventArgs e)
        {

            if (comboBoxDiaON.Text == "-Seleccione dia-")
            {
                MessageBox.Show("Seleccione día!");

            }

            else
            {

                //PARAMETROS INGRESADOS
                string dia = comboBoxDiaON.SelectedItem.ToString();
                int hora = Convert.ToInt32(txtONhrs.Text);
                int minuto = Convert.ToInt32(txtONmins.Text);



                //INSTANCIA CLASE ConexBD
                Clases.ConexBD conex = new Clases.ConexBD();


                //VALIDA SI EL REGISTRO YA EXISTE
                if (SecadorBotas.Clases.ConexBD.ValidaPeriodoONSecador5(dia, hora, minuto))
                {
                    MessageBox.Show("Encendido automático ya existe!");
                }

                else
                {
                    //LLAMADA DEL METODO INSERTAR ENCENDIDO DE SECADOR 6
                    conex.InsertarEncendido5(dia, hora, minuto);

                    //LLAMADA A METODO QUE CARGA EL GRID
                    CargarDataGridON();

                    //MENSAJE POR PANTALLA
                    MessageBox.Show("Encendido automático guardado!");
                }
            }
        }


        //LOAD
        private void FrmConfPeriodoActividad5_Load(object sender, EventArgs e)
        {
            //CARGA DE DATAGRIDVIEWS
            CargarDataGridON();
            CargarDataGridOFF();
        }


        private void CargarDataGridON()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM EncendidoSecador5", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewON.DataSource = dt;
            cn.Close();
        }

        //METODO QUE MUESTRA LOS DATOS MEDIANTE UN DATATABLE
        private void CargarDataGridOFF()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ApagadoSecador5", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewOFF.DataSource = dt;
            cn.Close();
        }

        private void pictureBoxBorrarON_Click(object sender, EventArgs e)
        {
            if (dataGridViewON.CurrentRow == null)

                return;

            //Campo de la tabla
            int Id = Convert.ToInt32(dataGridViewON.CurrentRow.Cells["id"].Value);

            using (SqlConnection cnn = new SqlConnection(sqlConexionWebConfig))

            {

                string query = "delete from EncendidoSecador5 where id = @Id";

                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();

            }

            dataGridViewON.Rows.Remove(dataGridViewON.CurrentRow);

            //MENSAJE POR PANTALLA
            MessageBox.Show("Encendido automático removido!");
        }

        private void pbAumentaONhrs_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtONhrs.Text);
            valor++;
            txtONhrs.Text = valor.ToString();
        }

        private void pbDecrementaONhrs_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtONhrs.Text);
            if (valor == 0)
            {
                txtONhrs.Text = 0.ToString();
            }
            else
            {
                valor--;
                txtONhrs.Text = valor.ToString();
            }
        }

        private void pbAumentaONmins_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtONmins.Text);
            valor++;
            txtONmins.Text = valor.ToString();
        }

        private void pbDecrementaONmins_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtONmins.Text);
            if (valor == 0)
            {
                txtONmins.Text = 0.ToString();
            }
            else
            {
                valor--;
                txtONmins.Text = valor.ToString();
            }
        }

        private void btnGuardarOFF_Click(object sender, EventArgs e)
        {

            if (comboBoxOFF.Text == "-Seleccione dia-")
            {
                MessageBox.Show("Seleccione día!");

            }
            else
            {
                //PARAMETROS INGRESADOS
                string dia = comboBoxOFF.SelectedItem.ToString();
                int hora = Convert.ToInt32(numericUpDownHrs.Text);
                int minuto = Convert.ToInt32(numericUpDownMins.Text);


                //INSTANCIA CLASE ConexBD
                Clases.ConexBD conex = new Clases.ConexBD();

                //VALIDA SI EL REGISTRO YA EXISTE
                if (SecadorBotas.Clases.ConexBD.ValidaPeriodoOFFSecador5(dia, hora, minuto))
                {
                    MessageBox.Show("Apagado automático ya existe!");
                }
                else
                {

                    //LLAMADA DEL METODO INSERTAR APAGADO DE SECADOR 7
                    conex.InsertarApagado5(dia, hora, minuto);

                    //LLAMADA A METODO QUE CARGA EL GRID
                    CargarDataGridOFF();

                    //MENSAJE POR PANTALLA
                    MessageBox.Show("Apagado automático guardado!");
                }
            }
        }

        private void pictureBoxBorrarOFF_Click(object sender, EventArgs e)
        {
            if (dataGridViewOFF.CurrentRow == null)

                return;

            //El campo del DataGridView debe llamarse igual que el campo de la tabla, en este caso idOff

            //Campo de la tabla
            int IdOff = Convert.ToInt32(dataGridViewOFF.CurrentRow.Cells["idOff"].Value);

            using (SqlConnection cnn = new SqlConnection(sqlConexionWebConfig))

            {

                string query = "delete from ApagadoSecador5 where idOff = @Id";

                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();

                cmd.Parameters.AddWithValue("@Id", IdOff);
                cmd.ExecuteNonQuery();

            }

            dataGridViewOFF.Rows.Remove(dataGridViewOFF.CurrentRow);

            //MENSAJE POR PANTALLA
            MessageBox.Show("Apagado automático removido!");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
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

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(numericUpDownMins.Text);
            valor++;
            numericUpDownMins.Text = valor.ToString();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
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
    }
}

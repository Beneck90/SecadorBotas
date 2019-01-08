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
    public partial class FrmConfigPeriodoActividad : Form
    {
        public FrmConfigPeriodoActividad()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            /*Isntancia de la clase ScheduledTasks*/
            Clases.ScheduledTasks st = new Clases.ScheduledTasks();
            

            // Crear una tarea

            Task t;
            try
            {
                t = st.CreateTask("Abrir seriales");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Task name already exists");
                return;
            }
        }
    }
}

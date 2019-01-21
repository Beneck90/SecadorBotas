namespace SecadorBotas.Frames
{
    partial class FrmTarjeta2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerTemp = new System.Windows.Forms.Timer(this.components);
            this.timerBotonONOFF = new System.Windows.Forms.Timer(this.components);
            this.timerONCalefactor = new System.Windows.Forms.Timer(this.components);
            this.timerOFFCalefactor = new System.Windows.Forms.Timer(this.components);
            this.timerOnUV2 = new System.Windows.Forms.Timer(this.components);
            this.timerOffUV2 = new System.Windows.Forms.Timer(this.components);
            this.timerSesion2 = new System.Windows.Forms.Timer(this.components);
            this.lblEstadoCalefactor2 = new System.Windows.Forms.Label();
            this.lblEstadoUV2 = new System.Windows.Forms.Label();
            this.lblEstadoVent2 = new System.Windows.Forms.Label();
            this.ESTADO2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTempMax2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBarTemp2 = new System.Windows.Forms.ProgressBar();
            this.lblTemp2 = new System.Windows.Forms.Label();
            this.lblMensaje2 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerON = new System.Windows.Forms.Timer(this.components);
            this.timerOFF = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerTemp
            // 
            this.timerTemp.Tick += new System.EventHandler(this.timerTemp_Tick);
            // 
            // timerBotonONOFF
            // 
            this.timerBotonONOFF.Tick += new System.EventHandler(this.timerBotonONOFF_Tick);
            // 
            // timerONCalefactor
            // 
            this.timerONCalefactor.Tick += new System.EventHandler(this.timerONCalefactor_Tick);
            // 
            // timerOFFCalefactor
            // 
            this.timerOFFCalefactor.Tick += new System.EventHandler(this.timerOFFCalefactor_Tick);
            // 
            // timerOnUV2
            // 
            this.timerOnUV2.Tick += new System.EventHandler(this.timerOnUV2_Tick);
            // 
            // timerOffUV2
            // 
            this.timerOffUV2.Tick += new System.EventHandler(this.timerOffUV2_Tick);
            // 
            // timerSesion2
            // 
            this.timerSesion2.Interval = 900000;
            this.timerSesion2.Tick += new System.EventHandler(this.timerSesion2_Tick);
            // 
            // lblEstadoCalefactor2
            // 
            this.lblEstadoCalefactor2.BackColor = System.Drawing.Color.Black;
            this.lblEstadoCalefactor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstadoCalefactor2.Font = new System.Drawing.Font("Handel Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCalefactor2.ForeColor = System.Drawing.Color.Snow;
            this.lblEstadoCalefactor2.Location = new System.Drawing.Point(300, 468);
            this.lblEstadoCalefactor2.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoCalefactor2.Name = "lblEstadoCalefactor2";
            this.lblEstadoCalefactor2.Size = new System.Drawing.Size(78, 30);
            this.lblEstadoCalefactor2.TabIndex = 83;
            this.lblEstadoCalefactor2.Text = "ON/OFF";
            this.lblEstadoCalefactor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoUV2
            // 
            this.lblEstadoUV2.BackColor = System.Drawing.Color.Black;
            this.lblEstadoUV2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstadoUV2.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoUV2.ForeColor = System.Drawing.Color.Snow;
            this.lblEstadoUV2.Location = new System.Drawing.Point(300, 348);
            this.lblEstadoUV2.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoUV2.Name = "lblEstadoUV2";
            this.lblEstadoUV2.Size = new System.Drawing.Size(78, 30);
            this.lblEstadoUV2.TabIndex = 82;
            this.lblEstadoUV2.Text = "ON/OFF";
            this.lblEstadoUV2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoVent2
            // 
            this.lblEstadoVent2.BackColor = System.Drawing.Color.Black;
            this.lblEstadoVent2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstadoVent2.Font = new System.Drawing.Font("Handel Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoVent2.ForeColor = System.Drawing.Color.Snow;
            this.lblEstadoVent2.Location = new System.Drawing.Point(300, 230);
            this.lblEstadoVent2.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoVent2.Name = "lblEstadoVent2";
            this.lblEstadoVent2.Size = new System.Drawing.Size(78, 30);
            this.lblEstadoVent2.TabIndex = 81;
            this.lblEstadoVent2.Text = "ON/OFF";
            this.lblEstadoVent2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ESTADO2
            // 
            this.ESTADO2.AutoSize = true;
            this.ESTADO2.Font = new System.Drawing.Font("Handel Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ESTADO2.ForeColor = System.Drawing.Color.White;
            this.ESTADO2.Location = new System.Drawing.Point(382, 86);
            this.ESTADO2.Name = "ESTADO2";
            this.ESTADO2.Size = new System.Drawing.Size(289, 27);
            this.ESTADO2.TabIndex = 79;
            this.ESTADO2.Text = "ESTADO SECADOR 2";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblTempMax2);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(528, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 77);
            this.groupBox2.TabIndex = 242;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temperatura maxima";
            // 
            // lblTempMax2
            // 
            this.lblTempMax2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblTempMax2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTempMax2.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempMax2.ForeColor = System.Drawing.Color.White;
            this.lblTempMax2.Location = new System.Drawing.Point(39, 26);
            this.lblTempMax2.Margin = new System.Windows.Forms.Padding(0);
            this.lblTempMax2.Name = "lblTempMax2";
            this.lblTempMax2.Size = new System.Drawing.Size(90, 39);
            this.lblTempMax2.TabIndex = 117;
            this.lblTempMax2.Text = "0°C";
            this.lblTempMax2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.progressBarTemp2);
            this.groupBox3.Controls.Add(this.lblTemp2);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(528, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 75);
            this.groupBox3.TabIndex = 239;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temperatura ";
            // 
            // progressBarTemp2
            // 
            this.progressBarTemp2.BackColor = System.Drawing.Color.DarkRed;
            this.progressBarTemp2.ForeColor = System.Drawing.Color.Red;
            this.progressBarTemp2.Location = new System.Drawing.Point(27, 27);
            this.progressBarTemp2.Name = "progressBarTemp2";
            this.progressBarTemp2.Size = new System.Drawing.Size(240, 23);
            this.progressBarTemp2.TabIndex = 10;
            // 
            // lblTemp2
            // 
            this.lblTemp2.AutoSize = true;
            this.lblTemp2.ForeColor = System.Drawing.Color.White;
            this.lblTemp2.Location = new System.Drawing.Point(273, 27);
            this.lblTemp2.Name = "lblTemp2";
            this.lblTemp2.Size = new System.Drawing.Size(32, 14);
            this.lblTemp2.TabIndex = 11;
            this.lblTemp2.Text = "0°C";
            // 
            // lblMensaje2
            // 
            this.lblMensaje2.AutoSize = true;
            this.lblMensaje2.Font = new System.Drawing.Font("Handel Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje2.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMensaje2.Location = new System.Drawing.Point(524, 485);
            this.lblMensaje2.Name = "lblMensaje2";
            this.lblMensaje2.Size = new System.Drawing.Size(0, 22);
            this.lblMensaje2.TabIndex = 275;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::SecadorBotas.Properties.Resources.servicio;
            this.pictureBox8.Location = new System.Drawing.Point(710, 626);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(85, 79);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 244;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::SecadorBotas.Properties.Resources.BtnVolver;
            this.pictureBox7.Location = new System.Drawing.Point(858, 626);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(85, 79);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 243;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::SecadorBotas.Properties.Resources.temperatura_alta;
            this.pictureBox9.Location = new System.Drawing.Point(451, 388);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(71, 65);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 241;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::SecadorBotas.Properties.Resources.termometro;
            this.pictureBox6.Location = new System.Drawing.Point(451, 280);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(71, 65);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 240;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SecadorBotas.Properties.Resources.acondicionador_de_aire2;
            this.pictureBox5.Location = new System.Drawing.Point(173, 437);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(95, 83);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 85;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SecadorBotas.Properties.Resources.filtroUVON;
            this.pictureBox4.Location = new System.Drawing.Point(162, 307);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(123, 111);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 84;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SecadorBotas.Properties.Resources.acondicionador_de_aire;
            this.pictureBox2.Location = new System.Drawing.Point(173, 437);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 76;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SecadorBotas.Properties.Resources.filtro_uv_2_;
            this.pictureBox3.Location = new System.Drawing.Point(162, 307);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(123, 111);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 75;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SecadorBotas.Properties.Resources.ventilador;
            this.pictureBox1.Location = new System.Drawing.Point(173, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // timerON
            // 
            this.timerON.Tick += new System.EventHandler(this.timerON_Tick);
            // 
            // timerOFF
            // 
            this.timerOFF.Tick += new System.EventHandler(this.timerOFF_Tick);
            // 
            // FrmTarjeta2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblMensaje2);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblEstadoCalefactor2);
            this.Controls.Add(this.lblEstadoUV2);
            this.Controls.Add(this.lblEstadoVent2);
            this.Controls.Add(this.ESTADO2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTarjeta2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmTarjeta2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerTemp;
        private System.Windows.Forms.Timer timerBotonONOFF;
        private System.Windows.Forms.Timer timerONCalefactor;
        private System.Windows.Forms.Timer timerOFFCalefactor;
        private System.Windows.Forms.Timer timerOnUV2;
        private System.Windows.Forms.Timer timerOffUV2;
        private System.Windows.Forms.Timer timerSesion2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblEstadoCalefactor2;
        private System.Windows.Forms.Label lblEstadoUV2;
        private System.Windows.Forms.Label lblEstadoVent2;
        private System.Windows.Forms.Label ESTADO2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTempMax2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBarTemp2;
        private System.Windows.Forms.Label lblTemp2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblMensaje2;
        private System.Windows.Forms.Timer timerON;
        private System.Windows.Forms.Timer timerOFF;
    }
}
namespace SecadorBotas.Frames
{
    partial class FrmTarjeta1
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
            this.progressBarTemp1 = new System.Windows.Forms.ProgressBar();
            this.lblTemp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.timerTemp = new System.Windows.Forms.Timer(this.components);
            this.timerBotonONOFF = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerONCalefactor = new System.Windows.Forms.Timer(this.components);
            this.timerOFFCalefactor = new System.Windows.Forms.Timer(this.components);
            this.timerOnUV1 = new System.Windows.Forms.Timer(this.components);
            this.timerOffUV1 = new System.Windows.Forms.Timer(this.components);
            this.timerSesion1 = new System.Windows.Forms.Timer(this.components);
            this.lblTempMax1 = new System.Windows.Forms.Label();
            this.LOGIN = new System.Windows.Forms.Label();
            this.lblEstadoCalefactor1 = new System.Windows.Forms.Label();
            this.lblEstadoUV1 = new System.Windows.Forms.Label();
            this.lblEstadoVent1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMensaje1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarTemp1
            // 
            this.progressBarTemp1.BackColor = System.Drawing.Color.DarkRed;
            this.progressBarTemp1.ForeColor = System.Drawing.Color.Red;
            this.progressBarTemp1.Location = new System.Drawing.Point(27, 27);
            this.progressBarTemp1.Name = "progressBarTemp1";
            this.progressBarTemp1.Size = new System.Drawing.Size(240, 23);
            this.progressBarTemp1.TabIndex = 10;
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.ForeColor = System.Drawing.Color.White;
            this.lblTemp.Location = new System.Drawing.Point(273, 27);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(32, 14);
            this.lblTemp.TabIndex = 11;
            this.lblTemp.Text = "0°C";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.progressBarTemp1);
            this.groupBox1.Controls.Add(this.lblTemp);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(528, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 75);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperatura ";
            // 
            // lblMinutos
            // 
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Location = new System.Drawing.Point(366, 246);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(0, 13);
            this.lblMinutos.TabIndex = 67;
            // 
            // timerTemp
            // 
            this.timerTemp.Tick += new System.EventHandler(this.timerTemp_Tick);
            // 
            // timerBotonONOFF
            // 
            this.timerBotonONOFF.Tick += new System.EventHandler(this.timerBotonONOFF_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerONCalefactor
            // 
            this.timerONCalefactor.Tick += new System.EventHandler(this.timerONCalefactor_Tick);
            // 
            // timerOFFCalefactor
            // 
            this.timerOFFCalefactor.Tick += new System.EventHandler(this.timerOFFCalefactor_Tick);
            // 
            // timerOnUV1
            // 
            this.timerOnUV1.Tick += new System.EventHandler(this.timerOnUV1_Tick);
            // 
            // timerOffUV1
            // 
            this.timerOffUV1.Tick += new System.EventHandler(this.timerOffUV1_Tick);
            // 
            // timerSesion1
            // 
            this.timerSesion1.Interval = 900000;
            this.timerSesion1.Tick += new System.EventHandler(this.timerSesion1_Tick);
            // 
            // lblTempMax1
            // 
            this.lblTempMax1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblTempMax1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTempMax1.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempMax1.ForeColor = System.Drawing.Color.White;
            this.lblTempMax1.Location = new System.Drawing.Point(39, 26);
            this.lblTempMax1.Margin = new System.Windows.Forms.Padding(0);
            this.lblTempMax1.Name = "lblTempMax1";
            this.lblTempMax1.Size = new System.Drawing.Size(90, 39);
            this.lblTempMax1.TabIndex = 117;
            this.lblTempMax1.Text = "0°C";
            this.lblTempMax1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LOGIN
            // 
            this.LOGIN.AutoSize = true;
            this.LOGIN.Font = new System.Drawing.Font("Handel Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGIN.ForeColor = System.Drawing.Color.White;
            this.LOGIN.Location = new System.Drawing.Point(382, 86);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(279, 27);
            this.LOGIN.TabIndex = 66;
            this.LOGIN.Text = "ESTADO SECADOR 1";
            // 
            // lblEstadoCalefactor1
            // 
            this.lblEstadoCalefactor1.BackColor = System.Drawing.Color.Black;
            this.lblEstadoCalefactor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstadoCalefactor1.Font = new System.Drawing.Font("Handel Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCalefactor1.ForeColor = System.Drawing.Color.Snow;
            this.lblEstadoCalefactor1.Location = new System.Drawing.Point(300, 468);
            this.lblEstadoCalefactor1.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoCalefactor1.Name = "lblEstadoCalefactor1";
            this.lblEstadoCalefactor1.Size = new System.Drawing.Size(78, 30);
            this.lblEstadoCalefactor1.TabIndex = 70;
            this.lblEstadoCalefactor1.Text = "ON/OFF";
            this.lblEstadoCalefactor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoUV1
            // 
            this.lblEstadoUV1.BackColor = System.Drawing.Color.Black;
            this.lblEstadoUV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstadoUV1.Font = new System.Drawing.Font("Handel Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoUV1.ForeColor = System.Drawing.Color.Snow;
            this.lblEstadoUV1.Location = new System.Drawing.Point(300, 348);
            this.lblEstadoUV1.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoUV1.Name = "lblEstadoUV1";
            this.lblEstadoUV1.Size = new System.Drawing.Size(78, 30);
            this.lblEstadoUV1.TabIndex = 69;
            this.lblEstadoUV1.Text = "ON/OFF";
            this.lblEstadoUV1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoVent1
            // 
            this.lblEstadoVent1.BackColor = System.Drawing.Color.Black;
            this.lblEstadoVent1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstadoVent1.Font = new System.Drawing.Font("Handel Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoVent1.ForeColor = System.Drawing.Color.Snow;
            this.lblEstadoVent1.Location = new System.Drawing.Point(300, 230);
            this.lblEstadoVent1.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoVent1.Name = "lblEstadoVent1";
            this.lblEstadoVent1.Size = new System.Drawing.Size(78, 30);
            this.lblEstadoVent1.TabIndex = 68;
            this.lblEstadoVent1.Text = "ON/OFF";
            this.lblEstadoVent1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblTempMax1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(528, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 77);
            this.groupBox2.TabIndex = 238;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temperatura maxima";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::SecadorBotas.Properties.Resources.temperatura_alta;
            this.pictureBox9.Location = new System.Drawing.Point(451, 382);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(71, 65);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 237;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::SecadorBotas.Properties.Resources.servicio;
            this.pictureBox8.Location = new System.Drawing.Point(710, 626);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(85, 79);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 236;
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
            this.pictureBox7.TabIndex = 235;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::SecadorBotas.Properties.Resources.termometro;
            this.pictureBox6.Location = new System.Drawing.Point(451, 280);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(71, 65);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 234;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SecadorBotas.Properties.Resources.acondicionador_de_aire2;
            this.pictureBox5.Location = new System.Drawing.Point(173, 437);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(95, 83);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 72;
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
            this.pictureBox4.TabIndex = 71;
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
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SecadorBotas.Properties.Resources.filtro_uv_2_;
            this.pictureBox3.Location = new System.Drawing.Point(162, 307);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(123, 111);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SecadorBotas.Properties.Resources.ventilador;
            this.pictureBox1.Location = new System.Drawing.Point(173, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblMensaje1
            // 
            this.lblMensaje1.AutoSize = true;
            this.lblMensaje1.Font = new System.Drawing.Font("Handel Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje1.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMensaje1.Location = new System.Drawing.Point(524, 486);
            this.lblMensaje1.Name = "lblMensaje1";
            this.lblMensaje1.Size = new System.Drawing.Size(0, 22);
            this.lblMensaje1.TabIndex = 274;
            // 
            // FrmTarjeta1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblMensaje1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblEstadoCalefactor1);
            this.Controls.Add(this.lblEstadoUV1);
            this.Controls.Add(this.lblEstadoVent1);
            this.Controls.Add(this.lblMinutos);
            this.Controls.Add(this.LOGIN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTarjeta1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmTarjeta1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
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

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBarTemp1;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Timer timerTemp;
        private System.Windows.Forms.Timer timerBotonONOFF;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerONCalefactor;
        private System.Windows.Forms.Timer timerOFFCalefactor;
        private System.Windows.Forms.Timer timerOnUV1;
        private System.Windows.Forms.Timer timerOffUV1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer timerSesion1;
        private System.Windows.Forms.Label lblTempMax1;
        private System.Windows.Forms.Label LOGIN;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblEstadoCalefactor1;
        private System.Windows.Forms.Label lblEstadoUV1;
        private System.Windows.Forms.Label lblEstadoVent1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMensaje1;
    }
}
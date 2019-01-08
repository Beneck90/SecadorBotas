namespace SecadorBotas.Frames
{
    partial class FrmMenuServicioTarj1
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
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblMsjCorreo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timerHrsFuncionamiento = new System.Windows.Forms.Timer(this.components);
            this.timerSesion = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHrsMaxMotor = new System.Windows.Forms.Label();
            this.lblHrsMaxUV = new System.Windows.Forms.Label();
            this.lblHrsMaxCalefactor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHrsSeCalefactor = new System.Windows.Forms.Label();
            this.lblHrsSerUV = new System.Windows.Forms.Label();
            this.lblHrsSerMotor = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.BackColor = System.Drawing.Color.SteelBlue;
            this.lblServicio.Font = new System.Drawing.Font("Handel Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.White;
            this.lblServicio.Location = new System.Drawing.Point(421, 107);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(228, 27);
            this.lblServicio.TabIndex = 1;
            this.lblServicio.Text = "MENU SERVICIO";
            // 
            // lblMsjCorreo
            // 
            this.lblMsjCorreo.AutoSize = true;
            this.lblMsjCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsjCorreo.ForeColor = System.Drawing.Color.Red;
            this.lblMsjCorreo.Location = new System.Drawing.Point(32, 467);
            this.lblMsjCorreo.Name = "lblMsjCorreo";
            this.lblMsjCorreo.Size = new System.Drawing.Size(0, 13);
            this.lblMsjCorreo.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(77, 602);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 14);
            this.label10.TabIndex = 240;
            this.label10.Text = "Crear contrasena";
            // 
            // timerHrsFuncionamiento
            // 
            this.timerHrsFuncionamiento.Tick += new System.EventHandler(this.timerHrsFuncionamiento_Tick);
            // 
            // timerSesion
            // 
            this.timerSesion.Interval = 900000;
            this.timerSesion.Tick += new System.EventHandler(this.timerSesion_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SecadorBotas.Properties.Resources.passnew;
            this.pictureBox1.Location = new System.Drawing.Point(93, 630);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 239;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::SecadorBotas.Properties.Resources.BtnVolver;
            this.pictureBox7.Location = new System.Drawing.Point(862, 630);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(85, 79);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 237;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.lblHrsMaxMotor);
            this.groupBox1.Controls.Add(this.lblHrsMaxUV);
            this.groupBox1.Controls.Add(this.lblHrsMaxCalefactor);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblHrsSeCalefactor);
            this.groupBox1.Controls.Add(this.lblHrsSerUV);
            this.groupBox1.Controls.Add(this.lblHrsSerMotor);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(154, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 244);
            this.groupBox1.TabIndex = 271;
            this.groupBox1.TabStop = false;
            // 
            // lblHrsMaxMotor
            // 
            this.lblHrsMaxMotor.AutoSize = true;
            this.lblHrsMaxMotor.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsMaxMotor.ForeColor = System.Drawing.Color.White;
            this.lblHrsMaxMotor.Location = new System.Drawing.Point(556, 75);
            this.lblHrsMaxMotor.Name = "lblHrsMaxMotor";
            this.lblHrsMaxMotor.Size = new System.Drawing.Size(88, 19);
            this.lblHrsMaxMotor.TabIndex = 158;
            this.lblHrsMaxMotor.Text = "Hrs máx.";
            // 
            // lblHrsMaxUV
            // 
            this.lblHrsMaxUV.AutoSize = true;
            this.lblHrsMaxUV.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsMaxUV.ForeColor = System.Drawing.Color.White;
            this.lblHrsMaxUV.Location = new System.Drawing.Point(556, 124);
            this.lblHrsMaxUV.Name = "lblHrsMaxUV";
            this.lblHrsMaxUV.Size = new System.Drawing.Size(88, 19);
            this.lblHrsMaxUV.TabIndex = 157;
            this.lblHrsMaxUV.Text = "Hrs máx.";
            // 
            // lblHrsMaxCalefactor
            // 
            this.lblHrsMaxCalefactor.AutoSize = true;
            this.lblHrsMaxCalefactor.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsMaxCalefactor.ForeColor = System.Drawing.Color.White;
            this.lblHrsMaxCalefactor.Location = new System.Drawing.Point(556, 176);
            this.lblHrsMaxCalefactor.Name = "lblHrsMaxCalefactor";
            this.lblHrsMaxCalefactor.Size = new System.Drawing.Size(88, 19);
            this.lblHrsMaxCalefactor.TabIndex = 156;
            this.lblHrsMaxCalefactor.Text = "Hrs máx.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(534, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 19);
            this.label9.TabIndex = 155;
            this.label9.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(534, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 19);
            this.label8.TabIndex = 154;
            this.label8.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(534, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 19);
            this.label7.TabIndex = 153;
            this.label7.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(487, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 152;
            this.label6.Text = "Hrs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(487, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 19);
            this.label5.TabIndex = 151;
            this.label5.Text = "Hrs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(487, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 150;
            this.label4.Text = "Hrs";
            // 
            // lblHrsSeCalefactor
            // 
            this.lblHrsSeCalefactor.BackColor = System.Drawing.Color.Black;
            this.lblHrsSeCalefactor.Font = new System.Drawing.Font("Handel Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsSeCalefactor.ForeColor = System.Drawing.Color.Snow;
            this.lblHrsSeCalefactor.Location = new System.Drawing.Point(377, 168);
            this.lblHrsSeCalefactor.Margin = new System.Windows.Forms.Padding(0);
            this.lblHrsSeCalefactor.Name = "lblHrsSeCalefactor";
            this.lblHrsSeCalefactor.Size = new System.Drawing.Size(107, 30);
            this.lblHrsSeCalefactor.TabIndex = 149;
            this.lblHrsSeCalefactor.Text = "0";
            this.lblHrsSeCalefactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHrsSerUV
            // 
            this.lblHrsSerUV.BackColor = System.Drawing.Color.Black;
            this.lblHrsSerUV.Font = new System.Drawing.Font("Handel Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsSerUV.ForeColor = System.Drawing.Color.Snow;
            this.lblHrsSerUV.Location = new System.Drawing.Point(377, 116);
            this.lblHrsSerUV.Margin = new System.Windows.Forms.Padding(0);
            this.lblHrsSerUV.Name = "lblHrsSerUV";
            this.lblHrsSerUV.Size = new System.Drawing.Size(107, 30);
            this.lblHrsSerUV.TabIndex = 148;
            this.lblHrsSerUV.Text = "0";
            this.lblHrsSerUV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHrsSerMotor
            // 
            this.lblHrsSerMotor.BackColor = System.Drawing.Color.Black;
            this.lblHrsSerMotor.Font = new System.Drawing.Font("Handel Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsSerMotor.ForeColor = System.Drawing.Color.Snow;
            this.lblHrsSerMotor.Location = new System.Drawing.Point(377, 67);
            this.lblHrsSerMotor.Margin = new System.Windows.Forms.Padding(0);
            this.lblHrsSerMotor.Name = "lblHrsSerMotor";
            this.lblHrsSerMotor.Size = new System.Drawing.Size(107, 30);
            this.lblHrsSerMotor.TabIndex = 147;
            this.lblHrsSerMotor.Text = "0";
            this.lblHrsSerMotor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(80, 171);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(258, 19);
            this.label17.TabIndex = 146;
            this.label17.Text = "Horas servicio calefactor ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(80, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(218, 19);
            this.label18.TabIndex = 144;
            this.label18.Text = "Horas servicio motor ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(80, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(198, 19);
            this.label19.TabIndex = 145;
            this.label19.Text = "Horas servicio UV  ";
            // 
            // FrmMenuServicioTarj1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.lblMsjCorreo);
            this.Controls.Add(this.lblServicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenuServicioTarj1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMenuServicioTarj1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblMsjCorreo;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timerHrsFuncionamiento;
        private System.Windows.Forms.Timer timerSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHrsMaxMotor;
        private System.Windows.Forms.Label lblHrsMaxUV;
        private System.Windows.Forms.Label lblHrsMaxCalefactor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHrsSeCalefactor;
        private System.Windows.Forms.Label lblHrsSerUV;
        private System.Windows.Forms.Label lblHrsSerMotor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}
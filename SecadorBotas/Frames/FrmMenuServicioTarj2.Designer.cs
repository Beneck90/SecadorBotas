namespace SecadorBotas.Frames
{
    partial class FrmMenuServicioTarj2
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
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.timerHrsFuncionamiento = new System.Windows.Forms.Timer(this.components);
            this.timerSesion = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHrsMaxMotor2 = new System.Windows.Forms.Label();
            this.lblHrsMaxUV2 = new System.Windows.Forms.Label();
            this.lblHrsMaxCalefactor2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHrsSerCalefactor3 = new System.Windows.Forms.Label();
            this.lblHrsSerUV2 = new System.Windows.Forms.Label();
            this.lblHrsSerMotor2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Handel Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblServicio.ForeColor = System.Drawing.Color.White;
            this.lblServicio.Location = new System.Drawing.Point(421, 107);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(228, 27);
            this.lblServicio.TabIndex = 53;
            this.lblServicio.Text = "MENU SERVICIO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Handel Gothic", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(77, 602);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 14);
            this.label10.TabIndex = 242;
            this.label10.Text = "Crear contrasena";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SecadorBotas.Properties.Resources.passnew;
            this.pictureBox1.Location = new System.Drawing.Point(93, 630);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 241;
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
            this.pictureBox7.TabIndex = 243;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // timerHrsFuncionamiento
            // 
            this.timerHrsFuncionamiento.Interval = 20;
            this.timerHrsFuncionamiento.Tick += new System.EventHandler(this.timerHrsFuncionamiento_Tick);
            // 
            // timerSesion
            // 
            this.timerSesion.Interval = 900000;
            this.timerSesion.Tick += new System.EventHandler(this.timerSesion_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.lblHrsMaxMotor2);
            this.groupBox1.Controls.Add(this.lblHrsMaxUV2);
            this.groupBox1.Controls.Add(this.lblHrsMaxCalefactor2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblHrsSerCalefactor3);
            this.groupBox1.Controls.Add(this.lblHrsSerUV2);
            this.groupBox1.Controls.Add(this.lblHrsSerMotor2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(154, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 244);
            this.groupBox1.TabIndex = 270;
            this.groupBox1.TabStop = false;
            // 
            // lblHrsMaxMotor2
            // 
            this.lblHrsMaxMotor2.AutoSize = true;
            this.lblHrsMaxMotor2.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblHrsMaxMotor2.ForeColor = System.Drawing.Color.White;
            this.lblHrsMaxMotor2.Location = new System.Drawing.Point(549, 76);
            this.lblHrsMaxMotor2.Name = "lblHrsMaxMotor2";
            this.lblHrsMaxMotor2.Size = new System.Drawing.Size(92, 19);
            this.lblHrsMaxMotor2.TabIndex = 158;
            this.lblHrsMaxMotor2.Text = "Hrs max.";
            // 
            // lblHrsMaxUV2
            // 
            this.lblHrsMaxUV2.AutoSize = true;
            this.lblHrsMaxUV2.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblHrsMaxUV2.ForeColor = System.Drawing.Color.White;
            this.lblHrsMaxUV2.Location = new System.Drawing.Point(549, 125);
            this.lblHrsMaxUV2.Name = "lblHrsMaxUV2";
            this.lblHrsMaxUV2.Size = new System.Drawing.Size(92, 19);
            this.lblHrsMaxUV2.TabIndex = 157;
            this.lblHrsMaxUV2.Text = "Hrs max.";
            // 
            // lblHrsMaxCalefactor2
            // 
            this.lblHrsMaxCalefactor2.AutoSize = true;
            this.lblHrsMaxCalefactor2.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblHrsMaxCalefactor2.ForeColor = System.Drawing.Color.White;
            this.lblHrsMaxCalefactor2.Location = new System.Drawing.Point(549, 177);
            this.lblHrsMaxCalefactor2.Name = "lblHrsMaxCalefactor2";
            this.lblHrsMaxCalefactor2.Size = new System.Drawing.Size(92, 19);
            this.lblHrsMaxCalefactor2.TabIndex = 156;
            this.lblHrsMaxCalefactor2.Text = "Hrs max.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(527, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 19);
            this.label9.TabIndex = 155;
            this.label9.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(527, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 19);
            this.label8.TabIndex = 154;
            this.label8.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(527, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 19);
            this.label7.TabIndex = 153;
            this.label7.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(480, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 152;
            this.label6.Text = "Hrs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(480, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 19);
            this.label5.TabIndex = 151;
            this.label5.Text = "Hrs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(480, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 150;
            this.label4.Text = "Hrs";
            // 
            // lblHrsSerCalefactor3
            // 
            this.lblHrsSerCalefactor3.BackColor = System.Drawing.Color.Black;
            this.lblHrsSerCalefactor3.Font = new System.Drawing.Font("Handel Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsSerCalefactor3.ForeColor = System.Drawing.Color.Snow;
            this.lblHrsSerCalefactor3.Location = new System.Drawing.Point(370, 169);
            this.lblHrsSerCalefactor3.Margin = new System.Windows.Forms.Padding(0);
            this.lblHrsSerCalefactor3.Name = "lblHrsSerCalefactor3";
            this.lblHrsSerCalefactor3.Size = new System.Drawing.Size(107, 30);
            this.lblHrsSerCalefactor3.TabIndex = 149;
            this.lblHrsSerCalefactor3.Text = "0";
            this.lblHrsSerCalefactor3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHrsSerUV2
            // 
            this.lblHrsSerUV2.BackColor = System.Drawing.Color.Black;
            this.lblHrsSerUV2.Font = new System.Drawing.Font("Handel Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsSerUV2.ForeColor = System.Drawing.Color.Snow;
            this.lblHrsSerUV2.Location = new System.Drawing.Point(370, 117);
            this.lblHrsSerUV2.Margin = new System.Windows.Forms.Padding(0);
            this.lblHrsSerUV2.Name = "lblHrsSerUV2";
            this.lblHrsSerUV2.Size = new System.Drawing.Size(107, 30);
            this.lblHrsSerUV2.TabIndex = 148;
            this.lblHrsSerUV2.Text = "0";
            this.lblHrsSerUV2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHrsSerMotor2
            // 
            this.lblHrsSerMotor2.BackColor = System.Drawing.Color.Black;
            this.lblHrsSerMotor2.Font = new System.Drawing.Font("Handel Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrsSerMotor2.ForeColor = System.Drawing.Color.Snow;
            this.lblHrsSerMotor2.Location = new System.Drawing.Point(370, 68);
            this.lblHrsSerMotor2.Margin = new System.Windows.Forms.Padding(0);
            this.lblHrsSerMotor2.Name = "lblHrsSerMotor2";
            this.lblHrsSerMotor2.Size = new System.Drawing.Size(107, 30);
            this.lblHrsSerMotor2.TabIndex = 147;
            this.lblHrsSerMotor2.Text = "0";
            this.lblHrsSerMotor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(79, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 19);
            this.label11.TabIndex = 146;
            this.label11.Text = "Horas servicio calefactor ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(79, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(218, 19);
            this.label12.TabIndex = 144;
            this.label12.Text = "Horas servicio motor ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Handel Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(79, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 19);
            this.label13.TabIndex = 145;
            this.label13.Text = "Horas servicio UV  ";
            // 
            // FrmMenuServicioTarj2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblServicio);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenuServicioTarj2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMenuServicioTarj2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Timer timerHrsFuncionamiento;
        private System.Windows.Forms.Timer timerSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHrsMaxMotor2;
        private System.Windows.Forms.Label lblHrsMaxUV2;
        private System.Windows.Forms.Label lblHrsMaxCalefactor2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHrsSerCalefactor3;
        private System.Windows.Forms.Label lblHrsSerUV2;
        private System.Windows.Forms.Label lblHrsSerMotor2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
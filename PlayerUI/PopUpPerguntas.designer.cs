﻿namespace PlayerUI
{
    partial class PopUpPerguntas
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
            this.button5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBoxPartidaRapida = new System.Windows.Forms.GroupBox();
            this.radioBtnDezPerguntas = new System.Windows.Forms.RadioButton();
            this.radioBtnVintePerguntas = new System.Windows.Forms.RadioButton();
            this.radioBtnCinquentaPerguntas = new System.Windows.Forms.RadioButton();
            this.groupBoxModoJogo = new System.Windows.Forms.GroupBox();
            this.groupBoxCarreira = new System.Windows.Forms.GroupBox();
            this.radioBtnTodas = new System.Windows.Forms.RadioButton();
            this.radioBtnPersonalizado = new System.Windows.Forms.RadioButton();
            this.textBoxPersonalizado = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBoxPartidaRapida.SuspendLayout();
            this.groupBoxModoJogo.SuspendLayout();
            this.groupBoxCarreira.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 14;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(90)))), ((int)(((byte)(204)))));
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.LightGray;
            this.button9.Location = new System.Drawing.Point(357, 302);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(153, 40);
            this.button9.TabIndex = 15;
            this.button9.Text = "COMEÇAR";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBoxPartidaRapida
            // 
            this.groupBoxPartidaRapida.Controls.Add(this.radioBtnCinquentaPerguntas);
            this.groupBoxPartidaRapida.Controls.Add(this.radioBtnVintePerguntas);
            this.groupBoxPartidaRapida.Controls.Add(this.radioBtnDezPerguntas);
            this.groupBoxPartidaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPartidaRapida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(90)))), ((int)(((byte)(204)))));
            this.groupBoxPartidaRapida.Location = new System.Drawing.Point(36, 152);
            this.groupBoxPartidaRapida.Name = "groupBoxPartidaRapida";
            this.groupBoxPartidaRapida.Size = new System.Drawing.Size(474, 100);
            this.groupBoxPartidaRapida.TabIndex = 16;
            this.groupBoxPartidaRapida.TabStop = false;
            this.groupBoxPartidaRapida.Text = "Partida Rápida";
            // 
            // radioBtnDezPerguntas
            // 
            this.radioBtnDezPerguntas.AutoSize = true;
            this.radioBtnDezPerguntas.Location = new System.Drawing.Point(16, 47);
            this.radioBtnDezPerguntas.Name = "radioBtnDezPerguntas";
            this.radioBtnDezPerguntas.Size = new System.Drawing.Size(134, 24);
            this.radioBtnDezPerguntas.TabIndex = 0;
            this.radioBtnDezPerguntas.TabStop = true;
            this.radioBtnDezPerguntas.Text = "10 Perguntas";
            this.radioBtnDezPerguntas.UseVisualStyleBackColor = true;
            // 
            // radioBtnVintePerguntas
            // 
            this.radioBtnVintePerguntas.AutoSize = true;
            this.radioBtnVintePerguntas.Location = new System.Drawing.Point(165, 47);
            this.radioBtnVintePerguntas.Name = "radioBtnVintePerguntas";
            this.radioBtnVintePerguntas.Size = new System.Drawing.Size(134, 24);
            this.radioBtnVintePerguntas.TabIndex = 1;
            this.radioBtnVintePerguntas.TabStop = true;
            this.radioBtnVintePerguntas.Text = "20 Perguntas";
            this.radioBtnVintePerguntas.UseVisualStyleBackColor = true;
            // 
            // radioBtnCinquentaPerguntas
            // 
            this.radioBtnCinquentaPerguntas.AutoSize = true;
            this.radioBtnCinquentaPerguntas.Location = new System.Drawing.Point(321, 47);
            this.radioBtnCinquentaPerguntas.Name = "radioBtnCinquentaPerguntas";
            this.radioBtnCinquentaPerguntas.Size = new System.Drawing.Size(134, 24);
            this.radioBtnCinquentaPerguntas.TabIndex = 2;
            this.radioBtnCinquentaPerguntas.TabStop = true;
            this.radioBtnCinquentaPerguntas.Text = "50 Perguntas";
            this.radioBtnCinquentaPerguntas.UseVisualStyleBackColor = true;
            // 
            // groupBoxModoJogo
            // 
            this.groupBoxModoJogo.Controls.Add(this.groupBox1);
            this.groupBoxModoJogo.Controls.Add(this.button9);
            this.groupBoxModoJogo.Controls.Add(this.groupBoxCarreira);
            this.groupBoxModoJogo.Controls.Add(this.groupBoxPartidaRapida);
            this.groupBoxModoJogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxModoJogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(90)))), ((int)(((byte)(204)))));
            this.groupBoxModoJogo.Location = new System.Drawing.Point(81, 33);
            this.groupBoxModoJogo.Name = "groupBoxModoJogo";
            this.groupBoxModoJogo.Size = new System.Drawing.Size(542, 419);
            this.groupBoxModoJogo.TabIndex = 17;
            this.groupBoxModoJogo.TabStop = false;
            this.groupBoxModoJogo.Text = "MODO DE JOGO";
            // 
            // groupBoxCarreira
            // 
            this.groupBoxCarreira.Controls.Add(this.textBoxPersonalizado);
            this.groupBoxCarreira.Controls.Add(this.radioBtnPersonalizado);
            this.groupBoxCarreira.Controls.Add(this.radioBtnTodas);
            this.groupBoxCarreira.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCarreira.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(90)))), ((int)(((byte)(204)))));
            this.groupBoxCarreira.Location = new System.Drawing.Point(36, 34);
            this.groupBoxCarreira.Name = "groupBoxCarreira";
            this.groupBoxCarreira.Size = new System.Drawing.Size(474, 100);
            this.groupBoxCarreira.TabIndex = 17;
            this.groupBoxCarreira.TabStop = false;
            this.groupBoxCarreira.Text = "Carreira";
            // 
            // radioBtnTodas
            // 
            this.radioBtnTodas.AutoSize = true;
            this.radioBtnTodas.Location = new System.Drawing.Point(16, 47);
            this.radioBtnTodas.Name = "radioBtnTodas";
            this.radioBtnTodas.Size = new System.Drawing.Size(76, 24);
            this.radioBtnTodas.TabIndex = 0;
            this.radioBtnTodas.TabStop = true;
            this.radioBtnTodas.Text = "Todas";
            this.radioBtnTodas.UseVisualStyleBackColor = true;
            // 
            // radioBtnPersonalizado
            // 
            this.radioBtnPersonalizado.AutoSize = true;
            this.radioBtnPersonalizado.Location = new System.Drawing.Point(165, 47);
            this.radioBtnPersonalizado.Name = "radioBtnPersonalizado";
            this.radioBtnPersonalizado.Size = new System.Drawing.Size(140, 24);
            this.radioBtnPersonalizado.TabIndex = 1;
            this.radioBtnPersonalizado.TabStop = true;
            this.radioBtnPersonalizado.Text = "Personalizado";
            this.radioBtnPersonalizado.UseVisualStyleBackColor = true;
            // 
            // textBoxPersonalizado
            // 
            this.textBoxPersonalizado.Location = new System.Drawing.Point(321, 46);
            this.textBoxPersonalizado.Name = "textBoxPersonalizado";
            this.textBoxPersonalizado.Size = new System.Drawing.Size(100, 26);
            this.textBoxPersonalizado.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(90)))), ((int)(((byte)(204)))));
            this.groupBox1.Location = new System.Drawing.Point(36, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Corrida";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 2;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 47);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tempo";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // PopUpPerguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(677, 464);
            this.Controls.Add(this.groupBoxModoJogo);
            this.Controls.Add(this.button5);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PopUpPerguntas";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBoxPartidaRapida.ResumeLayout(false);
            this.groupBoxPartidaRapida.PerformLayout();
            this.groupBoxModoJogo.ResumeLayout(false);
            this.groupBoxCarreira.ResumeLayout(false);
            this.groupBoxCarreira.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBoxPartidaRapida;
        private System.Windows.Forms.RadioButton radioBtnCinquentaPerguntas;
        private System.Windows.Forms.RadioButton radioBtnVintePerguntas;
        private System.Windows.Forms.RadioButton radioBtnDezPerguntas;
        private System.Windows.Forms.GroupBox groupBoxModoJogo;
        private System.Windows.Forms.GroupBox groupBoxCarreira;
        private System.Windows.Forms.RadioButton radioBtnTodas;
        private System.Windows.Forms.TextBox textBoxPersonalizado;
        private System.Windows.Forms.RadioButton radioBtnPersonalizado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
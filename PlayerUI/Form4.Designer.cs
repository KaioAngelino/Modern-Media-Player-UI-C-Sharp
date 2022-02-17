namespace PlayerUI
{
    partial class Form4
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelPergunta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPergunta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxEscolherResposta = new System.Windows.Forms.GroupBox();
            this.itemA = new System.Windows.Forms.RadioButton();
            this.itemB = new System.Windows.Forms.RadioButton();
            this.itemC = new System.Windows.Forms.RadioButton();
            this.itemD = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBiblia = new System.Windows.Forms.TextBox();
            this.btnCriarPergunta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxEscolherResposta.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(1, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 12;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1014, 517);
            this.dataGridView1.TabIndex = 11;
            // 
            // labelPergunta
            // 
            this.labelPergunta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPergunta.AutoSize = true;
            this.labelPergunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPergunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.labelPergunta.Location = new System.Drawing.Point(452, 9);
            this.labelPergunta.Name = "labelPergunta";
            this.labelPergunta.Size = new System.Drawing.Size(173, 25);
            this.labelPergunta.TabIndex = 10;
            this.labelPergunta.Text = "FORMULARIO X1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCriarPergunta);
            this.groupBox1.Controls.Add(this.txtBiblia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBoxEscolherResposta);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPergunta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 454);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nova Pergunta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Resposta: ";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(558, 200);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(240, 20);
            this.txtD.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Opção D:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(111, 200);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(240, 20);
            this.txtB.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Opção B:";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(559, 122);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(240, 20);
            this.txtC.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(450, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Opção C:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(112, 122);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(240, 20);
            this.txtA.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opção A:";
            // 
            // txtPergunta
            // 
            this.txtPergunta.Location = new System.Drawing.Point(112, 42);
            this.txtPergunta.Name = "txtPergunta";
            this.txtPergunta.Size = new System.Drawing.Size(689, 20);
            this.txtPergunta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pergunta:";
            // 
            // groupBoxEscolherResposta
            // 
            this.groupBoxEscolherResposta.Controls.Add(this.itemD);
            this.groupBoxEscolherResposta.Controls.Add(this.itemC);
            this.groupBoxEscolherResposta.Controls.Add(this.itemB);
            this.groupBoxEscolherResposta.Controls.Add(this.itemA);
            this.groupBoxEscolherResposta.Location = new System.Drawing.Point(112, 284);
            this.groupBoxEscolherResposta.Name = "groupBoxEscolherResposta";
            this.groupBoxEscolherResposta.Size = new System.Drawing.Size(230, 53);
            this.groupBoxEscolherResposta.TabIndex = 11;
            this.groupBoxEscolherResposta.TabStop = false;
            // 
            // itemA
            // 
            this.itemA.AutoSize = true;
            this.itemA.Location = new System.Drawing.Point(12, 20);
            this.itemA.Name = "itemA";
            this.itemA.Size = new System.Drawing.Size(33, 17);
            this.itemA.TabIndex = 0;
            this.itemA.TabStop = true;
            this.itemA.Text = "A";
            this.itemA.UseVisualStyleBackColor = true;
            // 
            // itemB
            // 
            this.itemB.AutoSize = true;
            this.itemB.Location = new System.Drawing.Point(74, 20);
            this.itemB.Name = "itemB";
            this.itemB.Size = new System.Drawing.Size(33, 17);
            this.itemB.TabIndex = 1;
            this.itemB.TabStop = true;
            this.itemB.Text = "B";
            this.itemB.UseVisualStyleBackColor = true;
            // 
            // itemC
            // 
            this.itemC.AutoSize = true;
            this.itemC.Location = new System.Drawing.Point(131, 20);
            this.itemC.Name = "itemC";
            this.itemC.Size = new System.Drawing.Size(33, 17);
            this.itemC.TabIndex = 2;
            this.itemC.TabStop = true;
            this.itemC.Text = "C";
            this.itemC.UseVisualStyleBackColor = true;
            // 
            // itemD
            // 
            this.itemD.AutoSize = true;
            this.itemD.Location = new System.Drawing.Point(185, 20);
            this.itemD.Name = "itemD";
            this.itemD.Size = new System.Drawing.Size(34, 17);
            this.itemD.TabIndex = 3;
            this.itemD.TabStop = true;
            this.itemD.Text = "D";
            this.itemD.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(440, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = " Texto da Bíblia: ";
            // 
            // txtBiblia
            // 
            this.txtBiblia.Location = new System.Drawing.Point(602, 301);
            this.txtBiblia.Name = "txtBiblia";
            this.txtBiblia.Size = new System.Drawing.Size(199, 20);
            this.txtBiblia.TabIndex = 13;
            // 
            // btnCriarPergunta
            // 
            this.btnCriarPergunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriarPergunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnCriarPergunta.FlatAppearance.BorderSize = 0;
            this.btnCriarPergunta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarPergunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarPergunta.ForeColor = System.Drawing.Color.LightGray;
            this.btnCriarPergunta.Location = new System.Drawing.Point(326, 379);
            this.btnCriarPergunta.Name = "btnCriarPergunta";
            this.btnCriarPergunta.Size = new System.Drawing.Size(150, 40);
            this.btnCriarPergunta.TabIndex = 14;
            this.btnCriarPergunta.Text = "Confirmar";
            this.btnCriarPergunta.UseVisualStyleBackColor = false;
            this.btnCriarPergunta.Click += new System.EventHandler(this.btnCriarPergunta_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1040, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelPergunta);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxEscolherResposta.ResumeLayout(false);
            this.groupBoxEscolherResposta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelPergunta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPergunta;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxEscolherResposta;
        private System.Windows.Forms.RadioButton itemA;
        private System.Windows.Forms.RadioButton itemC;
        private System.Windows.Forms.RadioButton itemB;
        private System.Windows.Forms.RadioButton itemD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBiblia;
        private System.Windows.Forms.Button btnCriarPergunta;
    }
}
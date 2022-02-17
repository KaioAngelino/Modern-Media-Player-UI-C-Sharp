using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form3 : Form
    {
        int totalPerguntas = 0;
        int totalAcertos = 0;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(int totalQuestoes, int totalAcertos)
        {
            InitializeComponent();


            this.totalPerguntas = totalQuestoes;
            this.totalAcertos = totalAcertos;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            popularTela();
        }

        private void popularTela()
        {
            quantidadePerguntas.Text = (this.totalPerguntas-1).ToString();
            labelTotalAcertos.Text = this.totalAcertos.ToString();
        }
    }
}

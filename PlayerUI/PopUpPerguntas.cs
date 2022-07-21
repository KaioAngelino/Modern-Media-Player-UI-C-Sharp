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
    public partial class PopUpPerguntas : Form
    {
        int totalPerguntas = 0;

        public PopUpPerguntas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            popularTela();
        }

        private void popularTela()
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

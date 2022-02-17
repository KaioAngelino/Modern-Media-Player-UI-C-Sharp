using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.JScript;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2 : Form
    {

        string pergunta = "";
        string alternativaA = "";
        string alternativaB = "";
        string alternativaC = "";
        string alternativaD = "";
        string resposta = "";
        string textoBiblia = "";

        int totalPerguntas = 0;
        int totalAcertos = 0;
        int perguntaAtual = 1;

        private OleDbConnection _olecon;
        private OleDbCommand _oleCmd;
        private static String _Arquivo = @"C:\File\Quiz.xlsx";
        private String _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _Arquivo);
        private String _Consulta;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lerQuestoes("1");
        }
        private void lerQuestoes(string questao)
        {
            limparTela();
            eliminaDuas(true);
            exibirQuestoes();



            try
            {
                _olecon = new OleDbConnection(_StringConexao);
                _olecon.Open();

                _oleCmd = new OleDbCommand();
                _oleCmd.Connection = _olecon;
                _oleCmd.CommandType = CommandType.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            buscarQuestao(questao);


            labelPergunta.Text = pergunta;
            radioAlternativaA.Text = alternativaA;
            radioAlternativaB.Text = alternativaB;
            radioAlternativaC.Text = alternativaC;
            radioAlternativaD.Text = alternativaD;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            atualizarTela();
        }

        private void atualizarTela()
        {
            var checkedButton = groupBoxAlternativas.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
            {
                if (checkedButton.Text == resposta)
                {
                    labelRespostaERRADA.Visible = false;
                    labelRespostaCERTA.Visible = true;

                    totalAcertos++;
                }
                else
                {
                    labelRespostaCERTA.Visible = false;
                    labelRespostaERRADA.Visible = true;
                }

                perguntaAtual++;

                if (perguntaAtual == totalPerguntas)
                {
                    Form3 form3 = new Form3(totalPerguntas, totalAcertos);
                    form3.Show();
                    this.Close();
                }
                else
                {
                    btnMenosDuas.Enabled = true;
                    btnResposta.Enabled = true;
                    btnVerNaBilbia.Enabled = true;
                    lerQuestoes(perguntaAtual.ToString());
                }
            }

        }

        private void limparTela()
        {
            labelRespostaCERTA.Visible = false;
            labelRespostaERRADA.Visible = false;

            var checkedButton = groupBoxAlternativas.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
            {
                checkedButton.Checked = false;
            }
        }

        private void btnResposta_Click(object sender, EventArgs e)
        {
            btnResposta.Enabled = false;
            verResposta();
        }

        private void verResposta()
        {
            limparTela();
            var respostasErradas = groupBoxAlternativas.Controls.OfType<RadioButton>().Where(r => r.Text != resposta);
            foreach (RadioButton r in respostasErradas)
            {
                r.Visible = false;
            }
            var respostaCerta = groupBoxAlternativas.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Text == resposta);
            respostaCerta.Checked = true;
        }

        private void exibirQuestoes()
        {
            limparTela();
            var respostasErradas = groupBoxAlternativas.Controls.OfType<RadioButton>().Where(r => r.Text != null);
            foreach (RadioButton r in respostasErradas)
            {
                r.Visible = true;
            }
        }

        private void buscarQuestao(string questao)
        {
            try
            {
                _oleCmd.CommandText = "SELECT * FROM [Questoes$] Where ID = " + questao;
                OleDbDataReader reader = _oleCmd.ExecuteReader();

                while (reader.Read())
                {
                    pergunta = reader.GetValue(1).ToString();
                    alternativaA = reader.GetValue(2).ToString();
                    alternativaB = reader.GetValue(3).ToString();
                    alternativaC = reader.GetValue(4).ToString();
                    alternativaD = reader.GetValue(5).ToString();
                    textoBiblia = reader.GetValue(6).ToString();
                    resposta = reader.GetValue(7).ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaDuas(bool visibilidade)
        {
            limparTela();

            var respostasErradas = groupBoxAlternativas.Controls.OfType<RadioButton>().Where(r => r.Text != resposta);
            List<RadioButton> eliminaDuas = new List<RadioButton>();
            eliminaDuas.Add(respostasErradas.ToList()[0]);
            eliminaDuas.Add(respostasErradas.ToList()[1]);
            foreach (RadioButton r in eliminaDuas)
            {
                r.Visible = visibilidade;
            }

        }

        private void btnMenosDuas_Click(object sender, EventArgs e)
        {
            btnMenosDuas.Enabled = false;
            eliminaDuas(false);
        }

        private void btnVerNaBilbia_Click(object sender, EventArgs e)
        {
            groupBoxVejaBiblia.Visible = true;
            txtVejaNaBiblia.Text = "Veja o(s) seguinte(s) texto(s): " + textoBiblia;
        }
    }
}

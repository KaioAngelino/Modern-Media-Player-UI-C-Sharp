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
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Convert = System.Convert;

namespace PlayerUI
{
    public partial class Perguntas : Form
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

        SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "database.db;Version=3", true);
        public Perguntas()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lerQuestoes("", true);
        }
        private void lerQuestoes(string questao, bool novoJogo)
        {
            limparTela();
            eliminaDuas(true);
            exibirQuestoes();

            buscarQuestao(questao, novoJogo);


            txtPergunta.Text = pergunta;
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
                    Resultado form3 = new Resultado(totalPerguntas, totalAcertos);
                    form3.Show();
                    this.Close();
                }
                else
                {
                    btnMenosDuas.Enabled = true;
                    btnResposta.Enabled = true;
                    btnVerNaBilbia.Enabled = true;
                    lerQuestoes(perguntaAtual.ToString(), false);
                }
                groupBoxVejaBiblia.Visible = false;
                txtVejaNaBiblia.Text = null;
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
            btnMenosDuas.Enabled = false;
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

        private void buscarQuestao(string questao, bool novoJogo)
        {

            DataTable dt = new DataTable();
            String sql = "SELECT * FROM Questao";

            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, sql_con);
                da.Fill(dt);

                DataRow row;
                if (novoJogo)
                {
                    row = dt.DefaultView.Table.Select().FirstOrDefault<DataRow>();
                }
                else
                {
                    row = (DataRow)dt.DefaultView.ToTable().Select().GetValue(Convert.ToInt32(questao)-1);
                }

                


                pergunta = row[1].ToString();
                alternativaA = row[2].ToString();
                alternativaB = row[3].ToString();
                alternativaC = row[4].ToString();
                alternativaD = row[5].ToString();
                textoBiblia = row[6].ToString();
                resposta = row[7].ToString();

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("O índice estava fora dos limites da matriz."))
                {
                    this.Close();
                    this.Dispose();
                    Resultado form3 = new Resultado(dt.DefaultView.Count, totalAcertos);

                    form3.Show();
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
            finally
            {
                if (sql_con.State == ConnectionState.Open)
                {
                    sql_con.Close();
                }
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
            btnVerNaBilbia.Enabled = false;
            groupBoxVejaBiblia.Visible = true;
            txtVejaNaBiblia.Text = "Veja o(s) seguinte(s) texto(s): " + textoBiblia;
        }

        private void radioAlternativaA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioAlternativaB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioAlternativaC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioAlternativaD_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

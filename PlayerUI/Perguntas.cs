using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
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
        int minutosCronometro = 0;
        TelaInicial telaInicial = null;

        Boolean confirmarResposta = false;
        Boolean isNovoJogo = true;

        SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\database.db;Version=3", true);
        string pathSoundLastSeconds = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "sound.wav";
        Stopwatch cronometro = new Stopwatch();

        string minutosTimer = "";
        string segundosTimer = "";
        DataTable dt = new DataTable();
        IEnumerable<DataRow> questoes;
        List<DataRow> listaQuestoes = new List<DataRow>();
        Random random = new Random();

        public Perguntas()
        {

            InitializeComponent();

            if (tmrCronometro != null)
            {
                this.minutosCronometro = 0;
                tmrCronometro.Stop();
            }
        }

        public Perguntas(TelaInicial telaInicial, int perguntas)
        {
            InitializeComponent();
            if (tmrCronometro != null)
            {
                this.minutosCronometro = 0;
                tmrCronometro.Stop();
            }
            this.telaInicial = telaInicial;
            totalPerguntas = perguntas;


        }
        public Perguntas(TelaInicial telaInicial, int perguntas, int minutosCronometro)
        {
            InitializeComponent();
            this.telaInicial = telaInicial;
            totalPerguntas = perguntas;
            this.minutosCronometro = minutosCronometro * 60;



            if (minutosCronometro > 0)
            {
                label1.Visible = true;

                tmrCronometro = new Timer();
                tmrCronometro.Tick += new EventHandler(count_down);
                tmrCronometro.Interval = 1000;
                tmrCronometro.Start();


                minutosTimer = (this.minutosCronometro / 60).ToString();
                segundosTimer = (this.minutosCronometro % 60).ToString();
                if (segundosTimer.Length == 1)
                {
                    segundosTimer = "0" + segundosTimer;
                }
                label1.Text = minutosTimer + " : " + segundosTimer;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            String sql = "SELECT * FROM Questao";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, sql_con);
            da.Fill(dt);

            lerQuestoes(isNovoJogo);

        }

        private void count_down(object sender, EventArgs e)
        {

            if (this.minutosCronometro == 0)
            {
                tmrCronometro.Stop();
                EncerrarJogo();

            }
            else if (this.minutosCronometro > 0)
            {
                if (this.minutosCronometro <= 60)
                {
                    label1.ForeColor = Color.Red;
                }
                if (this.minutosCronometro == 10)
                {
                    LastSecondsSound();
                }
                this.minutosCronometro--;
                minutosTimer = (this.minutosCronometro / 60).ToString();
                segundosTimer = (this.minutosCronometro % 60).ToString();
                if (segundosTimer.Length == 1)
                {
                    segundosTimer = "0" + segundosTimer;
                }
                label1.Text = minutosTimer + " : " + segundosTimer;
            }
        }
        private void lerQuestoes(bool novoJogo)
        {
            if (novoJogo)
            {
                if (totalPerguntas == 0)
                {
                    questoes = dt.DefaultView.Table.Rows.Cast<DataRow>().OrderBy(rand => random.Next()).Take(dt.DefaultView.Table.Rows.Count);
                }
                else
                {
                    questoes = dt.DefaultView.Table.Rows.Cast<DataRow>().OrderBy(rand => random.Next()).Take(totalPerguntas);
                }

                limparTela();
                listaQuestoes = questoes.ToList();

            }


            exibirEliminaDuas(true);
            exibirQuestoes();

            buscarQuestao();


            txtPergunta.Text = pergunta;
            radioAlternativaA.Text = alternativaA;
            radioAlternativaB.Text = alternativaB;
            radioAlternativaC.Text = alternativaC;
            radioAlternativaD.Text = alternativaD;

            AjustarTextoPergunta(); // Chamar a função para ajustar o texto corretamente

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            var checkedButton = groupBoxAlternativas.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Checked);

            if (checkedButton != null)
            {
                confirmarResposta = true;
                btnConfirmar.Enabled = false;
                if (checkedButton.Text == resposta)
                {
                    labelRespostaERRADA.Visible = false;
                    labelRespostaCERTA.Visible = true;

                    //totalAcertos++;
                }
                else
                {
                    labelRespostaCERTA.Visible = false;
                    labelRespostaERRADA.Visible = true;
                }


            }

        }

        private void atualizarTela()
        {

            if ((perguntaAtual - 1) == totalPerguntas)
            {
                EncerrarJogo();
            }
            else
            {
                btnMenosDuas.Enabled = true;
                btnResposta.Enabled = true;
                btnVerNaBilbia.Enabled = true;
                lerQuestoes(false);
            }
            groupBoxVejaBiblia.Visible = false;
            txtVejaNaBiblia.Text = null;


        }
        private void EncerrarJogo()
        {
            this.telaInicial.openChildForm(new Resultado(totalPerguntas, totalAcertos));

            this.Close();
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
            textoBiblia = "";
        }

        private void btnResposta_Click(object sender, EventArgs e)
        {
            btnMenosDuas.Enabled = false;
            btnResposta.Enabled = false;
            verResposta();

        }

        private void verResposta()
        {

            try
            {
                var respostasErradas = groupBoxAlternativas.Controls.OfType<RadioButton>().Where(r => r.Text != resposta);
                foreach (RadioButton r in respostasErradas)
                {
                    r.Visible = false;
                }
                var respostaCerta = groupBoxAlternativas.Controls.OfType<RadioButton>()
                                                      .FirstOrDefault(r => r.Text == resposta);
                respostaCerta.Checked = true;
                //limparTela();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Existe um erro nesta pergunta.  Verifique em [MINHAS PERGUNTAS]. \nLEMBRE-SE: Acentuação e Espaços em branco são levados em conta.");
            }
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

        private void buscarQuestao()
        {
            try
            {
                DataRow row;

                int index = random.Next(questoes.Count());



                row = (DataRow)questoes.ElementAt(index);

                pergunta = row[1].ToString();
                alternativaA = row[2].ToString();
                alternativaB = row[3].ToString();
                alternativaC = row[4].ToString();
                alternativaD = row[5].ToString();
                textoBiblia = row[6].ToString();
                resposta = row[7].ToString();

                questoes = questoes.Where(q => (!q.Equals(row))).ToList();

                perguntaAtual++;

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("O índice estava fora dos limites da matriz."))
                {
                    this.Close();
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

        private void exibirEliminaDuas(bool visibilidade)
        {
          //  limparTela();

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
            exibirEliminaDuas(false);
        }

        private void btnVerNaBilbia_Click(object sender, EventArgs e)
        {
            btnVerNaBilbia.Enabled = false;
            groupBoxVejaBiblia.Visible = true;
            txtVejaNaBiblia.Text = "Veja o(s) seguinte(s) texto(s): " + textoBiblia;
        }

        private void TmrCronometro_Tick(object sender, EventArgs e)
        {

            if (cronometro.Elapsed.Minutes < 10)
            {
                minutosTimer = "0" + cronometro.Elapsed.Minutes.ToString();
            }
            else
            {
                minutosTimer = cronometro.Elapsed.Minutes.ToString();
            }
            if (cronometro.Elapsed.Seconds < 10)
            {
                segundosTimer = "0" + cronometro.Elapsed.Seconds.ToString();
            }
            else
            {
                segundosTimer = cronometro.Elapsed.Seconds.ToString();
            }

        }

        private void LastSecondsSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(pathSoundLastSeconds);
            simpleSound.Play();
        }

        private void Avancar_Click(object sender, EventArgs e)
        {

            if (labelRespostaCERTA.Visible == true)
            {
                totalAcertos++;
                btnConfirmar.Enabled = true;
                confirmarResposta = false;
                atualizarTela();

            }
            else
            {
                if (labelRespostaERRADA.Visible == true)
                {
                    btnConfirmar.Enabled = true;
                    confirmarResposta = false;
                    atualizarTela();
                }
                if (!confirmarResposta)
                {
                    MessageBox.Show("Responda e Confirme essa questão antes de avançar.");
                }
                else
                {
                    btnConfirmar.Enabled = true;
                    confirmarResposta = false;
                    atualizarTela();
                }

            }
        }
        private void AjustarTextoPergunta()
        {
            int limiteCaracteres = 45; // Definir o limite baseado na referência

            // 1. Quebrar o texto corretamente
            string textoFormatado = QuebrarTexto(pergunta, limiteCaracteres);
            txtPergunta.Text = textoFormatado;

            // 2. Ajustar tamanho da fonte caso ultrapasse duas linhas
            using (Graphics g = txtPergunta.CreateGraphics())
            {
                SizeF tamanhoTexto = g.MeasureString(txtPergunta.Text, txtPergunta.Font);

                if (tamanhoTexto.Height > txtPergunta.Height) // Se ultrapassar o espaço
                {
                    txtPergunta.Font = new Font(txtPergunta.Font.FontFamily, txtPergunta.Font.Size - 2, FontStyle.Regular);
                }
            }
        }

        private string QuebrarTexto(string texto, int limite)
        {
            string[] palavras = texto.Split(' ');
            StringBuilder linhaAtual = new StringBuilder();
            StringBuilder resultado = new StringBuilder();
            int linhas = 0;

            foreach (string palavra in palavras)
            {
                if (linhaAtual.Length + palavra.Length + 1 > limite)
                {
                    resultado.AppendLine(linhaAtual.ToString().Trim());
                    linhaAtual.Clear();
                    linhas++;

                    if (linhas >= 2) // Limita a 2 linhas
                        break;
                }

                linhaAtual.Append(palavra + " ");
            }

            if (linhaAtual.Length > 0)
            {
                resultado.AppendLine(linhaAtual.ToString().Trim());
            }

            return resultado.ToString().Trim();
        }
    }

}

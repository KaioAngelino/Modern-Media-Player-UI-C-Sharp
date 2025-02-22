﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class PopUpPerguntas : Form
    {
        int totalPerguntas = 0;
        SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\database.db;Version=3", true);

        private List<RadioButton> listaRadioButtons = new List<RadioButton>();
        private TelaInicial telaInicial;


        public PopUpPerguntas()
        {
            InitializeComponent();

        }
        private void ExtractDatabaseIfNeeded()
        {
            string resourceName = "PlayerUI.database.db";  // Nome do recurso embutido no projeto
            string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string dbPath = Path.Combine(appDirectory, "database.db");

            // Verifica se o banco já foi extraído
            if (!File.Exists(dbPath))
            {
                // O banco de dados ainda não foi extraído, então extraímos
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("O banco de dados embutido não foi encontrado no projeto.");
                        return;
                    }

                    using (FileStream fileStream = new FileStream(dbPath, FileMode.Create, FileAccess.Write))
                    {
                        resourceStream.CopyTo(fileStream);
                    }

                    MessageBox.Show("Banco de dados extraído com sucesso!");
                }
            }

            // Após a extração, podemos conectar ao banco de dados
            string connectionString = $"Data Source={dbPath};Version=3;";
            sql_con = new SQLiteConnection(connectionString);
        }

        public PopUpPerguntas(TelaInicial telaInicial, Color themeColor)
        {
            this.telaInicial = telaInicial;

            InitializeComponent();
            this.BackColor = themeColor;
            groupBox1.BackColor = themeColor;
            groupBoxCarreira.BackColor = themeColor;
            groupBoxModoJogo.BackColor = themeColor;
            groupBoxPartidaRapida.BackColor = themeColor;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            // Verifica e extrai o banco de dados embutido, se necessário
            ExtractDatabaseIfNeeded();
            BuscarTotalPerguntas();
            GerenciarRadioButtons();

        }

        private void GerenciarRadioButtons()
        {
            listaRadioButtons.Add(radioBtnTodas);
            listaRadioButtons.Add(radioBtnPersonalizado);
            listaRadioButtons.Add(radioBtnDezPerguntas);
            listaRadioButtons.Add(radioBtnVintePerguntas);
            listaRadioButtons.Add(radioBtnCinquentaPerguntas);
            listaRadioButtons.Add(radioBtnTempo);

            foreach (var radio in listaRadioButtons)
            {
                radio.CheckedChanged -= GerenciarRadioButtonExclusivo;
                radio.CheckedChanged += GerenciarRadioButtonExclusivo;
            }
        }

        private void GerenciarRadioButtonExclusivo(object sender, EventArgs e)
        {
            RadioButton senderRadio = (RadioButton)sender;
            if (!senderRadio.Checked)
            {
                return;
            }
            foreach (var radio in listaRadioButtons)
            {
                if (radio == sender || !radio.Checked)
                {
                    continue;
                }
                radio.Checked = false;
            }
        }

        private void BuscarTotalPerguntas()
        {
            DataTable dt = new DataTable();
            String sql = "SELECT * FROM Questao";

            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, sql_con);
                da.Fill(dt);


                totalPerguntas = dt.DefaultView.Count;
                lblTotalPerguntasCount.Text = totalPerguntas.ToString();

                ControleElementos(totalPerguntas);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);

            }
            finally
            {
                if (sql_con.State == ConnectionState.Open)
                {
                    sql_con.Close();
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Perguntas formPerguntas = null;
            RadioButton radioBtn = listaRadioButtons
                                          .Where(x => x.Checked).FirstOrDefault();
            if (radioBtn != null)
            {
                switch (radioBtn.Name)
                {
                    case "radioBtnTodas":
                        formPerguntas = new Perguntas(telaInicial, totalPerguntas);
                        break;
                    case "radioBtnPersonalizado":
                        if (textBoxPersonalizado.Value > totalPerguntas)
                        {
                            MessageBox.Show("Total de perguntas informado é maior que o número de perguntas cadastradas");
                        }
                        else
                        {
                            formPerguntas = new Perguntas(telaInicial, Convert.ToInt32(textBoxPersonalizado.Value));
                        }
                        break;
                    case "radioBtnDezPerguntas":
                        if (10 > totalPerguntas)
                        {
                            MessageBox.Show("Total de perguntas informado é maior que o número de perguntas cadastradas");
                        }
                        else
                        {
                            formPerguntas = new Perguntas(telaInicial, 10);
                        }
                        break;
                    case "radioBtnVintePerguntas":
                        if (20 > totalPerguntas)
                        {
                            MessageBox.Show("Total de perguntas informado é maior que o número de perguntas cadastradas");
                        }
                        else
                        {
                            formPerguntas = new Perguntas(telaInicial, 20);
                        }
                        break;
                    case "radioBtnCinquentaPerguntas":
                        if (50 > totalPerguntas)
                        {
                            MessageBox.Show("Total de perguntas informado é maior que o número de perguntas cadastradas");
                        }
                        else
                        {
                            formPerguntas = new Perguntas(telaInicial, 50);
                        }
                        break;
                    default:
                        if (numericPerguntasCorrida.Value > totalPerguntas)
                        {
                            MessageBox.Show("Total de perguntas informado é maior que o número de perguntas cadastradas");
                        }
                        else
                        {
                            formPerguntas = new Perguntas(telaInicial, Convert.ToInt32(numericPerguntasCorrida.Value));
                        }
                        break;


                }

                telaInicial.openChildForm(formPerguntas);
            }
            else
            {
                if (numericPerguntasCorrida.Value > 0 && totalMinutos.Value > 0)
                {
                    formPerguntas = new Perguntas(telaInicial, Convert.ToInt32(numericPerguntasCorrida.Value), Convert.ToInt32(totalMinutos.Value));
                    telaInicial.openChildForm(formPerguntas);
                }
            }


        }
        private void ControleElementos(int totalPerguntas)
        {

            if (totalPerguntas > 0)
            {
                radioBtnTodas.Text = totalPerguntas + " Perguntas";
            }

            if (totalPerguntas < 10)
            {
                groupBoxPartidaRapida.Enabled = false;
            }
            else
            {
                if (totalPerguntas < 20)
                {
                    radioBtnVintePerguntas.Enabled = false;
                    radioBtnCinquentaPerguntas.Enabled = false;
                }
                else
                {
                    if (totalPerguntas < 50)
                    {
                        radioBtnCinquentaPerguntas.Enabled = false;
                    }
                }
            }

            if (radioBtnTempo.Checked)
            {
                totalMinutos.Controls[0].Enabled = false;
            }
            else
            {
                totalMinutos.Controls[0].Enabled = true;
            }
        }
    }
}

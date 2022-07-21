using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        private SQLiteConnection _sqliteCon;
        private SQLiteCommand _sqliteCmd;
        SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "database.db;Version=3", true);
        private String _Consulta;
        private List<RadioButton> listaRadioButtons = new List<RadioButton>();
        private TelaInicial telaInicial;

        public PopUpPerguntas()
        {
            InitializeComponent();
        }

        public PopUpPerguntas(TelaInicial telaInicial)
        {
            this.telaInicial = telaInicial;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
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
                        formPerguntas = new Perguntas(telaInicial, Convert.ToInt32(textBoxPersonalizado.Value));
                        break;
                    case "radioBtnDezPerguntas":
                        formPerguntas = new Perguntas(telaInicial, 10);
                        break;
                    case "radioBtnVintePerguntas":
                        formPerguntas = new Perguntas(telaInicial, 20);
                        break;
                    case "radioBtnCinquentaPerguntas":
                        formPerguntas = new Perguntas(telaInicial, 50);
                        break;
                    default:
                        formPerguntas = new Perguntas(telaInicial, Convert.ToInt32(numericPerguntasCorrida.Value));
                        break;


                }

                telaInicial.openChildForm(formPerguntas);
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

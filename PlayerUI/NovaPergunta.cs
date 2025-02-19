using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PlayerUI
{
    public partial class NovaPergunta : Form
    {
        SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\database.db;Version=3", true);
        private SQLiteConnection _sqliteCon;
        private SQLiteCommand _sqliteCmd;
        private String _Consulta;

        public NovaPergunta()
        {
            InitializeComponent();

        }

        private void btnCriarPergunta_Click(object sender, EventArgs e)
        {


            try
            {
                _sqliteCon = new SQLiteConnection(sql_con.ConnectionString);
                _sqliteCmd = new SQLiteCommand();
                _sqliteCmd.Connection = _sqliteCon;



                _sqliteCmd.CommandType = CommandType.Text;
                var checkedButton = groupBoxEscolherResposta.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Checked);
                if (checkedButton != null)
                {
                    if (!AnyValueIsNull(txtPergunta.Text, txtA.Text, txtC.Text, txtB.Text, txtD.Text, txtBiblia.Text))
                    {
                        _sqliteCon.Open();

                        _Consulta = "INSERT INTO QUESTAO (" +
                                                "PERGUNTA, ALTERNATIVA_A, ALTERNATIVA_B," +
                                                " ALTERNATIVA_C, ALTERNATIVA_D, TEXTO_BIBLICO, RESPOSTA)" +
                                                " VALUES ";
                        _Consulta += "(@PERGUNTA, @A, @B, @C, @D, @TEXTO, @RESPOSTA)";
                        _sqliteCmd.CommandText = _Consulta;

                        _sqliteCmd.Parameters.Add("@PERGUNTA", DbType.String).Value = txtPergunta.Text.ToUpper();
                        _sqliteCmd.Parameters.Add("@A", DbType.String).Value = txtA.Text.ToUpper();
                        _sqliteCmd.Parameters.Add("@B", DbType.String).Value = txtC.Text.ToUpper();
                        _sqliteCmd.Parameters.Add("@C", DbType.String).Value = txtB.Text.ToUpper();
                        _sqliteCmd.Parameters.Add("@D", DbType.String).Value = txtD.Text.ToUpper();
                        _sqliteCmd.Parameters.Add("@TEXTO", DbType.String).Value = txtBiblia.Text.ToUpper();
                        _sqliteCmd.Parameters.Add("@RESPOSTA", DbType.String, 255).Value = GetResposta();
                        _sqliteCmd.ExecuteNonQuery();

                        _sqliteCmd.Parameters.Clear();

                        txtPergunta.ResetText();
                        txtA.ResetText();
                        txtC.ResetText();
                        txtB.ResetText();
                        txtD.ResetText();
                        txtBiblia.ResetText();


                        checkedButton.Checked = false;


                        _sqliteCmd.Parameters.Clear();
                        _sqliteCon.Close();
                        _sqliteCon.Dispose();

                        MessageBox.Show("Pergunta Cadastrada.");
                    }



                }
            }
            catch (Exception ex)
            {
                txtPergunta.ResetText();
                txtA.ResetText();
                txtC.ResetText();
                txtB.ResetText();
                txtD.ResetText();
                txtBiblia.ResetText();
                var checkedButton = groupBoxEscolherResposta.Controls.OfType<RadioButton>()
                                                 .FirstOrDefault(r => r.Checked);
                if (checkedButton != null)
                {
                    checkedButton.Checked = false;
                }

                _sqliteCmd.Parameters.Clear();
                _sqliteCon.Close();
                _sqliteCon.Dispose();
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetResposta()
        {
            var checkedButton = groupBoxEscolherResposta.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
            {
                string itemResposta = checkedButton.Text;
                switch (itemResposta)
                {
                    case "A":
                        return txtA.Text;
                    case "B":
                        return txtB.Text;
                    case "C":
                        return txtC.Text;
                    case "D":
                        return txtD.Text;
                    default: return null;
                }
                //                return checkedButton.Text;
            }
            return null;
        }

        public static bool AnyValueIsNull(params string[] itens)
        {

            foreach (string str in itens)
            {
                if (String.IsNullOrEmpty(str) && String.IsNullOrWhiteSpace(str))
                {
                    return true;
                }
            }
            return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

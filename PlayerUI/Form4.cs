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

namespace PlayerUI
{
    public partial class Form4 : Form
    {
        private OleDbConnection _olecon;
        private OleDbConnection _olecon2;
        private OleDbCommand _oleCmd;
        private OleDbCommand _oleCmd2;
        private static String _Arquivo = @"C:\File\QUIZ.xlsx";
        private String _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _Arquivo);
        private String _Consulta;

        public Form4()
        {
            InitializeComponent();

        }

        private void btnCriarPergunta_Click(object sender, EventArgs e)
        {
            try
            {
                _olecon = new OleDbConnection(_StringConexao);
                _olecon.Open();

                _oleCmd = new OleDbCommand();
                _oleCmd.Connection = _olecon;
                _oleCmd.CommandType = CommandType.Text;

                _Consulta = "INSERT INTO [Questoes$] ";
                _Consulta += "([ID],[PERGUNTA],[A], [B], [C], [D], [TEXTO], [RESPOSTA] ) ";
                _Consulta += "VALUES ";
                _Consulta += "(@ID, @PERGUNTA, @A, @B, @C, @D, @TEXTO, @RESPOSTA)";

                _oleCmd.CommandText = _Consulta;
                _oleCmd.Parameters.Add("@ID", OleDbType.Integer).Value = getProximaPergunta();
                _oleCmd.Parameters.Add("@PERGUNTA", OleDbType.VarChar, 255).Value = txtPergunta.Text;
                _oleCmd.Parameters.Add("@A", OleDbType.VarChar, 255).Value = txtA.Text;
                _oleCmd.Parameters.Add("@B", OleDbType.VarChar, 255).Value = txtB.Text;
                _oleCmd.Parameters.Add("@C", OleDbType.VarChar, 255).Value = txtC.Text;
                _oleCmd.Parameters.Add("@D", OleDbType.VarChar, 255).Value = txtD.Text;
                _oleCmd.Parameters.Add("@TEXTO", OleDbType.VarChar, 255).Value = txtBiblia.Text;
                _oleCmd.Parameters.Add("@RESPOSTA", OleDbType.VarChar, 255).Value = GetResposta();
                _oleCmd.ExecuteNonQuery();

                _oleCmd.Parameters.Clear();

                txtPergunta.ResetText();
                txtA.ResetText();
                txtB.ResetText();
                txtC.ResetText();
                txtD.ResetText();
                txtBiblia.ResetText();

                MessageBox.Show("Dados Incluídos...");

                if (_oleCmd != null)
                {
                    _oleCmd.Parameters.Clear();
                    _oleCmd.Dispose();
                }
                _oleCmd = null;

                if (_olecon != null)
                {
                    if (_olecon.State == ConnectionState.Open)
                        _olecon.Close();
                    _olecon.Dispose();
                }
                _olecon = null;

                //------------------

                if (_oleCmd2 != null)
                {
                    _oleCmd2.Parameters.Clear();
                    _oleCmd2.Dispose();
                }
                _oleCmd2 = null;

                if (_olecon2 != null)
                {
                    if (_olecon2.State == ConnectionState.Open)
                        _olecon2.Close();
                    _olecon2.Dispose();
                }
                _olecon2 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*try
            {
                _oleCmd.CommandText = "SELECT PERGUNTA, A FROM[Questoes$] Where id = 1";
                OleDbDataReader reader = _oleCmd.ExecuteReader();

                while (reader.Read())
                {
                    txtPergunta.Text = reader.GetString(0);
                    txtA.Text = reader.GetString(1);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public string GetResposta()
        {
            var checkedButton = groupBoxEscolherResposta.Controls.OfType<RadioButton>()
                                                  .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
            {
                return checkedButton.Text;
            }
            return null;
        }

        public int getProximaPergunta()
        {
            _olecon2 = new OleDbConnection(_StringConexao);
            _olecon2.Open();

            _oleCmd2 = new OleDbCommand();
            _oleCmd2.Connection = _olecon2;
            _oleCmd2.CommandType = CommandType.Text;

            _oleCmd2.CommandText = "SELECT COUNT(*) FROM [Questoes$]";
            int count = Convert.ToInt32(_oleCmd2.ExecuteScalar().ToString());
            _oleCmd2.Parameters.Clear();
            _olecon2.Close();
            return count + 1;
        }

    }
}

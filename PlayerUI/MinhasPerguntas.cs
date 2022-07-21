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

namespace PlayerUI
{
    public partial class MinhasPerguntas : Form
    {
        private SQLiteConnection _sqliteCon;
        private SQLiteCommand _sqliteCmd;
        SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "database.db;Version=3", true);
        private String _Consulta;
        private List<string> idsExistentes;
        private List<string> idsSalvar;
        public MinhasPerguntas()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            idsExistentes = new List<string>();
            idsSalvar = new List<string>();
            try
            {

                //busca os dados na base SQLite
                DataTable dt = CarregarDados();



                dataGridView1.DataSource = dt.DefaultView;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderCell.Value = dataGridView1.Columns[i].HeaderCell.Value.ToString().Replace("ALTERNATIVA", "");
                    dataGridView1.Columns[i].HeaderCell.Value = dataGridView1.Columns[i].HeaderCell.Value.ToString().Replace("_", " ");
                }

                // Print the value one column of each DataRow.
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    idsExistentes.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                }
                //ajusta a largura das colunas aos dados

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                DataRow row = dt.NewRow();
                row["ALTERNATIVA_A"] = null;
                row["ALTERNATIVA_B"] = null;
                row["ALTERNATIVA_C"] = null;
                row["ALTERNATIVA_D"] = null;
                row["TEXTO_BIBLICO"] = null;
                row["RESPOSTA"] = null;

                dt.Rows.Add(row);

                dataGridView1.Columns[0].Visible = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
        }

        private DataTable CarregarDados()
        {
            DataTable dt = new DataTable();
            String sql = "SELECT * FROM Questao";

            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, sql_con);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
                return null;
            }
            finally
            {
                if (sql_con.State == ConnectionState.Open)
                {
                    sql_con.Close();
                }
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _sqliteCon = new SQLiteConnection(sql_con.ConnectionString);
            _sqliteCmd = new SQLiteCommand();
            _sqliteCmd.Connection = _sqliteCon;

            _sqliteCon.Open();
            try
            {
                // Print the value one column of each DataRow.
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    idsSalvar.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                }
                var differences = idsExistentes.Except(idsSalvar);
                int total = differences.ToList().Count();
                if (total > 0)
                {
                    foreach (var id in differences.ToList())
                    {
                        _sqliteCmd.Parameters.Clear();
                        _Consulta = "DELETE FROM Questao WHERE ID = @ID";
                        _sqliteCmd.Parameters.Add("@ID", DbType.Int32).Value = Convert.ToInt32(id);
                        _sqliteCmd.CommandText = _Consulta;
                        _sqliteCmd.ExecuteNonQuery();
                        _sqliteCmd.Parameters.Clear();
                    }


                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!AnyValueIsNull(row.Cells["PERGUNTA"].Value, row.Cells["ALTERNATIVA_A"].Value, row.Cells["ALTERNATIVA_B"].Value, row.Cells["ALTERNATIVA_C"].Value,
                        row.Cells["ALTERNATIVA_D"].Value, row.Cells["TEXTO_BIBLICO"].Value, row.Cells["RESPOSTA"].Value))
                    {
                        if (AnyValueIsNull(row.Cells["ID"].Value))
                        {
                            _Consulta = "INSERT INTO QUESTAO (" +
                                                    "PERGUNTA, ALTERNATIVA_A, ALTERNATIVA_B," +
                                                    " ALTERNATIVA_C, ALTERNATIVA_D, TEXTO_BIBLICO, RESPOSTA)" +
                                                    " VALUES ";
                            _Consulta += "(@PERGUNTA, @A, @B, @C, @D, @TEXTO, @RESPOSTA)";
                            _sqliteCmd.CommandText = _Consulta;

                            _sqliteCmd.Parameters.Add("@PERGUNTA", DbType.String).Value = row.Cells["PERGUNTA"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@A", DbType.String).Value = row.Cells["ALTERNATIVA_A"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@B", DbType.String).Value = row.Cells["ALTERNATIVA_B"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@C", DbType.String).Value = row.Cells["ALTERNATIVA_C"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@D", DbType.String).Value = row.Cells["ALTERNATIVA_D"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@TEXTO", DbType.String).Value = row.Cells["TEXTO_BIBLICO"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@RESPOSTA", DbType.String).Value = row.Cells["RESPOSTA"].Value.ToString().ToUpper();
                            _sqliteCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            _sqliteCmd.Parameters.Clear();
                            _Consulta = "UPDATE QUESTAO ";
                            _Consulta += "SET PERGUNTA = upper(@PERGUNTA), ";
                            _Consulta += "ALTERNATIVA_A = upper(@A), ";
                            _Consulta += "ALTERNATIVA_B = upper(@B), ";
                            _Consulta += "ALTERNATIVA_C = upper(@C), ";
                            _Consulta += "ALTERNATIVA_D = upper(@D), ";
                            _Consulta += "TEXTO_BIBLICO = upper(@TEXTO), ";
                            _Consulta += "RESPOSTA = upper(@RESPOSTA) ";
                            _Consulta += "WHERE ";
                            _Consulta += "ID = @ID";
                            _sqliteCmd.CommandText = _Consulta;


                            _sqliteCmd.Parameters.Add("@PERGUNTA", DbType.String).Value = row.Cells["PERGUNTA"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@A", DbType.String).Value = row.Cells["ALTERNATIVA_A"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@B", DbType.String).Value = row.Cells["ALTERNATIVA_B"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@C", DbType.String).Value = row.Cells["ALTERNATIVA_C"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@D", DbType.String).Value = row.Cells["ALTERNATIVA_D"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@TEXTO", DbType.String).Value = row.Cells["TEXTO_BIBLICO"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@RESPOSTA", DbType.String).Value = row.Cells["RESPOSTA"].Value.ToString().ToUpper();
                            _sqliteCmd.Parameters.Add("@ID", DbType.Int32).Value = Convert.ToInt32(row.Cells["ID"].Value.ToString().ToUpper());
                            _sqliteCmd.ExecuteNonQuery();
                            _sqliteCmd.Parameters.Clear();
                        }

                    }


                }
                _sqliteCmd.Parameters.Clear();
                _sqliteCon.Close();
                _sqliteCon.Dispose();

                Form5_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
            }

        }
        public static bool AnyValueIsNull(params object[] itens)
        {

            foreach (object str in itens)
            {
                if (String.IsNullOrEmpty(str.ToString()) && String.IsNullOrWhiteSpace(str.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }

}

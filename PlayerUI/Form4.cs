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
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form4 : Form
    {
        int totalPerguntas = 0;

        public Form4()
        {
            InitializeComponent();

        }

        private void btnCriarPergunta_Click(object sender, EventArgs e)
        {
            FileStream fStream = File.Open(@"C:\File\Quiz.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
            DataSet resultDataSet = excelDataReader.AsDataSet();
            excelDataReader.Close();

            totalPerguntas = resultDataSet.Tables[0].Rows.Count;

            DataRow dr = resultDataSet.Tables[0].NewRow();
            dr[0] = txtPergunta.Text.ToUpper();
            resultDataSet.Tables[0].Rows.Add(dr);
            /*resultDataSet.Tables[0].Rows[totalPerguntas][1] = txtA.Text.ToUpper();// = Alternativa A
            resultDataSet.Tables[0].Rows[totalPerguntas][2] = txtB.Text.ToUpper();// = Alternativa B
            resultDataSet.Tables[0].Rows[totalPerguntas][3] = txtC.Text.ToUpper();// = Alternativa C
            resultDataSet.Tables[0].Rows[totalPerguntas][4] = txtD.Text.ToUpper();// = Alternativa D
            resultDataSet.Tables[0].Rows[totalPerguntas][5] = txtBiblia.Text.ToUpper();// = texto dica
            resultDataSet.Tables[0].Rows[totalPerguntas][6] = GetResposta();// = resposta*/

            SaveExcel(resultDataSet);
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

        public void SaveExcel(DataSet dataSet)
        {
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(@"C:\File\Quiz2.xlsx", SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

            foreach (DataTable table in dataSet.Tables)
            {
                UInt32Value sheetCount = 0;
                sheetCount++;

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = sheetCount, Name = table.TableName };
                sheets.AppendChild(sheet);

                Row headerRow = new Row();

                List<string> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row();
                    foreach (String col in columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

            }
            workbookPart.Workbook.Save();
        }
    }
}

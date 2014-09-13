using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dictionary
{
    public partial class NoDictionaryDetected : Form
    {
        private static string dictionaryFileTypes = "Excel|*.xlsx";
        public NoDictionaryDetected()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Globals.ThisAddIn.LoadDictionary();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = dictionaryFileTypes;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Globals.ThisAddIn.ExcelApplication = new Excel.Application();
                Globals.ThisAddIn.theWorkbook = Globals.ThisAddIn.ExcelApplication.Workbooks.Add();
                Globals.ThisAddIn.theWorkbook.SaveAs(dialog.FileName);
                Globals.ThisAddIn.dict = new DictionaryData(Globals.ThisAddIn.ExcelApplication);
                Globals.ThisAddIn.LoadTranslatePane();
                Globals.ThisAddIn.myTip.Visible = true;
                this.Close();
            }
        }
    }
}

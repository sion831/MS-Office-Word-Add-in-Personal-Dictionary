using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;
using System.IO;

namespace Dictionary
{
    public partial class ThisAddIn
    {
        private bool translateEnabled;
        private Microsoft.Office.Tools.CustomTaskPane translatePane;
        public TranslationPane myTip;
        public DictionaryData dict;
        public Excel.Workbook theWorkbook;
        public Excel.Application ExcelApplication;
        public string currentText;
        private static string dictionaryFileTypes = "Excel|*.xls;*.xlsx";

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WindowSelectionChange+=new Word.ApplicationEvents4_WindowSelectionChangeEventHandler(Application_WindowSelectionChange);
            this.Application.DocumentChange+=new Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);
            //LoadTranslatePane();
        }

        void Application_DocumentChange()
        {

            LoadTranslatePane();
        }

        public void LoadDictionary()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = dictionaryFileTypes;
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String path = openFileDialog.FileName;
                Excel.Application ExcelApplication = new Excel.Application();
                try
                {
                    theWorkbook = ExcelApplication.Workbooks.Open(path, 0, false, 5,
                    "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                }
                catch(Exception e){
                    return;
                }
                if (theWorkbook._CodeName.Equals("MEUSDictionary"))
                {

                }
                else
                {
                    dict = new DictionaryData(ExcelApplication);
                    LoadTranslatePane();
                    myTip.Visible = true;
                }
            }
        }


        public void LoadTranslatePane()
        {
            if (translatePane != null)
            {
                myTip.dictionary = dict;
                this.CustomTaskPanes.Remove(translatePane);
            }

            myTip = new TranslationPane(dict);
            translatePane = this.CustomTaskPanes.Add(myTip, "translatePane");
            translatePane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionFloating;
            translatePane.Width = 410;
            translatePane.Height = 450;
            //translatePane.DockPositionChanged += new EventHandler(translatePane_DockPositionChanged);
        }

        //void translatePane_DockPositionChanged(object sender, EventArgs e)
        //{
        //    Office.MsoCTPDockPosition currentPosition = ((Microsoft.Office.Tools.CustomTaskPane)sender).DockPosition;
        //    if (currentPosition == Office.MsoCTPDockPosition.msoCTPDockPositionRight ||
        //        currentPosition == Office.MsoCTPDockPosition.msoCTPDockPositionLeft)
        //    {
        //        ((Microsoft.Office.Tools.CustomTaskPane)sender).Width = 415;
        //    }
        //}

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if(theWorkbook!=null)
                theWorkbook.Close();
        }

        internal void setTranslateFlag(bool value)
        {
            translateEnabled = value;
            if (translateEnabled)
            {
                translatePane.Visible = true;
            }
            else
            {
                translatePane.Visible = false;
            }

        }

        internal void closeDictionaryPane()
        {
            translatePane.Visible = false;
        }



        void Application_WindowSelectionChange(Word.Selection Sel)
        {
            if (translateEnabled)
            {
                //bool exists = false;
                //if (dict != null)
                //{
                //    foreach (DictionaryData.Group group in dict.dictionary)
                //    {
                //        foreach (WordData word in group.wordList)
                //        {
                //            if (word.Equals(Sel.Text))
                //            {
                //                myTip.LoadWordData(word);
                //                exists = true;
                //                break;
                //            }
                //        }
                //    }
                //}
                //if (!exists)
                //{
                //    myTip.LoadWordData(null);
                //    string str = Sel.Text;
                //    str = str.Replace(System.Environment.NewLine,"");
                //    ((TextBox)myTip.Controls["WordName"]).Text = str;
                //}
                int i = 1;
                int rangeLength = 40 - Sel.Text.Length;
                string next40char = "";
                Word.Range range;
                while (i <= rangeLength && rangeLength>=1)
                {
                    range = Sel.Next(Word.WdUnits.wdCharacter, i++);
                    if (range == null)
                        break;
                    next40char += range.Text;
                }

                string str = Sel.Text + next40char.Trim();
                //str = str.Replace(System.Environment.NewLine, "");
                currentText = str;
                ((TextBox)myTip.Controls["WordName"]).Text = str;
            }
        }



        // For future's possible new comparing method
        //private int CompareText(string text1, string text2)
        //{
        //    return text1.CompareTo(text2);
        //}


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

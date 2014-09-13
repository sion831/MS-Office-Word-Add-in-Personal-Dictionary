using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace Dictionary
{
    public partial class TranslationPane : UserControl
    {

        private DictionaryData dictionaryData;

        public TranslationPane(DictionaryData data)
        {
            InitializeComponent();
            if (data != null)
            {
                dictionaryData = data;
                Group_ComboBox.Items.AddRange(dictionaryData.Groups.ToArray());
                WordList.Items.AddRange(dictionaryData.GetWordList());
            }
        }


        public DictionaryData dictionary
        {
            set
            {
                dictionaryData = value;
            }
            get
            {
                return dictionaryData;
            }
        }

        public static WordData.WordType getTypeByString(string type)
        {
            switch (type)
            {

                case "noun":
                    return WordData.WordType.noun;
                case "verb":
                    return WordData.WordType.verb;
                case "adj":
                    return WordData.WordType.adj;
                case "adv":
                    return WordData.WordType.adv;
                case "phrase":
                    return WordData.WordType.phrase;
                case "other":
                    return WordData.WordType.other;
                default :
                    return WordData.WordType.noun;
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (WordList.SelectedItem != null &&
                    WordComboBox.Text.CompareTo(WordList.SelectedItem.ToString()) == 0)
            {
                string sCaption = "Save Changes?";
                string sMessageBoxText;
                bool GroupChanged = false;
                bool NewGroup = false;
                if (Group_ComboBox.SelectedItem == null && Group_ComboBox.Text.Length>0)
                {
                    sMessageBoxText = "Creating a new group:" + Group_ComboBox.Text;
                    NewGroup = true;
                }
                else if (Group_ComboBox.SelectedItem.ToString() != ((WordData)WordList.SelectedItem).Group)
                {
                    sMessageBoxText = "Group has been changed";
                    GroupChanged = true;
                }
                else
                {
                    sMessageBoxText = "Changes are irreversible";
                }
                MessageBoxButtons btnMessageBox = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon icnMessageBox = MessageBoxIcon.Warning;
                DialogResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                switch (rsltMessageBox)
                {
                    case DialogResult.Yes:
                        if (GroupChanged)
                        {
                            Excel.Range wordCell = null;
                            foreach (Excel.Worksheet tempsheet in dictionary.excelObj.Sheets)
                            {
                                Excel.Range temp = tempsheet.Cells.Find(WordComboBox.Text);
                                if (temp != null)
                                {
                                    wordCell = temp;
                                    break;
                                }
                            }
                            if (wordCell != null)
                            {
                                Excel.Range wordRow = wordCell.EntireRow;
                                wordRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                            }
                            Excel.Worksheet sheet = dictionary.excelObj.Sheets[Group_ComboBox.SelectedItem];
                            WordData newWord = (WordData)WordList.SelectedItem;
                            dictionary.RemoveWord(newWord);
                            newWord.word = ((WordData)WordList.SelectedItem).ToString();
                            newWord.definition = Definition.Text as string;
                            newWord.type = getSelectedType();
                            newWord.Group = Group_ComboBox.SelectedItem as string;
                            dictionary.AddWord(newWord);
                            WordList.SelectedItem = newWord;
                        }
                        else if (NewGroup)
                        {
                            Excel.Range wordCell = null;
                            foreach(Excel.Worksheet sheet in dictionary.excelObj.Sheets){
                                Excel.Range temp = sheet.Cells.Find(WordComboBox.Text);
                                if (temp != null)
                                {
                                    wordCell = temp;
                                    break;
                                }
                            }
                            if (wordCell != null)
                            {
                                Excel.Range wordRow = wordCell.EntireRow;
                                wordRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                            }
                            WordData newWord = (WordData)WordList.SelectedItem;
                            newWord.Group = Group_ComboBox.Text;
                            dictionaryData.Groups.Add(Group_ComboBox.Text);
                            Group_ComboBox.Items.Add(Group_ComboBox.Text);
                            dictionary.AddWord(newWord);
                        }
                        else
                        {
                            ((WordData)WordList.SelectedItem).type = getSelectedType();
                            ((WordData)WordList.SelectedItem).definition = Definition.Text;
                            Excel.Range wordCell = null;
                            foreach (Excel.Worksheet tempsheet in dictionary.excelObj.Sheets)
                            {
                                Excel.Range temp = tempsheet.Cells.Find(WordComboBox.Text);
                                if (temp != null)
                                {
                                    wordCell = temp;
                                    break;
                                }
                            }
                            Excel.Range wordRow = wordCell.EntireRow;
                            Object[,] value2 = wordRow.Value2;
                            value2[1, 2] = Definition.Text;
                            value2[1, 3] = TypeComboBox.SelectedItem.ToString();
                            wordRow.Value2 = value2;
                            dictionary.excelObj.ActiveWorkbook.Save();
                        }
                        break;

                    case DialogResult.No:
                        /* ... */
                        break;

                    case DialogResult.Cancel:
                        /* ... */
                        break;
                }
            }
        }

        private WordData.WordType getSelectedType()
        {
            if (this.TypeComboBox.SelectedItem != null)
            {
                return getTypeByString(this.TypeComboBox.SelectedItem.ToString());
            }
            return WordData.WordType.noun;
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            WordData newWord = new WordData();
            newWord.word = WordName.Text.Trim() ;
            if (dictionaryData != null)
            {
                Tuple<bool, List<WordData>> findResult = dictionary.Contains(newWord);
                if (findResult.Item1 && 
                    findResult.Item2[findResult.Item2.Count - 1].word.Length >= newWord.word.Length)
                {
                    WordList.SelectedItem = findResult.Item2;
                    MessageBox.Show("Word Already Exist!");
                    return;
                }
                if (isAllSpace(WordName.Text))
                {
                    MessageBox.Show("No word detected!");
                }
                else
                {
                    newWord.definition = Definition.Text as string;
                    newWord.type = getSelectedType();
                    newWord.Group = Group_ComboBox.SelectedItem as string;
                    if (newWord.Group == null)
                    {
                        newWord.Group = Group_ComboBox.Text;
                        List<WordData> wordlist = new List<WordData>();
                        dictionaryData.Groups.Add(Group_ComboBox.Text);
                        Group_ComboBox.Items.Add(Group_ComboBox.Text);
                    }
                    if (newWord.Group == null || newWord.Group == "")
                    {
                        newWord.Group = Group_ComboBox.Items[0].ToString();
                    }
                    dictionary.AddWord(newWord);
                    WordList.Items.Add(newWord);
                    WordList.SelectedItem = newWord;

                }
            }
            else
            {
                NoDictionaryDetected nddWindow = new NoDictionaryDetected();
                nddWindow.ShowDialog();
                nddWindow.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private bool isAllSpace(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                    return false;
            }
            return true;
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            WordData temp = (WordData)WordList.SelectedItem;
            if (temp != null)
            {
                dictionary.RemoveWord(temp);
                WordList.Items.Remove(temp);
                LoadWordData(null);
                DeleteWordFromExcel(temp);
            }
        }

        private void DeleteWordFromExcel(WordData word)
        {
            Excel.Range wordCell = null;
            foreach (Excel.Worksheet sheet in dictionary.excelObj.Sheets)
            {
                Excel.Range temp = sheet.Cells.Find(word.word);
                if (temp != null)
                {
                    wordCell = temp;
                    break;
                }
            }
            if (wordCell != null)
            {
                Excel.Range wordRow = wordCell.EntireRow;
                wordRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.closeDictionaryPane();
        }

        private void WordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WordData temp = (WordData)WordList.SelectedItem;
            LoadWordData(temp);
        }

        public void LoadWordData(WordData data)
        {
            if (data != null)
            {
                WordComboBox.Text = data.word;
                Definition.Text = data.definition;
                Group_ComboBox.SelectedItem = data.Group;
                TypeComboBox.SelectedItem = data.type.ToString();
            }
            else
            {
                Definition.Text = "";
                Group_ComboBox.SelectedItem = null;
                TypeComboBox.SelectedItem = null;
            }
        }

        private void WordName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WordData newWord = new WordData();
                newWord.word = WordName.Text.Trim();
                Tuple<bool, List<WordData>> findResult = dictionary.Contains(newWord);
                if (findResult.Item1)
                {
                    WordData selectedWord = findResult.Item2[0];
                    if (WordName.Text.Trim().Length > findResult.Item2[findResult.Item2.Count-1].word.Length)
                    {
                        LoadWordData(null);
                        WordName.Text = Globals.ThisAddIn.Application.Selection.Text;
                        WordList.SelectedItem = null;
                    }
                    else
                    {
                        LoadWordData(findResult.Item2[0]);
                        WordList.SelectedItem = findResult.Item2;
                    }
                    WordComboBox.Items.Clear();
                    foreach (WordData word in findResult.Item2)
                    {
                        if (word.word.Length >= Globals.ThisAddIn.Application.Selection.Text.Trim().Length)
                        {
                            WordComboBox.Items.Add(word);
                        }

                    }
                    if (WordComboBox.Items.Count > 0)
                    {
                        WordComboBox.SelectedIndex = 0;
                    }
                }
                else
                {
                    WordList.SelectedItem = null;
                    LoadWordData(null);
                    WordComboBox.Text = "";
                    WordComboBox.Items.Clear();
                    if (Globals.ThisAddIn.currentText == WordName.Text)
                    {
                        WordName.Text = Globals.ThisAddIn.Application.Selection.Text;
                    }
                }
            }
            catch(NullReferenceException ee)
            {
                NoDictionaryDetected nddWindow = new NoDictionaryDetected();
                nddWindow.ShowDialog();
                nddWindow.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void Group_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WordComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWordData(WordComboBox.SelectedItem as WordData);
            WordList.SelectedItem = WordComboBox.SelectedItem;
        }

    }
}

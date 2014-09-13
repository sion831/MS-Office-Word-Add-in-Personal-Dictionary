using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dictionary
{
    public class DictionaryData
    {
        //public List<Group> dictionary;
        private TrieNode TrieRoot;

        public Excel.Application excelObj;
        public List<string> Groups;


        public DictionaryData(Excel.Application excelObj)
        {
            this.excelObj = excelObj;
            Groups = new List<string>();
            TrieRoot = new TrieNode();
            foreach(Excel.Worksheet sheet in excelObj.Sheets )
            {
                Excel.Range cells = sheet.UsedRange;
                Groups.Add(sheet.Name);
                foreach (Excel.Range row in cells.Rows)
                {
                    row.NumberFormat = "@";
                    Object[,] thisrow = row.Value2;
                    
                    WordData newWord = new WordData();
                    try
                    {
                        newWord.word = thisrow[1, 1] as string;
                        if (newWord.word == "")
                            continue;
                        TrieRoot.AddWord(newWord); // Add the word here because a word may have only the name, without definition or type.
                        newWord.Group = sheet.Name;
                        newWord.definition = thisrow[1, 2] as string;
                        newWord.type = TranslationPane.getTypeByString(thisrow[1, 3] as string);
                    }
                    catch (Exception e) { }
                }
                //dictionary.Add(myGroup);
            }


            //Now we are going to make the trie for quick reference
            
        }

        public Tuple<bool,List<WordData>> Contains(WordData newWord)
        {
            //foreach (DictionaryData.Group group in dictionary)
            //{
            //    foreach (WordData word in group.wordList)
            //    {
            //        if (word.CompareTo(newWord) == 0)
            //        {
            //            return new Tuple<bool,WordData>(true,word);
            //        }
            //    }
            //}
            List<WordData> foundNodes = TrieRoot.FindWord(newWord);

            return new Tuple<bool, List<WordData>>(foundNodes.Count != 0, foundNodes);
        }

        public WordData RemoveWord(WordData word)
        {
            //foreach (DictionaryData.Group group in dictionary)
            //{
            //    if (group.groupName == word.Group)
            //    {
            //        group.wordList.Remove(word);
            //    }
            //}

            return TrieRoot.RemoveWord(word);
        }

        public void AddWord(WordData word)
        {
            TrieRoot.AddWord(word);
            Excel.Worksheet currentSheet;
            try
            {
                currentSheet = excelObj.Sheets[word.Group];
            }
            catch
            {
                excelObj.Sheets.Add(Type.Missing,excelObj.Sheets[excelObj.Sheets.Count]);
                Excel.Worksheet newSheet = excelObj.Sheets[excelObj.Sheets.Count];
                newSheet.Name = word.Group;
                currentSheet = newSheet;
            }
            Excel.Range last = currentSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            currentSheet.Cells[last.Row + 1, 1] = word.word;
            currentSheet.Cells[last.Row + 1, 2] = word.definition;
            currentSheet.Cells[last.Row + 1, 3] = word.type.ToString();
            excelObj.ActiveWorkbook.Save();
        }

        public WordData[] GetWordList()
        {
            TrieNode currentNode = TrieRoot;
            List<WordData> myWordList = new List<WordData>();
            Queue<TrieNode> myQ = new Queue<TrieNode>();
            myQ.Enqueue(currentNode);
            while(myQ.Count>0){
                TrieNode tempNode = myQ.Dequeue();
                if(tempNode.Word!=null)
                {
                    myWordList.Add(tempNode.Word);
                }
                foreach (TrieNode node in tempNode.SubList)
                {
                    myQ.Enqueue(node);
                }
            }
            return myWordList.ToArray();
        }
    }
}

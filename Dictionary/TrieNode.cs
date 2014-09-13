using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    public class TrieNode
    {
        public Char Key;
        public WordData Word;  //The last character of this.Word should be equal to this.Key.
        public List<TrieNode> SubList;
        //public TrieNode Parent;

        public TrieNode()
        {
            SubList = new List<TrieNode>();
        }

        public void AddWord(WordData word)
        {
            TrieNode currentNode = this;
            foreach (char character in word.word)
            {
                currentNode = FindNode(currentNode.SubList,character);
            }
            currentNode.Word = word;
        }

        private TrieNode FindNode(List<TrieNode> list,  char character)
        {
            foreach (TrieNode node in list)
            {
                if (character == node.Key)
                    return node;
            }
            TrieNode newNode = new TrieNode();
            newNode.Key = character;
            list.Add(newNode);
            return newNode;
        }


        public List<WordData> FindWord(WordData word)
        {
            List<WordData> wordList = new List<WordData>();
            TrieNode currentNode = this;
            foreach (char character in word.word)
            {
                bool exist = false;
                foreach (TrieNode node in currentNode.SubList)
                {
                    if (character == node.Key)
                    {
                        currentNode = node;
                        if (currentNode.Word != null)
                        {
                            wordList.Add(currentNode.Word);
                        }
                        exist = true;
                    }
                }
                if (!exist)
                    return wordList;
            }
            return wordList;
        }

        public WordData RemoveWord(WordData word)
        {
            TrieNode currentNode = this;
            foreach (char character in word.word)
            {
                bool exist = false;
                foreach (TrieNode node in currentNode.SubList)
                {
                    if (character == node.Key)
                    {
                        currentNode = node;
                        exist = true;
                    }
                }
                if (!exist)
                    return null;
            }
            WordData removedWord = currentNode.Word;
            currentNode.Word = null;
            return removedWord;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    public class WordData : IComparable
    {
        private string _word;
        public string word
        {
            set
            {
                if (value == null)
                    _word = "";
                else
                    _word = value;
            }
            get
            {
                return _word;
            }
        }

        private string _definition;
        public string definition
        {
            set
            {
                if (value == null)
                    _definition = "";
                else
                    _definition = value;
            }
            get
            {
                return _definition;
            }
        }

        //private List<string> 
        public enum WordType { noun, verb, adj, adv, phrase, other };
        public WordType type;
        public string Group;
        public int CompareTo(Object obj){
            if(obj == null)
                return 1;
            if(obj is WordData)
                return word.CompareTo(((WordData)obj).word);
            throw new ArgumentException("The type of argument is not WordData");
        }

        public override string ToString()
        {
            return word;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is WordData)
            {
                if (((WordData)obj).word.Equals(this.word))
                    return true;
                return false;
            }
            return false;
            
        }

        public override int GetHashCode()
        {
            return word.GetHashCode();
        }

    }
}

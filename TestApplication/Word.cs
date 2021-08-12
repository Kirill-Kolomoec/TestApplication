using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication
{
    class Word
    {
        public string wordValue;
        public List<int> Indexes;
        public Word(string word, int Index)
        {
            wordValue = word;
            Indexes = new List<int>();
            Indexes.Add(Index);
        }

        public void AddIndex(int Index)
        {
            Indexes.Add(Index);
        }

    }
}

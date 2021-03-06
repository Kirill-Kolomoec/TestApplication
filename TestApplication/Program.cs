using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
             
            List<Word> Words = new List<Word>();
            //ввод названия файла с консоли
            Console.Write("Enter name of file - ");
            try
            {
                //считывание с файла
                using (StreamReader sr = new StreamReader(Console.ReadLine(), Encoding.Default))
                {
                    string line;
                     
                    for (int index = 1; ((line = sr.ReadLine()) != null); index++)
                    {
                        //удаление лишних символов
                        line = new string(line.Where(t => char.IsLetterOrDigit(t) || char.IsWhiteSpace(t)).ToArray());
                        //разделение слов
                        foreach (var item in line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var FindWord = (Words.Find(x => item.ToLower() == x.wordValue.ToLower()));
                            if (FindWord != null)
                            {
                                FindWord.AddIndex(index);
                            }
                            else
                            {
                                Words.Add(new Word(item.ToLower(), index));
                            }
                        }
                    }
                }


            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }

            //запись в файл
            using (StreamWriter file = new StreamWriter("result.txt", false, Encoding.Default))
            {
                foreach (var word in Words.OrderBy(u => u.wordValue))
                {
                    file.Write(word.wordValue + " ");
                    foreach (var Index in word.Indexes.Distinct())
                    {
                        file.Write(Index + " ");
                    }
                    file.WriteLine();
                }
            }
        }

        
    }




}

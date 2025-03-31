using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prakt15_rep
{
    class Predmet
    {
        public int number_page;
        public string words;
        Dictionary<int, string> page;

        public Predmet(Dictionary<int, string> pages, string searchWord)
        {
            page = pages;
            words = searchWord;
        }

        public string Search()
        {

            for (int i = 0; i < page.Count; i++)
            {
                var pageValue = page.ElementAt(i);

                string[] words_in_page = pageValue.Value.Split(' ');

                for (int y = 0; y < words_in_page.Length; y++)
                {
                    if (words_in_page[y] == words)
                    {
                        number_page = pageValue.Key;
                        return $"Слово найдено на странице {number_page}";
                    }
                }
            }
            return "Такого слова нет в тексте";
        }
    }

}


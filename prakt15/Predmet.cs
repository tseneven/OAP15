using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt15
{
    class Predmet
    {
        public int number_page;
        public string words;
        public Dictionary<int, string> page;

        // Метод поиска слова на каждой странице
        public string Search() 
        {
            for(int i = 0; i < page.Count; i++)
            {
                var pageValue = page.ElementAt(i);

                string[] words_in_page = pageValue.Value.Split(' ');

                for(int y = 0; y < words_in_page.Length; y++)
                {
                    if(words_in_page[i] == words)
                    {
                        number_page = pageValue.Key;
                        return $"Слово на странице {number_page}" ;
                    }
                }
            }
            return "Такого слова нету в тексте";
        }
    }
}

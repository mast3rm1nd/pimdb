using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace pimdb
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMDb imdb = new IMDb("The Godfather", true);
            if (args.Length != 1)
            {
                var help = "";

                help += "Использование: pimdb \"название_видеопродукта\"" + Environment.NewLine + Environment.NewLine;
                help += "Например: pimdb \"побег из шоушенка\"" + Environment.NewLine;

                Console.Write(help);

                return;
            }

            //var test1 = IMDBHelper.GetInfoByTitle("hackers");

            //var test2 = new IMDb("hackers");
            //var test3 = new IMDb("хакеры");

            var info = new IMDb(args[0]);

            if(!info.status)
            {
                Console.WriteLine(string.Format("Нет информации по \"{0}\"" + Environment.NewLine, args[0]));

                return;
            }

            var output = "";

            output += "Название:  " + info.Title + Environment.NewLine;
            output += "Год:       " + info.Year + Environment.NewLine;
            if(info.Genres.Count != 0)
            {
                if (info.Genres.Count == 1)
            output += "Жанр:      " + info.Genres[0] + Environment.NewLine;
                else
            output += "Жанры:     " + string.Join(", ", (String[])info.Genres.ToArray(typeof(string))) + Environment.NewLine;
            }
            output += "Описание:  " + info.Plot + Environment.NewLine;

            output += "Рейтинг:   " + info.Rating + Environment.NewLine;

            Console.WriteLine(output);

            //Console.ReadLine();
        }


        //static string GetHtmlByURL(string url)
        //{
        //    using (var browser = new WebClient())
        //    {
        //        Stream data = browser.OpenRead(url);
        //        StreamReader reader = new StreamReader(data);
        //        var html = reader.ReadToEnd();

        //        return html;
        //    }
        //}

        //static string GetInfoByTitle(string title)
        //{
        //    //http://www.imdb.com/search/title?title=the%20shawshank%20redemption&title_type=feature,tv_movie,tv_series,tv_episode,tv_special,mini_series,documentary,short,video

        //    var html = GetHtmlByURL("http://www.imdb.com/search/title?title=" + title + "&title_type=feature,tv_movie,tv_series,tv_episode,tv_special,mini_series,documentary,short,video");
        //}
    }
}

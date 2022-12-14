using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите строку: ");
                string a = Console.ReadLine();
                Console.Write("Введите кол-во часов: ");
                int n = Convert.ToInt32(Console.ReadLine());
                string reg = @"\d{2}:\d{2}";
                Regex regex = new Regex(reg);
                MatchCollection matches = regex.Matches(a);
                for (int i = 0; i < matches.Count; i++)
                {
                    string[] hhss = matches[i].Value.Split(':');
                    int hh = Convert.ToInt32(hhss[0]);
                    int mm = Convert.ToInt32(hhss[1]);
                    if (hh >= 0 && hh < 24 && mm >= 0 && mm < 60)
                    {
                        if (n > 24) n %= 24;
                        var time = new TimeSpan(hh, mm, 0).Add(new TimeSpan(-n, 0, 0));
                        string timer = Convert.ToString(time) + ":" + mm.ToString();
                        a = Regex.Replace(a, matches[i].Value, time.ToString(@"hh\:mm"));
                    }
                }

                Console.WriteLine(a);
            }
            catch { Console.WriteLine("Некорректный ввод данных!!!"); }
            Console.ReadKey();
        }
    }
}

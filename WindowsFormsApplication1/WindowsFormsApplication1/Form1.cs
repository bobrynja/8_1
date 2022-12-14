using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox1.Text;
                int n = Convert.ToInt32(textBox3.Text);
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

                textBox2.Text = a;
                //foreach (Match item in matches) { Console.WriteLine(item.ToString()); }
            }
            catch { MessageBox.Show("Некорректный ввод данных!!!"); }
        }
    }
}

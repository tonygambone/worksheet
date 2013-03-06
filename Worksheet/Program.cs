using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // number that fit on one page when printed from Chrome
                int problemCount = 48;

                var sb = new StringBuilder();
                var bonds = NumberBond.GetRandomNumberBondProblems().GetEnumerator();
                for (int i = 0; i < problemCount; i++)
                {
                    if (bonds.MoveNext())
                    {
                        var b = bonds.Current;
                        sb.AppendFormat("<div><div>{0}</div><div>{1}</div><div>{2}</div><div></div></div>\r\n",
                            b.Sum, b.Addend1, b.Addend2);
                    }
                }

                string content;
                using (var reader = new StreamReader("template.html"))
                {
                    content = reader.ReadToEnd();                    
                }
                content = content.Replace("<!--#BONDS#-->", sb.ToString());
                using (var writer = new StreamWriter("out.html"))
                {
                    writer.Write(content);
                }
                Process.Start("out.html");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}

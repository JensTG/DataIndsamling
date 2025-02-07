using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIndsamling
{
    internal class DAL
    {
        static string personPath = @"Persons.txt";
        static string dataPath = @"Data.txt";
        static void AddText(string[] Person, string[] Data)
        {
            using (StreamWriter swc = File.AppendText(personPath))
            {
                swc.WriteLine("{0},{1},{2},{3}", Person[0], Person[1], Person[2], Person[3]);
                swc.Close();
            }
            using (StreamWriter swc = File.AppendText(dataPath))
            {
                foreach (string svar in Data)
                {
                    swc.WriteLine("{0},{1}");
                 }
                swc.Close();
            }

        }

        static string ReadData(int index)
        {
            using (StreamReader sr = File.OpenText(personPath))
            {
                string s;
                List<string> Data = new List<string>();
                while ((s = sr.ReadLine()) != null)
                {
                    string[] subs = s.Split(',');
                    chart1.Series["Brugere"].Points.AddXY(Convert.ToString(subs[1]), Convert.ToInt16(subs[0]));
                }

            }


        }
}

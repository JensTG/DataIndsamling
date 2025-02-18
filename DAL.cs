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

        static void AddText(string[] PersonList, string[] DataList)
        {
            string dataPath = "@" + PersonList[0] + ".txt";

            using (StreamWriter swc = File.AppendText(personPath))
            {
                swc.WriteLine("{0},{1},{2},{3}", PersonList[0], PersonList[1], PersonList[2], PersonList[3]);
                swc.Close();
            }

            using (StreamWriter swc = File.AppendText(dataPath))
            {
                foreach (string svar in DataList)
                {
                    string[] subs = svar.Split(',');
                    swc.WriteLine("{0},{1}", subs[0], subs[1]);
                }
                swc.Close();
            }

        }

        static List<string> ReadData(string cpr)
        {
            string dataPath = "@" + cpr + ".txt";
            using (StreamReader sr = File.OpenText(dataPath))
            {
                List<string> Data = new List<string>();
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] subs = s.Split(',');
                    Data.Add(subs[1]);
                }
                return Data;
            }
        }

        static List<string> ReadPerson(string cpr)
        {
            using (StreamReader sr = File.OpenText(personPath))
            {
                List<string> Person = new List<string>();
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] subs = s.Split(',');
                    if (subs[0]==cpr)
                    {
                        for (int i=0;i<subs.Length;i++)
                        Person.Add(subs[i]);
                    }
                    
                }
                return Person;
            }
        }

        static void UpdateData(string cpr)
        {
            List<string> data = ReadData(cpr);
            string dataPath = "@" + cpr + ".txt";

            

        }

        static void DeleteData(string cpr)
        {
            string dataPath = "@" + cpr + ".txt";
            File.Delete(dataPath);
            
                
            
        }
    }
}

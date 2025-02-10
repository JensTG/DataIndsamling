﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIndsamling
{
    internal class DAL
    {
        static string personPath = @"Persons.txt";

        static void AddText()
        {

            Person person1 = new Person();
            string[] PersonList = person1.EksporterVærdier();

            string dataPath = "@" + PersonList[0] + ".txt";
            using (StreamWriter swc = File.AppendText(personPath))
            {

                swc.WriteLine("{0},{1},{2},{3}", PersonList[0], PersonList[1], PersonList[2], PersonList[3]);
                swc.Close();
            }
            using (StreamWriter swc = File.AppendText(dataPath))
            {
                string[] data = person1.EksporterData();

                foreach (string svar in data)
                {
                    string[] subs = svar.Split(',');
                    swc.WriteLine("{0},{1}", subs[0], subs[1]);
                }
                swc.Close();
            }

        }

        static List<string> ReadData(int index)
        {
            string dataPath = "@" + index + ".txt";
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

        static List<string> ReadPersons(int index)
        {
            using (StreamReader sr = File.OpenText(personPath))
            {
                List<string> Persons = new List<string>();
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] subs = s.Split(',');
                    Persons.Add(subs[1]);
                }
                return Persons;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIndsamling
{
    public class Person
    {
        // Basale værdier
        string CPR; // Indekser, string er nemmere at arbejde med
        int tlf_nr;
        string adresse;
        string navn;

        // Svar på spm
        List<string> Data = new List<string>();

        public Person()
        {

        }

        // Eksporterer Data, i formatet "#,Svar", hvor # er spm's indeks og Svar er svaret på dette
        public string[] EksporterData()
        {
            List<string> resultat = new List<string>();
            for (int i = 0; i < Data.Count; i++)
                resultat.Add(i + Data[i]);
        }

        // Eksporterer alt andet end Data, som et array, hvor hver værdi er sin egen string
        public string[] EksporterVærdier()
        {

        }
    } 
    public class BL
    {
        List<Person> personer = new List<Person>();

        public Person[] ReturnerAllePersoner()
        {
            return personer.ToArray();
        }
    }
}

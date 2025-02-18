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
        string tlf_nr;
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
                resultat.Add(i + ',' + Data[i]);
            return resultat.ToArray();
        }

        // Eksporterer alt andet end Data, som et array, hvor hver værdi er sin egen string
        public string[] EksporterVærdier()
        {
            string[] resultat = { CPR, tlf_nr, adresse, navn };
            return resultat;
        }

        // Returnerer svaret på et givent spørgsmål
        public string ReturnerSvar(int spm)
        {
            if (spm < Data.Count && spm > 0)
                return Data[spm];
            return null;
        }
    }
    public class BL
    {
        List<Person> personer = new List<Person>();

        public Person[] ReturnerAllePersoner()
        {
            return personer.ToArray();
        }

        // Returnerer personen med det pågældende CPR nr
        public Person ReturnerFraCPR(string CPR)
        {
            try
            {
                Person resultat =
                    (
                        from person in personer
                        where person.EksporterData()[0] == CPR
                        select person
                    ).ToArray()[0];
                return resultat;
            } catch
            {
                return null;
            }
        }

        // Returnerer personer som har svaret på et specifikt spørgsmål, (evt. på en vis måde)
        public Person[] ReturnerFraSvar(int spm, string svar = "")
        {
            Person[] resultat =
                (
                    from person in personer
                    where person.ReturnerSvar(spm) != null && (svar == "" || svar == person.ReturnerSvar(spm))
                    select person
                ).ToArray();
            return resultat;
        }
    }
}

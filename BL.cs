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

		public Person(string CPR)
		{
			this.CPR = CPR;
			tlf_nr = "";
			adresse = "";
			navn = "";
		}

		// Rediger værdier, eller skriv null, for ikke at ændre dem
		public void Opdater(string CPR = null, string tlf_nr = null, string adresse = null, string navn = null)
		{
			this.CPR = CPR == null ? this.CPR : CPR;
			this.tlf_nr = tlf_nr == null ? this.tlf_nr : tlf_nr;
			this.adresse = adresse == null ? this.adresse : adresse;
			this.navn = navn == null ? this.navn : navn;
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

	// Static fordi der kun skal være et BusinessLag
	static public class BL
	{
		// personer.Last() burde altid returnere den nuværende person
		static List<Person> personer = new List<Person>();

		static public Person[] ReturnerAllePersoner()
		{
			return personer.ToArray();
		}

		// Returnerer personen med det pågældende CPR nr
		static public Person ReturnerFraCPR(string CPR)
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
		static public Person[] ReturnerFraSvar(int spm, string svar = "")
		{
			Person[] resultat =
				(
					from person in personer
					where person.ReturnerSvar(spm) != null && (svar == "" || svar == person.ReturnerSvar(spm))
					select person
				).ToArray();
			return resultat;
		}

		// True, hvis det er en admin
		static public bool LogInd(string værdi)
		{
			if (værdi == "admin")
				return true;
			ReturnerFraCPR()
			personer.Add(new Person(værdi));
			return false;
		}
	}
}

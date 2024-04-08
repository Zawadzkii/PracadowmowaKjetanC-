using System;
using System.Collections.Generic;
using System.Globalization;

class Produkt
{
	public string Nazwa { get; set; }
	public double Cena { get; set; }

	public Produkt(string nazwa, double cena)
	{
		Nazwa = nazwa;
		Cena = cena;
	}
}

class ListaZakupow
{
	public string NazwaListy { get; set; }
	public List<Produkt> Produkty { get; set; }

	public ListaZakupow(string nazwaListy)
	{
		NazwaListy = nazwaListy;
		Produkty = new List<Produkt>();
	}

	public void DodajProdukt()
	{
		Console.Write("Nazwa produktu: ");
		string nazwa = Console.ReadLine();

		double cena;
		while (true)
		{
			Console.Write("Cena produktu: ");
			CultureInfo cultureInfo = new CultureInfo("pl-PL");
			if (double.TryParse(Console.ReadLine(), NumberStyles.Any, cultureInfo, out cena) && cena >= 0)
			{
				break;
			}
			else
			{
				Console.WriteLine("Błędna cena. Podaj liczbę dodatnią.");
			}
		}

		string sformatowanaCena = string.Format(new CultureInfo("pl-PL"), "{0:0.00}", cena);

		Produkty.Add(new Produkt(nazwa, cena));
		Console.WriteLine($"Dodano produkt '{nazwa}' o cenie {sformatowanaCena} zł do listy zakupów '{NazwaListy}'.");


		//Ta klasa ListaZakupow zawiera pole NazwaListy przechowujące nazwę listy zakupów oraz listę Produkty,która przechowuje produkty na tej liście. Metoda DodajProdukt() pozwala na dodawanie nowych produktów do listy zakupów.
	}


	public void UsunProdukt()
	{
		Console.Write("Podaj numer produktu do usunięcia: ");
		if (int.TryParse(Console.ReadLine(), out int indeks) && indeks >= 1 && indeks <= Produkty.Count)
		{
			Produkt produkt = Produkty[indeks - 1];
			Produkty.RemoveAt(indeks - 1);
			Console.WriteLine($"Usunięto produkt '{produkt.Nazwa}' z listy zakupów '{NazwaListy}'.");
		}
		else
		{
			Console.WriteLine("Niepoprawny numer produktu.");
		}
	}

	public void WyswietlListeZakupow()
	{
		Console.WriteLine($"Lista zakupów '{NazwaListy}':");
		for (int i = 0; i < Produkty.Count; i++)
		{
			string sformatowanaCena = string.Format(new CultureInfo("pl-PL"), "{0:0.00}", Produkty[i].Cena);
			Console.WriteLine($"{i + 1}. {Produkty[i].Nazwa} - {sformatowanaCena} zł");
		}
	}

	public void ObliczSumarycznaWartosc()
	{
		double suma = 0;
		foreach (var produkt in Produkty)
		{
			suma += produkt.Cena;
		}
		string sformatowanaSuma = string.Format(new CultureInfo("pl-PL"), "{0:0.00}", suma);
		Console.WriteLine($"Sumaryczna wartość produktów na liście '{NazwaListy}' wynosi: {sformatowanaSuma} zł");
	}
}



class Program
{
	static void Main()
	{
		Console.WriteLine("Witaj w aplikacji do zarządzania zakupami!");

		Console.Write("Podaj nazwę listy zakupów: ");
		string nazwaListy = Console.ReadLine();
		var listaZakupow = new ListaZakupow(nazwaListy);

		bool kontynuuj = true;
		while (kontynuuj)
		{
			Console.WriteLine("\n[1] Dodaj produkt");
			Console.WriteLine("[2] Usuń produkt");
			Console.WriteLine("[3] Wyświetl listę zakupów");
			Console.WriteLine("[4] Oblicz sumaryczną wartość");
			Console.WriteLine("[5] Wyjście");

			Console.Write("Wybierz opcję: ");
			string opcja = Console.ReadLine();

			switch (opcja)
			{
				case "1":
					listaZakupow.DodajProdukt();
					break;
				case "2":
					listaZakupow.UsunProdukt();
					break;
				case "3":
					listaZakupow.WyswietlListeZakupow();
					break;
				case "4":
					listaZakupow.ObliczSumarycznaWartosc();
					break;
				case "5":
					kontynuuj = false;
					break;
				default:
					Console.WriteLine("Niepoprawna opcja. Spróbuj ponownie.");

					break;

					//	






			}
		}

		Console.WriteLine("Dziękujemy za korzystanie z aplikacji!");
	}
}
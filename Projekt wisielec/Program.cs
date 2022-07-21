using System;
using System.Collections.Generic;

namespace Wisielec
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[,] tab = new int[,]{ {0, 1, 0, 1, 0, 1, 0, 1 },
                                    {1, 0, 1, 0, 1, 0, 1, 0 },
                                    {0, 1, 0, 1, 0, 1, 0, 1 },
                                    {1, 0, 1, 0, 1, 0, 1, 0 },
                                    {0, 1, 0, 1, 0, 1, 0, 1 },
                                    {1, 0, 1, 0, 1, 0, 1, 0 },
                                    {0, 1, 0, 1, 0, 1, 0, 1 },
                                    {1, 0, 1, 0, 1, 0, 1, 0 }};

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tab[i, j] == 1)
                        Console.Write("*");
                    else
                        Console.Write("#");
                }
                Console.WriteLine();*/

                // Lista słów dostępnych w grze
                string[] listaSlow = { "pies", "srubokret", "sprawiedliwosc", "autobus", "kawiarnia", "naszyjnik", "wytrzymalosc" };

            // Losujemy słowo
            Random random = new Random();
            int indeks = random.Next(0, listaSlow.Length);
            string slowo = listaSlow[indeks];

            // Utworzenie zmiennych do przechowywania
            // zgadywanych poprawnych i niepoprawnych liter
            char[] litery = new char[slowo.Length];
            List<char> bledneLitery = new List<char>();

            // Wypełnienie tablicy litery znakami podłogi
            for (int i = 0; i < slowo.Length; i++)
            {
                litery[i] = '_';
            }

            // Ustawienie ilości prób na 10
            for (int iloscProb = 10; iloscProb >= 0; iloscProb--)
            {
                // Wyczyszczenie konsoli i wypisanie danych o grze
                Console.Clear();
                Console.WriteLine(litery);
                Console.WriteLine("Pozostała ilość prób: {0}", iloscProb);
                Console.Write("Błędne litery: ");
                for (int i = 0; i < bledneLitery.Count; i++)
                {
                    Console.Write("{0} ", bledneLitery[i]);
                }
                Console.WriteLine();

                // W przypadku nie odgadnięcia słowa i skończenia się prób
                //zostaje wypisany komunikat o przegranej i nieodgadnięte słowo
                //gra zostaje zakończona

                if (iloscProb == 0)
                {
                    Console.WriteLine("Przegrałeś");
                    Console.WriteLine("Poprawne słowo to {0}", slowo);
                    break;
                }

                // Wczytanie litery wprowadzonej przez użytkownika
                Console.Write("Podaj literę: ");
                char litera = Console.ReadLine()[0];

                /* Wyłapowanie błędu podczas podawania litery
                {
                    try
                    {
						Console.Write("Podaj literę: ");
						char litera = Console.ReadLine()[0];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Za duża wartość. nie wpisuj cyfr. " + e.Message);
                    }
                }
                */

                bool literaWSlowie = false;
                bool wygrana = true;
                for (int i = 0; i < slowo.Length; i++)
                {
                    // Sprawdzenie czy litera podana przez użytkownika
                    // znajduje się w słowie, jeśli tak to litera jest ujawniana
                    if (slowo[i] == litera)
                    {
                        litery[i] = litera;
                        literaWSlowie = true;
                    }

                    // Sprawdzenie czy użytkownik odgadł już wszystkie litery
                    if (litery[i] == '_')
                    {
                        wygrana = false;
                    }
                }

                // W przypadku odgadnięcia wszystkich liter zostaje wypisany
                // komunikat o wygranej i gra się kończy
                if (wygrana)
                {
                    Console.Clear();
                    Console.WriteLine(litery);
                    Console.WriteLine("Pozostała ilość prób: {0}", iloscProb);
                    Console.Write("Błędne litery: ");
                    for (int i = 0; i < bledneLitery.Count; i++)
                    {
                        Console.Write("{0} ", bledneLitery[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Wygrałeś!");
                    break;
                }

                // W przypadku podania przez gracza poprawnej litery lub już wcześniej
                // podanej błednej litery ilość prób nie ulega zmianie (teraz iloscProb
                // jest zwiększana o 1, a z początkiem następnej pętli zostanie
                // zmniejszona o 1, więc jej wartość pozostanie taka sama)
                if (literaWSlowie || bledneLitery.Contains(litera))
                    iloscProb++;
                // W przypadku podania błednej litery, litera ta jest dodawana do
                // listy blędnych liter
                else
                    bledneLitery.Add(litera);
            }
        }
    }
}

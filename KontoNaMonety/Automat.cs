using System.Globalization;

namespace KontoNaMonety
{
    internal class Automat
    {

        private static int _ostatniNumerKonta = 0;

        private int _iloscMonet;
        private readonly decimal[] przyjmowaneMonety = [5, 2, 1, 0.5m, 0.2m, 0.1m];

        public void WrzucMonete(KontoNaMonety kontoBankowe, string wartoscMonety)
        {
            bool czyUdanyParse = decimal.TryParse(wartoscMonety, CultureInfo.InvariantCulture, out decimal wartosc);

            if (!czyUdanyParse)
            {
                Console.WriteLine("Nieudany odczyt monety.");
                return;
            }

            Console.WriteLine("Wrzucono monetę o wartości: " + wartosc + " zł.");

            foreach (decimal moneta in przyjmowaneMonety)
            {
                if (wartosc == moneta)
                {
                    kontoBankowe.Saldo += wartosc;
                    _iloscMonet++;
                }
            }
        }

        // autmoatyczne dodawanie numeru konta do kazdego z kont bankowych
        public void WyswietlNumerKonta(KontoNaMonety kontoBankowe)
        {
            if (string.IsNullOrEmpty(kontoBankowe.Numer))
            {
                _ostatniNumerKonta++;
                kontoBankowe.Numer = _ostatniNumerKonta.ToString();
            }

            Console.WriteLine("Numer konta: " + kontoBankowe.Numer);
        }
    }
}


//if (decimal.TryParse(wartoscMonety, out decimal wartosc))
//{
//    if (przyjmowaneMonety.Contains(wartosc))
//    {
//        konto.Saldo += wartosc;
//        _iloscMonet++;
//        Console.WriteLine($"Wrzucono monetę o nominale {wartosc} zł.");
//    }
//    else
//    {
//        Console.WriteLine($"Moneta o nominale {wartosc} zł nie jest akceptowana.");
//    }
//}
//else
//{
//    Console.WriteLine("Nieprawidłowa wartość monety.");
//}


//_saldo += nominał;
//_iloscMonet++;
//Console.WriteLine($"Wrzucono monetę o nominale {nominał} zł.");
//Wplac(nominał());



//Console.WriteLine($"Moneta o nominale {nominał} zł nie jest akceptowana.");

//public void Wplac(decimal kwota)
//{
//    _saldo += kwota;
//    Console.WriteLine($"Wpłacono {kwota} zł. Nowy stan konta: {_saldo} zł.");
//}

//public void Wyplac(decimal kwota)
//{
//    _saldo -= kwota;
//    Console.WriteLine($"Wypłacono {kwota} zł. Nowy stan konta: {_saldo} zł.");
//}



//public decimal Saldo
//{
//    get { return  _saldo; }
//    set { _saldo = value; }
//}
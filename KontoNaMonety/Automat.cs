using System.Globalization;

namespace KontoNaMonety
{
    internal class Automat
    {

        private static int _ostatniNumerKonta = 0;
        private int monety5zl = 0;
        private int monety2zl = 0;
        private int monety1zl = 0;
        private int monety50gr = 0;
        private int monety20gr = 0;
        private int monety10gr = 0;

        public void PokazMonety()
        {
            Console.WriteLine("Monety w automacie:");

            Console.WriteLine("5 zł: " + monety5zl);
            Console.WriteLine("2 zł: " + monety2zl);
            Console.WriteLine("1 zł: " + monety1zl);
            Console.WriteLine("0.50 zł: " + monety50gr);
            Console.WriteLine("0.20 zł: " + monety20gr);
            Console.WriteLine("0.10 zł: " + monety10gr);

            decimal suma =
                monety5zl * 5 +
                monety2zl * 2 +
                monety1zl * 1 +
                monety50gr * 0.5m +
                monety20gr * 0.2m +
                monety10gr * 0.1m;

            Console.WriteLine("Łączna wartość monet: " + suma + " zł");
        }

     
        private readonly decimal[] przyjmowaneMonety = [5, 2, 1, 0.5m, 0.2m, 0.1m];

        public void WrzucMonete(KontoNaMonety kontoBankowe, string wartoscMonety)
        {
            bool czyUdanyParse = decimal.TryParse(wartoscMonety, CultureInfo.InvariantCulture, out decimal wartosc);

            if (!czyUdanyParse)
            {
                Console.WriteLine("Nieudany odczyt monety.");
                return;
            }

            if (przyjmowaneMonety.Contains(wartosc))
            {
                Console.WriteLine("Moneta przyjęta: " + wartosc + " zł.");
                switch (wartosc)
                {
                    case 5:
                        monety5zl++;
                        break;

                    case 2:
                        monety2zl++;
                        break;

                    case 1:
                        monety1zl++;
                        break;

                    case 0.5m:
                        monety50gr++;
                        break;

                    case 0.2m:
                        monety20gr++;
                        break;

                    case 0.1m:
                        monety10gr++;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Zła moneta: " + wartosc + " zł.");
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
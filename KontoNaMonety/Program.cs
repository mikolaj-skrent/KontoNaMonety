using System.Runtime.InteropServices;

namespace KontoNaMonety
{
    internal class Program
    {
        static void Main(string[] args)
        {

            KontoNaMonety kontoBankowe = new KontoNaMonety();

            KontoNaMonety kontoTestowe = new KontoNaMonety();
            Automat automat = new Automat();

            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "0.2");
            automat.WrzucMonete(kontoBankowe, "0.1");
            automat.WrzucMonete(kontoBankowe, "5");
            automat.WrzucMonete(kontoBankowe, "2");
            WyswietlStanKonta(kontoBankowe, "dla konta bankowego");
            automat.WyswietlNumerKonta(kontoBankowe);
            Console.WriteLine("-----------------------");

            automat.WrzucMonete(kontoTestowe, "2");
            automat.WrzucMonete(kontoTestowe, "1");
            automat.WrzucMonete(kontoTestowe, "0.5");

            WyswietlStanKonta(kontoTestowe, "dla konta testowego");
            automat.WyswietlNumerKonta(kontoTestowe);

        }

        static void WyswietlStanKonta(KontoNaMonety kontoBankowe, string opis)
        {
            Console.WriteLine("Stan konta " + opis + ": " + kontoBankowe.Saldo.ToString("F2") + " zł");
        }
    }
}


// Konto bankowe, które da się wpłacać tylko monety.
// Monety mozna wrzucic poprzez automat, który przyjmuje monety i wpłaca je na konto.
// automat przyjmuje monety o nominałach 1, 2, 5, 10, 20, 50 groszy oraz 1, 2 i 5 złote.
// Po wrzuceniu monety automat:
// powiadamia, że jest ok, albo moneta nie jest zgodna z nominałami, które przyjmuje.
// Po wrzuceniu monety automat wpłaca ją na konto bankowe.
// Monety mozna wrzucac pojedynczo
// Automat liczy ilosc i rodzaj wrzuconych monet

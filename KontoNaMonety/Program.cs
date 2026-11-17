namespace KontoNaMonety;

internal class Program
{
    private static void Main()
    {
        KontoBankowe konto = new();
        Automat automat = new(2);
        Bankomat bankomat = new();

        Console.WriteLine($"Numer konta: {konto.Numer}");
        // /n preskakuje do kolejnej linii i dopiero wtedy wpisuje tekst
        Console.WriteLine("\nWpłata monet:");
        automat.WrzucMonety(konto, "5 2 1 0.5 0.2 0.1 3 abc");

        Console.WriteLine("\nPróba przekroczenia pojemności:");
        automat.WrzucMonety(konto, "5 5 5");

        Console.WriteLine("\nŁadowanie bankomatu:");
        bankomat.ZaladujMonety(5m, 1);
        bankomat.ZaladujMonety(2m, 2);
        bankomat.ZaladujMonety(1m, 1);
        bankomat.ZaladujMonety(0.5m, 1);
        bankomat.ZaladujMonety(0.2m, 2);
        bankomat.ZaladujMonety(0.1m, 1);

        Console.WriteLine("\nWypłata 6,50 zł:");
        bankomat.Wyplac(konto, 6.5m);

        Console.WriteLine("\nWypłata większa niż saldo:");
        bankomat.Wyplac(konto, 100m);

        Console.WriteLine("\nKwota niemożliwa do wydania:");
        bankomat.Wyplac(konto, 1.8m);

        Console.WriteLine($"\nStan konta: {konto.StanKonta():F2} zł");
        konto.PokazHistorieWplat();

        Console.WriteLine();
        bankomat.PokazMonety();
    }
}
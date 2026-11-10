namespace KontoNaMonety;

internal class Program
{
    private static void Main()
    {
        KontoBankowe pierwszeKonto = new();
        KontoBankowe drugieKonto = new();

        Automat automat = new(pojemnoscNominalu: 2);

        Console.WriteLine($"Numer pierwszego konta: {pierwszeKonto.Numer}");
        Console.WriteLine($"Numer drugiego konta: {drugieKonto.Numer}");
        Console.WriteLine( "---------------------------" );

        Console.WriteLine("Wpłata pierwsza:");
        automat.WrzucMonety(
            pierwszeKonto,
            "5 2 1 0.5 0.2 0.1 3 abc");

        Console.WriteLine("---------------------------");

        Console.WriteLine("Próba przekroczenia pojemności:");
        automat.WrzucMonety(
            pierwszeKonto,
            "5 5 5");

        Console.WriteLine("---------------------------");

        Console.WriteLine("Wpłata na drugie konto:");
        automat.WrzucMonety(
            drugieKonto,
            "2 0.5 abc 7");

        Console.WriteLine("---------------------------");

        Console.WriteLine($"Stan pierwszego konta: {pierwszeKonto.StanKonta():F2} zł");
        Console.WriteLine($"Numer pierwszego konta: {pierwszeKonto.Numer}");
        pierwszeKonto.PokazHistorieWplat();

        Console.WriteLine("---------------------------");

        Console.WriteLine($"Stan drugiego konta: {drugieKonto.StanKonta():F2} zł");
        Console.WriteLine($"Numer drugiego konta: {drugieKonto.Numer}");
        drugieKonto.PokazHistorieWplat();

        Console.WriteLine("---------------------------");

        automat.PokazMonety();
    }
}
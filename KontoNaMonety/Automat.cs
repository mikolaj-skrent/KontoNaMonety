using System.Globalization;

namespace KontoNaMonety;

internal class Automat
{
    // Jedyna tablica nominałów używana przez Automat i Bankomat.
    public static readonly decimal[] Nominały =
    [
        5m, 2m, 1m, 0.5m, 0.2m, 0.1m
    ];

    private readonly Dictionary<decimal, int> _liczbaMonet = [];
    private readonly int _pojemnoscNominalu;

    public Automat(int pojemnoscNominalu)
    {
        _pojemnoscNominalu = pojemnoscNominalu;

        foreach (decimal nominał in Nominały)
        {
            _liczbaMonet[nominał] = 0;
        }
    }

    public void WrzucMonety(KontoBankowe konto, string tekst)
    {
        string[] odczyty = tekst.Split(
            [' ', '\t', '\r', '\n'],
            StringSplitOptions.RemoveEmptyEntries);

        int przyjete = 0;
        int zwrocone = 0;

        foreach (string odczyt in odczyty)
        {
            if (!decimal.TryParse(
                    odczyt,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal wartosc))
            {
                Console.WriteLine($"Nieudany odczyt: {odczyt}");
                continue;
            }

            if (!Nominały.Contains(wartosc))
            {
                Console.WriteLine($"Zła moneta: {wartosc} zł");
                continue;
            }

            if (_liczbaMonet[wartosc] >= _pojemnoscNominalu)
            {
                Console.WriteLine(
                    $"Brak miejsca na monetę {wartosc} zł. Moneta zwrócona.");

                zwrocone++;
                continue;
            }

            _liczbaMonet[wartosc]++;
            konto.Wplac(wartosc);
            przyjete++;

            Console.WriteLine($"Moneta przyjęta: {wartosc} zł");
        }

        Console.WriteLine($"Liczba przyjętych monet: {przyjete}");
        Console.WriteLine($"Liczba zwróconych monet: {zwrocone}");
    }

    public void PokazMonety()
    {
        Console.WriteLine("Monety w automacie:");

        decimal suma = 0m;

        foreach (decimal nominał in Nominały)
        {
            int liczba = _liczbaMonet[nominał];
            suma += liczba * nominał;

            Console.WriteLine($"{nominał} zł: {liczba} szt.");
        }

        Console.WriteLine($"Łączna wartość monet: {suma:F2} zł");
    }
}
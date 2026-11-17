namespace KontoNaMonety;

internal class KontoBankowe
{
    private static int _ostatniNumerKonta;
    private decimal _saldo;
    private readonly List<decimal> _historiaWplat = [];

    public KontoBankowe()
    {
        Numer = ++_ostatniNumerKonta;
    }

    public int Numer { get; }

    public void Wplac(decimal kwota)
    {
        _saldo += kwota;
        _historiaWplat.Add(kwota);
    }

    public bool Wyplac(decimal kwota)
    {
        if (kwota <= 0 || kwota > _saldo)
        {
            return false;
        }

        _saldo -= kwota;
        return true;
    }

    public decimal StanKonta()
    {
        return _saldo;
    }

    public void PokazHistorieWplat()
    {
        Console.WriteLine($"Historia wpłat konta numer {Numer}:");
        Console.WriteLine($"Liczba wpłat: {_historiaWplat.Count}");

        if (_historiaWplat.Count == 0)
        {
            Console.WriteLine("Brak wpłat.");
            return;
        }

        for (int i = 0; i < _historiaWplat.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_historiaWplat[i]:F2} zł");
        }
    }
}
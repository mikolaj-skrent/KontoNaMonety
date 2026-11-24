//namespace KontoNaMonety;

//internal class Bankomat
//{
//    // dictionary to taki slownik czego uzywamy do przechowywania liczby monet w bankomacie
//    private readonly Dictionary<decimal, int> _liczbaMonet = [];

//    public Bankomat()
//    {
//        foreach (decimal nominał in Automat.Nominały)
//        {
//            _liczbaMonet[nominał] = 0;
//        }
//    }

//    public void ZaladujMonety(decimal nominał, int liczbaMonet)
//    {
//        if (!Automat.Nominały.Contains(nominał))
//        {
//            Console.WriteLine($"Zła moneta: {nominał} zł");
//            return;
//        }

//        _liczbaMonet[nominał] += liczbaMonet;

//        Console.WriteLine(
//            $"Załadowano {liczbaMonet} monet o nominale {nominał} zł");
//    }

//    public void Wyplac(KontoBankowe konto, decimal kwota)
//    {
//        if (kwota <= 0)
//        {
//            Console.WriteLine("Wypłata odrzucona: kwota musi być większa od zera.");
//            return;
//        }

//        if (kwota > konto.StanKonta())
//        {
//            Console.WriteLine("Wypłata odrzucona: na koncie brakuje środków.");
//            return;
//        }

//        Dictionary<decimal, int> wydaneMonety = [];
//        decimal pozostalaKwota = kwota;

//        foreach (decimal nominał in Automat.Nominały)
//        {
//            int liczba = Math.Min(
//                _liczbaMonet[nominał],
//                (int)(pozostalaKwota / nominał));

//            wydaneMonety[nominał] = liczba;
//            pozostalaKwota -= liczba * nominał;
//        }

//        if (pozostalaKwota != 0)
//        {
//            Console.WriteLine(
//                "Wypłata odrzucona: bankomat nie może wydać dokładnej kwoty.");
//            return;
//        }

//        konto.Wyplac(kwota);

//        Console.WriteLine($"Wypłacono {kwota:F2} zł:");

//        foreach (decimal nominał in Automat.Nominały)
//        {
//            int liczba = wydaneMonety[nominał];

//            if (liczba == 0)
//            {
//                continue;
//            }

//            _liczbaMonet[nominał] -= liczba;

//            Console.WriteLine(
//                $"- {liczba} monet o nominale {nominał} zł");
//        }
//    }

//    public void PokazMonety()
//    {
//        Console.WriteLine("Monety w bankomacie:");

//        decimal suma = 0m;

//        foreach (decimal nominał in Automat.Nominały)
//        {
//            int liczba = _liczbaMonet[nominał];
//            suma += liczba * nominał;

//            Console.WriteLine($"{nominał} zł: {liczba} szt.");
//        }

//        Console.WriteLine($"Łączna wartość monet: {suma:F2} zł");
//    }
//}
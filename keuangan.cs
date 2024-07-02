using System;
using System.Collections.Generic;

class Transaction
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static List<Transaction> transactions = new List<Transaction>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== Aplikasi Manajemen Keuangan Pribadi ===");
            Console.WriteLine("Pilih operasi yang ingin Anda lakukan:");
            Console.WriteLine("1. Tambah Transaksi Pengeluaran");
            Console.WriteLine("2. Tambah Transaksi Pemasukan");
            Console.WriteLine("3. Lihat Ringkasan Keuangan");
            Console.WriteLine("4. Keluar");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    TambahTransaksi(false);
                    break;
                case "2":
                    TambahTransaksi(true);
                    break;
                case "3":
                    LihatRingkasanKeuangan();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan pilih lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void TambahTransaksi(bool isIncome)
    {
        Console.WriteLine("Masukkan deskripsi transaksi:");
        string description = Console.ReadLine();

        Console.WriteLine("Masukkan jumlah transaksi (Rp):");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        DateTime date = DateTime.Now;

        Transaction transaction = new Transaction
        {
            Description = description,
            Amount = isIncome ? amount : -amount, 
            Date = date
        };

        transactions.Add(transaction);

        Console.WriteLine("Transaksi berhasil ditambahkan.");
    }

    static void LihatRingkasanKeuangan()
    {
        decimal totalPengeluaran = 0;
        decimal totalPemasukan = 0;

        foreach (var transaction in transactions)
        {
            if (transaction.Amount < 0)
            {
                totalPengeluaran += transaction.Amount;
            }
            else
            {
                totalPemasukan += transaction.Amount;
            }
        }

        Console.WriteLine("Ringkasan Keuangan:");
        Console.WriteLine($"Total Pemasukan: Rp {totalPemasukan}");
        Console.WriteLine($"Total Pengeluaran: Rp {Math.Abs(totalPengeluaran)}"); 
        Console.WriteLine($"Saldo: Rp {totalPemasukan + totalPengeluaran}");
    }
}

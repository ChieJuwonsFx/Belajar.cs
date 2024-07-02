using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Selamat datang di Kalkulator Sederhana");
        Console.WriteLine("Silakan masukkan operasi matematika (contoh: 2 + 3):");

        string input = Console.ReadLine(); // Membaca input dari pengguna

        // Memisahkan input menjadi angka dan operator
        string[] tokens = input.Split(' ');
        if (tokens.Length != 3)
        {
            Console.WriteLine("Format input tidak valid.");
            return;
        }

        // Mengambil angka pertama, operator, dan angka kedua
        double angka1 = Convert.ToDouble(tokens[0]);
        string operasi = tokens[1];
        double angka2 = Convert.ToDouble(tokens[2]);

        // Melakukan operasi berdasarkan operator
        double hasil = 0;
        switch (operasi)
        {
            case "+":
                hasil = angka1 + angka2;
                break;
            case "-":
                hasil = angka1 - angka2;
                break;
            case "*":
                hasil = angka1 * angka2;
                break;
            case "/":
                // Menghindari pembagian dengan nol
                if (angka2 != 0)
                {
                    hasil = angka1 / angka2;
                }
                else
                {
                    Console.WriteLine("Tidak dapat melakukan pembagian dengan nol.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Operator tidak valid.");
                return;
        }

        // Menampilkan hasil operasi
        Console.WriteLine("Hasil: " + hasil);
    }
}

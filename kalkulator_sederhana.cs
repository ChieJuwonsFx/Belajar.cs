using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Selamat datang di Kalkulator Sederhana");
        Console.WriteLine("Silakan masukkan operasi matematika (contoh: 2 + 3):");

        string input = Console.ReadLine(); 
      
        string[] tokens = input.Split(' ');
        if (tokens.Length != 3)
        {
            Console.WriteLine("Format input tidak valid.");
            return;
        }

        double angka1 = Convert.ToDouble(tokens[0]);
        string operasi = tokens[1];
        double angka2 = Convert.ToDouble(tokens[2]);

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

        Console.WriteLine("Hasil: " + hasil);
    }
}

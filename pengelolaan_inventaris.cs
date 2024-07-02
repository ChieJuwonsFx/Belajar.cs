using System;
using System.Collections.Generic;

class InventoryItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; }
}

class Program
{
    static List<InventoryItem> inventory = new List<InventoryItem>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== Aplikasi Pengelolaan Inventaris ===");
            Console.WriteLine("Pilih operasi yang ingin Anda lakukan:");
            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Tampilkan Inventaris");
            Console.WriteLine("3. Cari Barang");
            Console.WriteLine("4. Hapus Barang");
            Console.WriteLine("5. Keluar");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    TambahBarang();
                    break;
                case "2":
                    TampilkanInventaris();
                    break;
                case "3":
                    CariBarang();
                    break;
                case "4":
                    TampilkanInventaris();
                    HapusBarang();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan pilih lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void TambahBarang()
    {
        Console.WriteLine("Masukkan nama barang:");
        string name = Console.ReadLine();
        Console.WriteLine("Masukkan jumlah barang:");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Masukkan lokasi penyimpanan:");
        string location = Console.ReadLine();

        InventoryItem newItem = new InventoryItem { Name = name, Quantity = quantity, Location = location };
        inventory.Add(newItem);

        Console.WriteLine("Barang berhasil ditambahkan ke inventaris.");
    }

    static void TampilkanInventaris()
    {
        Console.WriteLine("Inventaris Barang:");

        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventaris kosong.");
        }
        else
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"Nama: {item.Name}, Jumlah: {item.Quantity}, Lokasi: {item.Location}");
            }
        }
    }

    static void CariBarang()
    {
        Console.WriteLine("Masukkan nama barang yang ingin dicari:");
        string nameToSearch = Console.ReadLine();

        List<InventoryItem> foundItems = inventory.FindAll(item => item.Name.Equals(nameToSearch, StringComparison.OrdinalIgnoreCase));

        if (foundItems.Count == 0)
        {
            Console.WriteLine($"Barang dengan nama '{nameToSearch}' tidak ditemukan.");
        }
        else
        {
            Console.WriteLine($"Barang ditemukan - Total {foundItems.Count} barang:");
            foreach (var item in foundItems)
            {
                Console.WriteLine($"Nama: {item.Name}, Jumlah: {item.Quantity}, Lokasi: {item.Location}");
            }
        }
    }

    static void HapusBarang()
    {
        Console.WriteLine("Masukkan nama barang yang ingin dihapus:");
        string nameToDelete = Console.ReadLine();

        InventoryItem itemToDelete = inventory.Find(item => item.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

        if (itemToDelete != null)
        {
            inventory.Remove(itemToDelete);
            Console.WriteLine("Barang berhasil dihapus dari inventaris.");
        }
        else
        {
            Console.WriteLine($"Barang dengan nama '{nameToDelete}' tidak ditemukan.");
        }
    }
}

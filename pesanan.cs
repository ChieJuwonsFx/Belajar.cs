using System;
using System.Collections.Generic;

class MenuItem
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class OrderItem
{
    public MenuItem Menu { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static List<MenuItem> menuItems = new List<MenuItem>
    {
        new MenuItem { Name = "Nasi Goreng", Price = 25000 },
        new MenuItem { Name = "Ayam Goreng", Price = 30000 },
        new MenuItem { Name = "Soto Ayam", Price = 20000 },
        new MenuItem { Name = "Capcay", Price = 18000 },
        new MenuItem { Name = "Es Teh Manis", Price = 5000 },
        new MenuItem { Name = "Es Jeruk", Price = 6000 }
    };

    static List<OrderItem> currentOrder = new List<OrderItem>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== Aplikasi Pemesanan Makanan ===");
            Console.WriteLine("Pilih operasi yang ingin Anda lakukan:");
            Console.WriteLine("1. Lihat Menu");
            Console.WriteLine("2. Tambah Pesanan");
            Console.WriteLine("3. Lihat Pesanan");
            Console.WriteLine("4. Hapus Pesanan");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Keluar");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    LihatMenu();
                    break;
                case "2":
                    TambahPesanan();
                    break;
                case "3":
                    LihatPesanan();
                    break;
                case "4":
                    HapusPesanan();
                    break;
                case "5":
                    Checkout();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan pilih lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void LihatMenu()
    {
        Console.WriteLine("Menu Makanan:");
        foreach (var item in menuItems)
        {
            Console.WriteLine($"{item.Name} - Rp {item.Price}");
        }
    }

    static void TambahPesanan()
    {
        Console.WriteLine("Masukkan nama item yang ingin dipesan:");
        string itemName = Console.ReadLine();

        MenuItem menuItem = menuItems.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (menuItem != null)
        {
            Console.WriteLine($"Masukkan jumlah pesanan untuk {menuItem.Name}:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            OrderItem orderItem = new OrderItem { Menu = menuItem, Quantity = quantity };
            currentOrder.Add(orderItem);

            Console.WriteLine($"Pesanan {menuItem.Name} ({quantity}x) berhasil ditambahkan.");
        }
        else
        {
            Console.WriteLine($"Item dengan nama '{itemName}' tidak ada di menu.");
        }
    }

    static void LihatPesanan()
    {
        Console.WriteLine("Daftar Pesanan:");
        if (currentOrder.Count == 0)
        {
            Console.WriteLine("Belum ada pesanan.");
        }
        else
        {
            foreach (var orderItem in currentOrder)
            {
                Console.WriteLine($"{orderItem.Menu.Name} - {orderItem.Quantity}x");
            }
        }
    }

    static void HapusPesanan()
    {
        Console.WriteLine("Masukkan nama item pesanan yang ingin dihapus:");
        string itemNameToDelete = Console.ReadLine();

        OrderItem orderItemToDelete = currentOrder.Find(item => item.Menu.Name.Equals(itemNameToDelete, StringComparison.OrdinalIgnoreCase));

        if (orderItemToDelete != null)
        {
            currentOrder.Remove(orderItemToDelete);
            Console.WriteLine($"Pesanan {itemNameToDelete} berhasil dihapus.");
        }
        else
        {
            Console.WriteLine($"Pesanan dengan nama '{itemNameToDelete}' tidak ditemukan.");
        }
    }

    static void Checkout()
    {
        double totalBiaya = 0;

        Console.WriteLine("Detail Pesanan:");
        foreach (var orderItem in currentOrder)
        {
            double subtotal = orderItem.Menu.Price * orderItem.Quantity;
            totalBiaya += subtotal;
            Console.WriteLine($"{orderItem.Menu.Name} - {orderItem.Quantity}x - Subtotal: Rp {subtotal}");
        }

        Console.WriteLine($"Total Biaya Pesanan: Rp {totalBiaya}");
        Console.WriteLine("Terima kasih telah melakukan pemesanan!");
        currentOrder.Clear(); 
    }
}

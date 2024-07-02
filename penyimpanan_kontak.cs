using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

class Program
{
    static List<Contact> contacts = new List<Contact>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== Aplikasi Manajemen Kontak ===");
            Console.WriteLine("Pilih operasi yang ingin Anda lakukan:");
            Console.WriteLine("1. Tambah Kontak");
            Console.WriteLine("2. Tampilkan Kontak");
            Console.WriteLine("3. Edit Kontak");
            Console.WriteLine("4. Hapus Kontak");
            Console.WriteLine("5. Cari Kontak");
            Console.WriteLine("6. Keluar");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    TambahKontak();
                    break;
                case "2":
                    TampilkanKontak();
                    break;
                case "3":
                    TampilkanKontak();
                    EditKontak();
                    break;
                case "4":
                    HapusKontak();
                    break;
                case "5":
                    CariKontak();
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

    static void TambahKontak()
    {
        Console.WriteLine("Masukkan nama kontak:");
        string name = Console.ReadLine();
        Console.WriteLine("Masukkan nomor telepon:");
        string phone = Console.ReadLine();
        Console.WriteLine("Masukkan alamat email:");
        string email = Console.ReadLine();

        Contact newContact = new Contact { Name = name, Phone = phone, Email = email };
        contacts.Add(newContact);

        Console.WriteLine("Kontak berhasil ditambahkan.");
    }

    static void TampilkanKontak()
    {
        Console.WriteLine("Daftar Kontak:");

        if (contacts.Count == 0)
        {
            Console.WriteLine("Belum ada kontak yang tersimpan.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Nama: {contact.Name}, Telepon: {contact.Phone}, Email: {contact.Email}");
            }
        }
    }

    static void EditKontak()
    {
        Console.WriteLine("Masukkan nama kontak yang ingin diedit:");
        string nameToEdit = Console.ReadLine();

        Contact contactToEdit = contacts.Find(c => c.Name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase));

        if (contactToEdit != null)
        {
            Console.WriteLine("Masukkan data baru untuk kontak:");
            Console.WriteLine("Nama baru:");
            contactToEdit.Name = Console.ReadLine();
            Console.WriteLine("Nomor telepon baru:");
            contactToEdit.Phone = Console.ReadLine();
            Console.WriteLine("Email baru:");
            contactToEdit.Email = Console.ReadLine();

            Console.WriteLine("Kontak berhasil diubah.");
        }
        else
        {
            Console.WriteLine($"Kontak dengan nama '{nameToEdit}' tidak ditemukan.");
        }
    }

    static void HapusKontak()
    {
        Console.WriteLine("Masukkan nama kontak yang ingin dihapus:");
        string nameToDelete = Console.ReadLine();

        Contact contactToDelete = contacts.Find(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

        if (contactToDelete != null)
        {
            contacts.Remove(contactToDelete);
            Console.WriteLine("Kontak berhasil dihapus.");
        }
        else
        {
            Console.WriteLine($"Kontak dengan nama '{nameToDelete}' tidak ditemukan.");
        }
    }

    static void CariKontak()
    {
        Console.WriteLine("Masukkan nama kontak yang ingin dicari:");
        string nameToSearch = Console.ReadLine();

        Contact contactFound = contacts.Find(c => c.Name.Equals(nameToSearch, StringComparison.OrdinalIgnoreCase));

        if (contactFound != null)
        {
            Console.WriteLine($"Kontak ditemukan - Nama: {contactFound.Name}, Telepon: {contactFound.Phone}, Email: {contactFound.Email}");
        }
        else
        {
            Console.WriteLine($"Kontak dengan nama '{nameToSearch}' tidak ditemukan.");
        }
    }
}

using System;
using modull8;

namespace modull8
{
    class program
    {
        public static void Main(string[] args) 
        {
            //ngambil data
            BankTransferConfigManager configApp = new BankTransferConfigManager();

            //ngambil data lang
            string lang = configApp.config.lang;
            Console.WriteLine("Language = en & id");
            string pilihBahasa = Console.ReadLine();
            if (pilihBahasa == "en")
            {
                lang = "en";
            }
            else if (pilihBahasa == "id")
            {
                lang = "id";
            }
            else
            {
                Console.WriteLine("Invalid choice, defaulting to English.");
                lang = "en";
            }

            //-------------------------------

            if (lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }
            int nominal = int.Parse(Console.ReadLine());

            //ya ni intinya buat ngatur duitnya
            int duit =
                (nominal > configApp.config.transfer.threshold)
                ? configApp.config.transfer.high_fee
                : configApp.config.transfer.low_fee;

            //-----------------------------

            if (lang == "en")
            {
                //nampilin fee
                Console.WriteLine($"Transfer fee = {nominal}");
                //total sama fee
                Console.WriteLine($"Total amount = {duit + nominal}");
                Console.WriteLine("");
                Console.WriteLine("Select transfer method:");
            }
            else if (lang == "id")
            {
                //nampilin fee
                Console.WriteLine($"Biaya transfer = {nominal}");
                //total sama fee
                Console.WriteLine($"Total biaya = {duit + nominal}");
                Console.WriteLine("");
                Console.WriteLine("Pilih metode transfer:");
            }

            //-------------------------------

            for (int i = 0; i < configApp.config.methods.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + configApp.config.methods[i]);
            }
            int pilihanMethod = int.Parse(Console.ReadLine());

            if (lang == "en")
            {
                //buat nampilin pilihannya
                Console.WriteLine("You have choose: " + configApp.config.methods[pilihanMethod - 1] + " method");
                Console.WriteLine("Please type 'yes' to confirm the transaction:");
                string konfirmasiInggris = Console.ReadLine();
                //utk ngecek data konfirmasi
                if (konfirmasiInggris == configApp.config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled"); 
                }
            }
            else if (lang == "id")
            {
                //buat nampilin pilihannya
                Console.WriteLine("Anda memilih metode: " + configApp.config.methods[pilihanMethod - 1]);
                Console.WriteLine("Ketik 'ya' untuk mengkonfirmasi transaksi:");
                string konfirmasiIndo = Console.ReadLine();
                //utk ngecek data konfirmasi
                if (konfirmasiIndo == configApp.config.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static modull8.BankTransferConfig;

namespace modull8
{

    //ngambil data data yang ada dari JSONNNYA
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public TransferClass transfer { get; set; }
        public string[] methods { get; set; }
        public ConfirmationClass confirmation { get; set; }

        public class TransferClass
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        public class ConfirmationClass
        {
            public string en { get; set; }
            public string id { get; set; }
        }
    }

    internal class BankTransferConfigManager
    {
        public BankTransferConfig config;

        //ini buat nyimpen file JSON
        private static string file_path = Path.Combine(Directory.GetCurrentDirectory(), "bank_transfer_config.json");

        //buat ngeread file JSON
        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(file_path);
            config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
        }

        //buat ngewrite
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions option = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, option);
            File.WriteAllText(file_path, jsonString);
        }


        //set default biar enak aja manggilnya
        private void SetDefault()
        {
            config = new BankTransferConfig();

            config.lang = "en";
            TransferClass transfer = new();
            transfer.threshold = 25000000;
            transfer.low_fee = 6500;
            transfer.high_fee = 15000;
            config.transfer = transfer;
            config.methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            ConfirmationClass confirmation = new();
            confirmation.en = "yes";
            confirmation.id = "ya";
            config.confirmation = confirmation;
        }

        public BankTransferConfigManager()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}

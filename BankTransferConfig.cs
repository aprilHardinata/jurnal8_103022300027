using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jurnal8_103022300027
{
    public class BankTransferConfig
    {

        public string lang { get; set; }
        public string name { get; set; }
        public Transfer transfer {  get; set; }
        public List <String> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public class Transfer
        {
            public string threshold { get; set; }
            public string low_fee { get; set; }
            public string high_fee { get; set; }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        } 
    }

    public class UIConfig
    {
        public BankTransferConfig config;
        public const String filePath = @"bank_transfer_config.json";
        public UIConfig() {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        public BankTransferConfig ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return config;
        }
        private void SetDefault() {
            config = new BankTransferConfig();
            config.lang = "en";
            config.transfer.threshold = "25000000";
            config.transfer.low_fee = "6500";
            config.transfer.high_fee = " 15000";
            config.methods = new List<string> { "RTO(real - time)", "SKN", "RTGS", "BI FAST"};
            config.confirmation.en = "YES";
            config.confirmation.id = "IYA";
        }
        private void WriteNewConfigFile() {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}

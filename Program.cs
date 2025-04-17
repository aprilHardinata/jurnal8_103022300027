// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using jurnal8_103022300027;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config;

        if (File.Exists("bank_transfer_config.json"))
        {
            string json = File.ReadAllText("bank_transfer_config.json");
            config = JsonSerializer.Deserialize<BankTransferConfig>(json);
        }
        else
        {
            config = new BankTransferConfig(); // default value
        }

        if (config.lang == "en") {
            Console.WriteLine("insert uang");
        }
    }
}



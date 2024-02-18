// See https://aka.ms/new-console-template for more information
using Encrypt;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
var builder = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();

var ApiUrl = config["apiurl"];
string pol = config["ConnectionString"];

string clientName = "";
var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://api.github.com/repos/swdowia1/itcentral"),
    Headers =
    {
        { "user-agent", "vscode-restclient" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}
return;

if (args.Length == 0)
{
    clientName= "Random " + Cipher.Klucz;
    Console.Title = clientName;

}
else
{
    if (args[0].ToLower() == "o")
    {
        using (var httpClient = new HttpClient())
        {
            var json = await httpClient.GetStringAsync("https://api.github.com/users/swdowia1");

            // Now parse with JSON.Net
        }
        Console.WriteLine("opis aplikacj z github");
        return;
    }
    else
    {

        clientName= args[0]+"_" + Cipher.Klucz;
     
        Console.Title = clientName;



    }
}
while (true)
{
    Console.WriteLine( DateTime.Now.ToLongTimeString());
    string KeyValue = Cipher.Klucz;
    string dane = "ala ma kota "+clientName+" " + DateTime.Now.ToLongTimeString();
    string message = Cipher.Encrypt(dane, KeyValue);
    Console.WriteLine(KeyValue);

    SendMessageCipher(KeyValue, message,pol);

    var client1 = new HttpClient();
    var request1 = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri(ApiUrl + KeyValue)
    };
    using (var response = await client1.SendAsync(request1))
    {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);
    }

    Thread.Sleep(10 * 1000);
}




static void SendMessageCipher(string KeyValue, string message,string pol)
{
    //string pol = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sw1;Integrated Security=True;Connect Timeout=30;Encrypt=False";


    using (SqlConnection connection = new SqlConnection(pol))
    {
        connection.Open();
        string sql = "INSERT INTO Messages([Key],MessageValue) VALUES(@param1,@param2)";
        using (SqlCommand cmd = new SqlCommand(sql, connection))
        {

            cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = KeyValue;
            cmd.Parameters.Add("@param2", SqlDbType.NVarChar, -1).Value = message;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
}

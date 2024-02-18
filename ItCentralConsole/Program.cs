// See https://aka.ms/new-console-template for more information
using Encrypt;
using System.Data;
using System.Data.SqlClient;
if (args.Length == 0)
{

    Console.Title = "Random " + Cipher.Klucz;

}
else
{
    if (args[0].ToLower() == "o")
    {
        Console.WriteLine("opis aplikacj z github");
    }
}

string KeyValue = Cipher.Klucz;
string dane = "ala ma kota "+DateTime.Now.ToLongTimeString();
string message = Cipher.Encrypt(dane, KeyValue);
Console.WriteLine(KeyValue);

SendMessageCipher(KeyValue, message);

var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://localhost:7000/api/Message/"+KeyValue),
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


static void SendMessageCipher(string KeyValue, string message)
{
    string pol = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sw1;Integrated Security=True;Connect Timeout=30;Encrypt=False";


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

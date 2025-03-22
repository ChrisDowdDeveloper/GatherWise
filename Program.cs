using Supabase;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .Build();

var url = config["Supabase:Url"];
var key = config["Supabase:AnonKey"];

if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
{
    Console.WriteLine("ERROR: Missing Supabase credentials!");
    return;
}

var options = new SupabaseOptions { AutoConnectRealtime = true };
var supabase = new Client(url, key, options);
await supabase.InitializeAsync();

Console.WriteLine("Supabase Connected!");

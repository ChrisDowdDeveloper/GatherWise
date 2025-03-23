using Supabase;
using Microsoft.EntityFrameworkCore;
using GatherWise.Interfaces;
using GatherWise.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.Services.AddSingleton(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var url = config["Supabase:Url"];
    var key = config["Supabase:AnonKey"];

    if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
        throw new Exception("Missing Supabase credentials!");

    var options = new SupabaseOptions { AutoConnectRealtime = true };
    var client = new Client(url, key, options);
    client.InitializeAsync().Wait();
    return client;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();

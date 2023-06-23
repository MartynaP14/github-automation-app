using githubAutomation.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();
var ghToken = config["GH_TOKEN"];
var owner = "MartynaP14";
var repo = "github-automation-app";

var httpClient = new HttpClient();
var githubClient = new GithubClient(httpClient, ghToken);
var result = await githubClient.GetRepository(owner, repo);

Console.WriteLine(result);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

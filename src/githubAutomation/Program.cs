using githubAutomation.Client;
using githubAutomation.Models;

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

//var result = await githubClient.GetRepository(owner, repo);


//var resultContent = await result.Content.ReadAsStringAsync();

//Console.WriteLine(resultContent);
// Configure the HTTP request pipeline.

var repository = new Repository {Name = "New Repo" };
//var description = "Description of new repository";
var createnewrepo = await githubClient.CreateRepository( repository);





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

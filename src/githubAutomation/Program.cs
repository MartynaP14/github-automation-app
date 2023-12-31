using githubAutomation.Client;
using githubAutomation.Models;
using githubAutomation.Services;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

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
var repo = "New-Repo";


var httpClient = new HttpClient();
var githubClient = new GithubClient(httpClient, ghToken!);

var githubRepoService = new GithubRepoService(githubClient);
await githubRepoService.GetRepositoryService(owner, repo);

githubRepoService.DeleteRepositoryService(owner, repo);

var repository = new Repository {Name = "New Repo" };
await githubRepoService.CreateRepositoryService(repository);
// Configure the HTTP request pipeline.


//var description = "Description of new repository";


var pathtwo = "README.md";
//var path = new Pathfile {PathName = "README.md"};


var content = "Content added";
var base64Encoder = new Base64Encoder();
var encodedContent = base64Encoder.EncodeService(content);


var message = new GithubMessage {Message = "New file added to repository", Content = encodedContent };

//

var updatereplacefile = await githubClient.UpdateRepository(owner, repo, pathtwo,  message);
var response = await updatereplacefile.Content.ReadAsStringAsync();










//Console.WriteLine(updatereplacefile);
Console.WriteLine(response);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Start();

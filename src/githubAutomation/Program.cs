using githubAutomation.Client;
using githubAutomation.Models;
using githubAutomation.Services;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;

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
Pathfile pathtwo = new Pathfile { PathName = "README.md" };



var httpClient = new HttpClient();
var githubClient = new GithubClient(httpClient, ghToken!);
var githubRepoService = new GithubRepoService(githubClient);
var option = 0;


while (option != 5)
{
    Console.WriteLine("Please enter the option");
    Console.WriteLine("Option one - View repository ");
    Console.WriteLine("Option two - Create new Repository");
    Console.WriteLine("Option three - Delete existing Repository");
    Console.WriteLine("Option four - Update existing Repository ");
    Console.WriteLine("Option five - Exit ");
    option = Int32.Parse(Console.ReadLine());

    if (option == 1)
    {
        Console.Write("Please enter the repo name: ");
        var repo = Console.ReadLine();
        var responseGet = await githubRepoService.GetRepositoryService(owner, repo);
        Console.WriteLine(responseGet);

    }

    if (option == 2)
    {

        Console.Write("Create new repository, please provide repo name: ");
        var name = Console.ReadLine();
        var repository = new Repository { Name = name};
        
        var responseCreate = await githubRepoService.CreateRepositoryService(repository);
        Console.WriteLine(responseCreate);

    }    

    if (option == 3)
    {

        Console.Write("To delete repository, please provide repo name: ");
        var repo = Console.ReadLine();

        var responseDelete = githubRepoService.DeleteRepositoryService(owner, repo);
        Console.WriteLine(responseDelete);

    }

    if (option == 4)
    {
        Console.Write("To update repository, please provide repo name: ");
        var repo = Console.ReadLine();

        var description = "Description of new repository";

        var content = "Content added";
        var base64Encoder = new Base64Encoder();
        var encodedContent = base64Encoder.EncodeService(content);
        var message = new GithubMessage { Message = "New file added to repository", Content = encodedContent };
       
        
        var updatereplacefile = await githubRepoService.UpdateRepositoryService(owner, repo, pathtwo.PathName, message);
      


        //Console.WriteLine(updatereplacefile);
        Console.WriteLine(updatereplacefile);

    }
     
    if (option == 5)
    {
        Console.WriteLine("Exit");
        break;
    }


    
}

















if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Start();







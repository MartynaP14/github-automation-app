﻿using githubAutomation.Client;
using githubAutomation.Models;
using System.Text;

namespace githubAutomation.Services
{
    public class GithubRepoService
    {
        private readonly GithubClient _githubClient;

        public GithubRepoService(GithubClient githubclient)
        {
            _githubClient = githubclient;
        }

        public async Task<string> GetRepositoryService(string owner, string repoName) 
        {
            var result = await _githubClient.GetRepository(owner, repoName);
            var resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;
        
        }


    }
}
//var result = await githubClient.GetRepository(owner, repo);


//var resultContent = await result.Content.ReadAsStringAsync();

//Console.WriteLine(resultContent);
// Configure the HTTP request pipeline.

//var repository = new Repository { Name = "New Repo" };
////var description = "Description of new repository";
////var createnewrepo = await githubClient.CreateRepository( repository);
////Console.WriteLine(createnewrepo);

////var deleterepo = await githubClient.DeleteRepository(owner, repo);

//var pathtwo = "README.md";
////var path = new Pathfile {PathName = "README.md"};


//var content = "Content added";
//var headerByte = Encoding.ASCII.GetBytes(content);
//var headerAsBase64 = Convert.ToBase64String(headerByte);

//var message = new GithubMessage { Message = "New file added to repository", Content = headerAsBase64 };


//var updatereplacefile = await githubClient.UpdateRepository(owner, repo, pathtwo, message);
//var response = await updatereplacefile.Content.ReadAsStringAsync();

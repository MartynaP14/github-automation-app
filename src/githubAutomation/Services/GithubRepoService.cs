using githubAutomation.Client;
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


        public async void DeleteRepositoryService(string owner, string repoName) 
        { 
            await _githubClient.DeleteRepository(owner, repoName);
            //need to validate if repository delted, if the user variable exists
        
        }


        public async Task<string> CreateRepositoryService(Repository repository)
        {
            var createResultResponse = await _githubClient.CreateRepository(repository);
            var createResultContent = await createResultResponse.Content.ReadAsStringAsync();    
            return createResultContent;
        }

    }
}


//var repository = new Repository { Name = "New Repo" };
////var description = "Description of new repository";


//var pathtwo = "README.md";
////var path = new Pathfile {PathName = "README.md"};


//var content = "Content added";
//var headerByte = Encoding.ASCII.GetBytes(content);
//var headerAsBase64 = Convert.ToBase64String(headerByte);

//var message = new GithubMessage { Message = "New file added to repository", Content = headerAsBase64 };


//var updatereplacefile = await githubClient.UpdateRepository(owner, repo, pathtwo, message);
//var response = await updatereplacefile.Content.ReadAsStringAsync();


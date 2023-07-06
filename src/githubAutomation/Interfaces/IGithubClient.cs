using githubAutomation.Models;
using System.Net.Http;

namespace githubAutomation.Interfaces
{
    public interface IGithubClient
    {
        public Task<HttpResponseMessage> GetRepository(string owner, string repo);



        public Task<HttpResponseMessage> CreateRepository(Repository repository);



        public Task<HttpResponseMessage> DeleteRepository(string owner, string repo);


        public Task<HttpResponseMessage> UpdateRepository(string owner, string repo, string path, GithubMessage message);

    }
}

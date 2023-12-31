﻿using githubAutomation.Interfaces;
using githubAutomation.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;

namespace githubAutomation.Client
{
    public class GithubClient : IGithubClient
    {
        private HttpClient _httpClient;
        private readonly string GithubApiAddress = "https://api.github.com";

        public GithubClient(HttpClient httpclient, string ghToken)
        {
            _httpClient= httpclient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{ghToken}");
            _httpClient.BaseAddress = new Uri(GithubApiAddress);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MartynaP14");
            
        }
            
        
        //Setting the Bearer token in the Authorisation header 
        
        

        //Http request 
        public async Task<HttpResponseMessage> GetRepository( string owner, string repo)
        {
           return await _httpClient.GetAsync($"/repos/{owner}/{repo}");

        }


        public async Task<HttpResponseMessage> CreateRepository(Repository repository)
        {
            return await _httpClient.PostAsJsonAsync("/user/repos", repository);

        }



        public async Task<HttpResponseMessage> DeleteRepository(string owner, string repo)
        {
            return await _httpClient.DeleteAsync($"/repos/{owner}/{repo}");

        }

        public async Task<HttpResponseMessage> UpdateRepository(string owner, string repo, string path, GithubMessage message)
        {
            return await _httpClient.PutAsJsonAsync($"/repos/{owner}/{repo}/contents/{path}", message);

        }

    }
}

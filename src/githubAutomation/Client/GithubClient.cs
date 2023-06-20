﻿using System.Net.Http;
using System.Net.Http.Headers;

namespace githubAutomation.Client
{
    public class GithubClient
    {
        private HttpClient _httpClient;

        public GithubClient(HttpClient httpclient, string ghToken)
        {
            _httpClient= httpclient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{ghToken}");
            
        }
            

        //Setting the Bearer token in the Authorisation header 
        

        //Http request 
        public async Task<HttpResponseMessage> CreateRepository()
        {
           return await _httpClient.GetAsync("");

        }
       

    }
}

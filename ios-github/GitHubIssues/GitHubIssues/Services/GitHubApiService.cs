using GitHubIssues.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GitHubIssues.Services
{

    public class GitHubApiService
    {
        private static string baseURL = "https://api.github.com/repos/github/hub/issues";

        public GitHubApiService()
        {
        }


        public async Task<List<IssueResponse.RootObject>> GetIssues(string state, int pageNumber)
        {
            List<IssueResponse.RootObject> responses = new List<IssueResponse.RootObject>();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(baseURL) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;

                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                        var jsonobj = JsonConvert.DeserializeObject(reader);
                        responses = JsonConvert.DeserializeObject<List<IssueResponse.RootObject>>(reader);                   
                    }
                }
                catch (Exception e)
                {
                    var x = e;
                }
            }

            return responses;
        }
    }
}
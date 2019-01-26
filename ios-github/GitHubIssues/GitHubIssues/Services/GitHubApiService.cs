using GitHubIssues.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using static GitHubIssues.MainActivity;

namespace GitHubIssues.Services
{

    public class GitHubApiService
    {
        private static string baseURL = "https://api.github.com/repos/Alamofire/Alamofire/issues";

        public GitHubApiService()
        {
        }


        public async Task<IssueResult> GetIssues(bool state, int pageNumber)
        {
            IssueResult response = new IssueResult();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(baseURL + "?state=" + (state ? "open" : "closed") + "&page=" + pageNumber) as HttpWebRequest;
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
                        response.RecievedIssues = JsonConvert.DeserializeObject<List<IssueResponse.Issue>>(reader);                   
                    }
                }
                catch (Exception e)
                {
                    response.ErrorMessage = e.Message;
                }
            }

            return response;
        }
    }
}
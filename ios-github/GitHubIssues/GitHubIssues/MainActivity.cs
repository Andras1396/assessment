using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using GitHubIssues.Services;
using System.Collections.Generic;
using GitHubIssues.Models;
using System;

namespace GitHubIssues
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private GitHubApiService service = new GitHubApiService();
        public List<IssueResponse.RootObject> Issues = new List<IssueResponse.RootObject>();
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Issues = await service.GetIssues("open", 1);

            foreach (var issue in Issues)
            {
                Console.WriteLine("ITTTTT !!!!! : " + issue.Title);
            }

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);           
            
        }

        
        
    }
}


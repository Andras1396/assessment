﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using GitHubIssues.Services;
using System.Collections.Generic;
using GitHubIssues.Models;
using System;
using Android.Support.V7.Widget;
using GitHubIssues.Misc;
using System.Threading.Tasks;
using Android.Graphics;
using System.Net;
using System.Linq;

namespace GitHubIssues
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private GitHubApiService service = new GitHubApiService();
        public List<IssueResponse.Issue> Issues = new List<IssueResponse.Issue>();
        private int counter = 1;

        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        IssueAdapter issueAdapter;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
           

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            layoutManager = new LinearLayoutManager(this);
            

            var onScrollListener = new RecyclerViewOnScrollListener((LinearLayoutManager)layoutManager);
            onScrollListener.LoadMoreEvent += async (object sender, EventArgs e) => {
                await AddIssues();
            };

            recyclerView.AddOnScrollListener(onScrollListener);
            recyclerView.SetLayoutManager(layoutManager);

            await AddIssues();

        }

        private async Task AddIssues()
        {
            int scrolltoPosition = 0;
            if (counter > 1) scrolltoPosition = recyclerView.GetAdapter().ItemCount;

            List<IssueResponse.Issue> result = await service.GetIssues("open", counter);
            var onlyIssues = await RemovePullRequests(result);
            Issues.AddRange(onlyIssues);
            

            issueAdapter = new IssueAdapter(this, recyclerView, Issues);
            recyclerView.SetAdapter(issueAdapter);
            if (counter > 1) recyclerView.ScrollToPosition(scrolltoPosition);

            counter++;
        }

        private async Task<List<IssueResponse.Issue>> RemovePullRequests(List<IssueResponse.Issue> issues)
        {
            foreach (var issue in issues.Reverse<IssueResponse.Issue>())
            {
                if (issue.Pull_request != null) issues.Remove(issue);  
                else issue.User.AvatarBitmap = await GetImageBitmapFromUrl(issue.User.Avatar_url);
            }
            return issues;
        }

        private async Task<Bitmap> GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }



    }
}


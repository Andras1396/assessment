using Android.App;
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
using Android.Views;
using Android.Content;
using Newtonsoft.Json;
using System.Threading;

namespace GitHubIssues
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        private GitHubApiService service = new GitHubApiService();
        public List<IssueResponse.Issue> Issues = new List<IssueResponse.Issue>();
        private int counter = 1;
        private bool stateIsOpen = true;

        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        IssueAdapter issueAdapter;
        SwitchCompat switchState;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);           


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            switchState = FindViewById<SwitchCompat>(Resource.Id.stateButton);


            switchState.CheckedChange += SwitchState_CheckedChange;


            layoutManager = new LinearLayoutManager(this);
            var onScrollListener = new RecyclerViewOnScrollListener((LinearLayoutManager)layoutManager);
            onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
                AddIssues(); ;
            };
            recyclerView.AddOnScrollListener(onScrollListener);
            recyclerView.SetLayoutManager(layoutManager);
            issueAdapter = new IssueAdapter(this, recyclerView, Issues);
            issueAdapter.ItemClick += OnItemClick;
            recyclerView.SetAdapter(issueAdapter);

            
            AddIssues();

        }

        private void SwitchState_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {            
            stateIsOpen = !stateIsOpen;
            counter = 1;
            Issues.Clear();
            AddIssues();
            issueAdapter.NotifyDataSetChanged();
        }

        private void OnItemClick(object sender, int e)
        {

            IssueResponse.Issue issueClicked = Issues[e];
            var activity = new Intent(this, typeof(IssueDetailsActivity));

            activity.PutExtra("issue", JsonConvert.SerializeObject(issueClicked));
            StartActivity(activity);
        }


        private void AddIssues()
        {
            var progressDialog = ProgressDialog.Show(this, "Please wait...", (counter == 1 ? "Loading issues..." : "Loading more issues..."), true);
            
            new Thread(new ThreadStart(async delegate
            {
                int scrolltoPosition = 0;
                if (counter > 1) scrolltoPosition = recyclerView.GetAdapter().ItemCount;
                var result = await service.GetIssues(stateIsOpen, counter);
                RunOnUiThread(() => {                    
                    if (result.ErrorMessage != null) Toast.MakeText(this, "Error occured", ToastLength.Long).Show();
                    else if (result.RecievedIssues.Count == 0 && counter == 1) Toast.MakeText(this, "Unable to load issues", ToastLength.Long).Show();
                    else if (result.RecievedIssues.Count == 0) Toast.MakeText(this, "Unable to load more " + (stateIsOpen ? "open" : "closed") + " issues", ToastLength.Short).Show();
                    else
                    {
                        var onlyIssues = RemovePullRequests(result.RecievedIssues);
                        Issues.AddRange(onlyIssues);
                        issueAdapter.NotifyDataSetChanged();
                        if (counter > 1) recyclerView.ScrollToPosition(scrolltoPosition);
                        counter++;

                    }
                });
                RunOnUiThread(() => progressDialog.Hide());
            })).Start();

        }

        private List<IssueResponse.Issue> RemovePullRequests(List<IssueResponse.Issue> issues)
        {
            foreach (var issue in issues.Reverse<IssueResponse.Issue>())
            {
                if (issue.Pull_request != null) issues.Remove(issue);
            }
            return issues;
        }

        

        public class IssueResult
        {
            public List<IssueResponse.Issue> RecievedIssues {get; set;}
            public string ErrorMessage {get; set;}
        }
    }
}


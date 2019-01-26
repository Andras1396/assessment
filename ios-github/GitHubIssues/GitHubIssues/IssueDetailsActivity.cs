using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GitHubIssues.Models;
using Newtonsoft.Json;

namespace GitHubIssues
{
    [Activity(Label = "IssueDetailsActivity")]
    public class IssueDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.issue_details);

            IssueResponse.Issue issue = JsonConvert.DeserializeObject<IssueResponse.Issue>(Intent.GetStringExtra("issue"));
            // Create your application here
        }
    }
}
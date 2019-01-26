using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubIssues.Models
{
    public class IssueResponse
    {
        public class User
        {
            public string Login { get; set; }
            public int Id { get; set; }
            public string Node_id { get; set; }
            public string Avatar_url { get; set; }
            
        }

        public class PullRequest
        {
            public string Url { get; set; }
            public string HtmlUrl { get; set; }
            public string DiffUrl { get; set; }
            public string PatchUrl { get; set; }
        }

        public class Issue
        {
            public int Number { get; set; }
            public string Title { get; set; }
            public User User { get; set; }
            public List<Label> Labels { get; set; }
            public DateTime Created_at { get; set; }

            public PullRequest Pull_request { get; set; }
            public string Body { get; set; }
        }

        public class Label
        {
            public string Name { get; set; }
            public string Color { get; set; }
        }
    }
}
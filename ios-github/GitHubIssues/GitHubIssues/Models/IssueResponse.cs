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
        }

        public class RootObject
        {
            public int Number { get; set; }
            public string Title { get; set; }
            public User User { get; set; }
            public List<object> Labels { get; set; }
            public DateTime CreatedAt { get; set; }
            public PullRequest PullRequest { get; set; }
            public string Body { get; set; }
        }
    }
}
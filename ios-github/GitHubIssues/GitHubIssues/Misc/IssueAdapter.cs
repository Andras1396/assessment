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
using Android.Support.V7.Widget;
using GitHubIssues.Models;
using Android.Graphics;
using System.Net;
using System.Threading.Tasks;
using System.Globalization;

namespace GitHubIssues.Misc
{
    public class IssueAdapter : RecyclerView.Adapter
    {
        private Context context;
        private Android.Support.V7.Widget.RecyclerView recyclerView;
        private List<IssueResponse.Issue> issues;

        public IssueAdapter(Context context, Android.Support.V7.Widget.RecyclerView recyclerView, List<IssueResponse.Issue> issues)
        {
            this.context = context;
            this.recyclerView = recyclerView;
            this.issues = issues;
        }

        public override int ItemCount => issues.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            IssueResponse.Issue issue = this.issues[position];
            ((IssueViewHolder)holder).Title.Text = issue.Title;
            ((IssueViewHolder)holder).Name.Text = issue.User.Login;
            ((IssueViewHolder)holder).Date.Text = issue.Created_at.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ((IssueViewHolder)holder).Number.Text = issue.Number.ToString();


            // Unsubscribe and subscribe the method, to avoid setting multiple times.
            ((IssueViewHolder)holder).Item.Click -= Issue_Click;
            ((IssueViewHolder)holder).Item.Click += Issue_Click;
        }

        private void Issue_Click(object sender, EventArgs e)
        {
            int position = this.recyclerView.GetChildAdapterPosition((View)sender);
            IssueResponse.Issue issueClicked = this.issues[position];
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.issue_item, parent, false);
            return new IssueViewHolder(itemView);
        }

        

    }
}
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
        private RecyclerView recyclerView;
        private List<IssueResponse.Issue> issues;

        public event EventHandler<int> ItemClick;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public IssueAdapter(Context context, Android.Support.V7.Widget.RecyclerView recyclerView, List<IssueResponse.Issue> issues)
        {
            this.context = context;
            this.recyclerView = recyclerView;
            this.issues = issues;
        }

        public override int ItemCount => issues.Count;

        public async override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            IssueResponse.Issue issue = this.issues[position];
            ((IssueViewHolder)holder).Title.Text = issue.Title;
            ((IssueViewHolder)holder).Attributes.Text = "#" + issue.Number.ToString() + " opened on " + issue.Created_at.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) + " by " + issue.User.Login;

            ((IssueViewHolder)holder).LabelContainer.RemoveAllViews();
            for (int i = 0; i < issue.Labels.Count; i++)
            {
                TextView tv = new TextView(context);
                tv.Text = issue.Labels[i].Name;
                string col = "#" + issue.Labels[i].Color;
                tv.SetBackgroundColor(Color.ParseColor(col));
                LinearLayout.LayoutParams ll = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                ll.SetMargins(0, 0, 0, 15);
                tv.LayoutParameters = ll;
                tv.SetPadding(5, 5, 5, 5);
                tv.TextSize = 11;
                ((IssueViewHolder)holder).LabelContainer.AddView(tv);
            }


            
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.issue_item, parent, false);
            return new IssueViewHolder(itemView, OnClick);
        }

        

    }
}
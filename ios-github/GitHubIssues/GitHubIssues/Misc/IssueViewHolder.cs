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

namespace GitHubIssues.Misc
{
    public class IssueViewHolder: Android.Support.V7.Widget.RecyclerView.ViewHolder
    {
        public View Item { get; private set; }
        public TextView Title { get; private set; }
        public TextView Name { get; private set; }
        public TextView Number { get; private set; }
        public TextView Date { get; private set; }

        public IssueViewHolder(View itemView) : base(itemView)
        {
            this.Item = itemView;
            this.Title = itemView.FindViewById<TextView>(Resource.Id.item_title);
            this.Name = itemView.FindViewById<TextView>(Resource.Id.item_name);
            this.Number = itemView.FindViewById<TextView>(Resource.Id.item_number);
            this.Date = itemView.FindViewById<TextView>(Resource.Id.item_date);
        }
    }
}
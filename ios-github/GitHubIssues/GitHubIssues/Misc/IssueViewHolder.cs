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
        public TextView Attributes { get; private set; }
        public LinearLayout LabelContainer { get; private set; }

        public IssueViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            this.Item = itemView;
            this.Title = itemView.FindViewById<TextView>(Resource.Id.item_title);
            this.Attributes = itemView.FindViewById<TextView>(Resource.Id.item_attributes);
            this.LabelContainer = itemView.FindViewById<LinearLayout>(Resource.Id.label_container);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
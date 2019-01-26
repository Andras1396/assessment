using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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
        TextView issueTitle;
        TextView issueDescription;
        TextView issueAttributes;
        TextView authorName;
        LinearLayout labelContainer;
        ImageView authorImage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.issue_details);

            IssueResponse.Issue issue = JsonConvert.DeserializeObject<IssueResponse.Issue>(Intent.GetStringExtra("issue"));



            issueTitle = FindViewById<TextView>(Resource.Id.issueTitle);
            issueDescription = FindViewById<TextView>(Resource.Id.issueDescription);
            issueAttributes = FindViewById<TextView>(Resource.Id.issueAttributes);
            labelContainer = FindViewById<LinearLayout>(Resource.Id.labelContainer);
            authorImage = FindViewById<ImageView>(Resource.Id.authorImage);
            authorName = FindViewById<TextView>(Resource.Id.authorName);

            authorImage.SetImageBitmap(GetImageBitmapFromUrl(issue.User.Avatar_url));
            issueTitle.Text =  issue.Title;
            issueDescription.Text = issue.Body;
            authorName.Text = issue.User.Login;
            issueAttributes.Text = "#" + issue.Number.ToString() + " opened on " + issue.Created_at.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            for (int i = 0; i < issue.Labels.Count; i++)
            {
                TextView tv = new TextView(this);
                tv.Text = issue.Labels[i].Name;
                string col = "#" + issue.Labels[i].Color;
                tv.SetBackgroundColor(Color.ParseColor(col));
                LinearLayout.LayoutParams ll = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                ll.SetMargins(0, 0, 15, 10);
                tv.LayoutParameters = ll;
                tv.SetPadding(5, 5, 5, 5);
                tv.TextSize = 14;
                labelContainer.AddView(tv);
            }

            
        }

        private Bitmap GetImageBitmapFromUrl(string url)
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
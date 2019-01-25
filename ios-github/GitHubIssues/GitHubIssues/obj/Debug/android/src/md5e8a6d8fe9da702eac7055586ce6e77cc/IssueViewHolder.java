package md5e8a6d8fe9da702eac7055586ce6e77cc;


public class IssueViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GitHubIssues.Misc.IssueViewHolder, GitHubIssues", IssueViewHolder.class, __md_methods);
	}


	public IssueViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == IssueViewHolder.class)
			mono.android.TypeManager.Activate ("GitHubIssues.Misc.IssueViewHolder, GitHubIssues", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

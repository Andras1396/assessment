package md542d822efbb8d75b44f26afd028e99c9f;


public class IssueDetailsActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GitHubIssues.IssueDetailsActivity, GitHubIssues", IssueDetailsActivity.class, __md_methods);
	}


	public IssueDetailsActivity ()
	{
		super ();
		if (getClass () == IssueDetailsActivity.class)
			mono.android.TypeManager.Activate ("GitHubIssues.IssueDetailsActivity, GitHubIssues", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

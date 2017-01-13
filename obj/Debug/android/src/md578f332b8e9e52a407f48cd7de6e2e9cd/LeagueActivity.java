package md578f332b8e9e52a407f48cd7de6e2e9cd;


public class LeagueActivity
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
		mono.android.Runtime.register ("LeagueManager.LeagueActivity, LeagueManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LeagueActivity.class, __md_methods);
	}


	public LeagueActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LeagueActivity.class)
			mono.android.TypeManager.Activate ("LeagueManager.LeagueActivity, LeagueManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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

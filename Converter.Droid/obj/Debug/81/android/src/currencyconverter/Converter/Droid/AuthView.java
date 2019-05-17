package currencyconverter.Converter.Droid;


public class AuthView
	extends android.widget.RelativeLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFinishInflate:()V:GetOnFinishInflateHandler\n" +
			"";
		mono.android.Runtime.register ("Converter.Droid.AuthView, Converter.Droid", AuthView.class, __md_methods);
	}


	public AuthView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AuthView.class)
			mono.android.TypeManager.Activate ("Converter.Droid.AuthView, Converter.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public AuthView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == AuthView.class)
			mono.android.TypeManager.Activate ("Converter.Droid.AuthView, Converter.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public AuthView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == AuthView.class)
			mono.android.TypeManager.Activate ("Converter.Droid.AuthView, Converter.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public AuthView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == AuthView.class)
			mono.android.TypeManager.Activate ("Converter.Droid.AuthView, Converter.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onFinishInflate ()
	{
		n_onFinishInflate ();
	}

	private native void n_onFinishInflate ();

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

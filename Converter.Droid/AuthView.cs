using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using currencyconverter.AuthorizationModule;

namespace Converter.Droid
{
    [Register("currencyconverter.Converter.Droid.AuthView")]
    public class AuthView : RelativeLayout, IAuthView
    {
        private LayoutInflater _inflater;
        private Context _context;
        private Button _signIn;
        private EditText _login;
        private EditText _password;

        public event Action<string, string> SignInClicked;

        public AuthView(Context context) : base(context)
        {
            _context = context;
        }

        public AuthView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            _context = context;
        }

        public AuthView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            _context = context;
        }

        public AuthView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            _context = context;
        }

        protected AuthView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            _inflater = LayoutInflater.From(Context);
            _inflater.Inflate(Resource.Layout.auth, this, true);
            InitViewComponents();

            _signIn.Click += SignInButtonClicked;
        }

        private void SignInButtonClicked(object sender, EventArgs e)
        {
            var login = _login.Text;
            var password = _password.Text;
            SignInClicked.Invoke(login, password); 
        }

        private void InitViewComponents()
        {
            _signIn = FindViewById<Button>(Resource.Id.sigin);
            _login = FindViewById<EditText>(Resource.Id.edit_login);
            _password = FindViewById<EditText>(Resource.Id.edit_password);
        }

        public void ShowResult(string result)
        {
            (Context as Activity).RunOnUiThread(() =>
            {
                Toast.MakeText(_context, result, ToastLength.Long).Show();
            });
        }
    }
}
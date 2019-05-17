using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using currencyconverter.AuthorizationModule;

namespace Converter.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private IAuthPresenter _authPresenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            InitAuthPresenter();
        }

        protected override void OnResume()
        {
            base.OnResume();
            _authPresenter.Subscribe();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _authPresenter.UnSubscribe();
        }

        private void InitAuthPresenter()
        {
            IAuthorizationInteractor interactor = new AuthorizationInteractor(new LoginValidator(), new PasswordValidator());
            IAuthView view = new AuthView(this);
            _authPresenter = new AuthPresenter(interactor, view);
            _authPresenter.Subscribe();
        }

    }
}


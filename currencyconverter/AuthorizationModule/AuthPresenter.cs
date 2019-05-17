using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyconverter.AuthorizationModule
{
    public class AuthPresenter : IAuthPresenter
    {
        private readonly IAuthorizationInteractor _authInteractor;
        private  IAuthView _authView;

        public AuthPresenter(IAuthorizationInteractor authInteractor, IAuthView authView)
        {
            _authInteractor = authInteractor ?? throw new ArgumentNullException(nameof(authInteractor));
            _authView = authView ?? throw new ArgumentNullException(nameof(authView));
        }

        public void Subscribe()
        {
            _authView.SignInClicked += ValidateFields; 
        }

        public void UnSubscribe()
        {
            _authView.SignInClicked -= ValidateFields;
        }

        public void ShowResult(string result)
        {
            _authView.ShowResult(result);
        }       

        private void ValidateFields(string login, string password)
        {
            var result = _authInteractor.Login(login, password);
            if(result == EAuthResult.Success)
            {
                ShowResult("Login Success!!!");
            }
            else
            {
                ShowResult("Invalid login or password");
            }
        }
    }
}

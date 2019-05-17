using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyconverter.AuthorizationModule
{
    public interface IAuthView
    {
        event Action<string, string> SignInClicked;
        void ShowResult(string result);
    }
}

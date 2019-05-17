using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyconverter.AuthorizationModule
{
    public interface IAuthPresenter
    {
        void Subscribe();
        void UnSubscribe();
        void ShowResult(string result);
    }
}

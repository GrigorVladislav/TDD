using System.Threading.Tasks;

namespace currencyconverter.AuthorizationModule
{
    public interface IAuthorizationInteractor
    {
        EAuthResult Login(string login, string pass);
    }
}

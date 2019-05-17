using System;
using System.Reflection;
using System.Threading.Tasks;
using currencyconverter.AuthorizationModule;
using Moq;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class AuthorizationInteractorTest
    {
        private IAuthorizationInteractor _interactor;
        //private Mock<IAuthSender> _sender;
        private Mock<IValidator> _loginValidator;
        private Mock<IValidator> _passValidator;

        [SetUp]
        public void SetUp()
        {
            _loginValidator = new Mock<IValidator>(MockBehavior.Strict);
            _passValidator = new Mock<IValidator>(MockBehavior.Strict);
            //_sender = new Mock<IAuthSender>(MockBehavior.Strict);
            _interactor = new AuthorizationInteractor(_loginValidator.Object, _passValidator.Object);
        }

        [Test]
        public void CtorTest_NullLogin()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _interactor = new AuthorizationInteractor(null, _passValidator.Object);
            });
        }

        [Test]
        public void CtorTest_NullPassword()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _interactor = new AuthorizationInteractor(_loginValidator.Object, null);
            });
        }

        [Test]
        public void LoginTest_Success()
        {
            var login = "login";
            var pass = "pass";
            _loginValidator.Setup(v => v.Validate(login)).Returns(true);
            _passValidator.Setup(v => v.Validate(pass)).Returns(true);
            var expextedResult = EAuthResult.Success;
            var actualResult = _interactor.Login(login, pass);
            Assert.That(Is.Equals(expextedResult, actualResult));
        }

        [Test]
        public void LoginTest_LoginInvalid()
        {
            var login = "";
            var pass = "pass";
            _loginValidator.Setup(v => v.Validate(login)).Returns(false);
            _passValidator.Setup(v => v.Validate(pass)).Returns(true);
            var expextedResult = EAuthResult.InvalidData;
            var actualResult = _interactor.Login(login, pass);
            Assert.That(Is.Equals(expextedResult, actualResult));
        }

        [Test]
        public void LoginTest_PassInvalid()
        {
            var login = "login";
            var pass = "";
            _loginValidator.Setup(v => v.Validate(login)).Returns(true);
            _passValidator.Setup(v => v.Validate(pass)).Returns(false);
            var expextedResult = EAuthResult.InvalidData;
            var actualResult = _interactor.Login(login, pass);
            Assert.That(Is.Equals(expextedResult, actualResult));
        }

        [Test]
        public void LoginTest_Pass_Login_Invalid()
        {
            var login = "";
            var pass = "";
            _loginValidator.Setup(v => v.Validate(login)).Returns(false);
            _passValidator.Setup(v => v.Validate(pass)).Returns(false);
            var expextedResult = EAuthResult.InvalidData;
            var actualResult = _interactor.Login(login, pass);
            Assert.That(Is.Equals(expextedResult, actualResult));
        }


        //[Test]
        //public void CtorLoginValidatorTest()
        //{
        //    var expected =
        //        typeof(AuthorizationInteractor)
        //            .GetField("_loginValidator",
        //            BindingFlags.Instance | BindingFlags.NonPublic)
        //            .GetValue(_interactor);
        //    Assert.AreEqual(_validator.Object, expected);
        //}

        //[Test]
        //public void CtorLAuthSenderTest()
        //{
        //    var expected =
        //        typeof(AuthorizationInteractor)
        //            .GetField("_authSender",
        //                BindingFlags.Instance | BindingFlags.NonPublic)
        //            .GetValue(_interactor);
        //    Assert.AreEqual(_sender.Object, expected);
        //}

        //[Test]
        //public void CtorLoginValidatorNullTest()
        //{
        //    var exception = Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        _interactor = new AuthorizationInteractor(null, _sender.Object);
        //    });

        //    Assert.AreEqual("loginValidator", exception.ParamName);
        //}

        //[Test]
        //public void CtorAuthSenderNullTest()
        //{
        //    var exception = Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        _interactor = new AuthorizationInteractor(_validator.Object, null);
        //    });

        //    Assert.AreEqual("authSender", exception.ParamName);
        //}

        //[TestCase(true, EAuthResult.Success)]
        //[TestCase(false, EAuthResult.Unauthorized)]
        //public async Task LoginTest(bool senderResult, EAuthResult expected)
        //{
        //    //Given
        //    var login = "login";
        //    var pass = "pass";
        //    _validator.Setup(f => f.Validate(login))
        //        .Returns(true);
        //    _sender.Setup(f => f.SendAuthRequest(login, pass))
        //        .Returns(Task.FromResult(senderResult));

        //    //When
        //    var actual = await _interactor.Login(login, pass);

        //    //Then
        //    _validator.Verify(f => f.Validate(login), Times.Once);
        //    _sender.Verify(f => f.SendAuthRequest(login, pass));
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test]
        //public async Task LoginTest_InvalidLogin()
        //{
        //    //Given
        //    var login = "invalid_string";
        //    var pass = "pass";
        //    var expected = EAuthResult.InvalidData;
        //    _validator.Setup(f => f.Validate(login))
        //        .Returns(false);

        //    //When
        //    var actual = await _interactor.Login(login, pass);

        //    //Then
        //    _validator.Verify(f => f.Validate(login), Times.Once);
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
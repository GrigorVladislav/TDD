using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using currencyconverter.AuthorizationModule;

namespace UnitTest
{
    [TestFixture]
    public class AuthPresenterTest
    {
        private Mock<IAuthorizationInteractor> _authInteractorMock;
        private Mock<IAuthView> _authViewMock;
        private IAuthPresenter _authPresenter;

        [SetUp]
        public void Setup()
        {
            _authInteractorMock = new Mock<IAuthorizationInteractor>(MockBehavior.Strict);
            _authViewMock = new Mock<IAuthView>(MockBehavior.Strict);
            _authPresenter = new AuthPresenter(_authInteractorMock.Object, _authViewMock.Object);

        }

        [Test]
        public void Ctor_NullInteractorTest()
        {
            Assert.Throws<ArgumentNullException>(() => {
                _authPresenter = new AuthPresenter(null, _authViewMock.Object);
            });
        }

        [Test]
        public void Ctor_NullViewTest()
        {
            Assert.Throws<ArgumentNullException>(() => {
                _authPresenter = new AuthPresenter(_authInteractorMock.Object, null);
            });
        }

        [Test]
        public void ShowResultTest()
        {
            var result = "Result";
            _authViewMock.Setup(a => a.ShowResult(result));
            _authPresenter.ShowResult(result);
            _authViewMock.Verify(a => a.ShowResult(result), Times.Once);
        }        
    }
}

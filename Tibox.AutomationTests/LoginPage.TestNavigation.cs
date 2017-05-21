using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Tibox.AutoMation;
using Xunit;

namespace Tibox.AutomationTests
{
    public class LoginPageTestNavigation
    {

        public LoginPageTestNavigation()
        {
            Driver.GetInstance(DriverOptions.Firefox);
        }

        [Fact]
        public void LoginTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("chino@gmail.com").WithPassWord("123456").Login();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            LoginPage.GetUrl().Should().Be("http://localhost:81/Tibox.Web/#!/product");
            LoginPage.Logout();
            Driver.CloseInstance();
        }

        [Fact]
        public void LoginInWrongTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("chino@gmail.com").WithPassWord("654321").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.IsAlertErrorPresent().Should().BeTrue();
            Driver.CloseInstance();
        }
    }
}

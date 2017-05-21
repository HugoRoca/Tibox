using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Tibox.AutoMation
{
    public class SimpleTest
    {
        public void Navigate()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Close();
            driver.Quit();
            driver = null;
        }
    }
}

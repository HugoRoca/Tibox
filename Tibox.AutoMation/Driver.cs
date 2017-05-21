using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Tibox.AutoMation
{
    public enum DriverOptions
    {
        Chrome,
        InternetExplorer,
        Firefox
    }

    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void GetInstance(DriverOptions options)
        {
            switch (options)
            {
                case DriverOptions.Chrome:
                    Instance = ChromeInstance();
                    break;
                case DriverOptions.InternetExplorer:
                    Instance = InternetExplorerInstance();
                    break;
                case DriverOptions.Firefox:
                    Instance = FirefoxInstance();
                    break;
                default:
                    Instance = null;
                    break;
            }
        }

        private static IWebDriver FirefoxInstance()
        {
            return new FirefoxDriver();
        }

        private static IWebDriver InternetExplorerInstance()
        {
            return new InternetExplorerDriver();
        }

        private static IWebDriver ChromeInstance()
        {
            var options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            return new ChromeDriver(options);
        }

        public static void CloseInstance()
        {
            Instance.Close();
            Instance.Quit();
            Instance = null;
        }
    }
}

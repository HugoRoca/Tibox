using System;
using OpenQA.Selenium;

namespace Tibox.AutoMation
{
    public class SupplierPage
    {
        public static void Login()
        {
            LoginPage.Go();
            LoginPage.LoginAs("chino@gmail.com").WithPassWord("123456").Login();
            Driver.Instance.Navigate().GoToUrl("http://localhost:81/Tibox.Web/#!/home");
            Driver.Instance.FindElement(By.CssSelector("a[href='#!/supplier']")).Click();
        }
        public static void SupplierAddError()
        {
            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-success")).Click();
            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-primary.ng-binding.ng-scope")).Click();
        }

        public static SupplierCommand SupplierCreate(string companyName)
        {
            return new SupplierCommand(companyName);
        }

        public static void SupplierDelete()
        {
            Driver.Instance.FindElement(By.Id("del1")).Click();

        }
    }

    public class SupplierCommand
    {
        private string companyName;
        private string contactName;
        private string contactTitle;
        private string city;
        private string country;
        private string phone;
        private string fax;

        public SupplierCommand(string companyName)
        {
            this.companyName = companyName;
        }

        public SupplierCommand withContactName(string contactName)
        {
            this.contactName = contactName;
            return this;
        }

        public SupplierCommand withContactTitle(string contactTitle)
        {
            this.contactTitle = contactTitle;
            return this;
        }

        public SupplierCommand withCity(string city)
        {
            this.city = city;
            return this;
        }

        public SupplierCommand withCountry(string country)
        {
            this.country = country;
            return this;
        }

        public SupplierCommand withPhone(string phone)
        {
            this.phone = phone;
            return this;
        }

        public SupplierCommand withFax(string fax)
        {
            this.fax = fax;
            return this;
        }

        public void Register()
        {
            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-success")).Click();

            Driver.Instance.FindElement(By.Id("companyName")).Clear();
            Driver.Instance.FindElement(By.Id("companyName")).SendKeys(companyName);

            Driver.Instance.FindElement(By.Id("contactName")).Clear();
            Driver.Instance.FindElement(By.Id("contactName")).SendKeys(contactName);

            Driver.Instance.FindElement(By.Id("contactTitle")).Clear();
            Driver.Instance.FindElement(By.Id("contactTitle")).SendKeys(contactTitle);

            Driver.Instance.FindElement(By.Id("city")).Clear();
            Driver.Instance.FindElement(By.Id("city")).SendKeys(city);

            Driver.Instance.FindElement(By.Id("country")).Clear();
            Driver.Instance.FindElement(By.Id("country")).SendKeys(country);

            Driver.Instance.FindElement(By.Id("phone")).Clear();
            Driver.Instance.FindElement(By.Id("phone")).SendKeys(phone);

            Driver.Instance.FindElement(By.Id("fax")).Clear();
            Driver.Instance.FindElement(By.Id("fax")).SendKeys(fax);

            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-primary.ng-binding.ng-scope")).Click();
        }

        public void Edit()
        {
            Driver.Instance.FindElement(By.Id("edt1")).Click();

            Driver.Instance.FindElement(By.Id("contactTitle")).Clear();
            Driver.Instance.FindElement(By.Id("contactTitle")).SendKeys(contactTitle);

            Driver.Instance.FindElement(By.Id("city")).Clear();
            Driver.Instance.FindElement(By.Id("city")).SendKeys(city);

            Driver.Instance.FindElement(By.Id("country")).Clear();
            Driver.Instance.FindElement(By.Id("country")).SendKeys(country);

            Driver.Instance.FindElement(By.Id("phone")).Clear();
            Driver.Instance.FindElement(By.Id("phone")).SendKeys(phone);

            Driver.Instance.FindElement(By.Id("fax")).Clear();
            Driver.Instance.FindElement(By.Id("fax")).SendKeys(fax);

            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-primary.ng-binding.ng-scope")).Click();
        }

    }
}

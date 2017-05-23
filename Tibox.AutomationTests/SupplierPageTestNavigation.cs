using System;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.AutoMation;
using Xunit;

namespace Tibox.AutomationTests
{
    public class SupplierPageTestNavigation
    {
        public SupplierPageTestNavigation()
        {
            Driver.GetInstance(DriverOptions.Chrome);
        }

        [Fact]
        public void SupplierLoginPage()
        {
            SupplierPage.Login();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Driver.CloseInstance();
        }

        [Fact]
        public void SupplierAddError()
        {
            SupplierPage.Login();

            SupplierPage.SupplierAddError();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            Driver.CloseInstance();
        }

        [Fact]
        public void SupplierAdd()
        {
            SupplierPage.Login();

            SupplierPage.SupplierCreate("Mario")
                .withContactName("Acosta")
                .withContactTitle("Hugo Roca")
                .withCity("Lima")
                .withCountry("Perú")
                .withPhone("945943857")
                .withFax("(09)121212 12").Register();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Driver.CloseInstance();
        }

        [Fact]
        public void SupplierEdit()
        {
            SupplierPage.Login();

            SupplierPage.SupplierCreate("Mario")
                .withContactName("Acosta")
                .withContactTitle("Hugo Roca")
                .withCity("Lima")
                .withCountry("Perú")
                .withPhone("945943857")
                .withFax("(09)121212 12").Edit();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Driver.CloseInstance();
        }

        [Fact]
        public void SupplierDel() {
            SupplierPage.Login();

            SupplierPage.SupplierDelete();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Driver.CloseInstance();
        }
    }
}

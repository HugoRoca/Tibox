using System;
using System.Linq;
using Tibox.AutoMation;
using Xunit;

namespace Tibox.AutomationTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var test = new SimpleTest();
            test.Navigate();
        }

    }
}

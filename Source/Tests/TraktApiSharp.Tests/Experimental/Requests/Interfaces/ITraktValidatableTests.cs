namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktValidatableTests
    {
        [TestMethod]
        public void TestITraktValidatableIsInterface()
        {
            typeof(ITraktValidatable).IsInterface.Should().BeTrue();
        }

        [TestMethod]
        public void TestITraktValidatableHasValidateMethod()
        {
            var methodInfo = typeof(ITraktValidatable).GetMethods()
                                                      .Where(m => m.Name == "Validate")
                                                      .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}

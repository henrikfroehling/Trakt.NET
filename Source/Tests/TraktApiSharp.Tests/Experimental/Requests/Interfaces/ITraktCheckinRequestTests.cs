namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktCheckinRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktCheckinRequestIsInterface()
        {
            typeof(ITraktCheckinRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktCheckinRequestHasIsCheckinRequestProperty()
        {
            var isCheckinRequestPropertyInfo = typeof(ITraktCheckinRequest).GetProperties()
                                                                           .Where(p => p.Name == "IsCheckinRequest")
                                                                           .FirstOrDefault();

            isCheckinRequestPropertyInfo.CanRead.Should().BeTrue();
            isCheckinRequestPropertyInfo.CanWrite.Should().BeFalse();
            isCheckinRequestPropertyInfo.PropertyType.Should().Be(typeof(bool));
        }
    }
}

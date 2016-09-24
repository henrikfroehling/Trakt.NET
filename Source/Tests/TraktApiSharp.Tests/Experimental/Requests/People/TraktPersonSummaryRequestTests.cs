namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.People;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktPersonSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestIsNotAbstract()
        {
            typeof(TraktPersonSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestIsSealed()
        {
            typeof(TraktPersonSummaryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktPersonSummaryRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktPerson>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktPersonSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktPersonSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestHasAuthorizationNotRequired()
        {
            var request = new TraktPersonSummaryRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestHasValidUriTemplate()
        {
            var request = new TraktPersonSummaryRequest(null);
            request.UriTemplate.Should().Be("people/{id}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestHasValidRequestObjectType()
        {
            var request = new TraktPersonSummaryRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.People);
        }
    }
}

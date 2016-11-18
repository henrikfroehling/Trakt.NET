namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestIsNotAbstract()
        {
            typeof(TraktShowCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestIsSealed()
        {
            typeof(TraktShowCommentsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestIsSubclassOfATraktPaginationGetByIdRequest()
        {
            typeof(TraktShowCommentsRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktComment>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowCommentsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestHasValidUriTemplate()
        {
            var request = new TraktShowCommentsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/comments{/sorting}{?page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktShowCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestHasSortingProperty()
        {
            var sortingPropertyInfo = typeof(TraktShowCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Sorting")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }
    }
}

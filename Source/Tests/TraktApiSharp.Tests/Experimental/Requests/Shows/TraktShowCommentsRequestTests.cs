namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
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

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktShowCommentsRequest).GetMethods()
                                                             .Where(m => m.Name == "GetUriPathParameters")
                                                             .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestUriParamsWithoutSorting()
        {
            var request = new TraktShowCommentsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestUriParamsWithUnspecifiedSorting()
        {
            var sorting = TraktCommentSortOrder.Unspecified;

            var request = new TraktShowCommentsRequest(null)
            {
                Sorting = sorting
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowCommentsRequestUriParamsWithSorting()
        {
            var sorting = TraktCommentSortOrder.Newest;

            var request = new TraktShowCommentsRequest(null)
            {
                Sorting = sorting
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("sorting", sorting.UriName);
        }
    }
}

namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestIsNotAbstract()
        {
            typeof(TraktMovieCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestIsSealed()
        {
            typeof(TraktMovieCommentsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestIsSubclassOfATraktPaginationGetByIdRequest()
        {
            typeof(TraktMovieCommentsRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktComment>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieCommentsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestHasValidUriTemplate()
        {
            var request = new TraktMovieCommentsRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/comments{/sorting}{?page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestHasSortingProperty()
        {
            var sortingPropertyInfo = typeof(TraktMovieCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Sorting")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktMovieCommentsRequest).GetMethods()
                                                              .Where(m => m.Name == "GetUriPathParameters")
                                                              .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestUriParamsWithoutSorting()
        {
            var request = new TraktMovieCommentsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestUriParamsWithUnspecifiedSorting()
        {
            var sorting = TraktCommentSortOrder.Unspecified;

            var request = new TraktMovieCommentsRequest(null)
            {
                Sorting = sorting
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieCommentsRequestUriParamsWithSorting()
        {
            var sorting = TraktCommentSortOrder.Newest;

            var request = new TraktMovieCommentsRequest(null)
            {
                Sorting = sorting
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("sorting", sorting.UriName);
        }
    }
}

namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesBoxOfficeRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_IsNotAbstract()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_IsSealed()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktBoxOfficeMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktMoviesBoxOfficeRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktMoviesBoxOfficeRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesBoxOfficeRequest();
            request.UriTemplate.Should().Be("movies/boxoffice{?extended}");
        }

        [Fact]
        public void Test_TraktMoviesBoxOfficeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktMoviesBoxOfficeRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktMoviesBoxOfficeRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}

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
    public class MoviesBoxOfficeRequest_Tests
    {
        [Fact]
        public void Test_MoviesBoxOfficeRequest_IsNotAbstract()
        {
            typeof(MoviesBoxOfficeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_IsSealed()
        {
            typeof(MoviesBoxOfficeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(MoviesBoxOfficeRequest).IsSubclassOf(typeof(AGetRequest<ITraktBoxOfficeMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(MoviesBoxOfficeRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new MoviesBoxOfficeRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviesBoxOfficeRequest();
            request.UriTemplate.Should().Be("movies/boxoffice{?extended}");
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MoviesBoxOfficeRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MoviesBoxOfficeRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}

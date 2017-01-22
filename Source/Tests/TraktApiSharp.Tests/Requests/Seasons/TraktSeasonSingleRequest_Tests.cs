namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonSingleRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonSingleRequest_IsNotAbstract()
        {
            typeof(TraktSeasonSingleRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonSingleRequest_IsSealed()
        {
            typeof(TraktSeasonSingleRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonSingleRequest_Inherits_ATraktSeasonRequest_1()
        {
            typeof(TraktSeasonSingleRequest).IsSubclassOf(typeof(ATraktSeasonRequest<TraktEpisode>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonSingleRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSeasonSingleRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSeasonSingleRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonSingleRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}{?extended}");
        }

        [Fact]
        public void Test_TraktSeasonSingleRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new TraktSeasonSingleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number / without extended info
            request = new TraktSeasonSingleRequest { Id = "123", SeasonNumber = 2 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2"
                                                   });

            // -------------------------------------------
            var extendedInfo = new TraktExtendedInfo { Full = true };

            // with implicit season number / with extended info
            request = new TraktSeasonSingleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });

            // with explicit season number / with extended info
            request = new TraktSeasonSingleRequest { Id = "123", SeasonNumber = 2, ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktSeasonSingleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonSingleRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonSingleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonSingleRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

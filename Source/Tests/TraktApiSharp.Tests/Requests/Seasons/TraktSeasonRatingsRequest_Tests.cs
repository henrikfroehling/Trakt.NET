namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonRatingsRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonRatingsRequest_IsNotAbstract()
        {
            typeof(TraktSeasonRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonRatingsRequest_IsSealed()
        {
            typeof(TraktSeasonRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonRatingsRequest_Inherits_ATraktSeasonRequest_1()
        {
            typeof(TraktSeasonRatingsRequest).IsSubclassOf(typeof(ATraktSeasonRequest<TraktRating>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonRatingsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/ratings");
        }

        [Fact]
        public void Test_TraktSeasonRatingsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new TraktSeasonRatingsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number
            request = new TraktSeasonRatingsRequest { Id = "123", SeasonNumber = 2 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2"
                                                   });
        }

        [Fact]
        public void Test_TraktSeasonRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonRatingsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

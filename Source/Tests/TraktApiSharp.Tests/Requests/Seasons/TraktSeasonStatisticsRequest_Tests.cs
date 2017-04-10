namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonStatisticsRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonStatisticsRequest_IsNotAbstract()
        {
            typeof(TraktSeasonStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonStatisticsRequest_IsSealed()
        {
            typeof(TraktSeasonStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonStatisticsRequest_Inherits_ATraktSeasonRequest_1()
        {
            typeof(TraktSeasonStatisticsRequest).IsSubclassOf(typeof(ATraktSeasonRequest<TraktStatistics>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonStatisticsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/stats");
        }

        [Fact]
        public void Test_TraktSeasonStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new TraktSeasonStatisticsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number
            request = new TraktSeasonStatisticsRequest { Id = "123", SeasonNumber = 2 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2"
                                                   });
        }

        [Fact]
        public void Test_TraktSeasonStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonStatisticsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonStatisticsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonStatisticsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

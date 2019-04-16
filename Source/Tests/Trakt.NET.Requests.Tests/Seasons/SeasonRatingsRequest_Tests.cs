﻿namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class SeasonRatingsRequest_Tests
    {
        [Fact]
        public void Test_SeasonRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonRatingsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/ratings");
        }

        [Fact]
        public void Test_SeasonRatingsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new SeasonRatingsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number
            request = new SeasonRatingsRequest { Id = "123", SeasonNumber = 2 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2"
                                                   });
        }

        [Fact]
        public void Test_SeasonRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonRatingsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new SeasonRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new SeasonRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

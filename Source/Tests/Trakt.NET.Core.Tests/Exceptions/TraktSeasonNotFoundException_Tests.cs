﻿namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktSeasonNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktSeasonNotFoundException_DefaultConstructor()
        {
            const string showId = "show id";
            const uint seasonNr = 1U;

            var exception = new TraktSeasonNotFoundException(showId, seasonNr);

            exception.Message.Should().Be("Season Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktSeasonNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string showId = "show id";
            const uint seasonNr = 1U;

            var exception = new TraktSeasonNotFoundException(message, showId, seasonNr);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}

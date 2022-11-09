﻿namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieSummaryRequest_Tests
    {
        [Fact]
        public void Test_MovieSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieSummaryRequest();
            request.UriTemplate.Should().Be("movies/{id}{?extended}");
        }

        [Fact]
        public void Test_MovieSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MovieSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MovieSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_MovieSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieSummaryRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new MovieSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new MovieSummaryRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

﻿namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowRatingsRequest_Tests
    {
        [Fact]
        public void Test_ShowRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowRatingsRequest();
            request.UriTemplate.Should().Be("shows/{id}/ratings");
        }

        [Fact]
        public void Test_ShowRatingsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowRatingsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowRatingsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new ShowRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new ShowRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

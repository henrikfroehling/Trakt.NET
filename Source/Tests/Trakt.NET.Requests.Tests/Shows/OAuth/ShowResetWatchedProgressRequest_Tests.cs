namespace TraktNet.Requests.Tests.Shows.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Shows.OAuth;
    using Xunit;

    [Category("Requests.Shows.OAuth")]
    public class ShowResetWatchedProgressRequest_Tests
    {
        [Fact]
        public void Test_ShowResetWatchedProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowResetWatchedProgressRequest();
            request.UriTemplate.Should().Be("shows/{id}/progress/watched/reset");
        }

        [Fact]
        public void Test_ShowResetWatchedProgressRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new ShowResetWatchedProgressRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowResetWatchedProgressRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowResetWatchedProgressRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowResetWatchedProgressRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowResetWatchedProgressRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // request body is null
            request = new ShowResetWatchedProgressRequest { Id = "id" };
            
            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

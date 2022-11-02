namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Shows.OAuth;
    using Xunit;

    [TestCategory("Requests.Shows")]
    public class ShowUndoResetWatchedProgressRequest_Tests
    {
        [Fact]
        public void Test_ShowUndoResetWatchedProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowUndoResetWatchedProgressRequest();
            request.UriTemplate.Should().Be("shows/{id}/progress/watched/reset");
        }

        [Fact]
        public void Test_ShowUndoResetWatchedProgressRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new ShowUndoResetWatchedProgressRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ShowUndoResetWatchedProgressRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowUndoResetWatchedProgressRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowUndoResetWatchedProgressRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowUndoResetWatchedProgressRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowUndoResetWatchedProgressRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowUndoResetWatchedProgressRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

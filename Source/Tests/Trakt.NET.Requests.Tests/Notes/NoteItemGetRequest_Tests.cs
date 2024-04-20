namespace TraktNet.Requests.Tests.Notes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Notes.OAuth;
    using Xunit;

    [TestCategory("Requests.Notes.OAuth")]
    public class NoteItemGetRequest_Tests
    {
        [Fact]
        public void Test_NoteItemGetRequest_Has_AuthorizationRequirement_Not_Required()
        {
            var request = new NoteItemGetRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_NoteItemGetRequest_Has_Valid_UriTemplate()
        {
            var request = new NoteItemGetRequest();
            request.UriTemplate.Should().Be("notes/{id}/item{?extended}");
        }

        [Fact]
        public void Test_NoteItemGetRequest_Returns_Valid_UriPathParameters()
        {
            var request = new NoteItemGetRequest { Id = 123 };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" } });

            request = new NoteItemGetRequest { Id = 123, ExtendedInfo = new TraktExtendedInfo { Full = true } };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" }, { "extended", "full" } });
        }

        [Fact]
        public void Test_NoteItemGetRequest_Validate_Throws_Exceptions()
        {
            // id is 0
            var request = new NoteItemGetRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

namespace TraktNet.Requests.Tests.Notes.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Notes.OAuth;
    using Xunit;

    [TestCategory("Requests.Notes.OAuth")]
    public class NoteGetRequest_Tests
    {
        [Fact]
        public void Test_NoteGetRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new NoteGetRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_NoteGetRequest_Has_Valid_UriTemplate()
        {
            var request = new NoteGetRequest();
            request.UriTemplate.Should().Be("notes/{id}");
        }

        [Fact]
        public void Test_NoteGetRequest_Returns_Valid_UriPathParameters()
        {
            var request = new NoteGetRequest { Id = 123 };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" } });
        }

        [Fact]
        public void Test_NoteGetRequest_Validate_Throws_Exceptions()
        {
            // id is 0
            var request = new NoteGetRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

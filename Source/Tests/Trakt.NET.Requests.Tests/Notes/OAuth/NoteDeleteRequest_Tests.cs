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
    public class NoteDeleteRequest_Tests
    {
        [Fact]
        public void Test_NoteDeleteRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new NoteDeleteRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_NoteDeleteRequest_Has_Valid_UriTemplate()
        {
            var request = new NoteDeleteRequest();
            request.UriTemplate.Should().Be("notes/{id}");
        }

        [Fact]
        public void Test_NoteDeleteRequest_Returns_Valid_UriPathParameters()
        {
            var request = new NoteDeleteRequest { Id = 123 };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" } });
        }

        [Fact]
        public void Test_NoteDeleteRequest_Validate_Throws_Exceptions()
        {
            // id is 0
            var request = new NoteDeleteRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

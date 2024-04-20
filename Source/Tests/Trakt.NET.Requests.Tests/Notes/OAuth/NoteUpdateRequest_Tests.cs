namespace TraktNet.Requests.Tests.Notes.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Notes;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Notes.OAuth;
    using Xunit;

    [TestCategory("Requests.Notes.OAuth")]
    public class NoteUpdateRequest_Tests
    {
        [Fact]
        public void Test_NoteUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new NoteUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_NoteUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new NoteUpdateRequest();
            request.UriTemplate.Should().Be("notes/{id}");
        }

        [Fact]
        public void Test_NoteUpdateRequest_Returns_Valid_UriPathParameters()
        {
            var request = new NoteUpdateRequest { Id = 123 };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" } });
        }

        [Fact]
        public void Test_NoteUpdateRequest_Validate_Throws_Exceptions()
        {
            // id is 0
            var request = new NoteUpdateRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // request body is null
            request = new NoteUpdateRequest { Id = 123 };
            act.Should().Throw<TraktRequestValidationException>();

            request = new NoteUpdateRequest
            {
                Id = 123,
                RequestBody = new TraktNotePost
                {
                    Notes = "new content",
                    IgnoreCompleteValidation = true
                }
            };
            
            act.Should().NotThrow();
        }
    }
}

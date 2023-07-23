namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class ListUnlikeRequest_Tests
    {
        [Fact]
        public void Test_ListUnlikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new ListUnlikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ListUnlikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ListUnlikeRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_ListUnlikeRequest_Has_Valid_UriTemplate()
        {
            var request = new ListUnlikeRequest();
            request.UriTemplate.Should().Be("lists/{id}/like");
        }

        [Fact]
        public void Test_ListUnlikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ListUnlikeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                    .And.HaveCount(1)
                                                    .And.Contain(new Dictionary<string, object>
                                                    {
                                                        ["id"] = "123"
                                                    });
        }

        [Fact]
        public void Test_ListUnlikeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ListUnlikeRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ListUnlikeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ListUnlikeRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

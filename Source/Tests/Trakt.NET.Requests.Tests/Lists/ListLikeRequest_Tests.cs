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
    public class ListLikeRequest_Tests
    {
        [Fact]
        public void Test_ListLikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new ListLikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ListLikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ListLikeRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_ListLikeRequest_Has_Valid_UriTemplate()
        {
            var request = new ListLikeRequest();
            request.UriTemplate.Should().Be("lists/{id}/like");
        }

        [Fact]
        public void Test_ListLikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ListLikeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                    .And.HaveCount(1)
                                                    .And.Contain(new Dictionary<string, object>
                                                    {
                                                        ["id"] = "123"
                                                    });
        }

        [Fact]
        public void Test_ListLikeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ListLikeRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ListLikeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ListLikeRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

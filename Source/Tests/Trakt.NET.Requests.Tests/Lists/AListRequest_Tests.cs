﻿namespace TraktNet.Requests.Tests.Lists
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
    public class AListRequest_Tests
    {
        internal class ListRequestMock : AListRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AListRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ListRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AListRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ListRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_AistRequest_Returns_Valid_UriPathParameters()
        {
            var requestMock = new ListRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_AListRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new ListRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            requestMock = new ListRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            requestMock = new ListRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

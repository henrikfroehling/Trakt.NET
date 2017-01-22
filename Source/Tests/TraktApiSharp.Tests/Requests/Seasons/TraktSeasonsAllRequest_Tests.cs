namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonsAllRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonsAllRequest_IsNotAbstract()
        {
            typeof(TraktSeasonsAllRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_IsSealed()
        {
            typeof(TraktSeasonsAllRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktSeasonsAllRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktSeason>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktSeasonsAllRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSeasonsAllRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonsAllRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons{?extended}");
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktSeasonsAllRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktSeasonsAllRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Shows);
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktSeasonsAllRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonsAllRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonsAllRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonsAllRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Is_Not_Abstract()
        {
            typeof(TraktShowWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Is_Sealed()
        {
            typeof(TraktShowWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowWatchingUsersRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktUser>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktShowWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowWatchingUsersRequest();
            request.UriTemplate.Should().Be("shows/{id}/watching{?extended}");
        }

        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktShowWatchingUsersRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktShowWatchingUsersRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktShowWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowWatchingUsersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowWatchingUsersRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

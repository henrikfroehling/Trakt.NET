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
    public class ShowWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_ShowWatchingUsersRequest_Is_Not_Abstract()
        {
            typeof(ShowWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ShowWatchingUsersRequest_Is_Sealed()
        {
            typeof(ShowWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ShowWatchingUsersRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(ShowWatchingUsersRequest).IsSubclassOf(typeof(AShowRequest<ITraktUser>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ShowWatchingUsersRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ShowWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ShowWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowWatchingUsersRequest();
            request.UriTemplate.Should().Be("shows/{id}/watching{?extended}");
        }

        [Fact]
        public void Test_ShowWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new ShowWatchingUsersRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new ShowWatchingUsersRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_ShowWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowWatchingUsersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new ShowWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new ShowWatchingUsersRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

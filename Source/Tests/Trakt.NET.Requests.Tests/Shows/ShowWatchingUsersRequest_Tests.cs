namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows")]
    public class ShowWatchingUsersRequest_Tests
    {
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
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new ShowWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new ShowWatchingUsersRequest { Id = "invalid id" };
            act.Should().Throw<ArgumentException>();
        }
    }
}

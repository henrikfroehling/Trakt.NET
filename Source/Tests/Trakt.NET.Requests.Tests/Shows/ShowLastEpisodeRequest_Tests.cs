namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows")]
    public class ShowLastEpisodeRequest_Tests
    {
        [Fact]
        public void Test_ShowLastEpisodeRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowLastEpisodeRequest();
            request.UriTemplate.Should().Be("shows/{id}/last_episode{?extended}");
        }

        [Fact]
        public void Test_ShowLastEpisodeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new ShowLastEpisodeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new ShowLastEpisodeRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_ShowLastEpisodeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowLastEpisodeRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowLastEpisodeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowLastEpisodeRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

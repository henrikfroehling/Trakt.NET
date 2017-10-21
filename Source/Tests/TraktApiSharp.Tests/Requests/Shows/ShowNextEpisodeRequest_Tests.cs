namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowNextEpisodeRequest_Tests
    {
        [Fact]
        public void Test_ShowNextEpisodeRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowNextEpisodeRequest();
            request.UriTemplate.Should().Be("shows/{id}/next_episode{?extended}");
        }

        [Fact]
        public void Test_ShowNextEpisodeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new ShowNextEpisodeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new ShowNextEpisodeRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_ShowNextEpisodeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowNextEpisodeRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new ShowNextEpisodeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new ShowNextEpisodeRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
